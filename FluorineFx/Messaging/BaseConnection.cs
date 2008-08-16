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
using System.Net;
using log4net;
using FluorineFx.Collections;
using FluorineFx.Messaging.Api;

namespace FluorineFx.Messaging
{
    /// <summary>
    /// Base abstract class for connections.
    /// </summary>
    [CLSCompliant(false)]
    public abstract class BaseConnection : AttributeStore, IConnection
    {
        private static ILog log = LogManager.GetLogger(typeof(BaseConnection));

        object _syncLock = new object();
        protected string _connectionId;
        protected ObjectEncoding _objectEncoding;

        /// Path of scope client connected to.
        /// </summary>
        protected string _path;
        /// <summary>
        /// Number of read messages.
        /// </summary>
        protected long _readMessages;
        /// <summary>
        /// Number of written messages.
        /// </summary>
        protected long _writtenMessages;
        /// <summary>
        /// Number of dropped messages.
        /// </summary>
        protected long _droppedMessages;
        /// <summary>
        /// Connection params passed from client with NetConnection.connect call.
        /// </summary>
        protected Hashtable _parameters;
        /// <summary>
        /// Client bound to connection.
        /// </summary>
        protected IClient _client;
        /// <summary>
        /// Scope that connection belongs to.
        /// </summary>
        private Scope _scope;
        /// <summary>
        /// Set of basic scopes.
        /// </summary>
        protected CopyOnWriteArraySet _basicScopes;

        //1 IsClosed
        //2 IsClosing
        //4
        //8 IsFlexClient
        //16 IsTunnelingDetected
        //32 IsTunneled
        //64
        protected byte __fields;

        FluorineFx.Messaging.Endpoints.IEndpoint _endpoint;


        /// <summary>
        /// Initializes a new instance of the BaseConnection class.
        /// </summary>
        /// <param name="remoteAddress">Remote address.</param>
        /// <param name="remotePort">Remote port.</param>
        /// <param name="path">Scope path on server.</param>
        /// <param name="parameters">Parameters passed from client.</param>
        public BaseConnection(FluorineFx.Messaging.Endpoints.IEndpoint endpoint, string path, Hashtable parameters)
            :this(endpoint, path, Guid.NewGuid().ToString("N").Remove(12, 1), parameters)
        {
            //V4 GUID should be safe to remove the 4 so we can use the id for rtmpt
        }

        /// <summary>
        /// Initializes a new instance of the BaseConnection class.
        /// </summary>
        /// <param name="remoteAddress">Remote address.</param>
        /// <param name="remotePort">Remote port.</param>
        /// <param name="path">Scope path on server.</param>
        /// <param name="connectionId">Connection id.</param>
        /// <param name="parameters">Parameters passed from client.</param>
        internal BaseConnection(FluorineFx.Messaging.Endpoints.IEndpoint endpoint, string path, string connectionId, Hashtable parameters)
        {
            _endpoint = endpoint;
            //V4 GUID should be safe to remove the 4 so we can use the id for rtmpt
            _connectionId = connectionId;
            _objectEncoding = ObjectEncoding.AMF0;
            _path = path;
            _parameters = parameters;
            _basicScopes = new CopyOnWriteArraySet();
            SetIsClosed(false);
        }

        public abstract IPEndPoint RemoteEndPoint { get; }
        public string Path { get { return _path; } }

        public bool IsClosed
        {
            get { return (__fields & 1) == 1; }
        }

        internal void SetIsClosed(bool value)
        {
            __fields = (value) ? (byte)(__fields | 1) : (byte)(__fields & ~1);
        }

        public bool IsClosing
        {
            get { return (__fields & 2) == 2; }
        }

        internal void SetIsClosing(bool value)
        {
            __fields = (value) ? (byte)(__fields | 2) : (byte)(__fields & ~2);
        }

        public bool IsFlexClient
        {
            get { return (__fields & 8) == 8; }
        }

        internal void SetIsFlexClient(bool value)
        {
            __fields = (value) ? (byte)(__fields | 8) : (byte)(__fields & ~8);
        }


        #region IConnection Members

        /// <summary>
        /// Initializes client.
        /// </summary>
        /// <param name="client">Client bound to connection.</param>
        public void Initialize(IClient client)
        {
            if (this.Client != null && this.Client is Client)
            {
                // Unregister old client
                (this.Client as Client).Unregister(this);
            }
            _client = client;
            if (this.Client is Client)
            {
                // Register new client
                (_client as Client).Register(this);
            }
        }

