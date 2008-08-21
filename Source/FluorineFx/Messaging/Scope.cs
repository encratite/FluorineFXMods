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
using FluorineFx.Collections;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Persistence;

namespace FluorineFx.Messaging
{
	/// <summary>
    /// The scope object.
    /// 
    /// A statefull object shared between a group of clients connected to the same
    /// context path. Scopes are arranged in a hierarchical way, so its possible for
    /// a scope to have a parent. If a client is connect to a scope then they are
    /// also connected to its parent scope. The scope object is used to access
    /// resources, shared object, streams, etc.
    /// 
    /// The following are all names for scopes: application, room, place, lobby.
	/// </summary>
	class Scope : BasicScope, IScope
	{
        static ILog log = LogManager.GetLogger(typeof(Scope));

		private static string ScopeType = "scope";
		public static string Separator = ":";


		private IScopeContext _context;
		private IScopeHandler _handler;
		private bool _autoStart = true;
		private bool _enabled = true;
		private bool _running = false;
        protected ServiceContainer _serviceContainer;

		/// <summary>
		/// String, IBasicScope
		/// </summary>
        private SynchronizedHashtable _children = new SynchronizedHashtable();
		/// <summary>
		/// IClient, Set(IConnection)
		/// </summary>
        private SynchronizedHashtable _clients = new SynchronizedHashtable();

		protected Scope():this(string.Empty)
		{
		}

        protected Scope(string name)
            : this(name, null)
		{
		}

        protected Scope(string name, FluorineFx.Messaging.Api.IServiceProvider serviceProvider)
            : base(null, ScopeType, name, false)
        {
            _serviceContainer = new ServiceContainer(serviceProvider);
        }

		public bool IsEnabled
		{
			get{ return _enabled; }
			set{ _enabled = value; }
		}

		public bool IsRunning
		{
			get{ return _running; }
		}

		public bool AutoStart
		{
			get{ return _autoStart; }
			set{ _autoStart = value; }
		}

		public bool HasContext
		{
			get{ return _context != null; }
		}

		public void Init()
		{
			if(HasParent) 
			{
				if(!Parent.HasChildScope(this.Name)) 
				{
					if(!Parent.AddChildScope(this)) 
					{
						return;
					}
				}
			}
			if(AutoStart) 
			{
				Start();
			}
		}

        /// <summary>
        /// Uninitialize scope and unregister from parent.
        /// </summary>
        public void Uninit()
        {
            foreach (IBasicScope child in _children.Values)
            {
                if (child is Scope)
                    ((Scope)child).Uninit();
            }
            Stop();
            if (HasParent)
            {
                if (this.Parent.HasChildScope(this.Name))
                {
                    this.Parent.RemoveChildScope(this);
                }
            }
        }

        /// <summary>
        /// Adds the specified service to the scope.
        /// </summary>
        /// <param name="serviceType">The type of service to add.</param>
        /// <param name="service">An instance of the service type to add.</param>
        public void AddService(Type serviceType, object service)
        {
            _serviceContainer.AddService(serviceType, service);
        }
        /// <summary>
        /// Adds the specified service to the scope.
        /// </summary>
        /// <param name="serviceType">The type of service to add.</param>
        /// <param name="service">An instance of the service type to add.</param>
        /// <param name="promote"></param>
        public void AddService(Type serviceType, object service, bool promote)
        {
            _serviceContainer.AddService(serviceType, service, promote);
        }
        /// <summary>
        /// Removes the specified service type from the service container.
        /// </summary>
        /// <param name="serviceType">The type of service to remove.</param>
        public void RemoveService(Type serviceType)
        {
            _serviceContainer.RemoveService(serviceType);
        }
        /// <summary>
        /// Removes the specified service type from the service container.
        /// </summary>
        /// <param name="serviceType">The type of service to remove.</param>
        /// <param name="promote"></param>
        public void RemoveService(Type serviceType, bool promote)
        {
            _serviceContainer.RemoveService(serviceType, promote);
        }
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type serviceType or a null reference (Nothing in Visual Basic) if there is no service object of type serviceType.</returns>
        public virtual object GetService(Type serviceType)
        {
            return _serviceContainer.GetService(serviceType);
        }


