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

namespace FluorineFx.IO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
    public class AMFMessage
	{
		protected ushort _version = 0;
		protected ArrayList _bodies;
		protected ArrayList _headers;

		/// <summary>
		/// Initializes a new instance of the AMFMessage class.
		/// </summary>
		public AMFMessage() : this(0)
		{
		}
		/// <summary>
		/// Initializes a new instance of the AMFMessage class.
		/// </summary>
		/// <param name="version"></param>
		public AMFMessage(ushort version)
		{
			this._version = version;
			_headers = new ArrayList(1);
			_bodies = new ArrayList(1);
		}

		public ushort Version
		{
			get{ return _version; }
		}

		public void AddBody(AMFBody body)
		{
			this._bodies.Add(body);
		}

		/*
		public void AddBodyAt(AMFBody body, int index)
		{
			this._bodies.Insert(index, body);
		}
		*/

		public void AddHeader(AMFHeader header)
		{
			this._headers.Add(header);
		}

		public int BodyCount
		{
			get{ return _bodies.Count; }
		}

		public ArrayList Bodies
		{
			get{ return ArrayList.ReadOnly(_bodies); }
		}
		
		public int HeaderCount
		{
			get{ return _headers.Count; }
		}

		public AMFBody GetBodyAt(int index)
		{
			return _bodies[index] as AMFBody;
		}

		public AMFHeader GetHeaderAt(int index)
		{
			return _headers[index] as AMFHeader;
		}

		public AMFHeader GetHeader(string header)
		{
			for(int i = 0; _headers != null && i < _headers.Count; i++)
			{
				AMFHeader amfHeader = _headers[i] as AMFHeader;
				if( amfHeader.Name == header )
					return amfHeader;
			}
			return null;
		}

		public ObjectEncoding ObjectEncoding
		{
			get
			{
				return (ObjectEncoding) _version;
			}
		}
	}
}
