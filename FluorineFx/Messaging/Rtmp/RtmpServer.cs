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
using System.Net.Sockets;
using System.Threading;
using log4net;
using FluorineFx.Context;
using FluorineFx.Configuration;
using FluorineFx.Util;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Api.SO;
using FluorineFx.Exceptions;
using FluorineFx.Messaging.Rtmp.SO;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.IO;
using FluorineFx.Threading;

namespace FluorineFx.Messaging.Rtmp
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class RtmpServer : DisposableBase
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(RtmpServer));

		event ErrorHandler _onErrorEvent;

        Hashtable _connections;
        ArrayList _socketListeners;

        //Timer _idleTimer;
        //int _idleCheckInterval = 1000 * 60;
        //int _idleTimeOutValue = 1000 * 60;

        //ThreadPoolEx _threadPoolEx;
        BufferPool _bufferPool;
        RtmpHandler _rtmpHandler;
        IEndpoint _endpoint;

        public RtmpServer(RtmpEndpoint endpoint)
		{
			_connections = new Hashtable();
			_socketListeners = new ArrayList();
            _endpoint = endpoint;
            _rtmpHandler = new RtmpHandler(endpoint);
		}
        /*
		internal ThreadPoolEx ThreadPoolEx
		{
			get{ return _threadPoolEx; }
		}
        */
        internal BufferPool BufferPool
        {
            get { return _bufferPool; }
        }

        internal IRtmpHandler RtmpHandler
        {
            get { return _rtmpHandler; }
        }

        internal IEndpoint Endpoint
        {
            get { return _endpoint; }
        }

		public event ErrorHandler OnError
		{
			add { _onErrorEvent += value; }
			remove { _onErrorEvent -= value; }
		}

		protected override void Free()
		{
			Stop();
            if (_bufferPool != null)
                _bufferPool.Dispose();
        }

        #region Server Management

        public void Start()
		{
			try
			{
				if( log.IsInfoEnabled )
					log.Info(__Res.GetString(__Res.SocketServer_Start));
				
				//_threadPoolEx = new ThreadPoolEx();
                _bufferPool = new BufferPool(FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.ReceiveBufferSize);

				if(!this.IsDisposed)
				{
                    foreach (RtmpSocketListener socketListener in _socketListeners)
					{
						socketListener.Start();
					}
				}
    			//_idleTimer = new Timer(new TimerCallback(IdleCheck), null, _idleCheckInterval, _idleCheckInterval);

				if( log.IsInfoEnabled )
                    log.Info(__Res.GetString(__Res.SocketServer_Started));
			}
			catch(Exception ex)
			{
				if( log.IsFatalEnabled )
					log.Fatal("SocketServer failed", ex);
			}
		}

		private void StopListeners()
		{
			if(!this.IsDisposed)
			{
				RtmpSocketListener[] socketListeners = GetSocketListeners();
				if( socketListeners != null )
				{
                    foreach (RtmpSocketListener socketListener in socketListeners)
					{
						try
						{
							socketListener.Stop();
							RemoveListener(socketListener);
						}
						catch { }
					}
				}
			}
		}

		private void StopConnections()
		{
			if( !this.IsDisposed )
			{
				RtmpServerConnection[] connections = GetConnections();
                if (connections != null)
				{
                    foreach (RtmpServerConnection connection in connections)
					{
						try
						{
                            connection.Close();
						}
						catch { }
					}
				}
			}
		}

		public void Stop()
		{
			if( !this.IsDisposed )
			{
				try
				{
					if( log.IsInfoEnabled )
                        log.Info(__Res.GetString(__Res.SocketServer_Stopping));
					StopListeners();
                    StopConnections();
                    //if (_threadPoolEx != null)
                    //    _threadPoolEx.Shutdown();
                    if (log.IsInfoEnabled)
                        log.Info(__Res.GetString(__Res.SocketServer_Stopped));
				}
				catch(Exception ex)
				{
					if( log.IsFatalEnabled )
                        log.Fatal(__Res.GetString(__Res.SocketServer_Failed), ex);
				}
			}
		}

        /*
        private void IdleCheck(object state)
		{
            if (!IsDisposed)
            {
                //Disable timer event
                _idleTimer.Change(Timeout.Infinite, Timeout.Infinite);
                try
                {
                    int loopSleep = 0;
                    RtmpServerConnection[] connections = GetConnections();
                    if (connections != null)
                    {
                        foreach (RtmpServerConnection connection in connections)
                        {
                            if (IsDisposed)
                                break;
                            try
                            {
                                if (connection != null && connection.IsActive)
                                {
                                    //Check the idle timeout
                                    if (DateTime.Now > (connection.LastAction.AddMilliseconds(_idleTimeOutValue)))
                                    {
                                        //connection.Close();
                                    }
                                }
                            }
                            finally
                            {
                                ThreadPoolEx.LoopSleep(ref loopSleep);
                            }
                        }
                    }
                }
                finally
                {
                    //Restart the timer event
                    if (!IsDisposed)
                        _idleTimer.Change(_idleCheckInterval, _idleCheckInterval);
                }
            }
		}
        */

		internal RtmpSocketListener[] GetSocketListeners()
		{
            RtmpSocketListener[] socketListeners = null;
			if(!this.IsDisposed)
			{
				lock(_socketListeners)
				{
                    socketListeners = new RtmpSocketListener[_socketListeners.Count];
					_socketListeners.CopyTo(socketListeners, 0);
				}

			}
			return socketListeners;
		}

        internal RtmpServerConnection[] GetConnections()
		{
            RtmpServerConnection[] connections = null;
			if(!this.IsDisposed)
			{
				lock(_connections)
				{
                    connections = new RtmpServerConnection[_connections.Count];
                    _connections.Keys.CopyTo(connections, 0);
				}

			}
            return connections;
		}

        internal void AddConnection(RtmpServerConnection connection)
		{
			if(!this.IsDisposed)
			{
				lock(_connections)
				{
                    _connections[connection] = connection;
				}
			}

		}

        internal void RemoveConnection(RtmpServerConnection connection)
		{
			if(!this.IsDisposed)
			{
				lock(_connections)
				{
                    _connections.Remove(connection);
				}
			}
		}

		public void AddListener(IPEndPoint localEndPoint)
		{
			AddListener(localEndPoint, 1);
		}

		public void AddListener(IPEndPoint localEndPoint, int acceptCount)
		{
			if(!this.IsDisposed)
			{
				lock(_socketListeners)
				{
                    RtmpSocketListener socketListener = new RtmpSocketListener(this, localEndPoint, acceptCount);
					_socketListeners.Add(socketListener);
				}
			}
		}

        public void RemoveListener(RtmpSocketListener socketListener)
		{
			if(!this.IsDisposed)
			{
				lock(_socketListeners)
				{
					_socketListeners.Remove(socketListener);
				}
			}
        }

        #endregion Server Management

        internal void InitializeConnection(Socket socket)
		{
			if(!IsDisposed)
			{
                RtmpServerConnection connection = new RtmpServerConnection(this, socket);
                if (log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Rtmp_SocketListenerAccept, connection.ConnectionId));
                //We are still in an IOCP thread 
                this.AddConnection(connection);
                _rtmpHandler.ConnectionOpened(connection);
                connection.BeginReceive(true);
			}
		}

		/// <summary>
		/// Begin disconnect the connection
		/// </summary>
        internal void OnConnectionClose(RtmpServerConnection connection)
		{
			if(!IsDisposed)
			{
                RemoveConnection(connection);
                //connection.Dispose();
			}
		}

		internal void RaiseOnError(Exception exception)
		{
			if(_onErrorEvent != null)
			{
				_onErrorEvent(this, new ServerErrorEventArgs(exception));
			}
		}
	}

	delegate void ErrorHandler(object sender, ServerErrorEventArgs e); 

	/// <summary>
	/// Base event arguments for connection events.
	/// </summary>
	class ServerErrorEventArgs : EventArgs
	{
		Exception _exception;

		public ServerErrorEventArgs(Exception exception)
		{
			_exception = exception;
		}

		#region Properties

		public Exception Exception
		{
			get { return _exception; }
		}

		#endregion
	}
}
