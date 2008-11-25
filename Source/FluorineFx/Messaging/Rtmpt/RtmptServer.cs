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
using System.Web;
using System.IO;
using log4net;
using FluorineFx.Util;
using FluorineFx.Collections;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Rtmp;
using FluorineFx.Context;

namespace FluorineFx.Messaging.Rtmpt
{
    sealed class RtmptServer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RtmptServer));
        
        /// <summary>
        /// Try to generate responses that contain at least 32768 bytes data.
        /// Increasing this value results in better stream performance, but also increases the latency.
        /// </summary>
	    private static int RESPONSE_TARGET_SIZE = 32768;

        SynchronizedHashtable _connections;
        RtmptEndpoint _endpoint;
        RtmpHandler _rtmpHandler;

        public RtmptServer(RtmptEndpoint endpoint)
        {
            _connections = new SynchronizedHashtable();
            _endpoint = endpoint;
            _rtmpHandler = new RtmpHandler(endpoint);
        }

        public IEndpoint Endpoint
        {
            get { return _endpoint; }
        }

        internal IRtmpHandler RtmpHandler
        {
            get { return _rtmpHandler; }
        }

        public void Service(HttpRequest request, HttpResponse response)
        {
            if (request.HttpMethod != "POST" || request.ContentLength == 0)
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_CommandBadRequest), response);

            string path = GetHttpRequestPath(request);
            char p = path[1];
            switch (p)
            {
                case 'o': // OPEN_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandOpen, path));
                    HandleOpen(request, response);
                    break;
                case 'c': // CLOSE_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandClose, path));
                    HandleClose(request, response);
                    break;
                case 's': // SEND_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandSend, path));
                    HandleSend(request, response);
                    break;
                case 'i': // IDLE_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandIdle, path));
                    HandleIdle(request, response);
                    break;
                default:
                    HandleBadRequest(__Res.GetString(__Res.Rtmpt_CommandNotSupported, path), response);
                    break;
            }
        }

        public void Service(RtmptRequest request)
        {
            if (request.HttpMethod != "POST" || request.ContentLength == 0)
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_CommandBadRequest), request);

            string path = request.Url;
            char p = path[1];
            switch (p)
            {
                case 'o': // OPEN_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandOpen, path));
                    HandleOpen(request);
                    break;
                case 'c': // CLOSE_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandClose, path));
                    HandleClose(request);
                    break;
                case 's': // SEND_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandSend, path));
                    HandleSend(request);
                    break;
                case 'i': // IDLE_REQUEST
                    if (log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_CommandIdle, path));
                    HandleIdle(request);
                    break;
                default:
                    HandleBadRequest(__Res.GetString(__Res.Rtmpt_CommandNotSupported, path), request);
                    break;
            }
        }

        internal void OnConnectionClose(RtmptConnection connection)
        {
            _connections.Remove(connection.ConnectionId);
        }

        private string GetHttpRequestPath(HttpRequest request)
        {
            string path = request.Path;
            if (request.Headers["RTMPT-command"] != null)
                path = request.Headers["RTMPT-command"];
            return path;
        }

        private string GetClientId(HttpRequest request)
        {
            string path = GetHttpRequestPath(request);
            if (path == string.Empty)
                return null;

            while (path.Length > 1 && path[0] == '/')
            {
                path = path.Substring(1);
            }

            int startPos = path.IndexOf('/');
            int endPos = path.IndexOf('/', startPos + 1);
            if (startPos != -1 && endPos != -1)
                path = path.Substring(startPos + 1, endPos - startPos - 1);
            return path;
        }

        private string GetClientId(RtmptRequest request)
        {
            string path = request.Url;
            if (path == string.Empty)
                return null;

            while (path.Length > 1 && path[0] == '/')
            {
                path = path.Substring(1);
            }

            int startPos = path.IndexOf('/');
            int endPos = path.IndexOf('/', startPos + 1);
            if (startPos != -1 && endPos != -1)
                path = path.Substring(startPos + 1, endPos - startPos - 1);
            return path;
        }


        private RtmptConnection GetConnection(HttpRequest request)
        {
            string id = GetClientId(request);
            return _connections[id] as RtmptConnection;
	    }

        private RtmptConnection GetConnection(RtmptRequest request)
        {
            string id = GetClientId(request);
            return _connections[id] as RtmptConnection;
        }

        private void HandleBadRequest(string message, HttpResponse response)
        {
            response.StatusCode = 400;
            response.ContentType = "text/plain";
            response.AppendHeader("Content-Length", message.Length.ToString());
            response.Write(message);
            response.Flush();
        }

        private void HandleBadRequest(string message, RtmptRequest request)
        {
            ByteBuffer buffer = ByteBuffer.Allocate(100);
            StreamWriter sw = new StreamWriter(buffer);
            if (request.HttpVersion == 1)
            {
                sw.Write("HTTP/1.1 400 " + message + "\r\n");
                sw.Write("Cache-Control: no-cache\r\n");
            }
            else
            {
                sw.Write("HTTP/1.0 400 " + message + "\r\n");
                sw.Write("Pragma: no-cache\r\n");
            }
            sw.Write("Content-Type: text/plain\r\n");
            sw.Write("Content-Length: " + message.Length.ToString() + "\r\n");
            sw.Write("Connection: Keep-Alive\r\n");
            sw.Write("\r\n");
            sw.Write(message);
            sw.Flush();
            request.Connection.Send(buffer);
        }


        private void HandleIdle(HttpRequest request, HttpResponse response)
        {
            RtmptConnection connection = GetConnection(request);
            if (connection == null)
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, GetHttpRequestPath(request)), response);
                return;
            }
            else if (connection.IsClosing)
            {
                // Tell client to close the connection
                ReturnMessage((byte)0, response);
                connection.DeferredClose();
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            ReturnPendingMessages(connection, response);
        }

        private void HandleIdle(RtmptRequest request)
        {
            RtmptConnection connection = GetConnection(request);
            if (connection == null)
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, request.Url), request);
                return;
            }
            else if (connection.IsClosing)
            {
                // Tell client to close the connection
                ReturnMessage((byte)0, request);
                connection.DeferredClose();
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            ReturnPendingMessages(connection, request);
        }

        private void HandleSend(HttpRequest request, HttpResponse response)
        {
            RtmptConnection connection = GetConnection(request);
            if (connection == null)
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, GetHttpRequestPath(request)), response);
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            int length = request.ContentLength;
            byte[] data = new byte[request.InputStream.Length];
            request.InputStream.Read(data, 0, (int)request.InputStream.Length);
            ByteBuffer buffer = ByteBuffer.Wrap(data);
            IList messages = connection.Decode(buffer);
            if (messages == null || messages.Count == 0)
            {
                ReturnMessage(connection.PollingDelay, response);
                return;
            }
		    // Execute the received RTMP messages
            foreach (object message in messages)
            {
                try
                {
                    if (message is ByteBuffer)
                    {
                        ByteBuffer buf = message as ByteBuffer;
                        connection.RawWrite(buf);
                    }
                    else
                    {
                        FluorineWebContext webContext = FluorineContext.Current as FluorineWebContext;
                        webContext.SetConnection(connection);
                        webContext.SetCurrentClient(connection.Client);
                        _rtmpHandler.MessageReceived(connection, message);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(__Res.GetString(__Res.Rtmp_CouldNotProcessMessage), ex);
                }
            }
		    // Send results to client
            ReturnPendingMessages(connection, response);
        }

        private void HandleSend(RtmptRequest request)
        {
            RtmptConnection connection = GetConnection(request);
            if (connection == null)
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, request.Url), request);
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            int length = request.ContentLength;
            ByteBuffer buffer = request.Data;
            IList messages = connection.Decode(buffer);
            if (messages == null || messages.Count == 0)
            {
                ReturnMessage(connection.PollingDelay, request);
                return;
            }
            // Execute the received RTMP messages
            foreach (object message in messages)
            {
                try
                {
                    if (message is ByteBuffer)
                    {
                        ByteBuffer buf = message as ByteBuffer;
                        connection.RawWrite(buf);
                    }
                    else
                    {
                        FluorineRtmpContext.Initialize(connection);
                        _rtmpHandler.MessageReceived(connection, message);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(__Res.GetString(__Res.Rtmp_CouldNotProcessMessage), ex);
                }
            }
            // Send results to client
            ReturnPendingMessages(connection, request);
        }

        private void HandleClose(HttpRequest request, HttpResponse response)
        {
            RtmptConnection connection = GetConnection(request);
            if( connection == null )
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, GetHttpRequestPath(request)), response);
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            connection.DeferredClose();
            ReturnMessage((byte)0, response);
        }

        private void HandleClose(RtmptRequest request)
        {
            RtmptConnection connection = GetConnection(request);
            if (connection == null)
            {
                HandleBadRequest(__Res.GetString(__Res.Rtmpt_UnknownClient, request.Url), request);
                return;
            }
            if (connection.Client != null)
                connection.Client.Renew();
            connection.DeferredClose();
            ReturnMessage((byte)0, request);
        }

        private void HandleOpen(HttpRequest request, HttpResponse response)
        {
            RtmptConnection connection = new RtmptConnection(this, null, null);
            _connections[connection.ConnectionId] = connection;
            // Return connection id to client
            ReturnMessage(connection.ConnectionId + "\n", response);
        }
        
        private void HandleOpen(RtmptRequest request)
        {
            RtmptConnection connection = new RtmptConnection(request.Connection.RemoteEndPoint, this, null, null);
            _connections[connection.ConnectionId] = connection;
            // Return connection id to client
            ReturnMessage(connection.ConnectionId + "\n", request);
        }

        private void ReturnMessage(string message, HttpResponse response)
        {
            response.StatusCode = 200;
            response.ClearHeaders();
            response.AppendHeader("Connection", "Keep-Alive");
            response.AppendHeader("Content-Length", message.Length.ToString());
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = ContentType.RTMPT;
            response.Write(message);
            response.Flush();
        }

        private void ReturnMessage(string message, RtmptRequest request)
        {
            ByteBuffer buffer = ByteBuffer.Allocate(100);
            StreamWriter sw = new StreamWriter(buffer);
            if (request.HttpVersion == 1)
            {
                sw.Write("HTTP/1.1 200 OK\r\n");
                sw.Write("Cache-Control: no-cache\r\n");
            }
            else
            {
                sw.Write("HTTP/1.0 200 OK\r\n");
                sw.Write("Pragma: no-cache\r\n");
            }
            sw.Write("Content-Length: " + message.Length.ToString() + "\r\n");
            sw.Write(string.Format("Content-Type: {0}\r\n", ContentType.RTMPT));
            sw.Write("Connection: Keep-Alive\r\n");
            sw.Write("\r\n");
            sw.Write(message);
            sw.Flush();
            request.Connection.Send(buffer);
        }

        private void ReturnMessage(byte message, HttpResponse response)
        {
            response.StatusCode = 200;
            response.ClearHeaders();
            response.AppendHeader("Connection", "Keep-Alive");
            response.AppendHeader("Content-Length", "1");
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = ContentType.RTMPT;
            response.Write((char)message);
            response.Flush();
        }

        private void ReturnMessage(byte message, RtmptRequest request)
        {
            ByteBuffer buffer = ByteBuffer.Allocate(100);
            StreamWriter sw = new StreamWriter(buffer);
            if (request.HttpVersion == 1)
            {
                sw.Write("HTTP/1.1 200 OK\r\n");
                sw.Write("Cache-Control: no-cache\r\n");
            }
            else
            {
                sw.Write("HTTP/1.0 200 OK\r\n");
                sw.Write("Pragma: no-cache\r\n");
            }
            sw.Write("Content-Length: 1\r\n");
            sw.Write("Connection: Keep-Alive\r\n");
            sw.Write(string.Format("Content-Type: {0}\r\n", ContentType.RTMPT));
            sw.Write("\r\n");
            sw.Write((char)message);
            sw.Flush();
            request.Connection.Send(buffer);
        }

        private void ReturnMessage(RtmptConnection connection, ByteBuffer data, HttpResponse response)
        {
            response.StatusCode = 200;
            response.ClearHeaders();
            response.AppendHeader("Connection", "Keep-Alive");
            int contentLength = data.Limit + 1;
            response.AppendHeader("Content-Length", contentLength.ToString());
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = ContentType.RTMPT;
            response.Write((char)connection.PollingDelay);
            byte[] buffer = data.ToArray();
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.Flush();            
        }

        private void ReturnMessage(RtmptConnection connection, ByteBuffer data, RtmptRequest request)
        {
            ByteBuffer buffer = ByteBuffer.Allocate((int)data.Length + 30);
            StreamWriter sw = new StreamWriter(buffer);
            int contentLength = data.Limit + 1;
            if (request.HttpVersion == 1)
            {
                sw.Write("HTTP/1.1 200 OK\r\n");
                sw.Write("Cache-Control: no-cache\r\n");
            }
            else
            {
                sw.Write("HTTP/1.0 200 OK\r\n");
                sw.Write("Pragma: no-cache\r\n");
            }
            sw.Write(string.Format("Content-Length: {0}\r\n", contentLength));
            sw.Write("Connection: Keep-Alive\r\n");
            sw.Write(string.Format("Content-Type: {0}\r\n", ContentType.RTMPT));
            sw.Write("\r\n");
            sw.Write((char)connection.PollingDelay);
            sw.Flush();
            BinaryWriter bw = new BinaryWriter(buffer);
            byte[] buf = data.ToArray();
            bw.Write(buf);
            bw.Flush();
            request.Connection.Send(buffer);
        }

        private void ReturnPendingMessages(RtmptConnection connection, HttpResponse response)
        {
            ByteBuffer data = connection.GetPendingMessages(RESPONSE_TARGET_SIZE);
		    if (data == null) 
            {
			    // no more messages to send...
                if (connection.IsClosing)
                {
                    // Tell client to close connection
                    ReturnMessage((byte)0, response);
                }
                else
                    ReturnMessage(connection.PollingDelay, response);
			    return;
		    }
		    ReturnMessage(connection, data, response);
	    }

        private void ReturnPendingMessages(RtmptConnection connection, RtmptRequest request)
        {
            ByteBuffer data = connection.GetPendingMessages(RESPONSE_TARGET_SIZE);
            if (data == null)
            {
                // no more messages to send...
                if (connection.IsClosing)
                {
                    // Tell client to close connection
                    ReturnMessage((byte)0, request);
                }
                else
                    ReturnMessage(connection.PollingDelay, request);
                return;
            }
            ReturnMessage(connection, data, request);
        }
    }
}
