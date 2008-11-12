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
using FluorineFx.Messaging.Api.Event;

namespace FluorineFx.Messaging.Rtmp.Event
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
	public class BaseEvent : IRtmpEvent
	{
        /// <summary>
        /// Event RTMP packet header.
        /// </summary>
		protected RtmpHeader _header;
        /// <summary>
        /// Event target object.
        /// </summary>
		protected object _object;
        /// <summary>
        /// Event timestamp.
        /// </summary>
		protected int _timestamp;
        /// <summary>
        /// Event data type.
        /// </summary>
		protected byte _dataType;
        /// <summary>
        /// Event type.
        /// </summary>
		protected EventType _eventType;
        /// <summary>
        /// Event listener.
        /// </summary>
		protected IEventListener _source;

        internal BaseEvent(EventType eventType)
		{
			_eventType = eventType;
			_object = null;
		}

        internal BaseEvent(EventType eventType, byte dataType, IEventListener source) 
		{
			_dataType = dataType;
			_eventType = eventType;
			_source = source;
		}

        /// <summary>
        /// Gets or sets event type.
        /// </summary>
        public EventType EventType
		{ 
			get{ return _eventType; }
			set{ _eventType = value; }
		}
        /// <summary>
        /// Gets or sets the RTMP packet header.
        /// </summary>
		public RtmpHeader Header
		{
			get{ return _header; }
			set{ _header = value; }
		}
        /// <summary>
        /// Gets event context object.
        /// </summary>
		public virtual object Object
		{ 
			get{ return _object; }
		}
        /// <summary>
        /// Gets or sets the event timestamp.
        /// </summary>
		public int Timestamp
		{
			get{ return _timestamp; }
			set{ _timestamp = value; }
		}
        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        public byte DataType
		{
			get{ return _dataType; }
			set{ _dataType = value; }
		}
        /// <summary>
        /// Gets or sets the event listener.
        /// </summary>
		public IEventListener Source
		{
			get{ return _source; }
			set{ _source = value; }
		}
        /// <summary>
        /// Gets whether event has source (event listeners).
        /// </summary>
		public bool HasSource
		{
			get{ return _source != null; }
		}
	}
}