        /// <summary>
        /// Connect to another scope on server.
        /// </summary>
        /// <param name="scope">New scope.</param>
        /// <returns>true on success, false otherwise.</returns>
        public bool Connect(IScope scope)
        {
            return Connect(scope, null);
        }
        /// <summary>
        /// Connect to another scope on server with given parameters.
        /// </summary>
        /// <param name="scope">New scope.</param>
        /// <param name="parameters">Parameters to connect with.</param>
        /// <returns>true on success, false otherwise.</returns>
        public virtual bool Connect(IScope scope, object[] parameters)
        {
            Scope oldScope = _scope;
            _scope = scope as Scope;
            if (_scope.Connect(this, parameters))
            {
                if (oldScope != null)
                {
                    oldScope.Disconnect(this);
                }
                return true;
            }
            else
            {
                _scope = oldScope;
                return false;
            }
        }
        /// <summary>
        /// Checks whether connection is alive.
        /// </summary>
        public virtual bool IsConnected
        {
            get { return _scope != null; }
        }
        /// <summary>
        /// Closes connection.
        /// </summary>
        public virtual void Close()
        {
            lock (this.SyncRoot)
            {
                if (IsClosed)
                    return;
                SetIsClosed(true);
                log.Debug("Close, disconnect from scope, and children");
                if (_basicScopes != null)
                {
                    try
                    {
                        //Close, disconnect from scope, and children
                        foreach (IBasicScope basicScope in _basicScopes)
                        {
                            UnregisterBasicScope(basicScope);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(__Res.GetString(__Res.Scope_UnregisterError), ex);
                    }
                }
                if (_scope != null)
                {
                    try
                    {
                        _scope.Disconnect(this);
                    }
                    catch (Exception ex)
                    {
                        log.Error(__Res.GetString(__Res.Scope_DisconnectError, _scope), ex);
                    }
                }
                if (_client != null && _client is Client)
                {
                    (_client as Client).Unregister(this);
                    _client = null;
                }
                _scope = null;
            }
        }

        public virtual void Timeout()
        {
        }

        public FluorineFx.Messaging.Endpoints.IEndpoint Endpoint { get { return _endpoint; } }

        public virtual int ClientLeaseTime { get { return 0; } }

        /// <summary>
        /// Gets connection parameters.
        /// </summary>
        public Hashtable Parameters { get { return _parameters; } }

        public IClient Client
        {
            get{ return _client; }
        }

        public IScope Scope
        {
            get{ return _scope; }
        }

        public IEnumerator BasicScopes
        {
            get{ return _basicScopes.GetEnumerator(); }
        }

        public string ConnectionId { get { return _connectionId; } }

        public string SessionId { get { return _connectionId; } }

        public ObjectEncoding ObjectEncoding
        {
            get { return _objectEncoding; }
        }

        public object SyncRoot { get { return _syncLock; } }

        public virtual void Ping()
        {
        }

        #endregion

        #region IEventDispatcher Members

        /// <summary>
        /// Dispatches event.
        /// </summary>
        /// <param name="evt">Event.</param>
        public virtual void DispatchEvent(FluorineFx.Messaging.Api.Event.IEvent evt)
        {
        }

        #endregion

        #region IEventHandler Members

        /// <summary>
        /// Handles event
        /// </summary>
        /// <param name="evt">Event.</param>
        /// <returns>true if associated scope was able to handle event, false otherwise.</returns>
        public virtual bool HandleEvent(FluorineFx.Messaging.Api.Event.IEvent evt)
        {
            return this.Scope.HandleEvent(evt);
        }

        #endregion

        #region IEventListener Members

        /// <summary>
        /// Notified on event.
        /// </summary>
        /// <param name="evt">Event.</param>
        public virtual void NotifyEvent(FluorineFx.Messaging.Api.Event.IEvent evt)
        {
        }

        #endregion

        /// <summary>
        /// Registers basic scope.
        /// </summary>
        /// <param name="basicScope">Basic scope to register.</param>
        public void RegisterBasicScope(IBasicScope basicScope)
        {
            _basicScopes.Add(basicScope);
            basicScope.AddEventListener(this);
        }
        /// <summary>
        /// Unregister basic scope.
        /// </summary>
        /// <param name="basicScope">Unregister basic scope.</param>
        public void UnregisterBasicScope(IBasicScope basicScope)
        {
            _basicScopes.Remove(basicScope);
            basicScope.RemoveEventListener(this);
        }

        public abstract long ReadBytes { get; }
        public abstract long WrittenBytes { get; }

        public long ReadMessages { get { return _readMessages; } }
        public long WrittenMessages { get { return _writtenMessages; } }
        public long DroppedMessages { get { return _droppedMessages; } }
        public long PendingMessages { get { return 0; } }
        public virtual long GetPendingVideoMessages(int streamId)
        {
            return 0;
        }
        public virtual long ClientBytesRead { get { return 0; } }
        public abstract int LastPingTime { get; }
    }
}
