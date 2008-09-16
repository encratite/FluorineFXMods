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
#if !(NET_1_1)
using System.Collections.Generic;
#endif

namespace FluorineFx.Messaging.Messages
{
	/// <summary>
	/// Base class for all messages. Messages have two customizable sections; headers and body. 
	/// The headers property provides access to specialized meta information for a specific message 
	/// instance. 
	/// The headers property is an associative array with the specific header name as the key.
	/// <br/><br/>
	/// The body of a message contains the instance specific data that needs to be delivered and 
	/// processed by the remote destination.
	/// The body is an object and is the payload for a message.
	/// </summary>
    [CLSCompliant(false)]
#if SILVERLIGHT
    public class MessageBase : IMessage
#else
    public class MessageBase : IMessage, ICloneable
#endif
	{
#if !(NET_1_1)
        protected Dictionary<string, object> _headers = new Dictionary<string,object>();
#else
        protected Hashtable _headers = new Hashtable();
#endif
        protected long _timestamp;
		protected object _clientId;
		protected string _destination;
		protected string _messageId;
		protected long _timeToLive;
		protected object _body;

		/// <summary>
		/// Messages pushed from the server may arrive in a batch, with messages in the batch 
		/// potentially targeted to different Consumer instances.
		/// Each message will contain this header identifying the Consumer instance that will 
		/// receive the message.
		/// </summary>
		public const string DestinationClientIdHeader = "DSDstClientId";
		/// <summary>
		/// Messages are tagged with the endpoint id for the Channel they are sent over.
		/// Channels set this value automatically when they send a message.
		/// </summary>
		public const string EndpointHeader = "DSEndpoint";
		/// <summary>
		/// Messages that need to set remote credentials for a destination carry the Base64 encoded 
		/// credentials in this header.
		/// </summary>
		public const string RemoteCredentialsHeader = "DSRemoteCredentials";
		/// <summary>
		/// Messages sent with a defined request timeout use this header.
		/// The request timeout value is set on outbound messages by services or channels and the value 
		/// controls how long the corresponding MessageResponder will wait for an acknowledgement, 
		/// result or fault response for the message before timing out the request.
		/// </summary>
		public const string RequestTimeoutHeader = "DSRequestTimeout";
		/// <summary>
		/// This header is used to transport the global FlexClient Id value in outbound messages 
		/// once it has been assigned by the server.
		/// </summary>
		public const string FlexClientIdHeader = "DSId";

		/// <summary>
		/// Initializes a new instance of the MessageBase class.
		/// </summary>
		public MessageBase()
		{
		}

		#region IMessage Members

        /// <summary>
        /// Gets or sets the client identity indicating which client sent the message.
        /// </summary>
        public object clientId
		{
			get{ return _clientId; }
			set{ _clientId = value; }
		}
		/// <summary>
		/// Gets or sets the message destination.
		/// </summary>
		public string destination
		{
			get{ return _destination; }
			set{ _destination = value; }
		}
        /// <summary>
        /// Gets or sets the identity of the message.
        /// </summary>
        /// <remarks>This field is unique and can be used to correlate a response to the original request message.</remarks>
        public string messageId
		{
			get{ return _messageId; }
			set{ _messageId = value; }
		}
        /// <summary>
        /// Gets or sets the time stamp for the message.
        /// </summary>
        /// <remarks>The time stamp is the date and time that the message was sent.</remarks>
        public long timestamp
		{
			get{ return _timestamp; }
			set{ _timestamp = value; }
		}
        /// <summary>
        /// Gets or sets the validity for the message.
        /// </summary>
        /// <remarks>Time to live is the number of milliseconds that this message remains valid starting from the specified timestamp value.</remarks>
        public long timeToLive
		{
			get{ return _timeToLive; }
			set{ _timeToLive = value; }
		}
        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        /// <remarks>The body is the data that is delivered to the remote destination.</remarks>
        public object body
		{
			get{ return _body; }
			set{ _body = value; }
		}
        /// <summary>
        /// Gets or sets the headers of the message.
        /// </summary>
		/// <remarks>
		/// The headers of a message are an associative array where the key is the header name and the value is the header value.
		/// This property provides access to the specialized meta information for the specific message instance. 
        /// Flex core header names begin with a 'DS' prefix. Custom header names should start with a unique prefix to avoid name collisions.
		/// </remarks>
#if !(NET_1_1)
        public Dictionary<string, object> headers
        {
            get { return _headers; }
            set { _headers = value; }
        }
#else
        public Hashtable headers
		{
			get{ return _headers; }
			set{ _headers = value; }
		}
#endif
        /// <summary>
        /// Retrieves the specified header value.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <returns>The value associated with the specified header name.</returns>
		public object GetHeader(string name)
		{
			if( _headers != null )
				return _headers[name];
			return null;
		}
        /// <summary>
        /// Sets a header value.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Value associated with the header name.</param>
        public void SetHeader(string name, object value)
		{
			if( _headers == null )
				_headers = new ASObject();
			_headers[name] = value;
		}
        /// <summary>
        /// Retrieves whether for the specified header name an associated value exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		public bool HeaderExists(string name)
		{
			if( _headers != null )
				return _headers.ContainsKey(name);
			return false;
		}
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
		public virtual object Clone()
		{
			MessageBase message = base.MemberwiseClone() as MessageBase;
			if( _headers != null )
#if !(NET_1_1)
                message.headers = new Dictionary<string, object>(_headers);
#else
				message.headers = _headers.Clone() as Hashtable;
#endif
			return message;
		}

		#endregion
	}
}
