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
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace FluorineFx.Management.Data
{
	/// <summary>
	/// Summary description for Domain.
	/// </summary>
	[Serializable]
	public class DataDomain : NamedObject
	{
        private DomainUrl _domainUrl;
        private Table[] _tables;
        private string _connectionType;
        private string _provider;
        private string _connectionString;


		public DataDomain() : this(string.Empty)
		{
		}

		public DataDomain(string url) : base(url)
		{
			_domainUrl = new DomainUrl(url);
			_tables = new Table[0];
		}

		public DataDomain(DomainUrl domainUrl) : base(domainUrl.Host)
		{
			_domainUrl = domainUrl;
			_tables = new Table[0];
		}

		public DomainUrl DomainUrl
		{
			get { return _domainUrl; }
			set { _domainUrl = value; }
		}

        [XmlIgnore]
        public string Url
        {
            get 
            { 
                if( DomainUrl != null )
                    return DomainUrl.Url;
                return null;
            }
        }

		public string ConnectionType
		{
			get { return _connectionType; }
			set { _connectionType = value; }
		}

		[XmlElement(Type = typeof(Table))]
		public Table[] Tables
		{ 
			get{ return _tables; } 
			set{ _tables = value; }
		}

		public void AddTable(Table table)
		{
			Table[] tempReDim = new Table[_tables.Length+1];
			Array.Copy(_tables, tempReDim, _tables.Length);
			_tables = tempReDim;
			_tables[_tables.Length-1] = table;
		}

		[Transient]
		public Table this[string tableName]
		{
			get
			{
				foreach(Table table in _tables)
				{
					if( table.Name == tableName )
						return table;
				}
				return null;
			}
		}

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        public string Provider
        {
            get{ return _provider; }
            set{ _provider = value; }
        }

        
	}
}
