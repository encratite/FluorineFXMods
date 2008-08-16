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
using System.Data.OleDb;

using FluorineFx.Management.Data;

namespace FluorineFx.Management.Data.Database.OleDb
{
	/// <summary>
	/// Summary description for AccessDomainBuilder.
	/// </summary>
	public class OleDbDomainBuilder : DomainBuilder
	{

		public OleDbDomainBuilder(Driver accessDriver) : base(accessDriver)
		{
			_sqlTypesDictionary.Add(typeof(System.Boolean), SqlType.Boolean);
			_sqlTypesDictionary.Add(typeof(System.Byte), SqlType.Byte);
			_sqlTypesDictionary.Add(typeof(System.DateTime), SqlType.DateTime);
			_sqlTypesDictionary.Add(typeof(System.Decimal), SqlType.Decimal);
			_sqlTypesDictionary.Add(typeof(System.Double), SqlType.Double);
			_sqlTypesDictionary.Add(typeof(System.Guid), SqlType.GUID);
			_sqlTypesDictionary.Add(typeof(System.Int16), SqlType.Int16);
			_sqlTypesDictionary.Add(typeof(System.Int32), SqlType.Int32);
			_sqlTypesDictionary.Add(typeof(System.String), SqlType.VarChar);
			_sqlTypesDictionary.Add(typeof(System.Byte[]), SqlType.VarBinary);

			_sqlTypesDictionary.Add(OleDbType.Binary, SqlType.Binary);
			_sqlTypesDictionary.Add(OleDbType.Boolean, SqlType.Boolean);
			_sqlTypesDictionary.Add(OleDbType.TinyInt, SqlType.Byte);
			_sqlTypesDictionary.Add(OleDbType.Date, SqlType.DateTime);
			_sqlTypesDictionary.Add(OleDbType.Numeric, SqlType.Decimal);
			_sqlTypesDictionary.Add(OleDbType.Decimal, SqlType.Decimal);
			_sqlTypesDictionary.Add(OleDbType.Double, SqlType.Double);
			_sqlTypesDictionary.Add(OleDbType.Guid, SqlType.GUID);
			_sqlTypesDictionary.Add(OleDbType.SmallInt, SqlType.Int16);
			_sqlTypesDictionary.Add(OleDbType.Integer, SqlType.Int32);
			_sqlTypesDictionary.Add(OleDbType.VarBinary, SqlType.VarBinary);
			_sqlTypesDictionary.Add(OleDbType.VarChar, SqlType.VarChar);
			_sqlTypesDictionary.Add(OleDbType.WChar, SqlType.VarChar);
		}

