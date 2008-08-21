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
using log4net;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Stream;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Util;
using FluorineFx.Context;
using FluorineFx.Scheduling;
using FluorineFx.Collections;
using FluorineFx.Configuration;

namespace FluorineFx.Messaging.Rtmp
{

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public abstract class RtmpConnection : BaseConnection, IServiceCapableConnection, IMessageConnection, IStreamCapableConnection
	{
        private static ILog log = LogManager.GetLogger(typeof(RtmpConnection));

        RtmpContext	_context;
        /// <summary>
        /// Connection channels.
        /// Integer, Channel
        /// </summary>
        SynchronizedHashtable _channels;
        SynchronizedHashtable _clients;

        /// <summary>
        /// Identifier for remote calls.
        /// </summary>
        AtomicInteger _invokeId = new AtomicInteger(1);
        /// <summary>
        /// Stores pending calls and ids as pairs.
        /// </summary>
        protected SynchronizedHashtable _pendingCalls = new SynchronizedHashtable();
        /// <summary>
        /// Deferred results set.
        /// </summary>
        protected SynchronizedHashtable _deferredResults = new SynchronizedHashtable();

        /// <summary>
        /// Client streams.
        /// Map(Integer, IClientStream)
        /// </summary>
        SynchronizedHashtable _streams = new SynchronizedHashtable();
        /// <summary>
        /// Remembers stream buffer durations
        /// Map(Integer, Integer)
        /// </summary>
        protected Hashtable _streamBuffers = new Hashtable();
        /// <summary>
        /// Map for pending video packets and stream IDs
        /// Map(Integer, AtomicInteger)
        /// </summary>
        private SynchronizedHashtable _pendingVideos = new SynchronizedHashtable();
        /// <summary>
        /// Number of streams used.
        /// </summary>
        private int _streamCount;
        /// <summary>
        /// Bandwidth configure.
        /// </summary>
        private IConnectionBWConfig _bwConfig;
        /// <summary>
        /// Bandwidth context used by bandwidth controller.
        /// </summary>
        private IBWControlContext _bwContext;

        static int StreamId = 0;

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
        private int _bytesReadInterval = 120 * 1024;
        /// <summary>
        /// Number of bytes to read next.
        /// </summary>
        private int _nextBytesRead = 120 * 1024;
        /// <summary>
        /// Previously number of bytes read from connection.
        /// </summary>
        private long _lastBytesRead = 0;

        /// <summary>
        /// Name of job that is waiting for a valid handshake.
        /// </summary>
        //private string _waitForHandshakeJob;
        /// <summary>
        /// Name of job that keeps connection alive.
        /// </summary>
        protected string _keepAliveJobName;

        internal RtmpConnection(IEndpoint endpoint, string path, Hashtable parameters)
            : base(endpoint, path, parameters)
		{
			// We start with an anonymous connection without a scope.
			// These parameters will be set during the call of "connect" later.
            _channels = new SynchronizedHashtable();
			_context = new RtmpContext(RtmpMode.Server);
            _clients = new SynchronizedHashtable();
		}

	    public override bool Connect(IScope newScope, object[] parameters) 
        {
		    bool success = base.Connect(newScope, parameters);
		    if (success) 
            {
			    // XXX Bandwidth control service should not be bound to
			    // a specific scope because it's designed to control
			    // the bandwidth system-wide.
                if (this.Scope != null && this.Scope.Context != null)
                {
                    IBWControlService bwController = this.Scope.GetService(typeof(IBWControlService)) as IBWControlService;
                    _bwContext = bwController.RegisterBWControllable(this);
                }
                /*
                if (_waitForHandshakeJob != null)
                {
                    ISchedulingService service = this.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                    service.RemoveScheduledJob(_waitForHandshakeJob);
                    _waitForHandshakeJob = null;
                }
                */
		    }
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
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_ConnectionClose, _connectionId));

