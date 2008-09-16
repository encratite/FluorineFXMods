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
using System.IO;
using System.Collections;

using FluorineFx.Util;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Api.Service;

namespace FluorineFx.Messaging.Rtmp.Event
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public class Notify : BaseEvent
	{
		protected IServiceCall		_serviceCall = null;
		protected ByteBuffer		_data = null;
		int							_invokeId = 0;
		IDictionary					_connectionParameters;

        internal Notify()
            : base(EventType.SERVICE_CALL)
		{
			_dataType = Constants.TypeNotify;
		}

        internal Notify(ByteBuffer data)
            : this()
		{
			_data = data;
		}

        internal Notify(byte[] data)
            : this()
        {
            _data = ByteBuffer.Wrap(data);
        }

        internal Notify(IServiceCall serviceCall)
            : this()
		{
			_serviceCall = serviceCall;
		}

		public ByteBuffer Data
		{
			get{ return _data; }
			set{ _data = value; }
		}

		public int InvokeId
		{
			get{ return _invokeId; }
			set{ _invokeId = value; }
		}

		public IServiceCall ServiceCall
		{
			get{ return _serviceCall; }
			set{ _serviceCall = value; }
		}

		public IDictionary ConnectionParameters
		{
			get{ return _connectionParameters; }
			set{ _connectionParameters = value; }
		}
	}
}
