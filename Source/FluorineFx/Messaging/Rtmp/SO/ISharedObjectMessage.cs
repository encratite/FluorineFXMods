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
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Rtmp.Event;

namespace FluorineFx.Messaging.Rtmp.SO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface ISharedObjectMessage : IRtmpEvent
	{
		/// <summary>
		/// Gets the name of the shared object this message belongs to.
		/// </summary>
		string Name{ get; }
		/// <summary>
		/// Returns the version to modify.
		/// </summary>
		int Version{ get; }
		/// <summary>
		/// Gets whether the message affects a persistent shared object.
		/// </summary>
		bool IsPersistent{ get; }

#if !(NET_1_1)
        /// <summary>
        /// Returns a set of ISharedObjectEvent objects containing informations what to change.
        /// </summary>
        IList<ISharedObjectEvent> Events { get; }
#else
		/// <summary>
		/// Returns a set of ISharedObjectEvent objects containing informations what to change.
		/// </summary>
		IList Events{ get; }
#endif
        void AddEvent(SharedObjectEventType type, string key, object value);
		void AddEvent(ISharedObjectEvent sharedObjectEvent);
		void Clear();
		bool IsEmpty{ get; }
	}
}
