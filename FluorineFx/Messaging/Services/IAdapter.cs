/*
	Fluorine .NET Flash Remoting Gateway open source library 
	Copyright (C) 2005 Zoltan Csibi, zoltan@TheSilentGroup.com
	
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

using FluorineFx.Messaging.Config;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;

namespace FluorineFx.Messaging.Services
{
	/// <summary>
    /// A Service adapter bridges destinations to back-end systems.
	/// </summary>
    [CLSCompliant(false)]
    public interface IAdapter
	{
        /// <summary>
        /// Process a message routed for this adapter.
        /// </summary>
        /// <param name="message">The message sent by the client.</param>
        /// <returns>The body of the acknowledge message (or null if there is no body).</returns>
		object Invoke(IMessage message);
        /// <summary>
        /// Accept and process a command from the adapter's service.
        /// For example, this handles subscribe, unsubscribe, and ping operations.
        /// </summary>
        /// <param name="commandMessage">The command message sent by the client.</param>
        /// <returns>The body of the acknowledge message (or null if there is no body).</returns>
		object Manage(CommandMessage commandMessage);
        /// <summary>
        /// Gets whether the adapter performs custom subscription management. The default return value is false.
        /// </summary>
        bool HandlesSubscriptions{ get; }

		IService Service { get; set; }
        Destination Destination { get; set; }
        DestinationSettings DestinationSettings { get; set; }
		AdapterSettings AdapterSettings { get; set; }
        /// <summary>
        /// Adapter initialization.
        /// </summary>
		void Init();
	}
}
