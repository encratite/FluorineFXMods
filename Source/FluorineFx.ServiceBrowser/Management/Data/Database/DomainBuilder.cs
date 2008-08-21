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

namespace FluorineFx.Management.Data.Database
{
	/// <summary>
	/// Summary description for DomainBuilder.
	/// </summary>
	public abstract class DomainBuilder
	{
		private Driver			_driver;
		protected Hashtable		_netDataTypes;
		protected Hashtable		_sqlTypesDictionary;


		public DomainBuilder(Driver driver)
		{
			_driver = driver;

			_netDataTypes = new Hashtable();
			_netDataTypes.Add(SqlType.AnsiText, "System.String");
			_netDataTypes.Add(SqlType.AnsiChar, "System.String");
			_netDataTypes.Add(SqlType.AnsiVarChar, "System.String");
			_netDataTypes.Add(SqlType.AnsiVarCharMax, "System.String");
			_netDataTypes.Add(SqlType.Byte, "System.Byte");
			_netDataTypes.Add(SqlType.Binary, "System.Byte[]");
			_netDataTypes.Add(SqlType.Boolean, "System.Boolean");
			_netDataTypes.Add(SqlType.Char, "System.String");
			_netDataTypes.Add(SqlType.DateTime, "System.DateTime");
			_netDataTypes.Add(SqlType.Decimal, "System.Decimal");
			_netDataTypes.Add(SqlType.Double, "System.Double");
			_netDataTypes.Add(SqlType.Float, "System.Double");
			_netDataTypes.Add(SqlType.GUID, "System.Guid");
			_netDataTypes.Add(SqlType.Int16, "System.Int16");
			_netDataTypes.Add(SqlType.Int32, "System.Int32");
			_netDataTypes.Add(SqlType.Int64, "System.Int64");
			_netDataTypes.Add(SqlType.Image, "System.Byte[]");
			_netDataTypes.Add(SqlType.Money, "System.Decimal");
			_netDataTypes.Add(SqlType.SmallDateTime, "System.DateTime");
			_netDataTypes.Add(SqlType.SmallMoney, "System.Decimal");
			_netDataTypes.Add(SqlType.Text, "System.String");
			_netDataTypes.Add(SqlType.TimeStamp, "System.DateTime");
			_netDataTypes.Add(SqlType.Unknown, "System.String");
			_netDataTypes.Add(SqlType.VarBinary, "System.Byte[]");
			_netDataTypes.Add(SqlType.VarBinaryMax, "System.Byte[]");
			_netDataTypes.Add(SqlType.VarChar, "System.String");
			_netDataTypes.Add(SqlType.VarCharMax, "System.String");

			_sqlTypesDictionary = new Hashtable();
		}

		public Driver Driver { get {return _driver; } }

		public abstract DataDomain BuildDomain();

	}
}
