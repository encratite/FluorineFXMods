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
	/// Summary description for UrlParameter.
	/// </summary>
	[Serializable]
	public class UrlParameter
	{
		string _name;
		string _value;

		public UrlParameter()
		{
		}

		public UrlParameter(string name, string value)
		{
			_name = name;
			_value = value;
		}

		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		public string Value
		{
			get{ return _value; }
			set{ _value = value; }
		}
	}
}
