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
using System.Web;
using FluorineFx;
using FluorineFx.Context;
using FluorineFx.Configuration;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Config;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Endpoints.Filter;
using FluorineFx.Messaging.Services.Remoting;
using FluorineFx.Util;

namespace FluorineFx.Messaging.Endpoints
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMFEndpoint : EndpointBase
	{
		FilterChain _filterChain;
        AtomicInteger _waitingPollRequests;

		public AMFEndpoint(MessageBroker messageBroker, ChannelSettings channelSettings):base(messageBroker, channelSettings)
		{
            _waitingPollRequests = new AtomicInteger();
		}

		public override void Start()
		{
			DeserializationFilter deserializationFilter = new DeserializationFilter();
			deserializationFilter.UseLegacyCollection = this.IsLegacyCollection;
			ServiceMapFilter serviceMapFilter = new ServiceMapFilter(this);
			WsdlFilter wsdlFilter = new WsdlFilter();
            AuthenticationFilter authenticationFilter = new AuthenticationFilter(this);
            DescribeServiceFilter describeServiceFilter = new DescribeServiceFilter();
			//CacheFilter cacheFilter = new CacheFilter();
			ProcessFilter processFilter = new ProcessFilter(this);
			MessageFilter messageFilter = new MessageFilter(this);
			DebugFilter debugFilter = new DebugFilter();
			SerializationFilter serializationFilter = new SerializationFilter();
			serializationFilter.UseLegacyCollection = this.IsLegacyCollection;
            serializationFilter.UseLegacyThrowable = this.IsLegacyThrowable;
			
			deserializationFilter.Next = serviceMapFilter;
			serviceMapFilter.Next = wsdlFilter;
            wsdlFilter.Next = authenticationFilter;
            authenticationFilter.Next = describeServiceFilter;
            describeServiceFilter.Next = processFilter;
            //describeServiceFilter.Next = cacheFilter;
			//cacheFilter.Next = processFilter;
			processFilter.Next = debugFilter;
			debugFilter.Next = messageFilter;
			messageFilter.Next = serializationFilter;

			_filterChain = new FilterChain(deserializationFilter);
		}

		public override void Stop()
		{
			_filterChain = null;
			base.Stop();
		}

		public override void Service()
		{
			AMFContext amfContext = new AMFContext(HttpContext.Current.Request.InputStream, HttpContext.Current.Response.OutputStream );
            AMFContext.Current = amfContext;
			_filterChain.InvokeFilters( amfContext );
		}

        public override IMessage ServiceMessage(IMessage message)
        {
            if (message is CommandMessage)
            {
                CommandMessage commandMessage = message as CommandMessage;
                switch (commandMessage.operation)
                {
                    case CommandMessage.PollOperation:
                        {
                            if (FluorineContext.Current.Client != null)
                                FluorineContext.Current.Client.Renew();

                            IMessage[] messages = null;
                            _waitingPollRequests.Increment();
                            int waitIntervalMillis = _channelSettings.WaitIntervalMillis != -1 ? _channelSettings.WaitIntervalMillis : 60000;// int.MaxValue;

                            if (FluorineContext.Current.Client != null)
                                FluorineContext.Current.Client.Renew();

                            if (commandMessage.HeaderExists(CommandMessage.FluorineSuppressPollWaitHeader))
                                waitIntervalMillis = 0;
                            //If async handling was not set long polling is not supported
                            if (!FluorineConfiguration.Instance.FluorineSettings.Runtime.AsyncHandler)
                                waitIntervalMillis = 0;
                            if (_channelSettings.MaxWaitingPollRequests <= 0 || _waitingPollRequests.Value >= _channelSettings.MaxWaitingPollRequests)
                                waitIntervalMillis = 0;

                            if (message.destination != null && message.destination != string.Empty)
                            {
                                string clientId = commandMessage.clientId as string;
                                MessageDestination messageDestination = this.GetMessageBroker().GetDestination(message.destination) as MessageDestination;
                                MessageClient client = messageDestination.SubscriptionManager.GetSubscriber(clientId);
                                client.Renew();
                                messages = client.GetPendingMessages();
                            }
                            else
                            {
                                if (FluorineContext.Current.Client != null)
                                    messages = FluorineContext.Current.Client.GetPendingMessages(waitIntervalMillis);
                            }
                            _waitingPollRequests.Decrement();

                            if (messages == null || messages.Length == 0)
                                return new AcknowledgeMessage();
                            else
                            {
                                CommandMessage resultMessage = new CommandMessage();
                                resultMessage.operation = CommandMessage.ClientSyncOperation;
                                resultMessage.body = messages;
                                return resultMessage;
                            }
                        }
                    case CommandMessage.SubscribeOperation:
                        {
                            if (FluorineContext.Current.Client == null)
                                FluorineContext.Current.SetCurrentClient(this.GetMessageBroker().ClientRegistry.GetClient(message));
                            RemotingConnection remotingConnection = null;
                            foreach (IConnection connection in FluorineContext.Current.Client.Connections)
                            {
                                if (connection is RemotingConnection)
                                {
                                    remotingConnection = connection as RemotingConnection;
                                    break;
                                }
                            }
                            if (remotingConnection == null)
                            {
                                remotingConnection = new RemotingConnection(this, null, FluorineContext.Current.Client.Id, null);
                                FluorineContext.Current.Client.Renew(remotingConnection.ClientLeaseTime);
                                remotingConnection.Initialize(FluorineContext.Current.Client);
                            }
                        }
                        break;
                }
            }
            return base.ServiceMessage(message);
        }

        public override void Push(IMessage message, MessageClient messageClient)
        {
            if (_channelSettings != null && _channelSettings.IsPollingEnabled)
            {
                IMessage messageClone = message.Clone() as IMessage;
                messageClone.SetHeader(MessageBase.DestinationClientIdHeader, messageClient.ClientId);
                messageClone.clientId = messageClient.ClientId;
                messageClient.AddMessage(messageClone);
            }
        }
	}
}
