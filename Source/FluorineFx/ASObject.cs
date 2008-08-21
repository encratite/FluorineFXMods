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
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace FluorineFx
{
	/// <summary>
	/// The ASObject class represents a Flash object.
	/// </summary>
	[Serializable]
	public class ASObject : Hashtable
	{
		private string _typeName;

		/// <summary>
		/// Initializes a new instance of the ASObject class.
		/// </summary>
		public ASObject()
		{
		}
		/// <summary>
		/// Initializes a new instance of the ASObject class.
		/// </summary>
		/// <param name="typeName">Typed object type name.</param>
		public ASObject(string typeName)
		{
			_typeName = typeName;
		}
		/// <summary>
		/// Initializes a new instance of the ASObject class.
		/// </summary>
		/// <param name="dictionary"></param>
		public ASObject(IDictionary dictionary): base(dictionary)
		{
		}
		/// <summary>
		/// Initializes a new instance of the ASObject class.
		/// </summary>
		/// <param name="nameValueCollection"></param>
		public ASObject(NameValueCollection nameValueCollection)
		{
			foreach(string key in nameValueCollection.AllKeys)
			{
				string value = nameValueCollection[key];
				this[key] = value;
			}
		}

		public ASObject(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
		/// <summary>
		/// Gets or sets the type name for a typed object.
		/// </summary>
		public string TypeName
		{
			get{ return _typeName; }
			set{ _typeName = value; }
		}
		/// <summary>
		/// Gets the Boolean value indicating whether the ASObject is typed.
		/// </summary>
		public bool IsTypedObject
		{
			get{ return _typeName != null && _typeName != string.Empty; }
		}
	}
}