            lock (this.SyncRoot)
            {
                if (!IsDisposed)
                {
                    if (_keepAliveJobName != null)
                    {
                        ISchedulingService service = this.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                        service.RemoveScheduledJob(_keepAliveJobName);
                        _keepAliveJobName = null;
                    }
                    IStreamService streamService = ScopeUtils.GetScopeService(this.Scope, typeof(IStreamService)) as IStreamService;
		            if (streamService != null) 
                    {
                        IClientStream[] streams = new IClientStream[_streams.Count];
                        _streams.Values.CopyTo(streams, 0);
                        foreach (IClientStream stream in streams)
                        {
					        if (stream != null) 
                            {
						        if (log.IsDebugEnabled) 
							        log.Debug("Closing stream: " + stream.StreamId);						
						        streamService.deleteStream(this, stream.StreamId);
						        _streamCount--;
                            }
                        }
                        _streams.Clear();
                    }
                    _channels.Clear();
                    if (_bwContext != null && this.Scope != null && this.Scope.Context != null)
                    {
                        IBWControlService bwController = this.Scope.GetService(typeof(IBWControlService)) as IBWControlService;
                        bwController.UnregisterBWControllable(_bwContext);
                        _bwContext = null;
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

		public void Setup(string host, string path, Hashtable parameters)
		{
			_path = path;
			_parameters = parameters;
			if( _parameters.ContainsKey("objectEncoding") )
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
			return _channels.Contains(channelId) && _channels[channelId] != null;
		}

		public RtmpChannel GetChannel(int channelId) 
		{
            lock (_channels)
			{
				if(!IsChannelUsed(channelId))
					_channels[channelId] = new RtmpChannel(this, channelId);
				return _channels[channelId] as RtmpChannel;
			}
		}

		public void CloseChannel(int channelId) 
		{
            lock (_channels)
			{
				_channels[channelId] = null;
			}
		}

		public int InvokeId
		{ 
			get{ return _invokeId.Increment(); } 
		}

		public IClientStream GetStreamByChannelId(int channelId) 
		{
			if(channelId < 4) 
				return null;
			return _streams[GetStreamIdForChannel(channelId) - 1] as IClientStream;
		}

        protected int StreamCount
        {
            get { return _streamCount; }
        }

		public int GetStreamIdForChannel(int channelId) 
		{
			if (channelId < 4) 
				return 0;
			return ((channelId - 4) / 5) + 1;
		}

		public IPendingServiceCall GetPendingCall(int invokeId)
		{
			IPendingServiceCall result;
            lock (_pendingCalls.SyncRoot)
            {
                result = _pendingCalls[invokeId] as IPendingServiceCall;
                if (result != null)
                {
                    _pendingCalls.Remove(invokeId);
                }
                {
                    //Do not warn as users may not pass IPendingServiceCall
                    //log.Warn(string.Format("Could not find PendingServiceCall for InvokeId {0}", invokeId));
                    log.Debug(string.Format("Could not find PendingServiceCall for InvokeId {0}", invokeId));
                }
            }
			return result;
		}

        internal void RegisterPendingCall(int invokeId, IPendingServiceCall call)
        {
            _pendingCalls[invokeId] = call;
        }

		public abstract void Write(RtmpPacket packet);


        #region IConnection Members


        protected void WritingMessage(RtmpPacket packet)
        {
            if (packet.Message is VideoData)
            {
                int streamId = packet.Header.StreamId;
                AtomicInteger value = new AtomicInteger();
                AtomicInteger old = _pendingVideos.AddIfAbsent(streamId, value) as AtomicInteger;
                if (old == null)
                    old = value;
                old.Increment();
            }
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

        public override int ClientLeaseTime
        {
            get
            {
                int timeout = this.Endpoint.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
                return timeout;
            }
        }


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
                _pendingCalls[invoke.InvokeId] = serviceCall;
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
			IServiceCall serviceCall = new ServiceCall(method, parameters);
			Notify(serviceCall);
		}

		#endregion

		public override string ToString()
		{
			return "RtmpConnection " + _connectionId;
		}


		#region IMessageConnection Members

		public void RegisterMessageClient(MessageClient client)
		{
            lock (_clients)
			{
				if(!_clients.Contains(client.ClientId))
				{
					_clients.Add(client.ClientId, client);
				}
			}
		}

		public void RemoveMessageClient(string clientId)
		{
            lock (_clients)
			{
				if(_clients.Contains(clientId))
				{
					MessageClient client = _clients[clientId] as MessageClient;
					_clients.Remove(clientId);
				}
			}
		}

		public void RemoveMessageClients()
		{
            lock (_clients)
			{
				_clients.Clear();
			}
		}

		public bool IsClientRegistered(string clientId)
		{
            lock (_clients)
			{
				return _clients.Contains(clientId);
			}
		}

		public int ClientCount
		{
			get
			{
                lock (_clients)
				{
					return _clients.Count; 
				}
			}
		}

		public abstract void Push(IMessage message, MessageClient messageClient);

		#endregion

        internal void RememberStreamBufferDuration(int streamId, int bufferDuration)
        {
            _streamBuffers.Add(streamId - 1, bufferDuration);
        }

        /// <summary>
        /// Gets collection of IClientStream.
        /// </summary>
        /// <returns></returns>
        internal ICollection GetStreams()
        {
            return _streams.Values;
        }

        /// <summary>
        /// Increases number of read messages by one. Updates number of bytes read.
        /// </summary>
        internal void MessageReceived()
        {
            _readMessages++;
            // Trigger generation of BytesRead messages            
            UpdateBytesRead();
        }

	    internal void MessageSent(RtmpPacket packet) 
        {
            if (packet.Message is VideoData) 
            {
                int streamId = packet.Header.StreamId;
                if( _pendingVideos.Contains(streamId) )
                {
                    AtomicInteger pending = _pendingVideos[streamId] as AtomicInteger;
                    pending.Decrement();
                }
			}
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
            log.Info("Client received " + bytes + " bytes, written " + this.WrittenBytes + " bytes, " + this.PendingMessages + " messages pending");
            _clientBytesRead = bytes;
        }
        /// <summary>
        /// Gets the number of bytes the client reported to have received.
        /// </summary>
        public override long ClientBytesRead
        {
            get { return _clientBytesRead; }
        }


        #region IStreamCapableConnection Members

        /// <summary>
        /// Total number of video messages that are pending to be sent to a stream.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Number of pending video messages.</returns>
        public override long GetPendingVideoMessages(int streamId)
        {
            AtomicInteger count = _pendingVideos[streamId] as AtomicInteger;
            long result = (count != null ? count.Value - this.StreamCount : 0);
            return result > 0 ? result : 0;
            //return 0;
        }
        /// <summary>
        /// Get a stream by its id.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Stream with given id.</returns>
        public IClientStream GetStreamById(int id)
        {
            if (id <= 0)
                return null;
            return _streams[id - 1] as IClientStream;
        }
        /// <summary>
        /// Returns a reserved stream id for use.
        /// According to FCS/FMS regulation, the base is 1.
        /// </summary>
        /// <returns>Reserved stream id.</returns>
        public int ReserveStreamId()
        {
            int result = Interlocked.Increment(ref StreamId);
            return result;
        }
        /// <summary>
        /// Unreserve this id for future use.
        /// </summary>
        /// <param name="streamId">ID of stream to unreserve.</param>
        public void UnreserveStreamId(int streamId)
        {
            DeleteStreamById(streamId);
        }
        /// <summary>
        /// Deletes the stream with the given id.
        /// </summary>
        /// <param name="streamId">Id of stream to delete.</param>
        public void DeleteStreamById(int streamId)
        {
		    if (streamId > 0) 
            {
                if (_streams[streamId - 1] != null)
                {
                    _pendingVideos.Remove(streamId);
                    _streamCount--;
                    _streams.Remove(streamId - 1);
                    _streamBuffers.Remove(streamId - 1);
                }
		    }
        }
        /// <summary>
        /// Creates a stream that can play only one item.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New subscriber stream that can play only one item.</returns>
        public ISingleItemSubscriberStream NewSingleItemSubscriberStream(int streamId)
        {
            return null;
        }
        /// <summary>
        /// Creates a stream that can play a list.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New stream that can play sequence of items.</returns>
        public IPlaylistSubscriberStream NewPlaylistSubscriberStream(int streamId)
        {
            lock (this.SyncRoot)
            {
                if (streamId < StreamId)
                    return null;
                //TODO
                PlaylistSubscriberStream pss = new PlaylistSubscriberStream();
                if (_streamBuffers.Contains(streamId - 1))
                {
                    int buffer = (int)_streamBuffers[streamId - 1];
                    pss.SetClientBufferDuration(buffer);
                }
                pss.Name = CreateStreamName();
                pss.Connection = this;
                pss.Scope = this.Scope;
                pss.StreamId = streamId;
                RegisterStream(pss);
                _streamCount++;
                return pss;
            }     
        }
        /// <summary>
        /// Generates new stream name.
        /// </summary>
        /// <returns>New stream name.</returns>
        protected string CreateStreamName()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Creates a broadcast stream.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>New broadcast stream.</returns>
        public IClientBroadcastStream NewBroadcastStream(int streamId)
        {
            lock (this.SyncRoot)
            {
                if (streamId < StreamId)
                    return null;
                //TODO
                ClientBroadcastStream cbs = new ClientBroadcastStream();
                if (_streamBuffers.Contains(streamId - 1))
                {
                    int buffer = (int)_streamBuffers[streamId - 1];
                    cbs.SetClientBufferDuration(buffer);
                }
                cbs.StreamId = streamId;
                cbs.Connection = this;
                cbs.Name = CreateStreamName();
                cbs.Scope = this.Scope;

                RegisterStream(cbs);
                _streamCount++;
                return cbs;
            }
        }
        /// <summary>
        /// Store a stream in the connection.
        /// </summary>
        /// <param name="stream"></param>
        protected void RegisterStream(IClientStream stream)
        {
            _streams[stream.StreamId - 1] = stream;
        }

        #endregion

        #region IBWControllable Members

        /// <summary>
        /// Returns parent IBWControllable object.
        /// </summary>
        /// <returns>Parent IBWControllable.</returns>
        public IBWControllable GetParentBWControllable()
        {
            // TODO return the client object
            return null;
        }
        /// <summary>
        /// Gets or sets bandwidth configuration object.
        /// Bandwidth configuration allows you to set bandwidth size for audio, video and total amount.
        /// </summary>
        public IBandwidthConfigure BandwidthConfiguration
        {
            get
            {
                return _bwConfig;
            }
            set
            {
                if (!(value is IConnectionBWConfig))
                    return;

                _bwConfig = value as IConnectionBWConfig;
                // Notify client about new bandwidth settings (in bytes per second)
                if (_bwConfig.DownstreamBandwidth > 0)
                {
                    ServerBW serverBW = new ServerBW((int)_bwConfig.DownstreamBandwidth / 8);
                    GetChannel((byte)2).Write(serverBW);
                }
                if (_bwConfig.UpstreamBandwidth > 0)
                {
                    ClientBW clientBW = new ClientBW((int)_bwConfig.UpstreamBandwidth / 8, (byte)0);
                    GetChannel((byte)2).Write(clientBW);
                    // Update generation of BytesRead messages
                    // TODO: what are the correct values here?
                    _bytesReadInterval = (int)_bwConfig.UpstreamBandwidth / 8;
                    _nextBytesRead = (int)this.WrittenBytes;
                }
                if (_bwContext != null)
                {
                    IBWControlService bwController = this.Scope.GetService(typeof(IBWControlService)) as IBWControlService;
                    bwController.UpdateBWConfigure(_bwContext);
                }
            }
        }

        #endregion

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

        internal void StartWaitForHandshake(ISchedulingService schedulingService)
        {
            if (FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.MaxHandshakeTimeout > 0)
            {
                //_waitForHandshakeJob = schedulingService.AddScheduledOnceJob(FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.MaxHandshakeTimeout, new WaitForHandshakeJob(this));
            }
        }

        /// <summary>
        /// Registers deferred result.
        /// </summary>
        /// <param name="result">Result to register.</param>
        internal void RegisterDeferredResult(DeferredResult result)
        {
            _deferredResults.Add(result, null);
        }
        /// <summary>
        /// Unregister deferred result.
        /// </summary>
        /// <param name="result">Result to unregister.</param>
        internal void UnregisterDeferredResult(DeferredResult result)
        {
            _deferredResults.Remove(result);
        }

        /*
        internal class WaitForHandshakeJob : ScheduledJobBase
        {
            RtmpConnection _connection;

            public WaitForHandshakeJob(RtmpConnection connection)
            {
                _connection = connection;
            }

            public override void Execute(ScheduledJobContext context)
            {
                FluorineRtmpContext.Initialize(_connection);
                _connection._waitForHandshakeJob = null;
                // Client didn't send a valid handshake, disconnect.
                _connection.OnInactive();
            }
        }
        */

        /// <summary>
        /// Inactive state event handler.
        /// </summary>
        protected abstract void OnInactive();

        /// <summary>
        /// Starts measurement.
        /// </summary>
        public void StartRoundTripMeasurement()
        {
            if (FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.PingInterval <= 0)
            {
                // Ghost detection code disabled
                return;
            }
            if (_keepAliveJobName == null)
            {
                ISchedulingService service = this.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                _keepAliveJobName = service.AddScheduledJob(FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.PingInterval, new KeepAliveJob(this));
            }
            log.Debug("Keep alive job name " + _keepAliveJobName);
        }

        private class KeepAliveJob : ScheduledJobBase
        {
            RtmpConnection _connection;

            public KeepAliveJob(RtmpConnection connection)
            {
                _connection = connection;
            }

            public override void Execute(ScheduledJobContext context)
            {
                if (!_connection.IsConnected)
                    return;
                long thisRead = _connection.ReadBytes;
                if (thisRead > _connection._lastBytesRead)
                {
                    // Client sent data since last check and thus is not dead. No need to ping.
                    _connection._lastBytesRead = thisRead;
                    return;
                }
                FluorineRtmpContext.Initialize(_connection);

                if (_connection._lastPongReceived > 0 && _connection._lastPingSent - _connection._lastPongReceived > FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.MaxInactivity)
                {
                    // Client didn't send response to ping command for too long, disconnect
                    log.Debug("Keep alive job name " +_connection._keepAliveJobName);

                    ISchedulingService service = _connection.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                    service.RemoveScheduledJob(_connection._keepAliveJobName);
                    _connection._keepAliveJobName = null;
                    log.Warn(string.Format("Closing {0} due to too much inactivity ({0}).", _connection, (_connection._lastPingSent - _connection._lastPongReceived)));
                    _connection.OnInactive();
                    return;
                }
                // Send ping command to client to trigger sending of data.
                _connection.Ping();
            }
        }
    }
}
