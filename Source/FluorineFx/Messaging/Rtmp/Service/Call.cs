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
#if !SILVERLIGHT
using log4net;
#endif
using FluorineFx.Invocation;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Exceptions;

namespace FluorineFx.Messaging.Rtmp.Service
{
    [CLSCompliant(false)]
    public class Call : IServiceCall
    {
        /// <summary>
        /// Pending status constant.
        /// </summary>
	    public const byte STATUS_PENDING = 0x01;
        /// <summary>
        /// Success result constant.
        /// </summary>
	    public const byte STATUS_SUCCESS_RESULT = 0x02;
        /// <summary>
        /// Returned value is null constant.
        /// </summary>
	    public const byte STATUS_SUCCESS_NULL = 0x03;
        /// <summary>
        /// Service returns no value constant.
        /// </summary>
	    public const byte STATUS_SUCCESS_VOID = 0x04;
        /// <summary>
        /// Service not found constant.
        /// </summary>
	    public const byte STATUS_SERVICE_NOT_FOUND = 0x10;
        /// <summary>
        /// Service's method not found constant.
        /// </summary>
	    public const byte STATUS_METHOD_NOT_FOUND = 0x11;
        /// <summary>
        /// Access denied constant.
        /// </summary>
	    public const byte STATUS_ACCESS_DENIED = 0x12;
        /// <summary>
        /// Exception on invocation constant.
        /// </summary>
        public const byte STATUS_INVOCATION_EXCEPTION = 0x13;
        /// <summary>
        /// General exception constant.
        /// </summary>
        public const byte STATUS_GENERAL_EXCEPTION = 0x14;
        /// <summary>
        /// The application for this service is currently shutting down.
        /// </summary>
        public const byte STATUS_APP_SHUTTING_DOWN = 0x15;

        /// <summary>
        /// Service name.
        /// </summary>
        protected string _serviceName;
        /// <summary>
        /// Service method name.
        /// </summary>
        protected string _serviceMethodName;
        /// <summary>
        /// Call arguments.
        /// </summary>
        protected object[] _arguments;
        /// <summary>
        /// Call status, initial one is pending.
        /// </summary>
        protected byte _status = STATUS_PENDING;
        /// <summary>
        /// Call exception if any, null by default.
        /// </summary>
        protected Exception _exception;

        public Call(string method)
        {
            _serviceMethodName = method;
        }

        public Call(string method, object[] args)
        {
            _serviceMethodName = method;
            _arguments = args;
        }

        public Call(string name, string method, object[] args)
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
            get { return _serviceMethodName; }
        }

        public string ServiceName
        {
            get { return _serviceName; }
        }

        public object[] Arguments
        {
            get { return _arguments; }
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
