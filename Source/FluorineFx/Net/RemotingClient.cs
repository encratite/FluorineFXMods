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
using FluorineFx;
using FluorineFx.IO;
using FluorineFx.AMF3;
using FluorineFx.Exceptions;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Rtmp.Event;

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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_gatewayUrl);
                request.ContentType = "application/x-amf";
                request.Method = "POST";

                AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);
                AMFBody amfBody = new AMFBody(command, callback.GetHashCode().ToString(), arguments);
                amfMessage.AddBody(amfBody);
                //Serialize
                Stream requestStream = request.GetRequestStream();
                AMFSerializer amfSerializer = new AMFSerializer(requestStream);
                amfSerializer.WriteMessage(amfMessage);
                amfSerializer.Flush();
                amfSerializer.Close();

                // Execute the request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Get response and deserialize
                Stream responseStream = response.GetResponseStream();
                AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
                AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
                AMFBody responseBody = responseMessage.GetBodyAt(0);

                PendingCall call = new PendingCall(command, arguments);
                call.Result = responseBody.Content;
                callback.ResultReceived(call);
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_gatewayUrl);
                request.ContentType = "application/x-amf";
                request.Method = "POST";

                AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);

                RemotingMessage remotingMessage = new RemotingMessage();
                remotingMessage.clientId = Guid.NewGuid().ToString("D");
                remotingMessage.destination = destination;
                remotingMessage.messageId = Guid.NewGuid().ToString("D");
                remotingMessage.timestamp = 0;
                remotingMessage.timeToLive = 0;
                remotingMessage.SetHeader(MessageBase.EndpointHeader, endpoint);
                if( _netConnection.ClientId == null )
                    remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, "nil");
                else
                    remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, _netConnection.ClientId);
                //Service stuff
                remotingMessage.source = source;
                remotingMessage.operation = operation;
                remotingMessage.body = arguments;

                AMFBody amfBody = new AMFBody(null, null, new object[] { remotingMessage });
                amfMessage.AddBody(amfBody);
                //Serialize
                Stream requestStream = request.GetRequestStream();
                AMFSerializer amfSerializer = new AMFSerializer(requestStream);
                amfSerializer.WriteMessage(amfMessage);
                amfSerializer.Flush();
                amfSerializer.Close();

                // Execute the request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Get response and deserialize
                Stream responseStream = response.GetResponseStream();
                AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
                AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
                AMFBody responseBody = responseMessage.GetBodyAt(0);
                object result = responseBody.Content;
                if (result is ErrorMessage)
                {
                    ASObject status = new ASObject();
                    status["level"] = "error";
                    status["code"] = "NetConnection.Call.Failed";
                    status["description"] = (result as ErrorMessage).faultString;
                    status["details"] = result;
                    _netConnection.RaiseNetStatus(status);
                }
                if (result is AcknowledgeMessage)
                {
                    AcknowledgeMessage ack = result as AcknowledgeMessage;
                    if (_netConnection.ClientId == null && ack.HeaderExists(MessageBase.FlexClientIdHeader))
                        _netConnection.SetClientId(ack.GetHeader(MessageBase.FlexClientIdHeader) as string);
                    PendingCall call = new PendingCall(source, operation, arguments);
                    call.Result = ack.body;
                    callback.ResultReceived(call);
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
}
