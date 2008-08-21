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
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace FluorineFx.Management.Data.Database.MySql
{
	/// <summary>
	/// Summary description for MySqlDomainBuilder.
	/// </summary>
	class MySqlDomainBuilder : DomainBuilder
	{
		public MySqlDomainBuilder(Driver accessDriver) : base(accessDriver)
		{
		}

		public override DataDomain BuildDomain()
		{
			DataDomain domain = new DataDomain(this.Driver.DomainUrl);

			using(MySqlConnection connection = this.Driver.OpenConnection() as MySqlConnection )
			{
				string commandTextTables = string.Format("SELECT Table_Name FROM information_schema.TABLES WHERE Table_Schema=\"{0}\" AND Table_Type=\"Base Table\"", this.Driver.DomainUrl.Database);
				MySqlCommand command = new MySqlCommand(commandTextTables, connection);

				using(IDataReader reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						string tableName = reader.GetString(0);
						Table table = new Table(tableName);
						domain.AddTable(table);
					}
				}

				string commandTextColumns = string.Format("SELECT table_catalog,table_schema,table_name,column_name,is_nullable,data_type,extra,column_type,column_key,character_maximum_length,numeric_precision,numeric_scale FROM information_schema.COLUMNS WHERE table_schema=\"{0}\"", this.Driver.DomainUrl.Database);
				command = new MySqlCommand(commandTextColumns, connection);

				using (IDataReader reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						string tableName = reader.GetString(2);//"TABLE_NAME"
						Table table = domain[tableName];

						if( table != null )
						{
							Column column = new Column();
							column.Name = reader.GetString(3);//"COLUMN_NAME"
							string dataType = reader.GetString(5);//"DATA_TYPE"
                            MySqlDbType mySqlDbType = (MySqlDbType)Enum.Parse(typeof(MySqlDbType), dataType);
                            column.OriginalSQLType = mySqlDbType.ToString();

							if(_sqlTypesDictionary.Contains(dataType))
								column.SqlType = (SqlType)_sqlTypesDictionary[dataType];
							else
								column.SqlType = SqlType.Unknown;

                            if (_netDataTypes.ContainsKey(column.SqlType))
                            {
                                column.NetDataType = (string)_netDataTypes[column.SqlType];
                                column.ActionScriptType = TypeMapper.GetActionScriptType(_netDataTypes[column.SqlType] as string);
                            }
                            else
                                column.NetDataType = "unknown";

							if ((column.SqlType == SqlType.Char) ||
								(column.SqlType == SqlType.AnsiChar) ||
								(column.SqlType == SqlType.VarChar) ||
								(column.SqlType == SqlType.AnsiVarChar) ||
								(column.SqlType == SqlType.Text) ||
								(column.SqlType == SqlType.Binary) ||
								(column.SqlType == SqlType.VarBinary))
							{
								column.Length = reader.GetInt32(9);//"CHARACTER_MAXIMUM_LENGTH";
							}
							else if (column.SqlType == SqlType.Decimal)
							{
								column.Precision = reader.GetByte(10);//numeric_precision
								column.Scale = reader.GetInt32(11);//"NUMERIC_SCALE"
							}

                            if ((column.SqlType == SqlType.Binary) ||
                                (column.SqlType == SqlType.VarBinary))
                            {
                                column.IsBlob = true;
                            }

							if (column.Length == -1)
							{
								switch (column.SqlType)
								{
									case SqlType.VarChar:
										column.SqlType = SqlType.VarCharMax;
										column.Length = 0;
										break;
									case SqlType.AnsiVarChar:
										column.SqlType = SqlType.AnsiVarCharMax;
										column.Length = 0;
										break;
									case SqlType.VarBinary:
										column.SqlType = SqlType.VarBinaryMax;
										column.Length = 0;
										break;
									default:
										break;
								}
							}

							if( !reader.IsDBNull(4) )//IS_NULLABLE
							{
								string tmp = reader.GetString(4);
								column.IsNullable = ("yes" == tmp.ToLower());
							}

							if( !reader.IsDBNull(6) )//"extra"
							{
								string tmp = reader.GetString(6);
								column.IsIdentity = ("auto_increment" == tmp.ToLower());
							} 

							table.AddColumn(column);
						}
					}
				}

				string commandTextKeys = string.Format("SELECT kcu.TABLE_SCHEMA, kcu.TABLE_NAME, kcu.CONSTRAINT_NAME, tc.CONSTRAINT_TYPE, kcu.COLUMN_NAME, kcu.ORDINAL_POSITION from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu ON kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA and kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME and kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA and kcu.TABLE_NAME = tc.TABLE_NAME WHERE ((tc.CONSTRAINT_TYPE = 'PRIMARY KEY') and (kcu.TABLE_SCHEMA =\"{0}\" )) order by kcu.TABLE_SCHEMA, kcu.TABLE_NAME, tc.CONSTRAINT_TYPE, kcu.CONSTRAINT_NAME, kcu.ORDINAL_POSITION", this.Driver.DomainUrl.Database);
				command = new MySqlCommand(commandTextKeys, connection);

				using (IDataReader reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						string tableName = reader.GetString(1);//"TABLE_NAME"
						Table table = domain[tableName];
						if( table != null )
						{
							string columnName = reader.GetString(4);//"COLUMN_NAME"
							Column column = table[columnName];
							if( column != null )
								column.IsPrimaryKey = true;
						}
					}
				}
			}
			return domain;
		}
	}
}
