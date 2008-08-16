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
using System.Security;
using FluorineFx.Messaging.Services;

namespace FluorineFx.Messaging.Messages
{
	/// <summary>
	/// The ErrorMessage class is used to report errors within the messaging system.
	/// An error message only occurs in response to a message sent within the system.
	/// </summary>
    [CLSCompliant(false)]
    public class ErrorMessage : AcknowledgeMessage
	{
		string _faultCode;
		string _faultString;
		string _faultDetail;
		object _rootCause;
		ASObject _extendedData;

		/// <summary>
		/// Initializes a new instance of the ErrorMessage class.
		/// </summary>
		public ErrorMessage()
		{
		}
		/// <summary>
		/// The fault code for the error. 
		/// This value typically follows the convention of "[outer_context].[inner_context].[issue]".
		/// 
		/// For example: "Channel.Connect.Failed", "Server.Call.Failed"
		/// </summary>
		public string faultCode
		{
			get{ return _faultCode; }
			set{ _faultCode = value; }
		}
		/// <summary>
		/// A simple description of the error.
		/// </summary>
		public string faultString
		{
			get{ return _faultString; }
			set{ _faultString = value; }
		}
		/// <summary>
		/// Detailed description of what caused the error. This is typically a stack trace from the remote destination
		/// </summary>
		public string faultDetail
		{
			get{ return _faultDetail; }
			set{ _faultDetail = value; }
		}
		/// <summary>
		/// Root cause for the error.
		/// </summary>
		public object rootCause
		{
			get{ return _rootCause; }
			set{ _rootCause = value; }
		}
        /// <summary>
        /// Extended data that the remote destination can choose to associate with this error for custom error processing on the client.
        /// </summary>
		public ASObject extendedData
		{
			get{ return _extendedData; }
			set{ _extendedData = value; }
		}

		internal static ErrorMessage GetErrorMessage(IMessage message, Exception exception)
		{
			MessageException me = null;
			if( exception is MessageException )
				me = exception as MessageException;
			else
				me = new MessageException(exception);
			ErrorMessage errorMessage = me.GetErrorMessage();
            if (message.clientId != null)
                errorMessage.clientId = message.clientId;
            else
                errorMessage.clientId = Guid.NewGuid().ToString("D");
			errorMessage.correlationId = message.messageId;
			errorMessage.destination = message.destination;
			if(exception is SecurityException)
                errorMessage.faultCode = AuthenticationService.ClientAuthenticationError;
			if(exception is UnauthorizedAccessException)
				errorMessage.faultCode = AuthenticationService.ClientAuthorizationError;
			return errorMessage;
		}

	}
}
