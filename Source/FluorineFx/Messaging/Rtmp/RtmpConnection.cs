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
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !SILVERLIGHT
using log4net;
#endif
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Stream;
using FluorineFx.Messaging.Rtmp.Service;
using FluorineFx.Util;
using FluorineFx.Context;
using FluorineFx.Collections;
using FluorineFx.Configuration;

namespace FluorineFx.Messaging.Rtmp
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    enum RtmpConnectionState
    {
        Inactive,
        Active,
        Disconnectig
    }

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public abstract class RtmpConnection : BaseConnection, IServiceCapableConnection, IMessageConnection//, IStreamCapableConnection
	{
#if !SILVERLIGHT
        private static ILog log = LogManager.GetLogger(typeof(RtmpConnection));
#endif
        RtmpContext	_context;
#if !(NET_1_1)
        /// <summary>
        /// Connection channels.
        /// Integer, Channel
        /// </summary>
        private Dictionary<int, RtmpChannel> _channels = new Dictionary<int, RtmpChannel>();
        private Dictionary<string, IMessageClient> _clients = new Dictionary<string, IMessageClient>();
        /// <summary>
        /// Stores pending calls and ids as pairs.
        /// </summary>
        protected Dictionary<int, IServiceCall> _pendingCalls = new Dictionary<int, IServiceCall>();
        /// <summary>
        /// Deferred results set.
        /// </summary>
        protected Dictionary<DeferredResult, object> _deferredResults = new Dictionary<DeferredResult, object>();
#else
        /// <summary>
        /// Connection channels.
        /// Integer, Channel
        /// </summary>
        private Hashtable _channels = new Hashtable();
        private Hashtable _clients = new Hashtable();
        /// <summary>
        /// Stores pending calls and ids as pairs.
        /// </summary>
        protected Hashtable _pendingCalls = new Hashtable();
        /// <summary>
        /// Deferred results set.
        /// </summary>
        protected Hashtable _deferredResults = new Hashtable();
#endif
        /// <summary>
        /// Identifier for remote calls.
        /// </summary>
        AtomicInteger _invokeId = new AtomicInteger(1);

        /// <summary>
        /// Timestamp when last ping command was sent.
        /// </summary>
        protected int _lastPingSent;
        /// <summary>
        /// Timestamp when last ping result was received.
        /// </summary>
        protected int _lastPongReceived;
        /// <summary>
        /// Last ping timestamp.
        /// </summary>
        protected int _lastPingTime = -1;
        /// <summary>
        /// Number of bytes the client reported to have received.
        /// </summary>
        private long _clientBytesRead = 0;
        /// <summary>
        /// Data read interval
        /// </summary>
        protected int _bytesReadInterval = 120 * 1024;
        /// <summary>
        /// Number of bytes to read next.
        /// </summary>
        protected int _nextBytesRead = 120 * 1024;
        /// <summary>
        /// Previously number of bytes read from connection.
        /// </summary>
        protected long _lastBytesRead = 0;

        internal RtmpConnection(string path, IDictionary parameters)
            : base(path, parameters)
		{
			// We start with an anonymous connection without a scope.
			// These parameters will be set during the call of "connect" later.
			_context = new RtmpContext(RtmpMode.Server);
		}

	    public override bool Connect(IScope newScope, object[] parameters) 
        {
		    bool success = base.Connect(newScope, parameters);
		    return success;
	    }

        public override void Timeout()
        {
            lock (this.SyncRoot)
            {
                if (!IsDisposed)
                {
                    if (this.IsFlexClient)
                    {
                        FlexInvoke flexInvoke = new FlexInvoke();
                        flexInvoke.Cmd = "onstatus";
                        StatusASO statusASO = new StatusASO(StatusASO.NC_CONNECT_CLOSED, StatusASO.STATUS, "Connection Timed Out", null, this.ObjectEncoding);
                        flexInvoke.Parameters = new object[] { statusASO };
                        RtmpChannel channel = this.GetChannel(3);
                        channel.Write(flexInvoke);
                    }
                    else
                    {
                        StatusASO statusASO = new StatusASO(StatusASO.NC_CONNECT_CLOSED, StatusASO.ERROR, "Connection Timed Out", null, this.ObjectEncoding);
                        RtmpChannel channel = this.GetChannel(3);
                        channel.SendStatus(statusASO);
                    }
                }
            }
        }

        public override void Close()
        {
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_ConnectionClose, _connectionId));
#endif
            lock (this.SyncRoot)
            {
                if (!IsDisposed)
                {
                    lock (((ICollection)_channels).SyncRoot)
                    {
                        _channels.Clear();
                    }
                    //DisconnectMessageClients();
                    base.Close();
                    _context.State = RtmpState.Disconnected;
                }
            }
        }
        

        public RtmpState State
        {
            get { return _context.State; }
        }

		public void Setup(string host, string path, IDictionary parameters)
		{
			_path = path;
			_parameters = parameters;
			if( _parameters.Contains("objectEncoding") )
			{
				int objectEncoding = System.Convert.ToInt32( _parameters["objectEncoding"] );
				_objectEncoding = (ObjectEncoding)objectEncoding;
			}
		}


		public RtmpContext Context
		{
			get{ return _context; }
		}


		public bool IsChannelUsed(int channelId) 
		{
            lock (((ICollection)_channels).SyncRoot)
            {
                return _channels.ContainsKey(channelId) && _channels[channelId] != null;
            }
		}

		public RtmpChannel GetChannel(int channelId) 
		{
            lock (((ICollection)_channels).SyncRoot)
			{
				if(!IsChannelUsed(channelId))
					_channels[channelId] = new RtmpChannel(this, channelId);
				return _channels[channelId] as RtmpChannel;
			}
		}

		public void CloseChannel(int channelId) 
		{
            lock (((ICollection)_channels).SyncRoot)
			{
				_channels[channelId] = null;
			}
		}

		public int InvokeId
		{ 
			get{ return _invokeId.Increment(); } 
		}

		public int GetStreamIdForChannel(int channelId) 
		{
			if (channelId < 4) 
				return 0;
			return ((channelId - 4) / 5) + 1;
		}

		public IPendingServiceCall GetPendingCall(int invokeId)
		{
			IPendingServiceCall result = null;
            lock (((ICollection)_pendingCalls).SyncRoot)
            {
                if( _pendingCalls.ContainsKey(invokeId) )
                    result = _pendingCalls[invokeId] as IPendingServiceCall;
                if (result != null)
                {
                    _pendingCalls.Remove(invokeId);
                }
                else
                {
#if !SILVERLIGHT
                    //Do not warn as users may not pass IPendingServiceCall
                    //log.Warn(string.Format("Could not find PendingServiceCall for InvokeId {0}", invokeId));
                    log.Debug(string.Format("Could not find PendingServiceCall for InvokeId {0}", invokeId));
#endif
                }
            }
			return result;
		}

        internal void RegisterPendingCall(int invokeId, IPendingServiceCall call)
        {
            lock (((ICollection)_pendingCalls).SyncRoot)
            {
                _pendingCalls[invokeId] = call;
            }
        }

		public abstract void Write(RtmpPacket packet);


        #region IConnection Members


        protected virtual void WritingMessage(RtmpPacket packet)
        {
        }

        /// <summary>
        /// Start measuring the roundtrip time for a packet on the connection.
        /// </summary>
        public override void Ping()
        {
            int newPingTime = Environment.TickCount;
            if(_lastPingSent == 0)
                _lastPongReceived = newPingTime;
            Ping pingRequest = new Ping();
            pingRequest.Value1 = (short)FluorineFx.Messaging.Rtmp.Event.Ping.PingClient;
            _lastPingSent = newPingTime;
            int now = (int)(_lastPingSent & 0xffffffff);
            pingRequest.Value2 = now;
            pingRequest.Value3 = FluorineFx.Messaging.Rtmp.Event.Ping.Undefined;
            Ping(pingRequest);
        }

        #endregion

        public void Ping(Ping ping)
        {
            GetChannel((byte)2).Write(ping);
        }

        /// <summary>
        /// Marks that pingback was received.
        /// </summary>
        /// <param name="pong"></param>
        internal void PingReceived(Ping pong)
        {
            _lastPongReceived = Environment.TickCount;
            int now = (int)(_lastPongReceived & 0xffffffff);
            _lastPingTime = now - pong.Value2;
        }

        public override int LastPingTime { get { return _lastPingTime; } }


		#region IServiceCapableConnection Members

        /// <summary>
        /// Invokes service using service call object.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
		public void Invoke(IServiceCall serviceCall)
		{
			Invoke(serviceCall, (byte)3);
		}
        /// <summary>
        /// Invokes service using service call object and channel.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
        /// <param name="channel">Channel to use.</param>
        public void Invoke(IServiceCall serviceCall, byte channel)
		{
			// We need to use Invoke for all calls to the client
			Invoke invoke = new Invoke();
			invoke.ServiceCall = serviceCall;
			invoke.InvokeId = this.InvokeId;
			if(serviceCall is IPendingServiceCall)
			{
                lock (((ICollection)_pendingCalls).SyncRoot)
                {
                    _pendingCalls[invoke.InvokeId] = serviceCall;
                }
			}
			GetChannel(channel).Write(invoke);
		}
        /// <summary>
        /// Invoke method by name.
        /// </summary>
        /// <param name="method">Method name.</param>
		public void Invoke(string method)
		{
			Invoke(method, null, null);
		}
        /// <summary>
        /// Invoke method by name with callback.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="callback">Callback used to handle return values.</param>
        public void Invoke(string method, IPendingServiceCallback callback)
		{
			Invoke(method, null, callback);
		}
        /// <summary>
        /// Invoke method with parameters.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Invocation parameters passed to the method.</param>
        public void Invoke(string method, object[] parameters)
		{
			Invoke(method, parameters, null);
		}
        /// <summary>
        /// Invoke method with parameters and callback.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Invocation parameters passed to the method.</param>
        /// <param name="callback">Callback used to handle return values.</param>
        public void Invoke(string method, object[] parameters, IPendingServiceCallback callback)
		{
			IPendingServiceCall call = new PendingCall(method, parameters);
			if(callback != null) 
				call.RegisterCallback(callback);
			Invoke(call);
		}
        /// <summary>
        /// Notifies service using service call object.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
		public void Notify(IServiceCall serviceCall)
		{
			Notify(serviceCall, (byte)3);
		}
        /// <summary>
        /// Notifies service using service call object and channel.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
        /// <param name="channel">Channel to use.</param>
		public void Notify(IServiceCall serviceCall, byte channel)
		{
			Notify notify = new Notify();
			notify.ServiceCall = serviceCall;
			GetChannel(channel).Write(notify);
		}
        /// <summary>
        /// Notifies method by name.
        /// </summary>
        /// <param name="method">Method name.</param>
		public void Notify(string method)
		{
			Notify(method, null);
		}
        /// <summary>
        /// Notifies method with parameters.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Parameters passed to the method.</param>
		public void Notify(string method, object[] parameters)
		{
			IServiceCall serviceCall = new Call(method, parameters);
			Notify(serviceCall);
		}

		#endregion

		public override string ToString()
		{
			return "RtmpConnection " + _connectionId;
		}


		#region IMessageConnection Members

		public void RegisterMessageClient(IMessageClient client)
		{
            lock (((ICollection)_clients).SyncRoot)
			{
				if(!_clients.ContainsKey(client.ClientId))
				{
					_clients.Add(client.ClientId, client);
				}
			}
		}

		public void RemoveMessageClient(string clientId)
		{
            lock (((ICollection)_clients).SyncRoot)
			{
				if(_clients.ContainsKey(clientId))
				{
					//MessageClient client = _clients[clientId] as MessageClient;
					_clients.Remove(clientId);
				}
			}
		}

		public void RemoveMessageClients()
		{
            lock (((ICollection)_clients).SyncRoot)
			{
				_clients.Clear();
			}
		}

		public bool IsClientRegistered(string clientId)
		{
            lock (((ICollection)_clients).SyncRoot)
			{
				return _clients.ContainsKey(clientId);
			}
		}

		public int ClientCount
		{
			get
			{
                lock (((ICollection)_clients).SyncRoot)
				{
					return _clients.Count; 
				}
			}
		}

		public abstract void Push(IMessage message, IMessageClient messageClient);

		#endregion

        /// <summary>
        /// Increases number of read messages by one. Updates number of bytes read.
        /// </summary>
        internal void MessageReceived()
        {
            _readMessages++;
            // Trigger generation of BytesRead messages            
            UpdateBytesRead();
        }

	    internal virtual void MessageSent(RtmpPacket packet) 
        {
		    _writtenMessages++;
	    }

        /// <summary>
        /// Update number of bytes to read next value.
        /// </summary>
        protected void UpdateBytesRead()
        {
            long bytesRead = this.ReadBytes;
            if (bytesRead >= _nextBytesRead)
            {
                BytesRead sbr = new BytesRead((int)bytesRead);
                GetChannel((byte)2).Write(sbr);
                _nextBytesRead += _bytesReadInterval;
            }
        }

        public override long ReadBytes { get { return 0; } }

        public override long WrittenBytes { get { return 0; } }

        public void ReceivedBytesRead(int bytes)
        {
#if !SILVERLIGHT
            log.Info("Client received " + bytes + " bytes, written " + this.WrittenBytes + " bytes, " + this.PendingMessages + " messages pending");
#endif
            _clientBytesRead = bytes;
        }
        /// <summary>
        /// Gets the number of bytes the client reported to have received.
        /// </summary>
        public override long ClientBytesRead
        {
            get { return _clientBytesRead; }
        }

        /// <summary>
        /// Creates output stream object from stream id. Output stream consists of audio, data and video channels.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Output stream object.</returns>
        public OutputStream CreateOutputStream(int streamId)
        {
            int channelId = (4 + ((streamId - 1) * 5));
            RtmpChannel data = GetChannel(channelId++);
            RtmpChannel video = GetChannel(channelId++);
            RtmpChannel audio = GetChannel(channelId++);
            return new OutputStream(video, audio, data);
        }

        /// <summary>
        /// Registers deferred result.
        /// </summary>
        /// <param name="result">Result to register.</param>
        internal void RegisterDeferredResult(DeferredResult result)
        {
            lock (((ICollection)_deferredResults).SyncRoot)
            {
                _deferredResults.Add(result, null);
            }
        }
        /// <summary>
        /// Unregister deferred result.
        /// </summary>
        /// <param name="result">Result to unregister.</param>
        internal void UnregisterDeferredResult(DeferredResult result)
        {
            lock (((ICollection)_deferredResults).SyncRoot)
            {
                _deferredResults.Remove(result);
            }
        }

        internal virtual void StartWaitForHandshake()
        {
        }

        internal virtual void StartRoundTripMeasurement()
        {
        }

        /// <summary>
        /// Inactive state event handler.
        /// </summary>
        protected abstract void OnInactive();


    }
}