		public override DataDomain BuildDomain()
		{
			DataDomain domain = new DataDomain(this.Driver.DomainUrl);

			using(IDbConnection connection = this.Driver.OpenConnection() )
			{
				DataTable schemaTable = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[0]);
				DataColumn tableTypeColumn = schemaTable.Columns["TABLE_TYPE"];
				DataColumn tableNameColumn = schemaTable.Columns["TABLE_NAME"];

				foreach(DataRow schemaRowTable in schemaTable.Rows)
				{
					if (string.Compare(schemaRowTable[tableTypeColumn].ToString(), "TABLE") == 0)
					{
						string tableName = schemaRowTable[tableNameColumn].ToString();
						Table table = new Table(tableName);

						DataTable schemaColumns = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName });
						DataColumn ordinalPosition = schemaColumns.Columns["ORDINAL_POSITION"];
						DataColumn dataType = schemaColumns.Columns["DATA_TYPE"];
						DataColumn columnNameColumn = schemaColumns.Columns["COLUMN_NAME"];
						DataColumn numericPrecisionColumn = schemaColumns.Columns["NUMERIC_PRECISION"];
						DataColumn allowDBNull = schemaColumns.Columns["IS_NULLABLE"];
						DataColumn columnSize = schemaColumns.Columns["CHARACTER_MAXIMUM_LENGTH"];
						DataColumn numericScale = schemaColumns.Columns["NUMERIC_SCALE"];
                        DataColumn descriptionColumn = schemaColumns.Columns["DESCRIPTION"];
						schemaColumns.DefaultView.Sort = ordinalPosition.ColumnName;
						foreach (DataRowView schemaRowColumn in schemaColumns.DefaultView)
						{
							string columnName = schemaRowColumn[columnNameColumn.Ordinal].ToString();

							Column column = new Column(columnName);
							column.IsNullable = (bool)schemaRowColumn[allowDBNull.Ordinal];
							OleDbType oleDbType = (OleDbType)schemaRowColumn[dataType.Ordinal];
							column.OriginalSQLType = oleDbType.ToString();

							if(_sqlTypesDictionary.Contains(oleDbType))
								column.SqlType = (SqlType)_sqlTypesDictionary[oleDbType];
							else
								column.SqlType = SqlType.Unknown;

                            if (_netDataTypes.ContainsKey(column.SqlType))
                            {
                                column.NetDataType = (string)_netDataTypes[column.SqlType];
                                column.ActionScriptType = TypeMapper.GetActionScriptType(_netDataTypes[column.SqlType] as string);
                            }
                            else
                                column.NetDataType = "unknown";

							if( schemaRowColumn[numericPrecisionColumn.Ordinal] != DBNull.Value )
								column.Length = Convert.ToInt32(schemaRowColumn[numericPrecisionColumn.Ordinal]);

							if((column.SqlType == SqlType.VarChar) || (column.SqlType == SqlType.VarBinary) || (column.SqlType == SqlType.Binary) )
							{
								column.Length = Convert.ToInt32(schemaRowColumn[columnSize.Ordinal]);
                                if (column.SqlType == SqlType.VarChar)
                                {
                                    column.SqlType = SqlType.Text;
                                    //column.Length = 0;
                                }
                                else
                                    column.IsBlob = true;
							}
							else if (column.SqlType == SqlType.Decimal)
							{
								column.Length = Convert.ToInt32(schemaRowColumn[numericPrecisionColumn.Ordinal]);
								column.Scale = Convert.ToInt32(schemaRowColumn[numericScale.Ordinal]);
							}

                            if (schemaRowColumn[descriptionColumn.Ordinal] != DBNull.Value)
                            {
                                string description = schemaRowColumn[descriptionColumn.Ordinal] as string;
                                if (description == "AutoNumber")
                                    column.IsIdentity = true;
                            }

							table.AddColumn(column);
						}

						DataTable schemaPrimaryKeys = ((OleDbConnection)connection).GetOleDbSchemaTable( OleDbSchemaGuid.Primary_Keys, new object [] { null, null, tableName});
						DataColumn pkColumnNameColumn = schemaColumns.Columns["COLUMN_NAME"];
						foreach (DataRowView schemaRowPK in schemaPrimaryKeys.DefaultView)
						{
							string columnName = (string)schemaRowPK[pkColumnNameColumn.Ordinal];
							Column column = table[ columnName ];
							if( column != null )
								column.IsPrimaryKey = true;
						}

						domain.AddTable(table);
					}
				}

				foreach(DataRow schemaRowTable in schemaTable.Rows)
				{
					if (string.Compare(schemaRowTable[tableTypeColumn].ToString(), "TABLE") == 0)
					{
						string tableName = schemaRowTable[tableNameColumn].ToString();

						DataTable schemaForeignKeys = ((OleDbConnection)connection).GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new object[0]);
						DataColumn constraintName = schemaForeignKeys.Columns["FK_NAME"];
						DataColumn columnOrdinal = schemaForeignKeys.Columns["ORDINAL"];
						DataColumn childTableName = schemaForeignKeys.Columns["FK_TABLE_NAME"];
						DataColumn parentColumnName = schemaForeignKeys.Columns["FK_COLUMN_NAME"];
						DataColumn updateRule = schemaForeignKeys.Columns["UPDATE_RULE"];
						DataColumn deleteRule = schemaForeignKeys.Columns["DELETE_RULE"];
						DataColumn parentTableName = schemaForeignKeys.Columns["PK_TABLE_NAME"];
						DataColumn childColumnName = schemaForeignKeys.Columns["PK_COLUMN_NAME"];

						schemaForeignKeys.DefaultView.Sort = constraintName + "," + columnOrdinal.ColumnName;
						schemaForeignKeys.DefaultView.RowFilter = childTableName.ColumnName + " = '" + tableName + "'";

						foreach (DataRowView schemaRowFK in schemaForeignKeys.DefaultView)
						{
							string parentTable = schemaRowFK[parentTableName.Ordinal].ToString();
							string primaryKeyColumnName = schemaRowFK[childColumnName.Ordinal].ToString();
						}
					}
				}
			}

			return domain;
		}

	}
}
