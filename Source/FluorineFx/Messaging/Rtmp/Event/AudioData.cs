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
using FluorineFx.Util;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Rtmp.Stream;

namespace FluorineFx.Messaging.Rtmp.Event
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AudioData : BaseEvent, IStreamData
	{
		protected ByteBuffer _data;

		public AudioData(ByteBuffer data):base(EventType.STREAM_DATA)
		{
			_dataType = Constants.TypeAudioData;
			_data = data;
		}

		public AudioData():this(ByteBuffer.Allocate(0))
		{
		}

        public AudioData(byte[] data)
            : this(ByteBuffer.Wrap(data))
        {
        }
		
		public override string ToString()
		{
			return "Audio  ts: " + this.Header.Timer;
		}

		#region IStreamData Members

		public ByteBuffer Data
		{
			get{ return _data; }
		}

		#endregion
	}
}
