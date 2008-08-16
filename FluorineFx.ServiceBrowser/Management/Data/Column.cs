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
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace FluorineFx.Management.Data
{
	/// <summary>
	/// Summary description for Column.
	/// </summary>
	[Serializable]
	public class Column : NamedObject
	{
        private bool _isPrimaryKey;
        private bool _isForeignKey = false;
        private bool _isIdentity;
        private bool _isNullable;
        private bool _isBlob;

        private string _netDataType;
        private ActionScriptType _actionScriptType;
        private SqlType _sqlType;
        private int _length;
        private int _precision;
        private int _scale;
        private string _defaultValue;
        private string _originalSQLType;

		public Column() : this(string.Empty)
		{
		}

		public Column(string name) : base(name)
		{
            _actionScriptType = TypeMapper.Object;
            _netDataType = "object";
		}

		public bool IsPrimaryKey
		{
			get { return _isPrimaryKey; }
			set { _isPrimaryKey = value; }
		}

		public bool IsForeignKey
		{
			get { return _isForeignKey; }
		}

		public bool IsIdentity
		{
			get { return _isIdentity; }
			set { _isIdentity = value; }
		}

		public bool IsNullable
		{
            get { return _isNullable; }
            set { _isNullable = value; }
		}

		public string NetDataType
		{
			get { return _netDataType; }
			set { _netDataType = value; }
		}

        public ActionScriptType ActionScriptType
        {
            get { return _actionScriptType; }
            set { _actionScriptType = value; }
        }

		public SqlType SqlType
		{
			get { return _sqlType; }
			set { _sqlType = value; }
		}


		public int Length
		{
			get { return _length; }
			set { _length = value; }
		}

		public int Precision
		{
			get { return _precision; }
			set { _precision = value; }
		}

		public int Scale
		{
			get { return _scale; }
			set { _scale = value; }
		}

		public String DefaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}

		public String OriginalSQLType
		{
			get { return _originalSQLType; }
			set { _originalSQLType = value; }
		}

        public bool IsBlob
        {
            get { return _isBlob; }
            set { _isBlob = value; }
        }

		public string SafeName
		{
			get{ return Util.GetSafeString(this.Name); }
		}

        [XmlIgnore]
        public string CamelCase
        {
            get
            {
                if (char.IsUpper(this.SafeName[0]))
                    return char.ToLower(this.SafeName[0]) + this.SafeName.Substring(1);
                return this.SafeName;
            }
        }
	}
}
