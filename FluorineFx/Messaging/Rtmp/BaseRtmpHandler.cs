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
using log4net;
using FluorineFx.Context;
using FluorineFx.Util;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.SO;
using FluorineFx.Messaging.Rtmp.Stream;
using FluorineFx.Scheduling;

namespace FluorineFx.Messaging.Rtmp
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    [CLSCompliant(false)]
    public abstract class BaseRtmpHandler : IRtmpHandler
    {
        /// <summary>
        /// Connection Action constant.
        /// </summary>
        public const string ACTION_CONNECT = "connect";
        /// <summary>
        /// Disconnect Action constant.
        /// </summary>
        public const string ACTION_DISCONNECT = "disconnect";
        /// <summary>
        /// CreateStream Action constant.
        /// </summary>
        public const string ACTION_CREATE_STREAM = "createStream";
        /// <summary>
        /// DeleteStream Action constant.
        /// </summary>
        public const string ACTION_DELETE_STREAM = "deleteStream";
        /// <summary>
        /// CloseStream Action constant.
        /// </summary>
        public const string ACTION_CLOSE_STREAM = "closeStream";
        /// <summary>
        /// ReleaseStream Action constant.
        /// </summary>
        public const string ACTION_RELEASE_STREAM = "releaseStream";
        /// <summary>
        /// Publish Action constant.
        /// </summary>
        public const string ACTION_PUBLISH = "publish";
        /// <summary>
        /// Pause Action constant.
        /// </summary>
        public const string ACTION_PAUSE = "pause";
        /// <summary>
        /// Seek Action constant.
        /// </summary>
        public const string ACTION_SEEK = "seek";
        /// <summary>
        /// Play Action constant.
        /// </summary>
        public const string ACTION_PLAY = "play";
        /// <summary>
        /// Stop Action constant.
        /// </summary>
        public const string ACTION_STOP = "disconnect";
        /// <summary>
        /// ReceiveVideo Action constant.
        /// </summary>
        public const string ACTION_RECEIVE_VIDEO = "receiveVideo";
        /// <summary>
        /// ReceiveAudio Action constant.
        /// </summary>
        public const string ACTION_RECEIVE_AUDIO = "receiveAudio";

        private static readonly ILog log = LogManager.GetLogger(typeof(BaseRtmpHandler));

        IEndpoint _endpoint;

        /// <summary>
        /// Initializes a new instance of the ClientRejectedExBaseRtmpHandlerception class.
        /// </summary>
        /// <param name="endpoint">Endpoint object.</param>
        public BaseRtmpHandler(IEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        internal IEndpoint Endpoint
        {
            get { return _endpoint; }
        }

        protected static string GetHostname(string url)
        {
            string[] parts = url.Split(new char[] { '/' });
            if (parts.Length == 2)
                return "";
            else
                return parts[2];
        }

        #region IRtmpHandler Members

        /// <summary>
        /// Connection open event.
        /// </summary>
        /// <param name="connection">Connection object.</param>
        public virtual void ConnectionOpened(RtmpConnection connection)
        {
            if (connection.Context.Mode == RtmpMode.Server)
            {
                FluorineRtmpContext.Initialize(connection);
                ISchedulingService schedulingService = _endpoint.GetMessageBroker().GlobalScope.GetService(typeof(ISchedulingService)) as ISchedulingService;
                connection.StartWaitForHandshake(schedulingService);
            }
        }
        /// <summary>
        /// Message recieved.
        /// </summary>
        /// <param name="connection">Connection object.</param>
        /// <param name="message">Message object.</param>
        public void MessageReceived(RtmpConnection connection, object obj)
        {
            IRtmpEvent message = null;
            try
            {
                RtmpPacket packet = obj as RtmpPacket;
                message = packet.Message;
                RtmpHeader header = packet.Header;
                RtmpChannel channel = connection.GetChannel(header.ChannelId);
                IClientStream stream = connection.GetStreamById(header.StreamId);

                // Support stream ids
                FluorineContext.Current.Connection.SetAttribute(FluorineContext.FluorineStreamIdKey, header.StreamId);

                // Increase number of received messages
                connection.MessageReceived();

                if (log != null && log.IsDebugEnabled)
                    log.Debug("RtmpConnection message received, type = " + header.DataType);

                if (message != null)
                    message.Source = connection;

                switch (header.DataType)
                {
                    case Constants.TypeInvoke:
                        OnInvoke(connection, channel, header, message as Invoke);
                        if (message.Header.StreamId != 0
                            && (message as Invoke).ServiceCall.ServiceName == null
                            && (message as Invoke).ServiceCall.ServiceMethodName == RtmpHandler.ACTION_PUBLISH)
                        {
                            if (stream != null) //Dispatch if stream was created
                                (stream as IEventDispatcher).DispatchEvent(message);
                        }
                        break;
                    case Constants.TypeFlexInvoke:
                        OnFlexInvoke(connection, channel, header, message as FlexInvoke);
                        if (message.Header.StreamId != 0
                            && (message as Invoke).ServiceCall.ServiceName == null
                            && (message as Invoke).ServiceCall.ServiceMethodName == RtmpHandler.ACTION_PUBLISH)
                        {
                            if (stream != null) //Dispatch if stream was created
                                (stream as IEventDispatcher).DispatchEvent(message);
                        }
                        break;
                    case Constants.TypeNotify:// just like invoke, but does not return
                        if ((message as Notify).Data != null && stream != null)
                        {
                            // Stream metadata
                            (stream as IEventDispatcher).DispatchEvent(message);
                        }
                        else
                            OnInvoke(connection, channel, header, message as Notify);
                        break;
                    case Constants.TypePing:
                        OnPing(connection, channel, header, message as Ping);
                        break;
                    case Constants.TypeBytesRead:
                        OnStreamBytesRead(connection, channel, header, message as BytesRead);
                        break;
                    case Constants.TypeSharedObject:
                    case Constants.TypeFlexSharedObject:
                        OnSharedObject(connection, channel, header, message as SharedObjectMessage);
                        break;
                    case Constants.TypeFlexStreamEnd:
                        if (stream != null)
                            (stream as IEventDispatcher).DispatchEvent(message);
                        break;
                    case Constants.TypeChunkSize:
                        OnChunkSize(connection, channel, header, message as ChunkSize);
                        break;
                    case Constants.TypeAudioData:
                    case Constants.TypeVideoData:
                        // NOTE: If we respond to "publish" with "NetStream.Publish.BadName",
                        // the client sends a few stream packets before stopping. We need to
                        // ignore them.
                        if (stream != null)
                            ((IEventDispatcher)stream).DispatchEvent(message);
                        break;
                    case Constants.TypeServerBandwidth:
                        OnServerBW(connection, channel, header, message as ServerBW);
                        break;
                    case Constants.TypeClientBandwidth:
                        OnClientBW(connection, channel, header, message as ClientBW);
                        break;
                    default:
                        if (log != null && log.IsDebugEnabled)
                            log.Debug("RtmpService event not handled: " + header.DataType);
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("Runtime error", ex);
            }
        }
        /// <summary>
        /// Message sent.
        /// </summary>
        /// <param name="connection">Connection object.</param>
        /// <param name="message">Message object.</param>
        public void MessageSent(RtmpConnection connection, object message)
        {
    		if (message is ByteBuffer)
			    return;

		    // Increase number of sent messages
		    connection.MessageSent(message as RtmpPacket);
		    RtmpPacket sent = message as RtmpPacket;
		    int channelId = sent.Header.ChannelId;
		    IClientStream stream = connection.GetStreamByChannelId(channelId);
		    // XXX we'd better use new event model for notification
		    if (stream != null && (stream is PlaylistSubscriberStream)) 
            {
                (stream as PlaylistSubscriberStream).Written(sent.Message);
		    }
        }
        /// <summary>
        /// Connection closed.
        /// </summary>
        /// <param name="connection">Connection object.</param>
        public virtual void ConnectionClosed(RtmpConnection connection)
        {
            FluorineRtmpContext.Initialize(connection);
            connection.Close();
        }

        #endregion

        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="source"></param>
        /// <param name="streamBytesRead"></param>
        protected void OnStreamBytesRead(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, BytesRead streamBytesRead)
        {
            connection.ReceivedBytesRead(streamBytesRead.Bytes);
        }
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        protected abstract void OnChunkSize(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ChunkSize chunkSize);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="source"></param>
        /// <param name="ping"></param>
        protected abstract void OnPing(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, Ping ping);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="header"></param>
        /// <param name="invoke"></param>
        protected abstract void OnInvoke(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, Notify invoke);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="header"></param>
        /// <param name="message"></param>
        protected abstract void OnSharedObject(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, SharedObjectMessage message);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="header"></param>
        /// <param name="invoke"></param>
        protected abstract void OnFlexInvoke(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, FlexInvoke invoke);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="source"></param>
        /// <param name="serverBW"></param>
        protected abstract void OnServerBW(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ServerBW serverBW);
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="channel"></param>
        /// <param name="source"></param>
        /// <param name="clientBW"></param>
        protected abstract void OnClientBW(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ClientBW clientBW);

        /// <summary>
        /// Handler for pending call result. Dispatches results to all pending call handlers.
        /// </summary>
        /// <param name="connection">Connection.</param>
        /// <param name="invoke">Pending call result event context.</param>
        protected void HandlePendingCallResult(RtmpConnection connection, Notify invoke)
        {
            IServiceCall call = invoke.ServiceCall;
            IPendingServiceCall pendingCall = connection.GetPendingCall(invoke.InvokeId);
            if (pendingCall != null)
            {
                // The client sent a response to a previously made call.
                object[] args = call.Arguments;
                if ((args != null) && (args.Length > 0))
                {
                    pendingCall.Result = args[0];
                }

                IPendingServiceCallback[] callbacks = pendingCall.GetCallbacks();
                if (callbacks != null && callbacks.Length > 0)
                {
                    foreach (IPendingServiceCallback callback in callbacks)
                    {
                        try
                        {
                            callback.ResultReceived(pendingCall);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error while executing callback " + callback, ex);
                        }
                    }
                }
            }
        }
    }
}
