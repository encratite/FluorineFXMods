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
#if !(NET_1_1)
using System.Collections.Generic;
using FluorineFx.Collections.Generic;
#endif
#if !SILVERLIGHT
using log4net;
#endif
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
#if !SILVERLIGHT
        private static ILog log = LogManager.GetLogger(typeof(BaseConnection));
#endif

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
        protected IDictionary _parameters;
        /// <summary>
        /// Client bound to connection.
        /// </summary>
        protected IClient _client;
        /// <summary>
        /// Scope that connection belongs to.
        /// </summary>
        private IScope _scope;
#if !(NET_1_1)
        /// <summary>
        /// Set of basic scopes.
        /// </summary>
        protected CopyOnWriteArraySet<IBasicScope> _basicScopes = new CopyOnWriteArraySet<IBasicScope>();
#else
        /// <summary>
        /// Set of basic scopes.
        /// </summary>
        protected CopyOnWriteArraySet _basicScopes = new CopyOnWriteArraySet();
#endif

        //1 IsClosed
        //2 IsClosing
        //4
        //8 IsFlexClient
        //16 IsTunnelingDetected
        //32 IsTunneled
        //64
        protected byte __fields;

        /// <summary>
        /// Initializes a new instance of the BaseConnection class.
        /// </summary>
        /// <param name="path">Scope path on server.</param>
        /// <param name="parameters">Parameters passed from client.</param>
        public BaseConnection(string path, IDictionary parameters)
            :this(path, Guid.NewGuid().ToString("N").Remove(12, 1), parameters)
        {
            //V4 GUID should be safe to remove the 4 so we can use the id for rtmpt
        }

        /// <summary>
        /// Initializes a new instance of the BaseConnection class.
        /// </summary>
        /// <param name="path">Scope path on server.</param>
        /// <param name="connectionId">Connection id.</param>
        /// <param name="parameters">Parameters passed from client.</param>
        internal BaseConnection(string path, string connectionId, IDictionary parameters)
        {
            //V4 GUID should be safe to remove the 4 so we can use the id for rtmpt
            _connectionId = connectionId;
            _objectEncoding = ObjectEncoding.AMF0;
            _path = path;
            _parameters = parameters;
            SetIsClosed(false);
        }
        /// <summary>
        /// Gets the network endpoint.
        /// </summary>
        public abstract IPEndPoint RemoteEndPoint { get; }
        /// <summary>
        /// Gets the path for this connection. This is not updated if you switch scope.
        /// </summary>
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
            if (this.Client != null)
            {
                // Unregister old client
                this.Client.Unregister(this);
            }
            _client = client;
            // Register new client
            _client.Register(this);
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
            IScope oldScope = _scope;
            _scope = scope;
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
#if !SILVERLIGHT
                log.Debug("Close, disconnect from scope, and children");
#endif
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
#if !SILVERLIGHT
                        log.Error(__Res.GetString(__Res.Scope_UnregisterError), ex);
#endif
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
#if !SILVERLIGHT
                        log.Error(__Res.GetString(__Res.Scope_DisconnectError, _scope), ex);
#endif
                    }
                }
                if (_client != null)
                {
                    _client.Unregister(this);
                    _client = null;
                }
                _scope = null;
            }
        }

        public virtual void Timeout()
        {
        }

        public virtual int ClientLeaseTime { get { return 0; } }

        /// <summary>
        /// Gets connection parameters.
        /// </summary>
        public IDictionary Parameters { get { return _parameters; } }

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
