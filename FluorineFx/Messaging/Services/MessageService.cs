/*
	FluorineFx open source library 
	Copyright (C) 2007 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU Lesser General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	Lesser General Public License for more details.
	
	You should have received a copy of the GNU Lesser General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

using System;
using System.Collections;
using System.IO;
using log4net;
using FluorineFx.Context;
using FluorineFx.Messaging.Config;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services.Messaging;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Api;
using FluorineFx.IO;

namespace FluorineFx.Messaging.Services
{
	/// <summary>
	/// The MessageService class is the Service implementation that manages point-to-point and publish-subscribe messaging.
	/// </summary>
    [CLSCompliant(false)]
    public class MessageService : ServiceBase
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(MessageService));

        private MessageService()
        {
        }
		
		public MessageService(MessageBroker messageBroker, ServiceSettings serviceSettings) : base(messageBroker, serviceSettings)
		{
		}

        [CLSCompliant(false)]
        protected override Destination NewDestination(DestinationSettings destinationSettings)
		{
			return new MessageDestination(this, destinationSettings);
		}


		public override object ServiceMessage(IMessage message)
		{
			CommandMessage commandMessage = message as CommandMessage;
			MessageDestination messageDestination = GetDestination(message) as MessageDestination;
			if( commandMessage != null )
			{
				string clientId = commandMessage.clientId as string;
                MessageClient messageClient = messageDestination.SubscriptionManager.GetSubscriber(clientId);

				switch(commandMessage.operation)
				{
					case CommandMessage.SubscribeOperation:
						AcknowledgeMessage acknowledgeMessage = null;
                        if (messageClient == null)
						{
							if( clientId == null )
								clientId = Guid.NewGuid().ToString("D");

							if (log.IsDebugEnabled)
								log.Debug(__Res.GetString(__Res.MessageServiceSubscribe, messageDestination.Id, clientId));

                            string endpointId = commandMessage.GetHeader(MessageBase.EndpointHeader) as string;
							commandMessage.clientId = clientId;

                            if (messageDestination.ServiceAdapter != null && messageDestination.ServiceAdapter.HandlesSubscriptions)
                            {
                                messageDestination.ServiceAdapter.Manage(commandMessage);
                            }

                            Subtopic subtopic = null;
                            Selector selector = null;
                            if (commandMessage.headers != null)
                            {
                                if (commandMessage.headers.Contains(CommandMessage.SelectorHeader))
                                {
                                    selector = Selector.CreateSelector(commandMessage.headers[CommandMessage.SelectorHeader] as string);
                                }
                                if (commandMessage.headers.Contains(AsyncMessage.SubtopicHeader))
                                {
                                    subtopic = new Subtopic(commandMessage.headers[AsyncMessage.SubtopicHeader] as string);
                                }
                            }
                            IClient client = FluorineContext.Current.Client;
                            client.Renew();
                            messageClient = messageDestination.SubscriptionManager.AddSubscriber(client, clientId, endpointId, messageDestination, subtopic, selector);
                            //client.RegisterMessageClient(client);
							acknowledgeMessage = new AcknowledgeMessage();
							acknowledgeMessage.clientId = clientId;
						}
						else
						{
							acknowledgeMessage = new AcknowledgeMessage();
							acknowledgeMessage.clientId = clientId;
						}
						return acknowledgeMessage;
					case CommandMessage.UnsubscribeOperation:
						if (log.IsDebugEnabled)
							log.Debug(__Res.GetString(__Res.MessageServiceUnsubscribe, messageDestination.Id, clientId));

                        if (messageDestination.ServiceAdapter != null && messageDestination.ServiceAdapter.HandlesSubscriptions)
                        {
                            messageDestination.ServiceAdapter.Manage(commandMessage);
                        }
                        if (messageClient != null)
						{
                            //IClient flexClient = this.GetMessageBroker().GetCurrentFlexClient();
                            //if (flexClient != null)
                            //    flexClient.UnregisterMessageClient(client);
                            messageClient.Unsubscribe();
						}
						return new AcknowledgeMessage();
                    case CommandMessage.PollOperation:
                        {
                            IClient client = FluorineContext.Current.Client;
                            client.Renew();
                            messageDestination.ServiceAdapter.Manage(commandMessage);
                            return new AcknowledgeMessage();
                        }
					case CommandMessage.ClientPingOperation:
                        if (messageDestination.ServiceAdapter != null && messageDestination.ServiceAdapter.HandlesSubscriptions)
                        {
                            messageDestination.ServiceAdapter.Manage(commandMessage);
                        }
						return true;
					default:
						//Just acknowledge everything
						if (log.IsDebugEnabled)
							log.Debug(__Res.GetString(__Res.MessageServiceUnknown, commandMessage.operation, messageDestination.Id));
                        messageDestination.ServiceAdapter.Manage(commandMessage);
                        return new AcknowledgeMessage();
				}
			}
			else
			{
				if (log.IsDebugEnabled)
					log.Debug(__Res.GetString(__Res.MessageServiceRoute, messageDestination.Id, message.clientId));

                if (FluorineContext.Current != null && FluorineContext.Current.Client != null)//Not set when user code initiates push
                {
                    IClient client = FluorineContext.Current.Client;
                    client.Renew();
                }
                object result = messageDestination.ServiceAdapter.Invoke(message);
				return result;
			}
		}

		public void PushMessageToClients(IMessage message)
		{
			MessageDestination destination = GetDestination(message) as MessageDestination;
			SubscriptionManager subscriptionManager = destination.SubscriptionManager;
			ICollection subscribers = subscriptionManager.GetSubscribers(message);
			if( subscribers != null && subscribers.Count > 0 )
			{
				PushMessageToClients(subscribers, message);
			}
		}

		internal void PushMessageToClients(ICollection subscribers, IMessage message)
		{
			MessageDestination destination = GetDestination(message) as MessageDestination;
			SubscriptionManager subscriptionManager = destination.SubscriptionManager;
			if( subscribers != null && subscribers.Count > 0 )
			{
				IMessage messageClone = message.Clone() as IMessage;
                /*
				if( subscribers.Count > 1 )
				{
					messageClone.SetHeader(MessageBase.DestinationClientIdHeader, BinaryMessage.DestinationClientGuid);
					messageClone.clientId = BinaryMessage.DestinationClientGuid;
					//Cache the message
					MemoryStream ms = new MemoryStream();
					AMFSerializer amfSerializer = new AMFSerializer(ms);
					//TODO this should depend on endpoint settings 
					amfSerializer.UseLegacyCollection = false;
					amfSerializer.WriteData(ObjectEncoding.AMF3, messageClone);
					amfSerializer.Flush();
					byte[] cachedContent = ms.ToArray();
					ms.Close();
					BinaryMessage binaryMessage = new BinaryMessage();
					binaryMessage.body = cachedContent;
					//binaryMessage.Prepare();
					messageClone = binaryMessage;
				}
                */
				foreach(string clientId in subscribers)
				{
					MessageClient client = subscriptionManager.GetSubscriber(clientId);
					if( client == null )
						continue;
					if (log.IsDebugEnabled)
					{
						if( messageClone is BinaryMessage )
							log.Debug(__Res.GetString(__Res.MessageServicePushBinary, message.GetType().Name, clientId));
						else
                            log.Debug(__Res.GetString(__Res.MessageServicePush, message.GetType().Name, clientId));
					}

					IEndpoint endpoint = _messageBroker.GetEndpoint(client.Endpoint);
					endpoint.Push(messageClone, client);
				}
			}
		}
	}
}
