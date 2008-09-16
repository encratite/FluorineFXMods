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
using System.Reflection;
using System.Net;
using System.Net.Sockets;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !SILVERLIGHT
using log4net;
#endif
using FluorineFx.Configuration;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.SO;
using FluorineFx.Messaging.Rtmp;
using FluorineFx.Messaging.Rtmp.Service;
using FluorineFx.Util;
using FluorineFx.Invocation;
using FluorineFx.Exceptions;

namespace FluorineFx.Net
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    class RtmpClient : BaseRtmpHandler, INetConnectionClient, IPendingServiceCallback
    {
#if !SILVERLIGHT
        private static readonly ILog log = LogManager.GetLogger(typeof(RtmpClient));
#endif

        NetConnection _netConnection;
#if !(NET_1_1)
        Dictionary<string, object> _connectionParameters;
#else
        Hashtable _connectionParameters;
#endif

        RtmpClientConnection _connection;
        object[] _connectArguments;

        public RtmpClient(NetConnection netConnection)
            : base()
        {
            _netConnection = netConnection;
#if !(NET_1_1)
            _connectionParameters = new Dictionary<string,object>();
#else
            _connectionParameters = new Hashtable();
#endif
            //_connectionParams.Add("pageUrl", "");
            _connectionParameters.Add("objectEncoding", (double)_netConnection.ObjectEncoding);
            _connectionParameters.Add("capabilities", 15);
            _connectionParameters.Add("audioCodecs", (double)1639);
            _connectionParameters.Add("flashVer", _netConnection.PlayerVersion);
            //_connectionParams.Add("swfUrl", "");
            _connectionParameters.Add("videoFunction", (double)1);
            _connectionParameters.Add("fpad", false);
            _connectionParameters.Add("videoCodecs", (double)252);
        }

        public override void ConnectionOpened(RtmpConnection connection)
        {
            try
            {
                // Send "connect" call to the server
                RtmpChannel channel = connection.GetChannel((byte)3);
                PendingCall pendingCall = new PendingCall("connect", _connectArguments);
                Invoke invoke = new Invoke(pendingCall);
                invoke.ConnectionParameters = _connectionParameters;
                invoke.InvokeId = connection.InvokeId;
                pendingCall.RegisterCallback(this);
                connection.RegisterPendingCall(invoke.InvokeId, pendingCall);
                channel.Write(invoke);
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }

        public void Invoke(string method, IPendingServiceCallback callback)
        {
            _connection.Invoke(method, callback);
        }

        public void Invoke(string method, object[] parameters, IPendingServiceCallback callback)
        {
            _connection.Invoke(method, parameters, callback);
        }

        protected override void OnChunkSize(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ChunkSize chunkSize)
        {
            //ChunkSize is not implemented yet
        }

        protected override void OnPing(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, Ping ping)
        {
            switch (ping.Value1)
            {
                case 6:
                    // The server wants to measure the RTT
                    Ping pong = new Ping();
                    pong.Value1 = ((short)Ping.PongServer);
                    int now = (int)(System.Environment.TickCount & 0xffffffff);
                    pong.Value2 = now;
                    pong.Value3 = Ping.Undefined;
                    connection.Ping(pong);
                    break;
            }
        }

        protected override void OnServerBW(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ServerBW serverBW)
        {
        }

        protected override void OnClientBW(RtmpConnection connection, RtmpChannel channel, RtmpHeader source, ClientBW clientBW)
        {
            channel.Write(new ServerBW(clientBW.Bandwidth));
        }

        protected override void OnInvoke(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, Notify invoke)
        {
            IServiceCall call = invoke.ServiceCall;
            if (call.ServiceMethodName == "_result" || call.ServiceMethodName == "_error")
            {
                if (call.ServiceMethodName == "_error")
                    call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION;
                if (call.ServiceMethodName == "_result")
                    call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
                HandlePendingCallResult(connection, invoke);
                return;
            }

            if (call is IPendingServiceCall)
            {
                IPendingServiceCall psc = call as IPendingServiceCall;
                /*
                object result = psc.Result;
                object result = psc.Result;
                if (result is DeferredResult)
                {
                    DeferredResult dr = result as DeferredResult;
                    dr.InvokeId = invoke.InvokeId;
                    dr.ServiceCall = psc;
                    dr.Channel = channel;
                    connection.RegisterDeferredResult(dr);
                }
                else
                {
                    Invoke reply = new Invoke();
                    reply.ServiceCall = call;
                    reply.InvokeId = invoke.InvokeId;                    
                    channel.Write(reply);
                }
                */                
                MethodInfo mi = MethodHandler.GetMethod(_netConnection.Client.GetType(), call.ServiceMethodName, call.Arguments, false, false);
                if (mi != null)
                {
                    ParameterInfo[] parameterInfos = mi.GetParameters();
                    object[] args = new object[parameterInfos.Length];
                    call.Arguments.CopyTo(args, 0);
                    TypeHelper.NarrowValues(args, parameterInfos);
                    try
                    {
                        InvocationHandler invocationHandler = new InvocationHandler(mi);
                        object result = invocationHandler.Invoke(_netConnection.Client, args);
                        if (mi.ReturnType == typeof(void))
                            call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_VOID;
                        else
                        {
                            call.Status = result == null ? FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_NULL : FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
                            psc.Result = result;
                        }
                    }
                    catch (Exception exception)
                    {
                        call.Exception = exception;
                        call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION;
                        //log.Error("Error while invoking method " + call.ServiceMethodName + " on client", exception);
                    }
                }
                else
                {
                    string msg = __Res.GetString(__Res.Invocation_NoSuitableMethod, call.ServiceMethodName);
                    call.Status = FluorineFx.Messaging.Rtmp.Service.Call.STATUS_METHOD_NOT_FOUND;
                    call.Exception = new FluorineException(msg);
                    //log.Error(msg, call.Exception);
                }
                if (call.Status == FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_VOID || call.Status == FluorineFx.Messaging.Rtmp.Service.Call.STATUS_SUCCESS_NULL)
                {
#if !SILVERLIGHT
                    if (log.IsDebugEnabled)
                        log.Debug("Method does not have return value, do not reply");
#endif
                    return;
                }
                Invoke reply = new Invoke();
                reply.ServiceCall = call;
                reply.InvokeId = invoke.InvokeId;
                channel.Write(reply);
            }
        }

        protected override void OnSharedObject(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, SharedObjectMessage message)
        {
            _netConnection.OnSharedObject(connection, channel, header, message);
        }

        protected override void OnFlexInvoke(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, FlexInvoke invoke)
        {
            OnInvoke(connection, channel, header, invoke);
        }

        public override void ConnectionClosed(RtmpConnection connection)
        {
            base.ConnectionClosed(connection);
            _netConnection.RaiseDisconnect();
        }

        #region INetConnectionClient Members

        public IConnection Connection
        {
            get { return _connection; }
        }

        public void Connect(string command, params object[] arguments)
        {
            Uri uri = new Uri(command);
            _connectArguments = arguments;
            //_connectionParameters["tcUrl"] = "rtmp://" + uri.Host + ':' + uri.Port + '/' + uri.PathAndQuery;
            _connectionParameters["tcUrl"] = "rtmp://" + uri.Host + ':' + uri.Port + '/' + uri.Query;
            _connectionParameters["app"] = uri.LocalPath.TrimStart(new char[] { '/' });

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
#if NET_1_1
			IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(uri.Host), uri.Port);
			socket.Connect(endpoint);
#else
#if !SILVERLIGHT
            socket.Connect(uri.Host, uri.Port);
            _connection = new RtmpClientConnection(this, socket);
            _connection.BeginHandshake();
#else
            DnsEndPoint endPoint = new DnsEndPoint(uri.Host, uri.Port);
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.UserToken = socket;
            args.RemoteEndPoint = endPoint;
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketConnectCompleted);
            socket.ConnectAsync(args); 
#endif
#endif
        }

