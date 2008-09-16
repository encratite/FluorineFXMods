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
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Rtmp.Event;
#if !(NET_1_1)
using System.Collections.Generic;
#endif

namespace FluorineFx.Messaging.Rtmp.SO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public class SharedObjectMessage : BaseEvent, ISharedObjectMessage
	{
		private string _name;
		//ISharedObjectEvent
#if !(NET_1_1)
        private List<ISharedObjectEvent> _events = new List<ISharedObjectEvent>();
#else
        private ArrayList _events = new ArrayList();
#endif
		private int _version = 0;
		private bool _persistent = false;

        internal SharedObjectMessage(string name, int version, bool persistent)
            : this(null, name, version, persistent)
		{
		}

        internal SharedObjectMessage(IEventListener source, string name, int version, bool persistent)
            : base(EventType.SHARED_OBJECT, Constants.TypeSharedObject, source)
		{
			_name = name;
			_version = version;
			_persistent = persistent;
		}


		#region ISharedObjectMessage Members

		public string Name
		{
			get
			{
				return _name;
			}
		}

        internal void SetName(string name)
        {
            _name = name;
        }

		public int Version
		{
			get
			{
				return _version;
			}
		}

		public bool IsPersistent
		{
			get
			{
				return _persistent;
			}
		}

        internal void SetIsPersistent(bool persistent)
        {
            _persistent = persistent;
        }

		public void AddEvent(SharedObjectEventType type, string key, object value)
		{
			_events.Add(new SharedObjectEvent(type, key, value));
		}

		public void AddEvent(ISharedObjectEvent sharedObjectEvent)
		{
			_events.Add(sharedObjectEvent);
		}

		public void Clear()
		{
			_events.Clear();
		}

		public bool IsEmpty
		{
			get
			{
				return _events.Count == 0;
			}
		}

		#endregion

#if !(NET_1_1)
        public IList<ISharedObjectEvent> Events
        {
            get
            {
                return _events;
            }
        }

        public void AddEvents(IList<ISharedObjectEvent> events)
        {
            _events.AddRange(events);
        }
#else
		public IList Events
		{
			get
			{
				//return _events.ToArray(typeof(ISharedObjectEvent)) as ISharedObjectEvent[];
				return _events;
			}
		}

		public void AddEvents(IList events) 
		{
			_events.AddRange(events);
		}
#endif

        #region IEvent Members

        public override object Object
		{
			get
			{
				return this.Events;
			}
		}

		#endregion
	}
}
