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
using System.Diagnostics;
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
using FluorineFx.Messaging.Rtmpt;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Util;
using FluorineFx.Context;
using FluorineFx.Configuration;
using FluorineFx.Collections;
using FluorineFx.Threading;
using FluorineFx.Scheduling;

namespace FluorineFx.Messaging.Rtmp
{
    class SocketBufferPool
    {
        private static BufferPool bufferPool;

        public static BufferPool Pool
        {
            get
            {
                if (bufferPool == null)
                {
                    lock (typeof(SocketBufferPool))
                    {
                        if (bufferPool == null)
                            bufferPool = new BufferPool(FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.ReceiveBufferSize);
                    }
                }
                return bufferPool;
            }
        }
    }

    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class RtmpServerConnection : RtmpConnection, IStreamCapableConnection
    {
        private static ILog log = LogManager.GetLogger(typeof(RtmpServerConnection));

#if !(NET_1_1)
        /// <summary>
        /// Client streams.
        /// Map(Integer, IClientStream)
        /// </summary>
        private Dictionary<int, IClientStream> _streams = new Dictionary<int, IClientStream>();
        /// <summary>
        /// Remembers stream buffer durations
        /// Map(Integer, Integer)
        /// </summary>
        protected Dictionary<int, int> _streamBuffers = new Dictionary<int, int>();
        /// <summary>
        /// Map for pending video packets and stream IDs
        /// Map(Integer, AtomicInteger)
        /// </summary>
        private Dictionary<int, AtomicInteger> _pendingVideos = new Dictionary<int, AtomicInteger>();
#else
        /// <summary>
        /// Client streams.
        /// Map(Integer, IClientStream)
        /// </summary>
        private Hashtable _streams = new Hashtable();
        /// <summary>
        /// Remembers stream buffer durations
        /// Map(Integer, Integer)
        /// </summary>
        protected Hashtable _streamBuffers = new Hashtable();
        /// <summary>
        /// Map for pending video packets and stream IDs
        /// Map(Integer, AtomicInteger)
        /// </summary>
        private Hashtable _pendingVideos = new Hashtable();
#endif

        static int StreamId = 0;
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


        RtmpServer _rtmpServer;
        ByteBuffer _readBuffer;
        RtmpNetworkStream _rtmpNetworkStream;
        DateTime _lastAction;
        volatile RtmpConnectionState _state;
        FluorineFx.Messaging.Endpoints.IEndpoint _endpoint;
        /// <summary>
        /// Name of job that is waiting for a valid handshake.
        /// </summary>
        //private string _waitForHandshakeJob;
        /// <summary>
        /// Name of job that keeps connection alive.
        /// </summary>
        protected string _keepAliveJobName;
        
        RtmptRequest _rtmptRequest;
        
        private long _readBytes;
        private long _writtenBytes;

        public RtmpServerConnection(RtmpServer rtmpServer, Socket socket)
            : base(null, null)
		{
            _endpoint = rtmpServer.Endpoint;
            _readBuffer = ByteBuffer.Allocate(4096);
            _readBuffer.Flip();

			// We start with an anonymous connection without a scope.
			// These parameters will be set during the call of "connect" later.
            _rtmpServer = rtmpServer;
            _rtmpNetworkStream = new RtmpNetworkStream(socket);
            _state = RtmpConnectionState.Active;
            SetIsTunneled(false);
            IsTunnelingDetected = false;
		}

        public bool IsTunneled
        {
            get { return (__fields & 32) == 32; }
        }

        internal void SetIsTunneled(bool value)
        {
            __fields = (value) ? (byte)(__fields | 32) : (byte)(__fields & ~32);
        }

        internal bool IsTunnelingDetected
        {
            get { return (__fields & 16) == 16; }
            set { __fields = (value) ? (byte)(__fields | 16) : (byte)(__fields & ~16); }
        }

        public bool IsActive
        {
            get { return _state == RtmpConnectionState.Active; }
        }

        public bool IsDisconnecting
        {
            get { return _state == RtmpConnectionState.Disconnectig; }
        }

        public bool IsDisconnected
        {
            get { return _state == RtmpConnectionState.Inactive; }
        }

        public DateTime LastAction
        {
            get { return _lastAction; }
            set { _lastAction = value; }
        }

        public override IPEndPoint RemoteEndPoint
        {
            get { return _rtmpNetworkStream.Socket.RemoteEndPoint as IPEndPoint; }
        }

        public FluorineFx.Messaging.Endpoints.IEndpoint Endpoint { get { return _endpoint; } }


        #region Network IO
        public void BeginReceive(bool IOCPThread)
        {
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketBeginReceive, _connectionId, IOCPThread));

