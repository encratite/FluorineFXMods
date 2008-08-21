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

using FluorineFx.Messaging.Config;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;

namespace FluorineFx.Messaging.Services
{
	/// <summary>
    /// A Service adapter bridges destinations to back-end systems.
	/// The ServiceAdapter class is the base definition of a service adapter.
	/// </summary>
    [CLSCompliant(false)]
    public abstract class ServiceAdapter
	{
        private object _syncLock = new object();
        private IService _service;
        private Destination _destination;
        private DestinationSettings _destinationSettings;
        private AdapterSettings _adapterSettings;

		protected ServiceAdapter()
		{
		}

        /// <summary>
        /// Process a message routed for this adapter.
        /// </summary>
        /// <param name="message">The message sent by the client.</param>
        /// <returns>The body of the acknowledge message (or null if there is no body).</returns>
        public virtual object Invoke(IMessage message)
        {
            return null;
        }
        /// <summary>
        /// Gets whether the adapter performs custom subscription management. The default return value is false.
        /// </summary>
        public virtual bool HandlesSubscriptions
		{
			get { return false; }
		}

        /// <summary>
        /// Accept a command from the adapter's service (subscribe, unsubscribe and ping operations).
        /// </summary>
        /// <param name="commandMessage"></param>
        /// <returns></returns>
        public virtual object Manage(CommandMessage commandMessage)
        {
            return new AcknowledgeMessage();
        }
        /// <summary>
        /// Adapter initialization.
        /// </summary>
		public virtual void Init()
		{
		}

        public virtual void Stop()
        {
        }

        public IService Service { get { return _service; } set { _service = value; } }
        internal Destination Destination { get { return _destination; } set { _destination = value; } }
        internal DestinationSettings DestinationSettings { get { return _destinationSettings; } set { _destinationSettings = value; } }
		public AdapterSettings AdapterSettings { get { return _adapterSettings; } set { _adapterSettings = value; } }
        public object SyncRoot { get { return _syncLock; } }
	}
}
