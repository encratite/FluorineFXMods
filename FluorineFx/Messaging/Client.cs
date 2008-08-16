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
using log4net;
using FluorineFx.Util;
using FluorineFx.Collections;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Api;
using FluorineFx.Context;

namespace FluorineFx.Messaging
{
    //[CLSCompliant(false)]
    class Client : AttributeStore, IClient
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Client));
        private static object _syncLock = new object();

        private string _id;
        private int _clientLeaseTime;
        ClientManager _clientManager;
        private CopyOnWriteArray _messageClients;
        protected CopyOnWriteDictionary _connectionToScope = new CopyOnWriteDictionary();
        private Hashtable _sessionDestroyedListeners;
        private bool _polling;

        internal Client(ClientManager clientManager, string id)
        {
            _clientManager = clientManager;
            _id = id;
            _clientLeaseTime = 1;
            _polling = false;
        }

        internal IList MessageClients
        {
            get
            {
                if (_messageClients == null)
                {
                    lock (this.SyncRoot)
                    {
                        if (_messageClients == null)
                            _messageClients = new CopyOnWriteArray();
                    }
                }
                return _messageClients;
            }
        }

        internal void Register(IConnection connection)
        {
            _connectionToScope.Add(connection, connection.Scope);
        }

        internal void Unregister(IConnection connection)
        {
            _connectionToScope.Remove(connection);
            if (_connectionToScope.Count == 0)
            {
                // This client is not connected to any scopes, remove from registry.
                Disconnect();
            }
        }

        internal void SetClientLeaseTime(int value)
        {
            _clientLeaseTime = value;
        }

        #region IClient Members

        public string Id
        {
            get { return _id; }
        }

        public int ClientLeaseTime 
        {
            get { return _clientLeaseTime; }
        }

        public object SyncRoot { get { return _syncLock; } }

        public ICollection Scopes
        {
            get { return _connectionToScope.Values; }
        }

        public ICollection Connections
        {
            get { return _connectionToScope.Keys; }
        }

        public void RegisterMessageClient(MessageClient messageClient)
        {
            if (!this.MessageClients.Contains(messageClient))
            {
                this.MessageClients.Add(messageClient);
            }
        }

        public void UnregisterMessageClient(MessageClient messageClient)
        {
            //This operation was possibly initiated by this client
            if (messageClient.IsDisconnecting)
                return;
            if (this.MessageClients.Contains(messageClient))
            {
                this.MessageClients.Remove(messageClient);
            }
            if (this.MessageClients.Count == 0)
            {
                Disconnect();
            }
        }

        public void Disconnect(bool timeout)
        {
            lock (this.SyncRoot)
            {
                //restore context
                IConnection currentConnection = null;
                if (this.Connections != null && this.Connections.Count > 0)
                {
                    IEnumerator enumerator = this.Connections.GetEnumerator();
                    enumerator.MoveNext();
                    currentConnection = enumerator.Current as IConnection;
                }
                if (FluorineContext.Current == null)
                {
                    _TimeoutContext context = new _TimeoutContext(currentConnection, this);
                    WebSafeCallContext.SetData(FluorineContext.FluorineContextKey, context);
                }
                _clientManager.RemoveSubscriber(this);
                if (_sessionDestroyedListeners != null)
                {
                    foreach (ISessionListener listener in _sessionDestroyedListeners.Keys)
                    {
                        listener.SessionDestroyed(this);
                    }
                }
                if (_messageClients != null)
                {
                    foreach (MessageClient messageClient in _messageClients)
                    {
                        if (timeout)
                            messageClient.Timeout();
                        else
                            messageClient.Disconnect();
                    }
                    _messageClients.Clear();
                }
                foreach (IConnection connection in this.Connections)
                {
                    if (timeout)
                        connection.Timeout();
                    connection.Close();
                }
            }
        }

        public void Disconnect()
        {
            Disconnect(false);
        }

        public void Timeout()
        {
            if (log.IsDebugEnabled)
                log.Debug(string.Format("Timeout Client {0}", this.Id));
            Disconnect(true);
        }

        public IMessage[] GetPendingMessages(int waitIntervalMillis)
        {
            ArrayList messages = new ArrayList();
            _polling = true;
            do
            {
                _clientManager.LookupClient(this._id);//renew

                foreach (MessageClient messageClient in this.MessageClients)
                {
                    messageClient.Renew();
                    messages.AddRange(messageClient.GetPendingMessages());
                }
                if (waitIntervalMillis == 0)
                {
                    _polling = false;
                    return messages.ToArray(typeof(IMessage)) as IMessage[];
                }
                if (messages.Count > 0)
                {
                    _polling = false;
                    return messages.ToArray(typeof(IMessage)) as IMessage[];
                }
                System.Threading.Thread.Sleep(500);
                waitIntervalMillis -= 500;
                if (waitIntervalMillis <= 0)
                    _polling = false;
            }
            while(_polling);
            return messages.ToArray(typeof(IMessage)) as IMessage[];
        }

        public void AddSessionDestroyedListener(ISessionListener listener)
        {
            if (listener == null)
                return;
            lock (this.SyncRoot)
            {
                if (_sessionDestroyedListeners == null)
                    _sessionDestroyedListeners = new Hashtable(1);
                _sessionDestroyedListeners[listener] = null;
            }
        }

        public void RemoveSessionDestroyedListener(ISessionListener listener)
        {
            if (listener == null)
                return;
            lock (this.SyncRoot)
            {
                if (_sessionDestroyedListeners != null)
                {
                    if (_sessionDestroyedListeners.Contains(listener))
                        _sessionDestroyedListeners.Remove(listener);
                }
            }
        }

        /// <summary>
        /// Renews a lease.
        /// </summary>
        public void Renew()
        {
            _clientManager.LookupClient(_id);
        }
        /// <summary>
        /// Renews a lease.
        /// </summary>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        public void Renew(int clientLeaseTime)
        {
            _clientManager.Renew(this, clientLeaseTime);
        }

        #endregion

        public override string ToString()
        {
            return "Client " + _id.ToString();
        }
    }
}