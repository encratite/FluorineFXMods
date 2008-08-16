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
using System.Xml;
using System.Xml.Serialization;

namespace FluorineFx.Management.Web
{
	/// <summary>
	/// Summary description for RemotingService.
	/// </summary>
	[Serializable]
	public class RemotingService : NamedObject
	{
		string		_id;
		string		_destination;
		string		_source;
		bool		_showBusyCursor;
		string		_endpoint;
		ArrayList	_methods;

		private bool		_checked;

		public RemotingService() : this(string.Empty)
		{
		}

		public RemotingService(string name) : base(name)
		{
			_methods = new ArrayList();
			_checked = true;
		}

		public string id
		{
			get{ return _id; }
			set{ _id = value; }
		}

		public string destination
		{
			get{ return _destination; }
			set{ _destination = value; }
		}

		public string source
		{
			get{ return _source; }
			set{ _source = value; }
		}

		public string endpoint
		{
			get{ return _endpoint; }
			set{ _endpoint = value; }
		}

		public bool showBusyCursor
		{
			get{ return _showBusyCursor; }
			set{ _showBusyCursor = value; }
		}

		[XmlElement(Type = typeof(RemotingServiceMethod))]
		public ArrayList Methods{ get{ return _methods; } }

		public bool Checked
		{
			get { return _checked; }
			set { _checked = value; }
		}
	}
}
