using System;
using System.Xml;
using System.Collections;
using System.Diagnostics;
using IMessage = Apache.NMS.IMessage;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using FluorineFx.Messaging.Config;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services;
using log4net;
using System.Collections.Generic;
using FluorineFx.Context;

namespace FluorineFx.NMS
{
    /**
     * Implementation of a FluorineFx Service Adapter to handle connections to Apache NMS Framework.
     * 
     * This connections to multiple message providers via a single framework.
     * 
     * Version:  0.1
     * Author: Peter Dolukhanov
     * 
     **/
    public class NMSAdapter : ServiceAdapter
    {
        // The maximum number of message producers used to send messages
        private static int MAX_PRODUCERS = 20;

        private static readonly ILog log = LogManager.GetLogger(typeof(NMSAdapter));

        NMSSettings _nmsSettings;

        IConnection _connection;
        ISession _session;
        ActiveMQDestination _destination;

        LinkedList<IMessageProducer> _producers;
        Hashtable _consumers;

        public override void Init()
        {
            base.Init();
            _producers = new LinkedList<IMessageProducer>();
            _consumers = new Hashtable();

            XmlNode nmsNode = this.DestinationDefinition.PropertiesXml.SelectSingleNode("nms");
            _nmsSettings = new NMSSettings(nmsNode);
            if (_nmsSettings != null)
            {
                ConnectionFactory connectionFactory = new ConnectionFactory(_nmsSettings.URI);

                log.Debug(string.Format("NMSAdapter Connected to URI {0}", _nmsSettings.URI));

                _connection = connectionFactory.CreateConnection();
                _connection.Start();
                _session = _connection.CreateSession(AcknowledgementMode.DupsOkAcknowledge);

                if (_nmsSettings.DESTINATION_TYPE.StartsWith(NMSSettings.QueueDestination))
                {
                    _destination = new ActiveMQQueue(_nmsSettings.Destination);
                    log.Debug(string.Format("NMSAdapter Connected to Queue {0}", _nmsSettings.Destination));
                }
                else if (_nmsSettings.DESTINATION_TYPE.StartsWith(NMSSettings.TopicDestination))
                {
                    _destination = new ActiveMQTopic(_nmsSettings.Destination);
                    log.Debug(string.Format("NMSAdapter Connected to Topic {0}", _nmsSettings.Destination));
                }
                else
                {
                    log.Debug(string.Format("Unknown Destination Type {0}", _nmsSettings.DESTINATION_TYPE));
                }
            }
        }


        public override void Stop()
        {
            if (_connection != null)
            {
                stopConsumers();
                _consumers.Clear();
                _session.Close();
                _connection.Stop();
            }
            base.Stop();
        }

        private void stopConsumers()
        {
            foreach (NMSConsumer con in _consumers.Values)
            {
                con.stop();
                con.MessageHandler -= onMessage;
            }

        }

        public override bool HandlesSubscriptions
        {
            get
            {
                return true;
            }
        }

        public override object Manage(CommandMessage commandMessage)
        {
            NMSConsumer _consumer;
            String subscriptionId = (String)commandMessage.clientId;
            String clientId = FluorineContext.Current.ClientId;

            object result = base.Manage(commandMessage);
            switch (commandMessage.operation)
            {
                case CommandMessage.SubscribeOperation:
                    lock (SyncRoot)
                    {
                        if (_consumers.Contains(clientId))
                        {
                            removeConsumer(clientId);
                        }


                        IMessageConsumer consumer = (commandMessage.HeaderExists(CommandMessage.SelectorHeader)) ?
                            _session.CreateConsumer(_destination, (String)commandMessage.GetHeader(CommandMessage.SelectorHeader)) :
                            _session.CreateConsumer(_destination);

                        _consumer = new NMSConsumer(consumer, clientId, subscriptionId);
                        _consumer.MessageHandler += onMessage;
                        _consumers.Add(clientId, _consumer);

                        log.Debug(string.Format("Created Consumer for Client ID: {0}", clientId));
                    }
                    break;
                case CommandMessage.UnsubscribeOperation:
                    lock (SyncRoot)
                    {
                        if (_consumers.Contains(clientId))
                        {
                            removeConsumer(clientId);
                        }
                    }
                    break;
            }
            return result;
        }

