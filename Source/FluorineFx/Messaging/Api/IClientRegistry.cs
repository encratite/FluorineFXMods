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
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Messages;

namespace FluorineFx.Messaging.Api
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IClientRegistry
	{
		/// <summary>
		/// Check if a client with a given id exists.
		/// </summary>
		/// <param name="id">The id of the client to check for.</param>
		/// <returns><code>true</code> if the client exists, <code>false</code> otherwise.</returns>
		bool HasClient(string id);

        /*
        /// <summary>
        /// Create a new client client object from connection parameters.
        /// </summary>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        /// <param name="parameters">The parameters the client passed during connection.</param>
        /// <returns>The new client.</returns>
        IClient NewClient(int clientLeaseTime, object[] parameters);
        /// <summary>
        /// Create a new client client object from connection parameters.
        /// </summary>
        /// <param name="id">Client identity.</param>
        /// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
        /// <param name="parameters">The parameters the client passed during connection.</param>
        /// <returns></returns>
        IClient NewClient(string id, int clientLeaseTime, object[] parameters);
        */
		/// <summary>
		/// Return an existing client from a client id.
		/// </summary>
		/// <param name="id">The id of the client to return.</param>
		/// <returns>The client object.</returns>
		IClient LookupClient(string id);

        IClient GetClient(string id);
        IClient GetClient(IMessage message);
	}
}
