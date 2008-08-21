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

namespace FluorineFx.Messaging.Api.Service
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public class ServiceCall : IServiceCall
	{
		public const byte STATUS_PENDING = 0x01;
		public const byte STATUS_SUCCESS_RESULT = 0x02;
		public const byte STATUS_SUCCESS_NULL = 0x03;
		public const byte STATUS_SUCCESS_VOID = 0x04;
		public const byte STATUS_SERVICE_NOT_FOUND = 0x10;
		public const byte STATUS_METHOD_NOT_FOUND = 0x11;
		public const byte STATUS_ACCESS_DENIED = 0x12;
		public const byte STATUS_INVOCATION_EXCEPTION = 0x13;
		public const byte STATUS_GENERAL_EXCEPTION = 0x14;
        /// <summary>
        /// The application for this service is currently shutting down.
        /// </summary>
        public const byte STATUS_APP_SHUTTING_DOWN = 0x15;

		protected string _serviceName;
		protected string _serviceMethodName;
		protected object[] _arguments;
		protected byte _status = STATUS_PENDING;
		protected Exception _exception;

		public ServiceCall(string method)
		{
			_serviceMethodName = method;
		}

		public ServiceCall(string method, object[] args) 
		{
			_serviceMethodName = method;
			_arguments = args;
		}

		public ServiceCall(string name, string method, object[] args) 
		{
			_serviceName = name;
			_serviceMethodName = method;
			_arguments = args;
		}

		#region IServiceCall Members

		public bool IsSuccess
		{
			get
			{
				return (_status == STATUS_SUCCESS_RESULT)
					|| (_status == STATUS_SUCCESS_NULL)
					|| (_status == STATUS_SUCCESS_VOID);
			}
		}

		public string ServiceMethodName
		{
			get
			{				
				return _serviceMethodName;
			}
		}

		public string ServiceName
		{
			get
			{
				return _serviceName;
			}
		}

		public object[] Arguments
		{
			get
			{
				return _arguments;
			}
		}

		public byte Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
			}
		}

		public Exception Exception
		{
			get
			{
				return _exception;
			}
			set
			{
				_exception = value;
			}
		}

		#endregion
	}
}
