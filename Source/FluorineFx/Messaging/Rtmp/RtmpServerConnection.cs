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
using log4net;
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
    class RtmpServerConnection : RtmpConnection
    {
        private static ILog log = LogManager.GetLogger(typeof(RtmpServerConnection));

        RtmpServer _rtmpServer;
        ByteBuffer _readBuffer;
        RtmpNetworkStream _rtmpNetworkStream;
        DateTime _lastAction;
        volatile RtmpConnectionState _state;
        
        RtmptRequest _rtmptRequest;
        
        private long _readBytes;
        private long _writtenBytes;

        public RtmpServerConnection(RtmpServer rtmpServer, Socket socket)
            : base(rtmpServer.Endpoint, null, null)
		{
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
                    ArrayList result = RtmpProtocolDecoder.DecodeBuffer(this.Context, _readBuffer);
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
                if (!IsDisposed && !IsDisconnected)
                {
                    _state = RtmpConnectionState.Inactive;
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

        public override void Push(IMessage message, MessageClient messageClient)
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
    }
}
