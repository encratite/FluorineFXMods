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
using System.Net.Sockets;
using FluorineFx.IO;
using FluorineFx.Configuration;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using FluorineFx.Messaging.Rtmp;
using FluorineFx.Messaging.Rtmp.Event;
using FluorineFx.Messaging.Rtmp.SO;
using FluorineFx.Util;

//Network Security Access Restrictions in Silverlight 2
//http://msdn.microsoft.com/en-us/library/cc645032(VS.95).aspx

namespace FluorineFx.Net
{
    /// <summary>
    /// Represents the method that will handle the NetStatus event of a NetConnection or RemoteSharedObject object. 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A NetStatusEventArgs object that contains the event data.</param>
    public delegate void NetStatusHandler(object sender, NetStatusEventArgs e);
    /// <summary>
    /// Represents the method that will handle the Connect event of a NetConnection or RemoteSharedObject object. 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">EventArgs object that contains the event data.</param>
    public delegate void ConnectHandler(object sender, EventArgs e);
    /// <summary>
    /// Represents the method that will handle the Disconnect event of a NetConnection or RemoteSharedObject object. 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">EventArgs object that contains the event data.</param>
    public delegate void DisconnectHandler(object sender, EventArgs e);

    /// <summary>
    /// The NetConnection class creates a connection between a .NET client and a Flash Media Server application or application server running Flash Remoting.
    /// </summary>
    [CLSCompliant(false)]
    public sealed class NetConnection
    {
        string _clientId;
        Uri _uri;
        object[] _arguments;
        INetConnectionClient _netConnectionClient;
        ObjectEncoding _objectEncoding;
        string _playerVersion;
        object _client;
#if !(NET_1_1)
        Dictionary<string, AMFHeader> _headers;
#else
        Hashtable _headers;
#endif

        event NetStatusHandler _netStatusHandler;
        event ConnectHandler _connectHandler;
        event DisconnectHandler _disconnectHandler;

        /// <summary>
        /// Initializes a new instance of the NetConnection class.
        /// </summary>
        public NetConnection()
        {
            _clientId = null;
            _playerVersion = "WIN 9,0,115,0";
            _objectEncoding = ObjectEncoding.AMF0;
#if !(NET_1_1)
            _headers = new Dictionary<string,AMFHeader>();
#else
            _headers = new Hashtable();
#endif
            _client = this;

            TypeHelper._Init();
        }
        /// <summary>
        /// Dispatched when a NetConnection instance is reporting its status or error condition.
        /// </summary>
        public event NetStatusHandler NetStatus
        {
            add { _netStatusHandler += value; }
            remove { _netStatusHandler -= value; }
        }
        /// <summary>
        /// Dispatched when a NetConnection instance is connected.
        /// </summary>
        public event ConnectHandler OnConnect
        {
            add { _connectHandler += value; }
            remove { _connectHandler -= value; }
        }
        /// <summary>
        /// Dispatched when a NetConnection instance is disconnected.
        /// </summary>
        public event DisconnectHandler OnDisconnect
        {
            add { _disconnectHandler += value; }
            remove { _disconnectHandler -= value; }
        }
        /// <summary>
        /// Gets URI of the application on the server.
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
        }
        /// <summary>
        /// Get or sets the player version string sent from .NET code.
        /// </summary>
        public string PlayerVersion
        {
            get { return _playerVersion; }
            set { _playerVersion = value; }
        }
        /// <summary>
        /// Gets or sets the object encoding (AMF version) for this NetConnection object. Default is ObjectEncoding.AMF0.
        /// </summary>
        public ObjectEncoding ObjectEncoding
        {
            get { return _objectEncoding; }
            set { _objectEncoding = value; }
        }
        /// <summary>
        /// Indicates the object on which callback methods should be invoked. The default is this NetConnection instance.
        /// If you set the client property to another object, callback methods will be invoked on that object. 
        /// </summary>
        public Object Client
        {
            get { return _client; }
            set
            {
                ValidationUtils.ArgumentNotNull(value, "Client");
                _client = value;
            }
        }
        /// <summary>
        /// Gets the client identity.
        /// </summary>
        public string ClientId
        {
            get { return _clientId; }
        }

