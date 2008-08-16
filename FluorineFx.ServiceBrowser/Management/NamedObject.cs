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

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for NamedObject.
	/// </summary>
	[Serializable]
	public class NamedObject
	{
		protected string _name;
		protected string _caption;
		protected string _code;
		protected string _description;
		protected Guid _guid;

		internal NamedObject():this(null)
		{
		}

		public NamedObject(string name)
		{
			_name = name;
			_caption = name;
			_guid = Guid.NewGuid();
		}

		public Guid Guid
		{
			get { return _guid; }
			set { _guid = value; }
		}

		public string Name
		{
			get{ return _name; }
			set
			{
				if(value == null )
					throw new ArgumentNullException("Name");
				
				if(value != _name)
				{
					_name = value;
				}
			}
		}

		public string Caption
		{
			get { return _caption; }
			set
			{
				//if(value == null || value == string.Empty)
				//	throw new ArgumentNullException("Caption");

				if (value != _caption)
				{
					_caption = value;
				}
			}
		}

		public string Code
		{
			get { return _code; }
			set
			{
				if (value != _code)
				{
					_code = value;
				}
			}
		}

    	public string Description
		{
			get { return _description; }
			set
			{
				//if(value == null || value == string.Empty)
				//	throw new ArgumentNullException("Description");
				if (value != _description)
				{
					_description = value;
				}
			}
		}

		public override string ToString()
		{
			return _name;
		}
	}
}
