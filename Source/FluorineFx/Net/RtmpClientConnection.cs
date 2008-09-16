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
using FluorineFx.Messaging.Rtmp;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Stream;
//using FluorineFx.Messaging.Rtmpt;
//using FluorineFx.Messaging.Endpoints;
using FluorineFx.Util;
using FluorineFx.Context;
using FluorineFx.Configuration;
using FluorineFx.Collections;
#if !SILVERLIGHT
using FluorineFx.Threading;
#endif

namespace FluorineFx.Net
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
                            bufferPool = new BufferPool(4096/*FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.ReceiveBufferSize*/);
                    }
                }
                return bufferPool;
            }
        }
    }
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class RtmpClientConnection : RtmpConnection
    {
#if !SILVERLIGHT
        private static ILog log = LogManager.GetLogger(typeof(RtmpClientConnection));
#endif
        IRtmpHandler _handler;
        ByteBuffer _readBuffer;
        RtmpNetworkStream _rtmpNetworkStream;
        DateTime _lastAction;
        volatile RtmpConnectionState _state;
        private long _readBytes;
        private long _writtenBytes;

        public RtmpClientConnection(IRtmpHandler handler, Socket socket)
            : base(null, null)
		{
#if NET_1_1
			try
			{
			    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.ReceiveBufferSize);
            }
			catch(SocketException ex)
			{
                log.Warn(__Res.GetString(__Res.SocketServer_SocketOptionFail, "ReceiveBuffer"), ex);
			}
			try
			{
			    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.SendBufferSize);
            }
			catch(SocketException ex)
			{
                log.Warn(__Res.GetString(__Res.SocketServer_SocketOptionFail, "SendBuffer"), ex);
			}
#else
#if FXCLIENT
            //TODO
            socket.ReceiveBufferSize = 4096;
            socket.SendBufferSize = 4096;
#else
            socket.ReceiveBufferSize = FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.ReceiveBufferSize;
            socket.SendBufferSize = FluorineConfiguration.Instance.FluorineSettings.RtmpServer.RtmpTransportSettings.SendBufferSize;
#endif
#endif
            _handler = handler;
            _readBuffer = ByteBuffer.Allocate(4096);
            _readBuffer.Flip();
            _rtmpNetworkStream = new RtmpNetworkStream(socket);
            _state = RtmpConnectionState.Active;
            this.Context.SetMode(RtmpMode.Client);
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

        public override bool IsConnected
        {
            get
            {
                return this.Context.State == RtmpState.Connected;
            }
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

        public void BeginHandshake()
        {
            //Handshake 1st phase
            ByteBuffer buffer = ByteBuffer.Allocate(RtmpProtocolDecoder.HandshakeSize + 1);
            buffer.Put((byte)0x03);
            /*
            buffer.Fill((byte)0x00, RtmpProtocolDecoder.HandshakeSize);
            buffer.Flip();
             */
            int tick = System.Environment.TickCount;
            buffer.Put(1, (byte)((tick >> 24) & 0xff));
            buffer.Put(2, (byte)((tick >> 16) & 0xff));
            buffer.Put(3, (byte)((tick >> 8) & 0xff));
            buffer.Put(4, (byte)(tick & 0xff));

            tick = tick % 256;
            for (int i = 8; i < 1536; i += 2)
            {
                tick = (0xB8CD75 * tick + 1) % 256;
                buffer.Put(i + 1, (byte)(tick & 0xff));
            }
            Send(buffer);
            BeginReceive(false);
        }

        #region Network IO
        public void BeginReceive(bool IOCPThread)
        {
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketBeginReceive, _connectionId, IOCPThread));
#endif
            if (!IOCPThread)
                ThreadPool.QueueUserWorkItem(new WaitCallback(BeginReceiveCallbackProcessing), null);
            else
                BeginReceiveCallbackProcessing(null);
        }

        public void BeginReceiveCallbackProcessing(object state)
        {
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketReceiveProcessing, _connectionId));
#endif
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
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketBeginRead, _connectionId));
#endif

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
#if !SILVERLIGHT
                        ThreadPoolEx.Global.QueueUserWorkItem(new WaitCallback(OnReceivedCallback), null);
#else
                        ThreadPool.QueueUserWorkItem(new WaitCallback(OnReceivedCallback), null);
#endif
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
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketReadProcessing, _connectionId));

            if (log.IsDebugEnabled)
                log.Debug("Begin handling packet " + this.ToString());
#endif

            try
            {
#if !(NET_1_1)
                List<object> result = RtmpProtocolDecoder.DecodeBuffer(this.Context, _readBuffer);
#else
                ArrayList result = RtmpProtocolDecoder.DecodeBuffer(this.Context, _readBuffer);
#endif
                if (Context.State == RtmpState.Handshake)
                {
                    ByteBuffer resultBuffer = result[0] as ByteBuffer;
                    //Handshake 3d phase
                    resultBuffer.Skip(1);
                    resultBuffer.Compact();
                    resultBuffer.Limit = RtmpProtocolDecoder.HandshakeSize;
                    ByteBuffer buffer = ByteBuffer.Allocate(RtmpProtocolDecoder.HandshakeSize);
                    buffer.Put(resultBuffer); 
                    Send(buffer);
                    Context.State = RtmpState.Connected;
                    _handler.ConnectionOpened(this);
                }
                else
                {
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
#if !SILVERLIGHT
                                FluorineRtmpContext.Initialize(this);
#endif
                                _handler.MessageReceived(this, obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug("End handling packet " + this.ToString());
#endif
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
#if !SILVERLIGHT
                if (log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Rtmp_SocketConnectionReset, _connectionId));
#endif
                error = false;
            }

#if !SILVERLIGHT
            if (error && log.IsErrorEnabled)
                log.Error("Error " + this.ToString(), exception);
#endif
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
#if !SILVERLIGHT
                    ThreadPoolEx.Global.QueueUserWorkItem(new WaitCallback(OnDisconnectCallback), null);
#else
                    ThreadPool.QueueUserWorkItem(new WaitCallback(OnDisconnectCallback), null);
#endif
                }
                catch (Exception ex)
                {
#if !SILVERLIGHT
                    if (log.IsErrorEnabled)
                        log.Error("BeginDisconnect " + this.ToString(), ex);
#endif
                }
            }
        }

        private void OnDisconnectCallback(object state)
        {
#if !SILVERLIGHT
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmp_SocketDisconnectProcessing, _connectionId));
#endif
            lock (this.SyncRoot)
            {
                try
                {
                    //_handler.ConnectionClosed(this);
                    Close();
                }
                catch (Exception ex)
                {
#if !SILVERLIGHT
                    if (log.IsErrorEnabled)
                        log.Error("OnDisconnectCallback " + this.ToString(), ex);
#endif
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
                    _state = RtmpConnectionState.Inactive;
                    base.Close();
                    _handler.ConnectionClosed(this);
                    _rtmpNetworkStream.Close();
                }
            }
        }

        public override void Write(RtmpPacket packet)
        {
            if (!IsDisposed && IsActive)
            {
#if !SILVERLIGHT
                if (log.IsDebugEnabled)
                    log.Debug("Write " + packet.Header);
#endif
                //encode
                WritingMessage(packet);
                ByteBuffer outputStream = RtmpProtocolEncoder.Encode(this.Context, packet);
                Send(outputStream);
                _handler.MessageSent(this, packet);
            }
        }

        public override void Push(IMessage message, IMessageClient messageClient)
        {
            if (IsActive)
            {
                BaseRtmpHandler.Push(this, message, messageClient);
            }
        }

        protected override void OnInactive()
        {
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

    }
}