            if (!IOCPThread)
                ThreadPool.QueueUserWorkItem(new WaitCallback(BeginReceiveCallbackProcessing), null);
            else
                BeginReceiveCallbackProcessing(null);
        }

        public void BeginReceiveCallbackProcessing(object state)
        {
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketReceiveProcessing, _connectionId));
            if (!IsDisposed && IsActive)
            {
                byte[] buffer = null;
                try
                {
                    buffer = SocketBufferPool.Pool.CheckOut();
                    _rtmpNetworkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(BeginReadCallbackProcessing), buffer);
                }
                catch (Exception ex)
                {
                    SocketBufferPool.Pool.CheckIn(buffer);
                    HandleError(ex);
                }
            }
        }

        private void BeginReadCallbackProcessing(IAsyncResult ar)
        {
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketBeginRead, _connectionId));

            byte[] buffer = ar.AsyncState as byte[];
            if (!IsDisposed && IsActive)
            {
                try
                {
                    _lastAction = DateTime.Now;
                    int readBytes = _rtmpNetworkStream.EndRead(ar);
                    _readBytes += readBytes;
                    if (readBytes > 0)
                    {
                        _readBuffer.Append(buffer, 0, readBytes);
                        //Leave IOCP thread
                        ThreadPoolEx.Global.QueueUserWorkItem(new WaitCallback(OnReceivedCallback), null);
                    }
                    else
                        // No data to read
                        Close();
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    SocketBufferPool.Pool.CheckIn(buffer);
                }
            }
            else
            {
                SocketBufferPool.Pool.CheckIn(buffer);
            }
        }

        private void OnReceivedCallback(object state)
        {
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketReadProcessing, _connectionId));

            if (log.IsDebugEnabled)
                log.Debug("Begin handling packet " + this.ToString());

            if (!IsTunnelingDetected)
            {
                IsTunnelingDetected = true;
                byte rtmpDetect = _readBuffer.Get(0);
                SetIsTunneled(rtmpDetect != 0x3);
            }
            try
            {
                if (!IsTunneled)
                {
#if !(NET_1_1)
                    List<object> result = RtmpProtocolDecoder.DecodeBuffer(this.Context, _readBuffer);
#else
                    ArrayList result = RtmpProtocolDecoder.DecodeBuffer(this.Context, _readBuffer);
#endif
                    if (result != null && result.Count > 0)
                    {
                        foreach (object obj in result)
                        {
                            if (obj is ByteBuffer)
                            {
                                ByteBuffer buf = obj as ByteBuffer;
                                Send(buf);
                            }
                            else
                            {
                                FluorineRtmpContext.Initialize(this);
                                _rtmpServer.RtmpHandler.MessageReceived(this, obj);
                            }
                        }
                    }
                }
                else
                {
                    //Reset buffer position
                    HandleRtmpt();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            if (log.IsDebugEnabled)
                log.Debug("End handling packet " + this.ToString());
            //Ready to receive again
            BeginReceive(false);
        }

        private void HandleError(Exception exception)
        {
            SocketException socketException = exception as SocketException;
            if (exception.InnerException != null && exception.InnerException is SocketException)
                socketException = exception.InnerException as SocketException;

            bool error = true;
            if (socketException != null && socketException.ErrorCode == 10054)//WSAECONNRESET
            {
                if (log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Rtmp_SocketConnectionReset, _connectionId));
                error = false;
            }

            if (error && log.IsErrorEnabled)
                log.Error("Error " + this.ToString(), exception);
            BeginDisconnect();
        }

        internal void BeginDisconnect()
        {
            if (!IsDisposed && !IsDisconnecting)
            {
                try
                {
                    //Leave IOCP thread
                    _state = RtmpConnectionState.Disconnectig;
                    ThreadPoolEx.Global.QueueUserWorkItem(new WaitCallback(OnDisconnectCallback), null);
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled)
                        log.Error("BeginDisconnect " + this.ToString(), ex);
                }
            }
        }

        private void OnDisconnectCallback(object state)
        {
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketDisconnectProcessing, _connectionId));

            lock (this.SyncRoot)
            {
                try
                {
                    _rtmpServer.RtmpHandler.ConnectionClosed(this);
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled)
                        log.Error("OnDisconnectCallback " + this.ToString(), ex);
                }
            }
            //Close(); -> IRtmpHandler
        }

        internal void Send(ByteBuffer buf)
        {
            lock (this.SyncRoot)
            {
                if (!IsDisposed && IsActive)
                {
                    byte[] buffer = buf.ToArray();
                    try
                    {
                        _rtmpNetworkStream.Write(buffer, 0, buffer.Length);
                        _writtenBytes += buffer.Length;
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                    }
                    _lastAction = DateTime.Now;
                }
            }
        }


        #endregion Network IO

        public override void Close()
        {
            lock (this.SyncRoot)
            {
                if (!IsDisposed && !IsDisconnected)
                {
                    if (!this.IsTunneled)
                    {
                        DeferredClose();
                    }
                    else
                    {
                        // Defer actual closing so we can send back pending messages to the client.
                        SetIsClosing(true);
                    }
                }
            }
        }

        public void DeferredClose()
        {
            lock (this.SyncRoot)
            {
                if (_keepAliveJobName != null)
                {
                    ISchedulingService service = this.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                    service.RemoveScheduledJob(_keepAliveJobName);
                    _keepAliveJobName = null;
                }
                if (!IsDisposed && !IsDisconnected)
                {
                    _state = RtmpConnectionState.Inactive;

                    IStreamService streamService = ScopeUtils.GetScopeService(this.Scope, typeof(IStreamService)) as IStreamService;
                    if (streamService != null)
                    {
                        lock (((ICollection)_streams).SyncRoot)
                        {
                            IClientStream[] streams = new IClientStream[_streams.Count];
                            _streams.Values.CopyTo(streams, 0);
                            foreach (IClientStream stream in streams)
                            {
                                if (stream != null)
                                {
#if !SILVERLIGHT
                                    if (log.IsDebugEnabled)
                                        log.Debug("Closing stream: " + stream.StreamId);
#endif
                                    streamService.deleteStream(this, stream.StreamId);
                                    _streamCount--;
                                }
                            }
                            _streams.Clear();
                        }
                    }
                    if (_bwContext != null && this.Scope != null && this.Scope.Context != null)
                    {
                        IBWControlService bwController = this.Scope.GetService(typeof(IBWControlService)) as IBWControlService;
                        bwController.UnregisterBWControllable(_bwContext);
                        _bwContext = null;
                    }
                    base.Close();
                    _rtmpServer.OnConnectionClose(this);
                    _rtmpNetworkStream.Close();
                }
            }
        }

		public override void Write(RtmpPacket packet)
		{
            if (!IsDisposed && IsActive)
            {
                if (log.IsDebugEnabled)
                    log.Debug("Write " + packet.Header);

                if (!this.IsTunneled)
                {
                    //encode
                    WritingMessage(packet);
                    ByteBuffer outputStream = RtmpProtocolEncoder.Encode(this.Context, packet);
                    Send(outputStream);
                    _rtmpServer.RtmpHandler.MessageSent(this, packet);
                }
                else
                {
                    //We should never get here
                    Debug.Assert(false);
                }
            }
		}

        public override void Push(IMessage message, IMessageClient messageClient)
        {
            if (IsActive)
            {
                RtmpHandler.Push(this, message, messageClient);
            }
        }

        protected override void OnInactive()
        {
            if (!this.IsTunneled)
            {
                this.Timeout();
                this.Close();
                this.DeferredClose();
            }
        }

        public override long WrittenBytes
        {
            get
            {
                return _writtenBytes;
            }
        }

        public override long ReadBytes
        {
            get
            {
                return _readBytes;
            }
        }

        public override int ClientLeaseTime
        {
            get
            {
                int timeout = this.Endpoint.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
                return timeout;
            }
        }

        internal override void StartWaitForHandshake()
        {
            if (FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.MaxHandshakeTimeout > 0)
            {
                //ISchedulingService schedulingService = this.Scope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                //_waitForHandshakeJob = schedulingService.AddScheduledOnceJob(FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpConnectionSettings.MaxHandshakeTimeout, new WaitForHandshakeJob(this));
            }
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
        /// Starts measurement.
        /// </summary>
        internal override void StartRoundTripMeasurement()
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
            RtmpServerConnection _connection;

            public KeepAliveJob(RtmpServerConnection connection)
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
                    log.Debug("Keep alive job name " + _connection._keepAliveJobName);

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

        private void HandleRtmpt()
        {
            if (_rtmptRequest == null)
            {
                BufferStreamReader sr = new BufferStreamReader(_readBuffer);
                string request = sr.ReadLine();
                string[] tokens = request.Split(new char[] { ' ' });
                string method = tokens[0];
                string url = tokens[1];
                // Decode all encoded parts of the URL using the built in URI processing class
                int i = 0;
                while ((i = url.IndexOf("%", i)) != -1)
                {
                    url = url.Substring(0, i) + Uri.HexUnescape(url, ref i) + url.Substring(i);
                }
                // Lets just make sure we are using HTTP, thats about all I care about
                string protocol = tokens[2];// "HTTP/"
                //Read headers
                Hashtable headers = new Hashtable();
                string line;
                string name = null;
                while ((line = sr.ReadLine()) != null && line != string.Empty)
                {
                    // If the value begins with a space or a hard tab then this
                    // is an extension of the value of the previous header and
                    // should be appended
                    if (name != null && Char.IsWhiteSpace(line[0]))
                    {
                        headers[name] += line;
                        continue;
                    }
                    // Headers consist of [NAME]: [VALUE] + possible extension lines
                    int firstColon = line.IndexOf(":");
                    if (firstColon != -1)
                    {
                        name = line.Substring(0, firstColon);
                        string value = line.Substring(firstColon + 1).Trim();
                        headers[name] = value;
                    }
                    else
                    {
                        //400, "Bad header: " + line
                        break;
                    }
                }
                _rtmptRequest = new RtmptRequest(this, url, protocol, method, headers);
            }
            if (_readBuffer.Remaining == _rtmptRequest.ContentLength)
            {
                IEndpoint endpoint = this.Endpoint.GetMessageBroker().GetEndpoint(RtmptEndpoint.FluorineRtmptEndpointId);
                RtmptEndpoint rtmptEndpoint = endpoint as RtmptEndpoint;
                if (rtmptEndpoint != null)
                {
                    _readBuffer.Compact();
                    _rtmptRequest.Data = _readBuffer;
                    _readBuffer = ByteBuffer.Allocate(4096);
                    _readBuffer.Flip();
                    rtmptEndpoint.Service(_rtmptRequest);
                    _rtmptRequest = null;
                }
            }
        }

        #region IStreamCapableConnection Members

        /// <summary>
        /// Total number of video messages that are pending to be sent to a stream.
        /// </summary>
        /// <param name="streamId">Stream id.</param>
        /// <returns>Number of pending video messages.</returns>
        public override long GetPendingVideoMessages(int streamId)
        {
            AtomicInteger count = null;
            lock (((ICollection)_pendingVideos).SyncRoot)
            {
                if (_pendingVideos.ContainsKey(streamId))
                    count = _pendingVideos[streamId] as AtomicInteger;
            }
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
            lock (((ICollection)_streams).SyncRoot)
            {
                if( _streams.ContainsKey(id - 1) )
                    return _streams[id - 1] as IClientStream;
                return null;
            }
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
                lock (((ICollection)_streams).SyncRoot)
                {
                    if (_streams.ContainsKey(streamId - 1))
                    {
                        lock (((ICollection)_pendingVideos).SyncRoot)
                        {
                            if (_pendingVideos.ContainsKey(streamId))
                                _pendingVideos.Remove(streamId);
                        }
                        _streamCount--;
                        if (_pendingVideos.ContainsKey(streamId - 1))
                            _streams.Remove(streamId - 1);
                        lock (((ICollection)_streamBuffers).SyncRoot)
                        {
                            if (_streamBuffers.ContainsKey(streamId - 1))
                                _streamBuffers.Remove(streamId - 1);
                        }
                    }
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
                lock (((ICollection)_streamBuffers).SyncRoot)
                {
                    if (_streamBuffers.ContainsKey(streamId - 1))
                    {
                        int buffer = (int)_streamBuffers[streamId - 1];
                        pss.SetClientBufferDuration(buffer);
                    }
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
                lock (((ICollection)_streamBuffers).SyncRoot)
                {
                    if (_streamBuffers.ContainsKey(streamId - 1))
                    {
                        int buffer = (int)_streamBuffers[streamId - 1];
                        cbs.SetClientBufferDuration(buffer);
                    }
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
            lock (((ICollection)_streams).SyncRoot)
            {
                _streams[stream.StreamId - 1] = stream;
            }
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

        public IClientStream GetStreamByChannelId(int channelId)
        {
            if (channelId < 4)
                return null;
            lock (((ICollection)_streams).SyncRoot)
            {
                int streamId = GetStreamIdForChannel(channelId);
                if (_streams.ContainsKey(streamId - 1))
                    return _streams[streamId - 1] as IClientStream;
            }
            return null;
        }

        protected int StreamCount
        {
            get { return _streamCount; }
        }

        internal void RememberStreamBufferDuration(int streamId, int bufferDuration)
        {
            lock (((ICollection)_streamBuffers).SyncRoot)
            {
                _streamBuffers.Add(streamId - 1, bufferDuration);
            }
        }

        /// <summary>
        /// Gets collection of IClientStream.
        /// </summary>
        /// <returns></returns>
        public ICollection GetStreams()
        {
            lock (((ICollection)_streams).SyncRoot)
            {
                return _streams.Values;
            }
        }

        protected override void WritingMessage(RtmpPacket packet)
        {
            base.WritingMessage(packet);
            if (packet.Message is VideoData)
            {
                int streamId = packet.Header.StreamId;
                AtomicInteger value = new AtomicInteger();
                AtomicInteger old = null;
                lock (((ICollection)_pendingVideos).SyncRoot)
                {
                    if (!_pendingVideos.ContainsKey(streamId))
                    {
                        _pendingVideos.Add(streamId, value);
                        old = value;
                    }
                    else
                        old = _pendingVideos[streamId] as AtomicInteger;
                }
                if (old == null)
                    old = value;
                old.Increment();
            }
        }

        internal override void MessageSent(RtmpPacket packet)
        {
            if (packet.Message is VideoData)
            {
                int streamId = packet.Header.StreamId;
                lock (((ICollection)_pendingVideos).SyncRoot)
                {
                    if (_pendingVideos.ContainsKey(streamId))
                    {
                        AtomicInteger pending = _pendingVideos[streamId] as AtomicInteger;
                        pending.Decrement();
                    }
                }
            }
            base.MessageSent(packet);
        }
    }
}
