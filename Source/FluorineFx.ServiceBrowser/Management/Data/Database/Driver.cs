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

namespace FluorineFx.Management.Data.Database
{
    /// <summary>
    /// Summary description for Driver.
    /// </summary>
    public abstract class Driver
    {
        DomainUrl _url;

        public Driver(DomainUrl url)
        {
            _url = url;
        }

        public DomainUrl DomainUrl { get { return _url; } }

        public IDbConnection OpenConnection()
        {
            IDbConnection connection = CreateConnection();
            connection.Open();
            ConfigureConnection(connection);
            return connection;
        }

        public abstract IDbConnection CreateConnection();

        public abstract void ConfigureConnection(IDbConnection connection);

        public abstract IDbDataAdapter GetDbDataAdapter();

        public abstract IDbCommand GetDbCommand(string cmdText, IDbConnection connection);

        public abstract string ConnectionClass { get; }
        public abstract string CommandClass { get; }
        public abstract string DataReaderClass { get; }

        public virtual string GetDataReaderAccessor(Column column)
        {
            switch (column.SqlType)
            {
                case SqlType.AnsiChar:
                case SqlType.AnsiText:
                case SqlType.AnsiVarChar:
                case SqlType.AnsiVarCharMax:
                case SqlType.Char:
                case SqlType.Text:
                case SqlType.VarChar:
                case SqlType.VarCharMax:
                    return "GetString";
                case SqlType.Binary:
                    break;
                case SqlType.Boolean:
                    return "GetBoolean";
                case SqlType.Byte:
                    return "GetByte";
                case SqlType.DateTime:
                case SqlType.SmallDateTime:
                    return "GetDateTime";
                case SqlType.Decimal:
                    return "GetDecimal";
                case SqlType.Double:
                    return "GetDouble";
                case SqlType.Float:
                    return "GetFloat";
                case SqlType.GUID:
                    return "GetGuid";
                case SqlType.Image:
                    break;
                case SqlType.Int16:
                case SqlType.UInt16:
                    return "GetInt16";
                case SqlType.Int32:
                case SqlType.UInt32:
                    return "GetInt32";
                case SqlType.Int64:
                case SqlType.UInt64:
                    return "GetInt64";
                case SqlType.Money:
                case SqlType.SmallMoney:
                    break;
                case SqlType.SByte:
                    return "GetByte";
                case SqlType.TimeStamp:
                    return "GetDouble";
            }
            return string.Empty;
        }

        public abstract string IdentityQuery { get; }

        public abstract string GetCommand(Column column, string parameterName, ParameterDirection parameterDirection, DataRowVersion dataRowVersion, bool isNullable);
    }
}