        internal void SetClientId(string clientId)
        {
            _clientId = clientId;
        }

#if !(NET_1_1)
        internal Dictionary<string, AMFHeader> Headers
#else
        internal Hashtable Headers
#endif
        {
            get { return _headers; }
        }

        internal INetConnectionClient NetConnectionClient
        {
            get { return _netConnectionClient; }
        }

        /// <summary>
        /// Indicates whether this connection has connected to a server through a persistent RTMP connection (true) or not (false).
        /// It is always true for AMF connections to application servers.
        /// </summary>
        public bool Connected
        {
            get
            {
                if (_netConnectionClient != null)
                    return _netConnectionClient.Connected;
                return false;
            }
        }

        /// <summary>
        /// Adds a context header to the Action Message Format (AMF) packet structure.
        /// This header is sent with every future AMF packet.
        /// To remove a header call AddHeader with the name of the header to remove an undefined object.
        /// </summary>
        /// <param name="operation">Identifies the header and the ActionScript object data associated with it.</param>
        /// <param name="mustUnderstand">A value of true indicates that the server must understand and process this header before it handles any of the following headers or messages.</param>
        /// <param name="param">Any ActionScript object or null.</param>
        /// <remarks>Not implemented.</remarks>
        public void AddHeader(string operation, bool mustUnderstand, object param)
        {
            if (param == null)
            {
                if (_headers.ContainsKey(operation))
                    _headers.Remove(operation);
                return;
            }
            AMFHeader header = new AMFHeader(operation, mustUnderstand, param);
            _headers[operation] = header;
        }
        /// <summary>
        /// Authenticates a user with a credentials header
        /// </summary>
        /// <param name="userid">A username to be used by the server for authentication.</param>
        /// <param name="password"> password to be used by the server for authentication.</param>
        public void SetCredentials(string userid, string password)
        {
            ASObject aso = new ASObject();
            aso.Add("userid", userid);
            aso.Add("password", password);
            AddHeader("Credentials", false, aso);
        }
        /// <summary>
        /// Opens a connection to a server. Through this connection, you can invoke commands on a remote server. 
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="arguments">Optional parameters of any type to be passed to the application specified in command.
        /// If the application is unable to process the parameters in the order in which they are received, NetStatusEvent is dispatched with the code property set to NetConnection.Connect.Rejected
        /// </param>
        /// <remarks>
        /// Set the command parameter to the URI of the application on the server that runs when the connection is made.
        /// Use the following format. protocol://host[:port]/appname/[instanceName]
        /// </remarks>
        /// <example>
        /// NetConnection conn = new NetConnection();
        /// conn.Connect("http://localhost:2896/WebSite/Gateway.aspx");
        /// conn.Call("ServiceLibrary.MyDataService.GetCustomers", new GetCustomersHandler(), new object[] { "415" });
        /// <br/>
        /// public class GetCustomersHandler : IPendingServiceCallback
        /// {
        ///     public void ResultReceived(IPendingServiceCall call)
        ///     {
        ///         object result = call.Result;
        ///     }
        /// }
        /// </example>
        public void Connect(string command, params object[] arguments)
        {
            _uri = new Uri(command);
            _arguments = arguments;
            Connect();
        }
        /// <summary>
        /// Asynchronous version of Connect.
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="callback">Callback object.</param>
        /// <param name="state"></param>
        /// <param name="arguments">Optional parameters of any type to be passed to the application specified in command.</param>
        /// <returns></returns>
        public IAsyncResult BeginConnect(string command, AsyncCallback callback, object state, params object[] arguments)
        {
            _uri = new Uri(command);
            _arguments = arguments;
            // Create IAsyncResult object identifying the asynchronous operation
            AsyncResultNoResult ar = new AsyncResultNoResult(callback, state);
            // Use a thread pool thread to perform the operation
#if NET_1_1
			System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(DoConnect), ar);
#else
            System.Threading.ThreadPool.QueueUserWorkItem(DoConnect, ar);
#endif
			// Return the IAsyncResult to the caller
            return ar;
        }

        /// <summary>
        /// Asynchronous version of Connect.
        /// </summary>
        /// <param name="asyncResult"></param>
        public void EndConnect(IAsyncResult asyncResult)
        {
            AsyncResultNoResult ar = asyncResult as AsyncResultNoResult;
            // Wait for operation to complete, then return result or throw exception
            ar.EndInvoke();
        }

        private void DoConnect(object asyncResult)
        {
            AsyncResultNoResult ar = asyncResult as AsyncResultNoResult;
            try
            {
                // Perform the operation; if sucessful set the result
                Connect();
                ar.SetAsCompleted(null, false);
            }
            catch (Exception ex)
            {
                // If operation fails, set the exception
                ar.SetAsCompleted(ex, false);
            }
        }

        private void Connect()
        {
            if (_uri.Scheme == "http")
            {
                _netConnectionClient = new RemotingClient(this);
                _netConnectionClient.Connect(_uri.ToString(), _arguments);
                return;
            }
            if (_uri.Scheme == "rtmp")
            {
                _netConnectionClient = new RtmpClient(this);
                _netConnectionClient.Connect(_uri.ToString(), _arguments);
                return;
            }
            throw new UriFormatException();
        }

        /// <summary>
        /// Closes the connection that was opened with the server and dispatches the netStatus event with a code property of NetConnection.Connect.Close.
        /// </summary>
        public void Close()
        {
            if (_netConnectionClient != null)
            {
                _netConnectionClient.Close();
            }
            _netConnectionClient = null;
        }

        internal void RaiseNetStatus(Exception exception)
        {
            if (_netStatusHandler != null)
            {
                _netStatusHandler(this, new NetStatusEventArgs(exception));
            }
        }

        internal void RaiseNetStatus(ASObject info)
        {
            if (_netStatusHandler != null)
            {
                _netStatusHandler(this, new NetStatusEventArgs(info));
            }
        }

        internal void RaiseNetStatus(string message)
        {
            if (_netStatusHandler != null)
            {
                _netStatusHandler(this, new NetStatusEventArgs(message));
            }
        }

        internal void RaiseOnConnect()
        {
            if (_connectHandler != null)
            {
                _connectHandler(this, new EventArgs());
            }
        }

        internal void RaiseDisconnect()
        {
            RemoteSharedObject.DispatchDisconnect(this);
            if (_disconnectHandler != null)
            {
                _disconnectHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Invokes a command or method on the server to which this connection is connected.
        /// </summary>
        /// <param name="command">A method specified in object path form.</param>
        /// <param name="callback">An optional object that is used to handle return values from the server.</param>
        /// <param name="arguments">Optional arguments. These arguments are passed to the method specified in the command parameter when the method is executed on the remote application server.</param>
        public void Call(string command, IPendingServiceCallback callback, params object[] arguments)
        {
            _netConnectionClient.Call(command, callback, arguments);
        }

        /// <summary>
        /// Invokes a command or method on the server to which this connection is connected.
        /// </summary>
        /// <param name="endpoint">Flex RPC endpoint name.</param>
        /// <param name="destination">Flex RPC message destination.</param>
        /// <param name="source">The name of the service to be called including namespace name.</param>
        /// <param name="operation">The name of the remote method/operation that should be called.</param>
        /// <param name="callback">An optional object that is used to handle return values from the server.</param>
        /// <param name="arguments">Optional arguments. These arguments are passed to the method specified in the command parameter when the method is executed on the remote application server.</param>
        /// <remarks>
        /// For RTMP connection this method throws a NotSupportedException.
        /// </remarks>
        public void Call(string endpoint, string destination, string source, string operation, IPendingServiceCallback callback, params object[] arguments)
        {
            _netConnectionClient.Call(endpoint, destination, source, operation, callback, arguments);
        }

        internal void OnSharedObject(RtmpConnection connection, RtmpChannel channel, RtmpHeader header, SharedObjectMessage message)
        {
            RemoteSharedObject.Dispatch(message);
        }
    }
}
