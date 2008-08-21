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
using FluorineFx;

namespace FluorineFx.Management.Data
{
	/// <summary>
	/// Summary description for Table.
	/// </summary>
	[Serializable]
	public class Table : NamedObject
	{
		private string		_catalog = null;
		private string		_schema = null;
		private bool		_isTable;
		private Column[]	_columns;

		private bool		_checked;

		public Table() : base(string.Empty)
		{
			_columns = new Column[0];
			_checked = true;
		}

		public Table(string name) : base(name)
		{
            _schema = name;
            _columns = new Column[0];
			_checked = true;
		}

		public void AddColumn(Column column)
		{
			Column[] tempReDim = new Column[_columns.Length+1];
			Array.Copy(_columns, tempReDim, _columns.Length);
			_columns = tempReDim;
			_columns[_columns.Length-1] = column;
		}

		/// <summary>
		/// Get/Set the catalog of this table as read from the database.
		/// </summary>
		public string Catalog
		{
			get { return _catalog; }
			set { _catalog = value; }
		}

		/// <summary>
		/// Get/Set the Schema of this table as read from the database.
		/// </summary>
		public string Schema
		{
			get { return _schema; }
			set { _schema = value; }
		}

		/// <summary>
		/// Is view or is table type
		/// </summary>
		public bool IsTable
		{
			get { return _isTable; }
			set { _isTable = value; }
		}

		public bool Checked
		{
			get { return _checked; }
			set { _checked = value; }
		}

		[XmlElement(Type = typeof(Column))]
		public Column[] Columns
		{ 
			get{ return _columns; } 
			set{ _columns = value; }
		}

		/// <summary>
		/// Returns the number of columns in this table.
		/// </summary>
		public int ColumnCount
		{
			get
			{
				return _columns.Length;
			}
		}

		[Transient]
		public Column this[ string columnName ]
		{
			get
			{
				string tempColumnName = columnName.ToLower();
				for( int i = 0 ; i < _columns.Length ; i ++ )
				{
					if( (_columns[i] as Column).Name.ToLower() == tempColumnName )
						return _columns[i];
				}

				return null;
			}
		}

		public string SafeName
		{
			get{ return Util.GetSafeString(this.Name); }
		}

        public Column GetIdentityColumn()
        {
            for (int i = 0; i < _columns.Length; i++)
            {
                if (_columns[i].IsIdentity)
                    return _columns[i];
            }

            return null;
        }

        public Column[] GetPrimaryKeys()
        {
            ArrayList columns = new ArrayList();
            for (int i = 0; i < _columns.Length; i++)
            {
                if (_columns[i].IsPrimaryKey)
                    columns.Add(_columns[i]);
            }
            return columns.ToArray(typeof(Column)) as Column[];
        }
	}
}
