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
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using log4net;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Messaging;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api.Statistics;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Rtmp.Messaging;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Stream;
using FluorineFx.Messaging.Rtmp.Stream.Codec;
using FluorineFx.Messaging.Rtmp.Stream.Consumer;
using FluorineFx.Messaging.Rtmp.Stream.Messages;
using FluorineFx.Messaging.Messages;
using FluorineFx.Collections;

namespace FluorineFx.Messaging.Rtmp.Stream
{
    /// <summary>
    /// An implementation of IBroadcastStream that allows connection-less providers to publish a stream.
    /// </summary>
    [CLSCompliant(false)]
    public class BroadcastStream : IBroadcastStream, IProvider, IPipeConnectionListener, IEventDispatcher
    {
        private static ILog log = LogManager.GetLogger(typeof(BroadcastStream));

        object _syncLock = new object();
        private string _publishedName;
        private IPipe _livePipe;
        private IScope _scope;
        // Codec handling stuff for frame dropping
        private StreamCodecInfo _codecInfo;
        private VideoCodecFactory _videoCodecFactory;
        private bool _createVideoCodecInfo;

        /// <summary>
        /// Listeners to get notified about received packets.
        /// Set(IStreamListener)
        /// </summary>
        private CopyOnWriteArraySet _listeners = new CopyOnWriteArraySet();

        public BroadcastStream(string name, IScope scope)
        {
            _publishedName = name;
            _scope = scope;
            _livePipe = null;
            // We want to create a video codec when we get our first video packet.
            _createVideoCodecInfo = false;
            _codecInfo = new StreamCodecInfo();
            _videoCodecFactory = null;
        }

        #region IBroadcastStream Members

        public void SaveAs(string filePath, bool isAppend)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string SaveFilename
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string PublishedName
        {
            get
            {
                return _publishedName;
            }
            set
            {
                _publishedName = value;
            }
        }

        public IProvider Provider
        {
            get { return this; }
        }
        /// <summary>
        /// Add a listener to be notified about received packets.
        /// </summary>
        /// <param name="listener">The listener to add.</param>
        public void AddStreamListener(IStreamListener listener)
        {
            _listeners.Add(listener);
        }
        /// <summary>
        /// Return registered stream listeners.
        /// </summary>
        /// <returns>The registered listeners.</returns>
        public ICollection GetStreamListeners()
        {
            return _listeners;
        }
        /// <summary>
        /// Remove a listener from being notified about received packets.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void RemoveStreamListener(IStreamListener listener)
        {
            _listeners.Remove(listener);
        }

        #endregion

        #region IStream Members

        public string Name
        {
            get { return _publishedName; }
        }

        public IScope Scope
        {
            get { return _scope; }
        }

        public void Start()
        {
            try
            {
                _videoCodecFactory = this.Scope.GetService(typeof(VideoCodecFactory)) as VideoCodecFactory;
                _createVideoCodecInfo = true;
            }
            catch (Exception ex)
            {
                log.Warn("No video codec factory available.", ex);
            }
        }

        public void Stop()
        {
        }

        public void Close()
        {
        }

        public IStreamCodecInfo CodecInfo
        {
            get { return _codecInfo; }
        }

        public object SyncRoot
        {
            get { return _syncLock; }
        }

        #endregion

        #region IMessageComponent Members

        public void OnOOBControlMessage(IMessageComponent source, IPipe pipe, OOBControlMessage oobCtrlMsg)
        {
            //NA
        }

        #endregion

        #region IPipeConnectionListener Members

        public void OnPipeConnectionEvent(PipeConnectionEvent evt)
        {
            switch (evt.Type)
            {
                case PipeConnectionEvent.PROVIDER_CONNECT_PUSH:
                    if (evt.Provider == this && (evt.ParameterMap == null || !evt.ParameterMap.ContainsKey("record")))
                    {
                        _livePipe = evt.Source as IPipe;
                    }
                    break;
                case PipeConnectionEvent.PROVIDER_DISCONNECT:
                    if (_livePipe == evt.Source)
                    {
                        _livePipe = null;
                    }
                    break;
                case PipeConnectionEvent.CONSUMER_CONNECT_PUSH:
                    break;
                case PipeConnectionEvent.CONSUMER_DISCONNECT:
                    break;
                default:
                    break;
            }            
        }

        #endregion

        #region IEventDispatcher Members

        public void DispatchEvent(IEvent @event)
        {
            if (@event is IRtmpEvent)
            {
                IRtmpEvent rtmpEvent = @event as IRtmpEvent;
                if (_livePipe != null)
                {
                    RtmpMessage msg = new RtmpMessage();

                    msg.body = rtmpEvent;
                    try
                    {
                        if (@event is AudioData)
                        {
                            _codecInfo.HasAudio = true;
                        }
                        else if (@event is VideoData)
                        {
                            IVideoStreamCodec videoStreamCodec = null;
                            if (_videoCodecFactory != null && _createVideoCodecInfo)
                            {
                                videoStreamCodec = _videoCodecFactory.GetVideoCodec(((VideoData)@event).Data);
                                _codecInfo.VideoCodec = videoStreamCodec;
                                _createVideoCodecInfo = false;
                            }
                            else if (_codecInfo != null)
                            {
                                videoStreamCodec = _codecInfo.VideoCodec;
                            }

                            if (videoStreamCodec != null)
                            {
                                videoStreamCodec.AddData(((VideoData)rtmpEvent).Data);
                            }

                            if (_codecInfo != null)
                            {
                                _codecInfo.HasVideo = true;
                            }

                        }
                        _livePipe.PushMessage(msg);

                        // Notify listeners about received packet
                        if (rtmpEvent is IStreamPacket)
                        {
                            foreach (IStreamListener listener in GetStreamListeners())
                            {
                                try
                                {
                                    listener.PacketReceived(this, (IStreamPacket)rtmpEvent);
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Error while notifying listener " + listener, ex);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // ignore
                        log.Error("DispatchEvent failed", ex);
                    }
                }
            }
        }

        #endregion
    }
}
