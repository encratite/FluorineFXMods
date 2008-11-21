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
using System.Web.Caching;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using log4net;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Api;
using FluorineFx.Util;
using FluorineFx.Messaging.Messages;
using FluorineFx.Exceptions;
using FluorineFx.Context;
using FluorineFx.Messaging.Endpoints;

namespace FluorineFx.Messaging
{
    /// <summary>
    /// ClientManager manages clients connected to the FluorineFx server.
    /// </summary>
    /// <example>
    /// 	<code lang="CS">
    /// classChatAdapter : MessagingAdapter, ISessionListener
    /// {
    ///     private Hashtable _clients;
    ///  
    ///     public ChatAdapter()
    ///     {
    ///         _clients = new Hashtable();
    ///         ClientManager.AddSessionCreatedListener(this);
    ///     }
    ///  
    ///     public void SessionCreated(IClient client)
    ///     {
    ///         lock (_clients.SyncRoot)
    ///         {
    ///             _clients.Add(client.Id, client);
    ///         }
    ///         client.AddSessionDestroyedListener(this);
    ///     }
    ///  
    ///     public void SessionDestroyed(IClient client)
    ///     {
    ///         lock (_clients.SyncRoot)
    ///         {
    ///             _clients.Remove(client.Id);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    public class ClientManager : IClientRegistry
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ClientManager));
        object _objLock = new object();
        private static Hashtable _sessionCreatedListeners = new Hashtable();

        MessageBroker _messageBroker;
        Hashtable _clients;

        private ClientManager()
        {
        }

        internal ClientManager(MessageBroker messageBroker)
		{
            _messageBroker = messageBroker;
            _clients = new Hashtable();
		}

        internal string GetNextId()
        {
            return Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// Adds a session create listener that will be notified when the session is created.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public static void AddSessionCreatedListener(ISessionListener listener)
        {
            if (listener == null)
                return;
            lock (_sessionCreatedListeners.SyncRoot)
            {
                _sessionCreatedListeners[listener] = null;
            }
        }
        /// <summary>
        /// Removes a session create listener.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public static void RemoveSessionCreatedListener(ISessionListener listener)
        {
            if (listener == null)
                return;
            lock (_sessionCreatedListeners.SyncRoot)
            {
                if (_sessionCreatedListeners.Contains(listener))
                    _sessionCreatedListeners.Remove(listener);
            }
        }
        /// <summary>
        /// Notifies session listeners.
        /// </summary>
        /// <param name="client">The client(sesion) created.</param>
        protected void NotifyCreated(IClient client)
        {
            lock (_sessionCreatedListeners.SyncRoot)
            {
                foreach (ISessionListener listener in _sessionCreatedListeners.Keys)
                    listener.SessionCreated(client);
            }
        }

        #region IClientRegistry Members

        /// <summary>
        /// Returns an existing client from the message header transporting the global FlexClient Id value or creates a new one if not found.
        /// </summary>
        /// <param name="message">Message sent from client.</param>
        /// <returns>The client object.</returns>
        public IClient GetClient(IMessage message)
        {
            if (message.HeaderExists(MessageBase.FlexClientIdHeader))
            {
                string clientId = message.GetHeader(MessageBase.FlexClientIdHeader) as string;
                return GetClient(clientId);
            }
            return null;
        }
        /// <summary>
        /// Returns an existing client from a client id or creates a new one if not found.
        /// </summary>
        /// <param name="id">The identity of the client to return.</param>
        /// <returns>The client object.</returns>
        public IClient GetClient(string id)
        {
            lock (_objLock)
            {
                if (_clients.ContainsKey(id))
                {
                    HttpRuntime.Cache.Get(id);
                    return _clients[id] as Client;
                }
                if (id == null || id == "nil" || id == string.Empty)
                    id = Guid.NewGuid().ToString("N");
                Client client = new Client(this, id);
                int clientLeaseTime = 1;
                log.Debug(string.Format("Creating new Client {0}", id));
                Renew(client, clientLeaseTime);
                NotifyCreated(client);
                return client;
            }
        }
        /// <summary>
        /// Check if a client with a given id exists.
        /// </summary>
        /// <param name="id">The identity of the client to check for.</param>
        /// <returns><c>true</c> if the client exists, <c>false</c> otherwise.</returns>
        public bool HasClient(string id)
        {
            if (id == null)
                return false;
            lock (_objLock)
            {
                return _clients.ContainsKey(id);
            }
        }
        /// <summary>
        /// Returns an existing client from a client id.
        /// </summary>
        /// <param name="clientId">The identity of the client to return.</param>
        /// <returns>The client object if exists, null otherwise.</returns>
        public IClient LookupClient(string clientId)
        {
            if (clientId == null)
                return null;

            lock (_objLock)
            {
                Client client = null;
                if (_clients.Contains(clientId))
                {
                    client = _clients[clientId] as Client;
                    HttpRuntime.Cache.Get(clientId);
                }
                return client;
            }
        }


        #endregion

        internal void Renew(Client client, int clientLeaseTime)
        {
            lock (_objLock)
            {
                _clients[client.Id] = client;
                HttpRuntime.Cache.Remove(client.Id);
                if (client.ClientLeaseTime < clientLeaseTime)
                {
                    client.SetClientLeaseTime(clientLeaseTime);
                    log.Debug(string.Format("Renew Client {0} clientLeaseTime {1}", client.Id, clientLeaseTime));
                }
                if (clientLeaseTime == 0)
                {
                    client.SetClientLeaseTime(0);
                    log.Debug(string.Format("Renew Client {0} clientLeaseTime {1}", client.Id, clientLeaseTime));
                }
                if (client.ClientLeaseTime != 0)
                {
                    // Add the FlexClient to the Cache with the expiration item
                    HttpRuntime.Cache.Insert(client.Id, client, null,
                        Cache.NoAbsoluteExpiration,
                        new TimeSpan(0, client.ClientLeaseTime, 0),
                        CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(this.RemovedCallback));
                }
            }
        }

        internal Client RemoveSubscriber(Client client)
        {
            lock (_objLock)
            {
                RemoveSubscriber(client.Id);
                return client;
            }
        }

        internal Client RemoveSubscriber(string clientId)
        {
            lock (_objLock)
            {
                //if (log.IsDebugEnabled)
                //    log.Debug(string.Format("Removing Flex Client {0}", clientId));
                if (log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.SubscriptionManager_Remove, clientId));

                Client client = _clients[clientId] as Client;
                HttpRuntime.Cache.Remove(clientId);
                _clients.Remove(clientId);
                return client;
            }
        }

        internal void RemovedCallback(string key, object value, CacheItemRemovedReason callbackReason)
        {
            if (callbackReason == CacheItemRemovedReason.Expired)
            {
                lock (_objLock)
                {
                    if (_clients.Contains(key))
                    {
                        try
                        {
                            IClient client = LookupClient(key);
                            if (client != null)
                            {
                                if (log.IsDebugEnabled)
                                    log.Debug(__Res.GetString(__Res.SubscriptionManager_CacheExpired, client.Id));
                                client.Timeout();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (log.IsErrorEnabled)
                                log.Error(__Res.GetString(__Res.SubscriptionManager_CacheExpired, string.Empty), ex);
                        }
                    }
                }
            }
        }
    }
}