        /// <summary>
        /// Starts scope.
        /// </summary>
        /// <returns><code>true</code> if scope has handler and it's start method returned true, <code>false</code> otherwise.</returns>
        public bool Start() 
		{
            lock (this.SyncRoot)
            {
                bool result = false;
                if (IsEnabled && !IsRunning)
                {
                    if (HasHandler)
                    {
                        // Only start if scope handler allows it
                        try
                        {
                            // If we dont have a handler of our own dont try to start it
                            if (_handler != null)
                                result = _handler.Start(this);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Could not start scope " + this, ex);
                        }
                    }
                    else
                    {
                        // Always start scopes without handlers
                        log.Debug(string.Format("Scope {0} has no handler, allowing start.", this));
                        result = true;
                    }
                    _running = result;
                }
                return result;
            }
		}
        /// <summary>
        /// Stops scope.
        /// </summary>
        public void Stop()
        {
            lock (this.SyncRoot)
            {
                if (IsEnabled && IsRunning && HasHandler)
                {
                    try
                    {
                        //If we dont have a handler of our own don't try to stop it
                        if (_handler != null)
                        {
                            _handler.Stop(this);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Could not stop scope " + this, ex);
                    }
                }
                _serviceContainer.Shutdown();
                _running = false;
            }
        }

		protected override void Free()
		{
			if(HasParent) 
			{
				Parent.RemoveChildScope(this);
			}
			if(HasHandler) 
			{
				Handler.Stop(this);
				// TODO:  kill all child scopes
			}
		}

		#region IScope Members

		public bool Connect(IConnection connection)
		{
			return Connect(connection, null);
		}

		public bool Connect(IConnection connection, object[] parameters)
		{
			if(HasParent && !this.Parent.Connect(connection, parameters)) 
				return false;
			if(HasHandler && !this.Handler.Connect(connection, this, parameters))
				return false;
			IClient client = connection.Client;
            if (!connection.IsConnected)
            {
                // Timeout while connecting client
                return false;
            }
            //We would not get this far if there is no handler
            if (HasHandler && !this.Handler.Join(client, this))
            {
                return false;
            }
            if (!connection.IsConnected)
            {
                // Timeout while connecting client
                return false;
            }

            CopyOnWriteArraySet connections = _clients[client] as CopyOnWriteArraySet;
            if (connections == null)
            {
                connections = new CopyOnWriteArraySet();
                _clients[client] = connections;
            }
            connections.Add(connection);
            AddEventListener(connection);
			return true;
		}

		public void Disconnect(IConnection connection)
		{
			// We call the disconnect handlers in reverse order they were called
			// during connection, i.e. roomDisconnect is called before
			// appDisconnect.
			IClient client = connection.Client;
			if(_clients.ContainsKey(client)) 
			{
                CopyOnWriteArraySet connections = _clients[client] as CopyOnWriteArraySet;
				connections.Remove(connection);
				IScopeHandler handler = null;
				if(HasHandler) 
				{
					handler = this.Handler;
					try 
					{
						handler.Disconnect(connection, this);
					} 
					catch(Exception ex)
					{
						if( log != null && log.IsErrorEnabled )
							log.Error("Error while executing \"disconnect\" for connection " + connection + " on handler " + handler, ex);
					}
				}

				if(connections.Count == 0)
				{
					_clients.Remove(client);
					if(handler != null) 
					{
						try 
						{
							// there may be a timeout here ?
							handler.Leave(client, this);
						} 
						catch (Exception ex)
						{
							if( log != null && log.IsErrorEnabled )
								log.Error("Error while executing \"leave\" for client " + client + " on handler " + handler, ex);
						}
					}
				}
				RemoveEventListener(connection);
			}
			if(HasParent)
				this.Parent.Disconnect(connection);
		}

		public IScopeContext Context
		{
			get
			{
				if(!HasContext && HasParent) 
					return Parent.Context;
				else
					return _context;
			}
			set
			{
				_context = value;
			}
		}

		public bool HasChildScope(string name)
		{
			return _children.ContainsKey(ScopeType + Separator + name);
		}

		public bool HasChildScope(string type, string name)
		{
			return _children.ContainsKey(type + Separator + name);
		}

		public bool CreateChildScope(string name)
		{
			Scope scope = new Scope(name, _serviceContainer);
			scope.Parent = this;
			return AddChildScope(scope);
		}

		public bool AddChildScope(IBasicScope scope)
		{
			if(HasHandler && !Handler.AddChildScope(scope)) 
			{
				if( log != null && log.IsDebugEnabled )
					log.Debug("Failed to add child scope: " + scope + " to " + this);
				return false;
			}
			if(scope is IScope) 
			{
				// Start the scope
				if(HasHandler && !Handler.Start((IScope) scope)) 
				{
					if( log != null && log.IsDebugEnabled )
						log.Debug("Failed to start child scope: " + scope + " in " + this);
					return false;
				}
			}
			if( log != null && log.IsDebugEnabled )
				log.Debug("Add child scope: " + scope + " to " + this);
			_children[scope.Type + Separator + scope.Name] = scope;
			return true;
		}

		public void RemoveChildScope(IBasicScope scope)
		{
			if (scope is IScope) 
			{
				if(HasHandler)
					this.Handler.Stop((IScope) scope);				
			}
			_children.Remove(scope.Type + Separator + scope.Name);
			if(HasHandler)
			{
				if( log != null && log.IsDebugEnabled )
					log.Debug("Remove child scope");
				this.Handler.RemoveChildScope(scope);
			}
		}

		public ICollection GetScopeNames()
		{
			return _children.Keys;
		}

        public IEnumerator GetBasicScopeNames(string type)
		{
			if (type == null) 
				return _children.Keys.GetEnumerator();
			else
				return new PrefixFilteringStringEnumerator(_children.Keys, type + Separator);
		}

		public IBasicScope GetBasicScope(string type, string name)
		{
			return _children[type + Separator + name] as IBasicScope;
		}

		public IScope GetScope(string name)
		{
			return _children[ScopeType + Separator + name] as IScope;
		}

		public ICollection GetClients()
		{
			return _clients.Keys;
		}

		public bool HasHandler
		{
			get
			{
				return (_handler != null || (this.HasParent && this.Parent.HasHandler));
			}
		}

		public IScopeHandler Handler
		{
			get
			{ 
				if(_handler != null) 
				{
					return _handler;
				} 
				else if (HasParent) 
				{
					return Parent.Handler;
				} 
				else 
					return null;
			}
			set
			{ 
				_handler = value; 
				if (_handler is IScopeAware)
					(_handler as IScopeAware).SetScope(this);
			}
		}

		public virtual string ContextPath
		{
			get
			{
				if( HasContext )
				{
					return string.Empty;
				} else if (HasParent){
					return Parent.ContextPath + "/" + Name;				
				} else {
					return null;
				}
			}
		}

		public IEnumerator GetConnections()
		{
            return new ConnectionIterator(this);
		}

		/// <summary>
		/// Returns scope context.
		/// </summary>
		/// <returns></returns>
		public IScopeContext GetContext()
		{
			if(!HasContext && HasParent) 
				return _parent.Context;
			else 
				return _context;
		}

		public ICollection LookupConnections(IClient client)
		{
			if( _clients.Contains(client) )
				return _clients[client] as CopyOnWriteArraySet;
			else
				return null;
		}


		#endregion

		#region IBasicScope Members
        #endregion

        #region IEnumerable Members

        public override IEnumerator GetEnumerator()
        {
            return _children.Values.GetEnumerator();
        }

		#endregion


		sealed class PrefixFilteringStringEnumerator : IEnumerator
		{
			private string _prefix;
			private int _index;
			private object[] _enumerable = null;
			private string _currentElement;


			internal PrefixFilteringStringEnumerator(ICollection enumerable, string prefix)
			{
				_prefix = prefix;
				_index = -1;
                _enumerable = new object[enumerable.Count];
				enumerable.CopyTo(_enumerable, 0);
			}

			#region IEnumerator Members

			public void Reset()
			{
				_currentElement = null;
				_index = -1;
			}

			public string Current
			{
				get
				{
					if(_index == -1)
						throw new InvalidOperationException("Enum not started.");
					if(_index >= _enumerable.Length)
						throw new InvalidOperationException("Enumeration ended.");
					return _currentElement;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if(_index == -1)
						throw new InvalidOperationException("Enum not started.");
					if(_index >= _enumerable.Length)
						throw new InvalidOperationException("Enumeration ended.");
					return _currentElement;
				}
			}

			public bool MoveNext()
			{
				while(_index < _enumerable.Length - 1)
				{
					_index++;

					string element = _enumerable[_index] as string;
					if( element.StartsWith(_prefix) )
					{
						_currentElement = element;
						return true;
					}
				}
				_index = _enumerable.Length;
				return false;
			}

			#endregion
		}

        sealed class ConnectionIterator : IEnumerator
        {
            IEnumerator _connectionIterator;
            IDictionaryEnumerator _setIterator;

            public ConnectionIterator(Scope scope)
            {
                _setIterator = scope._clients.GetEnumerator();
            }

            #region IEnumerator Members

            public object Current
            {
                get { return _connectionIterator.Current; }
            }

            public bool MoveNext()
            {
                if (_connectionIterator != null && _connectionIterator.MoveNext())
                {
                    // More connections for this client
                    return true;
                }
                if(!_setIterator.MoveNext())
                {
                    // No more clients
                    return false;
                }

                _connectionIterator = (_setIterator.Value as CopyOnWriteArraySet).GetEnumerator();
                while (_connectionIterator != null)
                {
                    if (_connectionIterator.MoveNext())
                    {
                        // Found client with connections
                        return true;
                    }
                    if (!_setIterator.MoveNext())
                    {
                        // No more clients
                        return false;
                    }
                    // Advance to next client
                    _connectionIterator = (_setIterator.Value as CopyOnWriteArraySet).GetEnumerator();
                }
                return false;
            }

            public void Reset()
            {
                _connectionIterator = null;
                _setIterator.Reset();
            }

            #endregion
        }
	
	}
}
