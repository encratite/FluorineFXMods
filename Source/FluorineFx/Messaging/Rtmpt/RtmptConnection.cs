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
using FluorineFx.Util;
using FluorineFx.Collections;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Rtmp;
using FluorineFx.Messaging.Messages;

namespace FluorineFx.Messaging.Rtmpt
{
    class RtmptConnection : RtmpConnection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RtmptConnection));

        IPEndPoint _remoteEndPoint;
        RtmptServer _rtmptServer;
        
        /// <summary>
        /// Start to increase the polling delay after this many empty results
        /// </summary>
        protected static long INCREASE_POLLING_DELAY_COUNT = 10;
        /// <summary>
        /// Polling delay to start with.
        /// </summary>
        protected static byte INITIAL_POLLING_DELAY = 0;
        /// <summary>
        /// Maximum polling delay.
        /// </summary>
        protected static byte MAX_POLLING_DELAY = 32;
        /// <summary>
        /// Polling delay value
        /// </summary>
        protected byte _pollingDelay = INITIAL_POLLING_DELAY;
        /// <summary>
        /// Number of read bytes
        /// </summary>
        protected long _readBytes;
        /// <summary>
        /// Number of written bytes
        /// </summary>
        protected long _writtenBytes;
        /// <summary>
        /// Timeframe without pending messages. If this time is greater then polling delay, then polling delay increased
        /// </summary>
        protected long _noPendingMessages;

        protected ByteBuffer _buffer;
        /// <summary>
        /// List of pending messages
        /// </summary>
        protected LinkedList _pendingMessages = new LinkedList();
        /// <summary>
        /// List of notification messages
        /// </summary>
        protected LinkedList _notifyMessages = new LinkedList();


        static object[] EmptyList = new object[0];

        public RtmptConnection(RtmptServer rtmptServer, string path, Hashtable parameters)
            : base(path, parameters)
        {
            _rtmptServer = rtmptServer;
            IPAddress ipAddress = IPAddress.Parse(System.Web.HttpContext.Current.Request.UserHostAddress);
            _remoteEndPoint = new IPEndPoint(ipAddress, 80);
            _buffer = ByteBuffer.Allocate(2048);
            _readBytes = 0;
            _writtenBytes = 0;
        }

        public RtmptConnection(IPEndPoint ipEndPoint, RtmptServer rtmptServer, string path, Hashtable parameters)
            : base(path, parameters)
        {
            _rtmptServer = rtmptServer;
            _remoteEndPoint = ipEndPoint;
            _buffer = ByteBuffer.Allocate(2048);
            _readBytes = 0;
            _writtenBytes = 0;
        }

        public override IPEndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
        }

        public FluorineFx.Messaging.Endpoints.IEndpoint Endpoint { get { return _rtmptServer.Endpoint; } }

        public override long ReadBytes
        {
            get { return _readBytes; }
        }

        public override long WrittenBytes
        {
            get { return _writtenBytes; }
        }

        public byte PollingDelay
        {
            get
            {
                if( this.State == RtmpState.Disconnected)
                {
                    // Special value to notify client about a closed connection.
                    return (byte)0;
                }
                return (byte)(_pollingDelay + 1);
            }
        }

        public ByteBuffer GetPendingMessages(int targetSize)
        {
            if (_pendingMessages.Count == 0)
            {
                _noPendingMessages += 1;
                if (_noPendingMessages > INCREASE_POLLING_DELAY_COUNT)
                {
                    if (_pollingDelay == 0)
                        _pollingDelay = 1;
                    _pollingDelay = (byte)(_pollingDelay * 2);
                    if (_pollingDelay > MAX_POLLING_DELAY)
                        _pollingDelay = MAX_POLLING_DELAY;
                }
                return null;
            }
            ByteBuffer result = ByteBuffer.Allocate(2048);
            if (log.IsDebugEnabled)
                log.Debug(__Res.GetString(__Res.Rtmpt_ReturningMessages, _pendingMessages.Count));
            _noPendingMessages = 0;
            _pollingDelay = INITIAL_POLLING_DELAY;
            while (result.Limit < targetSize)
            {
                if (_pendingMessages.Count == 0)
                    break;
                lock (_pendingMessages.SyncRoot)
                {
                    foreach (ByteBuffer buffer in _pendingMessages)
                    {
                        result.Put(buffer);
                    }
                    _pendingMessages.Clear();
                }
                // We'll have to create a copy here to avoid endless recursion
                LinkedList toNotify = new LinkedList();
                lock (_notifyMessages.SyncRoot)
                {
                    toNotify.AddAll(_notifyMessages);
                    _notifyMessages.Clear();
                }
                foreach (object message in toNotify)
                {
                    try
                    {
                        _rtmptServer.RtmpHandler.MessageSent(this, message);
                    }
                    catch (Exception ex)
                    {
                        log.Error(__Res.GetString(__Res.Rtmpt_NotifyError), ex);
                        continue;
                    }
                }
            }
            result.Flip();
            _writtenBytes += result.Limit;
            return result;
        }

        public IList Decode(ByteBuffer data)
        {
            if (this.State == RtmpState.Disconnected)
                return EmptyList;
            _readBytes += data.Limit;
            _buffer.Put(data);
            _buffer.Flip();
            return RtmpProtocolDecoder.DecodeBuffer(this.Context, _buffer);
        }

        public override void Close()
        {
            lock (this.SyncRoot)
            {
                // Defer actual closing so we can send back pending messages to the client.
                SetIsClosing(true);
            }
        }

        public void DeferredClose()
        {
            lock (this.SyncRoot)
            {
                _notifyMessages.Clear();
                _pendingMessages.Clear();
                base.Close();
                _rtmptServer.OnConnectionClose(this);
            }
        }


        public override void Write(RtmpPacket packet)
        {
            if (this.State == RtmpState.Disconnected)
            {
                // Connection is being closed, don't send any new packets
                return;
            }
            // We need to synchronize to prevent two packages to the
            // same channel to be sent in different order thus resulting
            // in wrong headers being generated.
            lock (this.SyncRoot)
            {
                ByteBuffer data;
                try
                {
                    data = RtmpProtocolEncoder.Encode(this.Context, packet);
                }
                catch (Exception ex)
                {
                    log.Error("Could not encode message " + packet, ex);
                    return;
                }
                // Mark packet as being written
                WritingMessage(packet);
                // Enqueue encoded packet data to be sent to client
                RawWrite(data);
		        // Make sure stream subsystem will be notified about sent packet later
                lock (_notifyMessages.SyncRoot)
                {
                    _notifyMessages.Add(packet);
                }
            }
        }

        public void RawWrite(ByteBuffer packet)
        {
            lock (_pendingMessages.SyncRoot)
            {
                _pendingMessages.Add(packet);
            }
        }

        public override void Push(IMessage message, IMessageClient messageClient)
        {
            if (this.State == RtmpState.Disconnected)
            {
                // Connection is being closed, don't send any new packets
                return;
            }
            RtmpHandler.Push(this, message, messageClient);
            /*
            IMessage messageClone = message.Clone() as IMessage;
            messageClone.SetHeader(MessageBase.DestinationClientIdHeader, messageClient.ClientId);
            messageClone.clientId = messageClient.ClientId;
            messageClient.AddMessage(messageClone);
            */
        }

        protected override void OnInactive()
        {
            //this.Timeout();
            Close();
            DeferredClose();
        }

        public override int ClientLeaseTime
        {
            get
            {
                int timeout = this.Endpoint.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
                timeout = Math.Max(timeout, 1);//start with 1 minute timeout at least
                return timeout;
            }
        }

        public override string ToString()
        {
            return "RtmptConnection " + _connectionId;
        }
    }
}
