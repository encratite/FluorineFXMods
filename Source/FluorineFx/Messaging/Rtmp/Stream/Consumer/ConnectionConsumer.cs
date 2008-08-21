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
using System.IO;
using log4net;
using FluorineFx.Util;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Messaging;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Stream;
using FluorineFx.Messaging.Rtmp.Stream.Messages;
using FluorineFx.Messaging.Rtmp.IO;
using FluorineFx.Messaging.Messages;

namespace FluorineFx.Messaging.Rtmp.Stream.Consumer
{
    /// <summary>
    /// RTMP connection consumer.
    /// </summary>
    class ConnectionConsumer : IPushableConsumer, IPipeConnectionListener
    {
        private static ILog log = LogManager.GetLogger(typeof(ConnectionConsumer));

        /// <summary>
        /// Connection object.
        /// </summary>
        private RtmpConnection _connection;
        /// <summary>
        /// Video channel.
        /// </summary>
        private RtmpChannel _video;
        /// <summary>
        /// Audio channel.
        /// </summary>
        private RtmpChannel _audio;
        /// <summary>
        /// Data channel.
        /// </summary>
        private RtmpChannel _data;
        /// <summary>
        /// Chunk size. Packets are sent chunk-by-chunk.
        /// </summary>
        private int _chunkSize = -1;
        /// <summary>
        /// Stream tracker.
        /// </summary>
        private StreamTracker _streamTracker;

        public ConnectionConsumer(RtmpConnection connection, int videoChannel, int audioChannel, int dataChannel)
        {
            _connection = connection;
            _video = connection.GetChannel(videoChannel);
            _audio = connection.GetChannel(audioChannel);
            _data = connection.GetChannel(dataChannel);
            _streamTracker = new StreamTracker();
        }


        #region IPushableConsumer Members

        public void PushMessage(IPipe pipe, IMessage message)
        {
		    if (message is ResetMessage) 
            {
			    _streamTracker.Reset();
            } 
            else if (message is StatusMessage) 
            {
			    StatusMessage statusMsg = message as StatusMessage;
			    _data.SendStatus(statusMsg.body as StatusASO);
		    }
            else if (message is RtmpMessage)
            {
                FluorineFx.Messaging.Rtmp.Stream.Messages.RtmpMessage rtmpMsg = message as FluorineFx.Messaging.Rtmp.Stream.Messages.RtmpMessage;
                IRtmpEvent msg = rtmpMsg.body;
                RtmpHeader header = new RtmpHeader();
                int timestamp = _streamTracker.Add(msg);
                if (timestamp < 0)
                {
                    log.Warn("Skipping message with negative timestamp.");
                    return;
                }
                header.IsTimerRelative = _streamTracker.IsRelative;
                header.Timer = timestamp;

                switch (msg.DataType)
                {
                    case Constants.TypeStreamMetadata:
                        Notify notify = new Notify((msg as Notify).Data);
                        notify.Header = header;
                        notify.Timestamp = header.Timer;
                        _data.Write(notify);
                        break;
                    case Constants.TypeFlexStreamEnd:
                        // TODO: okay to send this also to AMF0 clients?
                        FlexStreamSend send = new FlexStreamSend((msg as Notify).Data);
                        send.Header = header;
                        send.Timestamp = header.Timer;
                        _data.Write(send);
                        break;
                    case Constants.TypeVideoData:
                        VideoData videoData = new VideoData((msg as VideoData).Data);
                        videoData.Header = header;
                        videoData.Timestamp = header.Timer;
                        _video.Write(videoData);
                        break;
                    case Constants.TypeAudioData:
                        AudioData audioData = new AudioData((msg as AudioData).Data);
                        audioData.Header = header;
                        audioData.Timestamp = header.Timer;
                        _audio.Write(audioData);
                        break;
                    case Constants.TypePing:
                        Ping ping = new Ping((msg as Ping).Value1, (msg as Ping).Value2, (msg as Ping).Value3, (msg as Ping).Value4);
                        header.IsTimerRelative = false;
                        header.Timer = 0;
                        ping.Header = header;
                        ping.Timestamp = header.Timer;
                        _connection.Ping(ping);
                        break;
                    case Constants.TypeBytesRead:
                        BytesRead bytesRead = new BytesRead((msg as BytesRead).Bytes);
                        header.IsTimerRelative = false;
                        header.Timer = 0;
                        bytesRead.Header = header;
                        bytesRead.Timestamp = header.Timer;
                        _connection.GetChannel((byte)2).Write(bytesRead);
                        break;
                    default:
                        _data.Write(msg);
                        break;
                }
            }
        }

        #endregion

        #region IMessageComponent Members

        public void OnOOBControlMessage(IMessageComponent source, IPipe pipe, OOBControlMessage oobCtrlMsg)
        {
            if (!"ConnectionConsumer".Equals(oobCtrlMsg.Target))
                return;

            if ("pendingCount".Equals(oobCtrlMsg.ServiceName))
            {
                oobCtrlMsg.Result = _connection.PendingMessages;
            }
            else if ("pendingVideoCount".Equals(oobCtrlMsg.ServiceName))
            {
                IClientStream stream = _connection.GetStreamByChannelId(_video.ChannelId);
                if (stream != null)
                {
                    oobCtrlMsg.Result = _connection.GetPendingVideoMessages(stream.StreamId);
                }
                else
                {
                    oobCtrlMsg.Result = (long)0;
                }
            }
            else if ("writeDelta".Equals(oobCtrlMsg.ServiceName))
            {
                long maxStream = 0;
                IBWControllable bwControllable = _connection;
                // Search FC containing valid BWC
                while (bwControllable != null && bwControllable.BandwidthConfiguration == null)
                {
                    bwControllable = bwControllable.GetParentBWControllable();
                }
                if (bwControllable != null && bwControllable.BandwidthConfiguration != null)
                {
                    IBandwidthConfigure bwc = bwControllable.BandwidthConfiguration;
                    if (bwc is IConnectionBWConfig)
                    {
                        maxStream = (bwc as IConnectionBWConfig).DownstreamBandwidth / 8;
                    }
                }
                if (maxStream <= 0)
                {
                    // Use default value
                    // TODO: this should be configured somewhere and sent to the client when connecting
                    maxStream = 120 * 1024;
                }
                // Return the current delta between sent bytes and bytes the client
                // reported to have received, and the interval the client should use
                // for generating BytesRead messages (half of the allowed bandwidth).
                oobCtrlMsg.Result = new long[] { _connection.WrittenBytes - _connection.ClientBytesRead, maxStream / 2 };
            }
            else if ("chunkSize".Equals(oobCtrlMsg.ServiceName))
            {
                int newSize = (int)oobCtrlMsg.ServiceParameterMap["chunkSize"];
                if (newSize != _chunkSize)
                {
                    _chunkSize = newSize;
                    ChunkSize chunkSizeMsg = new ChunkSize(_chunkSize);
                    _connection.GetChannel((byte)2).Write(chunkSizeMsg);
                }
            }
        }

        #endregion

        #region IPipeConnectionListener Members

        public void OnPipeConnectionEvent(PipeConnectionEvent evt)
        {
            switch (evt.Type)
            {
                case PipeConnectionEvent.PROVIDER_DISCONNECT:
                    // XXX should put the channel release code in ConsumerService
                    _connection.CloseChannel(_video.ChannelId);
                    _connection.CloseChannel(_audio.ChannelId);
                    _connection.CloseChannel(_data.ChannelId);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
