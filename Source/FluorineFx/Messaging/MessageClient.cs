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
using System.Text;
using System.Collections;
using System.Diagnostics;
using log4net;
using FluorineFx.Util;
using FluorineFx.Context;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services;
using FluorineFx.Messaging.Services.Messaging;
using FluorineFx.Messaging.Api;

namespace FluorineFx.Messaging
{
    /// <summary>
    /// Represents a client-side MessageAgent instance. 
    /// A server-side MessageClient is only created if its client-side counterpart has subscribed to a destination for pushed data (e.g. Consumer).
    /// </summary>
    /// <remarks>
    /// 	<para>Client-side Producers do not result in the creation of corresponding
    ///     server-side MessageClient instances.</para>
    /// 	<para></para>
    /// 	<para>Each MessageClient instance is bound to a client class (session) and when the
    ///     client is invalidated any associated MessageClient instances are invalidated as
    ///     well.</para>
    /// 	<para>MessageClient instances may also be timed out on a per-destination basis and
    ///     based on subscription inactivity. If no messages are pushed to the MessageClient
    ///     within the destination's subscription timeout period the MessageClient will be
    ///     shutdown.</para>
    /// 	<para>Per-destination subscription timeout should be used when inactive
    ///     subscriptions should be shut down opportunistically to preserve server
    ///     resources.</para>
    /// </remarks>
    public sealed class MessageClient : IMessageClient
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(MessageClient));
        private static object _syncLock = new object();

		string				_messageClientId;
		byte[]				_binaryId;

		MessageDestination	_messageDestination;
		string				_endpoint;
		SubscriptionManager _subscriptionManager;
        IMessageConnection _connection;
        IClient _client;

		Subtopic			_subtopic;
		Selector			_selector;

        static Hashtable    _messageClientCreatedListeners;
        Hashtable           _messageClientDestroyedListeners;
        bool _isDisconnecting;
        ArrayList _messageQueue;

        private MessageClient()
        {
        }

		internal MessageClient(IClient client, SubscriptionManager subscriptionManager, string messageClientId, string endpoint, MessageDestination messageDestination)
		{
            _client = client;
            _subscriptionManager = subscriptionManager;
            _messageClientId = messageClientId;
            Debug.Assert(messageDestination != null);
            _messageDestination = messageDestination;
            _endpoint = endpoint;
            _connection = FluorineContext.Current.Connection as IMessageConnection;
            if (_connection != null)
                _connection.RegisterMessageClient(this);

            if (_messageClientCreatedListeners != null)
            {
                foreach (IMessageClientListener listener in _messageClientCreatedListeners.Keys)
                    listener.MessageClientCreated(this);
            }
		}

        /// <summary>
        /// Gets an object that can be used to synchronize access. 
        /// </summary>
        public object SyncRoot { get { return _syncLock; } }

		internal MessageDestination Destination{ get{ return _messageDestination; } }

        /// <summary>
        /// Gets the destination identity the MessageClient is subscribed to.
        /// </summary>
        public string DestinationId { get { return _messageDestination.Id; } }

        internal IMessageConnection MessageConnection { get { return _connection; } }

        /// <summary>
        /// Gets the endpoint identity the MessageClient is subscribed to.
        /// </summary>
        public string Endpoint { get { return _endpoint; } }
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBinaryId()
		{
			if( _binaryId == null )
			{
				UTF8Encoding utf8Encoding = new UTF8Encoding();
				_binaryId = utf8Encoding.GetBytes(_messageClientId);
			}
			return _binaryId;
		}
        /// <summary>
        /// Gets the client identity.
        /// </summary>
        /// <value>The client identity.</value>
		public string ClientId
		{
			get
			{
				return _messageClientId;
			}
		}
        /// <summary>
        /// Gets whether the connection is being disconnected.
        /// </summary>
        public bool IsDisconnecting
        {
            get{ return _isDisconnecting; }
        }

        internal void SetIsDisconnecting(bool value)
        {
            _isDisconnecting = value;
        }

		internal Selector Selector
		{
			get{ return _selector; }
			set{ _selector = value; }
		}
        /// <summary>
        /// Gets the MessageClient subtopic.
        /// </summary>
        /// <value>The MessageClient subtopic.</value>
		public Subtopic Subtopic
		{
			get{ return _subtopic; }
			set{ _subtopic = value; }
		}

        internal ArrayList MessageQueue
        {
            get
            {
                if (_messageQueue == null)
                {
                    lock (this.SyncRoot)
                    {
                        if (_messageQueue == null)
                            _messageQueue = new ArrayList();
                    }
                }
                return _messageQueue;
            }
        }
        /// <summary>
        /// Adds a MessageClient created listener.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public static void AddMessageClientCreatedListener(IMessageClientListener listener)
        {
            lock(typeof(MessageClient))
            {
                if (_messageClientCreatedListeners == null)
                    _messageClientCreatedListeners = new Hashtable(1);
                _messageClientCreatedListeners[listener] = null;
            }
        }
        /// <summary>
        /// Removes a MessageClient created listener.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public static void RemoveMessageClientCreatedListener(IMessageClientListener listener)
        {
            lock (typeof(MessageClient))
            {
                if (_messageClientCreatedListeners != null)
                {
                    if (_messageClientCreatedListeners.Contains(listener))
                        _messageClientCreatedListeners.Remove(listener);
                }
            }
        }
        /// <summary>
        /// Adds a MessageClient destroy listener.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public void AddMessageClientDestroyedListener(IMessageClientListener listener)
        {
            if (_messageClientDestroyedListeners == null)
                _messageClientDestroyedListeners = new Hashtable(1);
            _messageClientDestroyedListeners[listener] = null;
        }
        /// <summary>
        /// Removes a MessageClient destroyed listener.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveMessageClientDestroyedListener(IMessageClientListener listener)
        {
            if (_messageClientDestroyedListeners != null)
            {
                if (_messageClientDestroyedListeners.Contains(listener))
                    _messageClientDestroyedListeners.Remove(listener);
            }
        }

        //Rtmpconnection.Close -> Disconnect -> Unsubscribe
        internal void Disconnect()
		{
			if( log.IsDebugEnabled )
				log.Debug(__Res.GetString(__Res.MessageClient_Disconnect, this.ClientId));
            this.SetIsDisconnecting(true);
            Unsubscribe(false);
		}

		/// <summary>
        /// Timeout -> Unsubscribe
        /// Client -> Unsubscribe
		/// </summary>
        internal void Unsubscribe()
		{
			if( log.IsDebugEnabled )
                log.Debug(__Res.GetString(__Res.MessageClient_Unsubscribe, this.ClientId));

            if (_messageClientDestroyedListeners != null)
            {
                foreach (IMessageClientListener listener in _messageClientDestroyedListeners.Keys)
                    listener.MessageClientDestroyed(this);
            }

            if (_messageDestination != null)
                _messageDestination.RemoveSubscriber(this.ClientId);
            _client.UnregisterMessageClient(this);
            _messageDestination = null;
        }

		internal void Timeout()
		{
			try
			{
                if (this.IsDisconnecting || _messageDestination == null )
					return;
				if( log.IsDebugEnabled )
                    log.Debug(__Res.GetString(__Res.MessageClient_Timeout, this.ClientId));

				//Timeout
				CommandMessage commandMessage = new CommandMessage();
				commandMessage.destination = this.Destination.Id;
				commandMessage.clientId = this.ClientId;
				//Indicate that the client's session with a remote destination has timed out
				commandMessage.operation = CommandMessage.SessionInvalidateOperation;
                commandMessage.headers[MessageBase.FlexClientIdHeader] = _client.Id;

				MessageService messageService = _messageDestination.Service as MessageService;
				object[] subscribers = new object[]{commandMessage.clientId};
				messageService.PushMessageToClients(subscribers, commandMessage);
                Unsubscribe(true);
			}
			catch(Exception ex)
			{
				if( log.IsErrorEnabled )
					log.Error(__Res.GetString(__Res.MessageClient_Timeout, this.ClientId), ex);                
			}
		}

        private void Unsubscribe(bool timeout)
        {
            MessageService messageService = _messageDestination.Service as MessageService;
            CommandMessage commandMessageUnsubscribe = new CommandMessage();
            commandMessageUnsubscribe.destination = this.Destination.Id;
            commandMessageUnsubscribe.operation = CommandMessage.UnsubscribeOperation;
            commandMessageUnsubscribe.clientId = this.ClientId;
            if (timeout)
            {
                commandMessageUnsubscribe.headers[CommandMessage.SessionInvalidatedHeader] = true;
                commandMessageUnsubscribe.headers[CommandMessage.FluorineMessageClientTimeoutHeader] = true;
                commandMessageUnsubscribe.headers[MessageBase.FlexClientIdHeader] = _client.Id;
            }
            messageService.ServiceMessage(commandMessageUnsubscribe);
        }

        internal void AddMessage(IMessage message)
        {
            lock (this.SyncRoot)
            {
                this.MessageQueue.Add(message);
            }
        }

        internal IMessage[] GetPendingMessages()
        {
            lock (this.SyncRoot)
            {
                IMessage[] messages = this.MessageQueue.ToArray(typeof(IMessage)) as IMessage[];
                this.MessageQueue.Clear();
                return messages;
            }
        }

        /// <summary>
        /// Renews a lease.
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public void Renew()
        {
            _subscriptionManager.GetSubscriber(_messageClientId);
        }
	}
}