        private void removeConsumer(String clientId)
        {
            NMSConsumer consumer = (NMSConsumer)_consumers[clientId];
            consumer.stop();
            consumer.MessageHandler -= onMessage;
            _consumers.Remove(clientId);
            log.Debug(string.Format("Removed Consumer for Client ID: {0}", clientId));
        }

        public virtual void onMessage(String clientId, String subscriptionId, IMessage message)
        {
            try
            {
                log.Debug(string.Format("Recieved new Message for Client ID: {0}", clientId));

                ArrayList list = new ArrayList();
                list.Add(subscriptionId);

                AsyncMessage asyncMessage = convertToFlexMessage(message, clientId);
                MessageService messageService = this.Destination.Service as MessageService;
                messageService.PushMessageToClients(list, asyncMessage);
            }
            catch (Exception ex)
            {
                log.Error("Error while handling incoming message", ex);
            }
        }

        private AsyncMessage convertToFlexMessage(IMessage message, String clientId)
        {
            AsyncMessage asyncMessage = new AsyncMessage();

            if (message is ActiveMQObjectMessage)
            {
                ActiveMQObjectMessage objectMessage = ((ActiveMQObjectMessage)message);
                asyncMessage.body = objectMessage.Body;
            }
            else if (message is ActiveMQTextMessage)
            {
                asyncMessage.body = ((ActiveMQTextMessage)message).Text;
            }

            try
            {
                asyncMessage.destination = this.DestinationDefinition.Id;
                asyncMessage.clientId = clientId;
                asyncMessage.messageId = message.NMSMessageId;
                asyncMessage.timestamp = message.NMSTimestamp.Ticks;
                asyncMessage.correlationId = message.NMSCorrelationID;

                foreach (String key in message.Properties.Keys)
                {
                    asyncMessage.headers.Add(key, message.Properties[key]);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error while converting to Flex Message", ex);
            }

            return asyncMessage;
        }

        public override object Invoke(FluorineFx.Messaging.Messages.IMessage message)
        {
            IMessageProducer producer;

            lock (_producers)
            {
                if (_producers.Count < MAX_PRODUCERS)
                {
                    producer = _session.CreateProducer(_destination);
                    log.Debug("Creating new Message Producer");
                }
                else
                {
                    producer = _producers.First.Value;
                    _producers.RemoveFirst();
                }

                _producers.AddLast(producer);
            }

            IMessage nmsMessage = _session.CreateObjectMessage(message.body);

            try
            {
                foreach (String key in message.headers.Keys)
                {
                    object value = message.headers[key];

                    if (value is string)
                    {
                        nmsMessage.Properties.SetString(key, (string)value);
                    }
                    else if (value is long)
                    {
                        nmsMessage.Properties.SetLong(key, (long)value);
                    }
                    else if (value is bool)
                    {
                        nmsMessage.Properties.SetBool(key, (bool)value);
                    }
                    else if (value is int)
                    {
                        nmsMessage.Properties.SetInt(key, (int)value);
                    }
                    else if (value is byte)
                    {
                        nmsMessage.Properties.SetByte(key, (byte)value);
                    }
                    else if (value is char)
                    {
                        nmsMessage.Properties.SetChar(key, (char)value);
                    }
                    else if (value is double)
                    {
                        nmsMessage.Properties.SetDouble(key, (double)value);
                    }
                    else if (value is float)
                    {
                        nmsMessage.Properties.SetFloat(key, (float)value);
                    }
                    else if (value is IList)
                    {
                        nmsMessage.Properties.SetList(key, (IList)value);
                    }
                    else if (value is short)
                    {
                        nmsMessage.Properties.SetShort(key, (short)value);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error while converting to NMS Message", ex);
            }

            producer.Send(nmsMessage);

            log.Debug(string.Format("Sent message for Client ID: {0}", message.clientId));

            return null;
        }
    }
}
