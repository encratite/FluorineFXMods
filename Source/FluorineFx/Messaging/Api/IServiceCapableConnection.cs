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
using FluorineFx.Messaging.Api.Service;

namespace FluorineFx.Messaging.Api
{
	/// <summary>
    /// Connection that has options to invoke and handle remote calls.
	/// </summary>
    [CLSCompliant(false)]
	public interface IServiceCapableConnection : IConnection
	{
        /// <summary>
        /// Invokes service using service call object.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
		void Invoke(IServiceCall serviceCall);
        /// <summary>
        /// Invokes service using service call object and channel.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
        /// <param name="channel">Channel to use.</param>
		void Invoke(IServiceCall serviceCall, byte channel);
        /// <summary>
        /// Invoke method by name.
        /// </summary>
        /// <param name="method">Method name.</param>
		void Invoke(string method);
        /// <summary>
        /// Invoke method by name with callback.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="callback">Callback used to handle return values.</param>
		void Invoke(string method, IPendingServiceCallback callback);
        /// <summary>
        /// Invoke method with parameters.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Invocation parameters passed to the method.</param>
		void Invoke(string method, object[] parameters);
        /// <summary>
        /// Invoke method with parameters and callback.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Invocation parameters passed to the method.</param>
        /// <param name="callback">Callback used to handle return values.</param>
        void Invoke(string method, object[] parameters, IPendingServiceCallback callback);
        /// <summary>
        /// Notifies service using service call object.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
        void Notify(IServiceCall serviceCall);
        /// <summary>
        /// Notifies service using service call object and channel.
        /// </summary>
        /// <param name="serviceCall">Service call object.</param>
        /// <param name="channel">Channel to use.</param>
        void Notify(IServiceCall serviceCall, byte channel);
        /// <summary>
        /// Notifies method by name.
        /// </summary>
        /// <param name="method">Method name.</param>
        void Notify(string method);
        /// <summary>
        /// Notifies method with parameters.
        /// </summary>
        /// <param name="method">Method name.</param>
        /// <param name="parameters">Parameters passed to the method.</param>
		void Notify(string method, object[] parameters);
	}
}
