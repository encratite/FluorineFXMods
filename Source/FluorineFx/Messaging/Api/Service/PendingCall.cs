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

namespace FluorineFx.Messaging.Api.Service
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public class PendingCall : ServiceCall, IPendingServiceCall
	{
		object		_result;
		ArrayList	_callbacks = new ArrayList();

		public PendingCall(string method) : base(method)
		{
		}

		public PendingCall(string method, object[] args) : base(method, args)
		{
		}

		public PendingCall(string name, string method, object[] args) : base(name, method, args)
		{
		}

		#region IPendingServiceCall Members

		public object Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
			}
		}

		public void RegisterCallback(IPendingServiceCallback callback)
		{
			_callbacks.Add(callback);
		}

		public void UnregisterCallback(IPendingServiceCallback callback)
		{
			_callbacks.Remove(callback);
		}

		public IPendingServiceCallback[] GetCallbacks()
		{
			return _callbacks.ToArray(typeof(IPendingServiceCallback)) as IPendingServiceCallback[];
		}

		#endregion

	}
}
