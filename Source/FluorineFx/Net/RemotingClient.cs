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
using System.IO;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using FluorineFx;
using FluorineFx.IO;
using FluorineFx.AMF3;
using FluorineFx.Exceptions;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.Service;

namespace FluorineFx.Net
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class RemotingClient : INetConnectionClient
    {
        string _gatewayUrl;
        NetConnection _netConnection;

        public RemotingClient(NetConnection netConnection)
        {
            _netConnection = netConnection;
        }

        #region INetConnectionClient Members

        public IConnection Connection
        {
            get { return null; }
        }

        public void Connect(string command, params object[] arguments)
        {
            _gatewayUrl = command;
        }

        public void Close()
        {
        }

        public bool Connected
        {
            get { return true; }
        }

        public void Call(string command, IPendingServiceCallback callback, params object[] arguments)
        {
            try
            {
                TypeHelper._Init();

                Uri uri = new Uri(_gatewayUrl);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.ContentType = "application/x-amf";
                request.Method = "POST";
#if !(SILVERLIGHT)
                request.CookieContainer = _netConnection.CookieContainer;
#endif
                AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);
                AMFBody amfBody = new AMFBody(command, callback.GetHashCode().ToString(), arguments);
                amfMessage.AddBody(amfBody);
#if !(NET_1_1)
                foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers)
                {
                    amfMessage.AddHeader(entry.Value);
                }
#else
                foreach (DictionaryEntry entry in _netConnection.Headers)
                {
                    amfMessage.AddHeader(entry.Value as AMFHeader);
                }
#endif
                PendingCall call = new PendingCall(command, arguments);
                RequestData requestData = new RequestData(request, amfMessage, call, callback);
                request.BeginGetRequestStream(new AsyncCallback(this.BeginRequestFlashCall), requestData);
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        private void BeginRequestFlashCall(IAsyncResult ar)
        {
            try
            {
                RequestData requestData = ar.AsyncState as RequestData;
                if (requestData != null)
                {
                    Stream requestStream = requestData.Request.EndGetRequestStream(ar);
                    AMFSerializer amfSerializer = new AMFSerializer(requestStream);
                    amfSerializer.WriteMessage(requestData.AmfMessage);
                    amfSerializer.Flush();
                    amfSerializer.Close();

                    requestData.Request.BeginGetResponse(new AsyncCallback(this.BeginResponseFlashCall), requestData);
                }
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        private void BeginResponseFlashCall(IAsyncResult ar)
        {
            try
            {
                RequestData requestData = ar.AsyncState as RequestData;
                if (requestData != null)
                {
                    HttpWebResponse response = (HttpWebResponse)requestData.Request.EndGetResponse(ar);
                    if (response != null)
                    {
                        //Get response and deserialize
                        Stream responseStream = response.GetResponseStream();
                        if (responseStream != null)
                        {
                            AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
                            AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
                            AMFBody responseBody = responseMessage.GetBodyAt(0);
                            for (int i = 0; i < responseMessage.HeaderCount; i++)
                            {
                                AMFHeader header = responseMessage.GetHeaderAt(i);
                                if (header.Name == AMFHeader.RequestPersistentHeader)
                                    _netConnection.AddHeader(header.Name, header.MustUnderstand, header.Content);
                            }
                            PendingCall call = requestData.Call;
                            call.Result = responseBody.Content;
                            if( responseBody.Target.EndsWith(AMFBody.OnStatus) )
                                call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION;
                            else
                                call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
                            requestData.Callback.ResultReceived(call);
                        }
                        else
                            _netConnection.RaiseNetStatus("Could not aquire ResponseStream");
                    }
                    else
                        _netConnection.RaiseNetStatus("Could not aquire HttpWebResponse");
                }
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        public void Call(string endpoint, string destination, string source, string operation, IPendingServiceCallback callback, params object[] arguments)
        {
            if (_netConnection.ObjectEncoding == ObjectEncoding.AMF0)
                throw new NotSupportedException("AMF0 not supported for Flex RPC");
            try
            {
                TypeHelper._Init();

                Uri uri = new Uri(_gatewayUrl);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.ContentType = "application/x-amf";
                request.Method = "POST";
#if !(SILVERLIGHT)
                request.CookieContainer = _netConnection.CookieContainer;
#endif
                AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);

                RemotingMessage remotingMessage = new RemotingMessage();
                remotingMessage.clientId = Guid.NewGuid().ToString("D");
                remotingMessage.destination = destination;
                remotingMessage.messageId = Guid.NewGuid().ToString("D");
                remotingMessage.timestamp = 0;
                remotingMessage.timeToLive = 0;
                remotingMessage.SetHeader(MessageBase.EndpointHeader, endpoint);
                if (_netConnection.ClientId == null)
                    remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, "nil");
                else
                    remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, _netConnection.ClientId);
                //Service stuff
                remotingMessage.source = source;
                remotingMessage.operation = operation;
                remotingMessage.body = arguments;

#if !(NET_1_1)
                foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers)
#else
                foreach (DictionaryEntry entry in _netConnection.Headers)
#endif
                {
                    amfMessage.AddHeader(entry.Value as AMFHeader);
                }
                AMFBody amfBody = new AMFBody(null, null, new object[] { remotingMessage });
                amfMessage.AddBody(amfBody);

                PendingCall call = new PendingCall(source, operation, arguments);
                RequestData requestData = new RequestData(request, amfMessage, call, callback);
                request.BeginGetRequestStream(new AsyncCallback(this.BeginRequestFlexCall), requestData);
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        private void BeginRequestFlexCall(IAsyncResult ar)
        {
            try
            {
                RequestData requestData = ar.AsyncState as RequestData;
                if (requestData != null)
                {
                    Stream requestStream = requestData.Request.EndGetRequestStream(ar);
                    AMFSerializer amfSerializer = new AMFSerializer(requestStream);
                    amfSerializer.WriteMessage(requestData.AmfMessage);
                    amfSerializer.Flush();
                    amfSerializer.Close();

                    requestData.Request.BeginGetResponse(new AsyncCallback(this.BeginResponseFlexCall), requestData);
                }
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        private void BeginResponseFlexCall(IAsyncResult ar)
        {
            try
            {
                RequestData requestData = ar.AsyncState as RequestData;
                if (requestData != null)
                {
                    HttpWebResponse response = (HttpWebResponse)requestData.Request.EndGetResponse(ar);
                    if (response != null)
                    {
                        //Get response and deserialize
                        Stream responseStream = response.GetResponseStream();
                        if (responseStream != null)
                        {
                            AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
                            AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
                            AMFBody responseBody = responseMessage.GetBodyAt(0);
                            for (int i = 0; i < responseMessage.HeaderCount; i++)
                            {
                                AMFHeader header = responseMessage.GetHeaderAt(i);
                                if (header.Name == AMFHeader.RequestPersistentHeader)
                                    _netConnection.AddHeader(header.Name, header.MustUnderstand, header.Content);
                            }
                            object result = responseBody.Content;
                            if (result is ErrorMessage)
                            {
                                /*
                                ASObject status = new ASObject();
                                status["level"] = "error";
                                status["code"] = "NetConnection.Call.Failed";
                                status["description"] = (result as ErrorMessage).faultString;
                                status["details"] = result;
                                _netConnection.RaiseNetStatus(status);
                                */
                                PendingCall call = requestData.Call;
                                call.Result = result;
                                call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION;
                                requestData.Callback.ResultReceived(call);
                            }
                            if (result is AcknowledgeMessage)
                            {
                                AcknowledgeMessage ack = result as AcknowledgeMessage;
                                if (_netConnection.ClientId == null && ack.HeaderExists(MessageBase.FlexClientIdHeader))
                                    _netConnection.SetClientId(ack.GetHeader(MessageBase.FlexClientIdHeader) as string);
                                PendingCall call = requestData.Call;
                                call.Result = ack.body;
                                call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
                                requestData.Callback.ResultReceived(call);
                            }
                        }
                        else
                            _netConnection.RaiseNetStatus("Could not aquire ResponseStream");
                    }
                    else
                        _netConnection.RaiseNetStatus("Could not aquire HttpWebResponse");
                }
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        public void Write(IRtmpEvent message)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    class RequestData
    {
        PendingCall _call;

        internal PendingCall Call
        {
            get { return _call; }
        }

        HttpWebRequest _request;

        public HttpWebRequest Request
        {
            get { return _request; }
        }

        AMFMessage _amfMessage;

        public AMFMessage AmfMessage
        {
            get { return _amfMessage; }
        }
        IPendingServiceCallback _callback;

        public IPendingServiceCallback Callback
        {
            get { return _callback; }
        }

        public RequestData(HttpWebRequest request, AMFMessage amfMessage, PendingCall call, IPendingServiceCallback callback)
        {
            _call = call;
            _request = request;
            _amfMessage = amfMessage;
            _callback = callback;
        }
    }
}