#if SILVERLIGHT
        private void OnSocketConnectCompleted(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                Socket socket = (Socket)e.UserToken;
                if (e.SocketError != SocketError.Success)
                {
                    _netConnection.RaiseNetStatus(new SocketException((int)e.SocketError));
                    socket.Close();
                }
                else
                {
                    _connection = new RtmpClientConnection(this, socket);
                    _connection.BeginHandshake();
                }
            }
            catch (Exception ex)
            {
                _netConnection.RaiseNetStatus(ex);
            }
        }
#endif

        public void Close()
        {
            if (Connected)
            {
                _connection.Close();
            }
            _connection = null;
        }

        public bool Connected
        {
            get
            {
                if (_connection != null)
                    return _connection.IsConnected;
                return false;
            }
        }

        public void Call(string command, IPendingServiceCallback callback, params object[] arguments)
        {
            _connection.Invoke(command, arguments, callback);
        }

        public void Call(string endpoint, string destination, string source, string operation, IPendingServiceCallback callback, params object[] arguments)
        {
            throw new NotSupportedException();
        }

        public void Write(IRtmpEvent message)
        {
            _connection.GetChannel(3).Write(message);
        }

        #endregion

        #region IPendingServiceCallback Members

        public void ResultReceived(IPendingServiceCall call)
        {
            ASObject info = call.Result as ASObject;
            _netConnection.RaiseNetStatus(info);
            if (info.ContainsKey("level") && info["level"].ToString() == "error")
                return;
            _netConnection.RaiseOnConnect();
        }

        #endregion
    }
}
