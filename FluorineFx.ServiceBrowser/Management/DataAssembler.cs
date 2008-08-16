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
using System.Text;
using System.Collections;
using System.Reflection;
using System.Xml.Serialization;
using FluorineFx.Management.Data;
using FluorineFx.ServiceBrowser.Sql;

namespace FluorineFx.Management
{
    [Serializable]
    public class DataAssembler : NamedObject
    {
        string _domainUrl;
        string _select;
        Table _table;

        public Table Table
        {
            get { return _table; }
            set { _table = value; }
        }

        public string Select
        {
            get { return _select; }
            set { _select = value; }
        }

        public string DomainUrl
        {
            get { return _domainUrl; }
            set { _domainUrl = value; }
        }

        public DataAssembler()
        {
        }

        internal DataAssembler(string domainUrl, Table table, string select)
            : base(table.Name + " Assembler")
        {
            _domainUrl = domainUrl;
            _select = select;
            _table = table;
        }


        public static DataAssembler FromQuery(DataDomain dataDomain, string query)
        {
            ISqlScript sqlScript = SqlParserService.Parse(query);
            if (sqlScript.Statements != null && sqlScript.Statements.Count > 0)
            {
                ISqlStatement statement = sqlScript.Statements[0];
                if (statement is ISelectStatement)
                {
                    ISelectStatement selectStatement = statement as ISelectStatement;
                    if (selectStatement.Tables != null && selectStatement.Tables.Count > 0)
                    {
                        SqlTable sqlTable = selectStatement.Tables[0];
                        Table table = dataDomain[sqlTable.Name];
                        DataAssembler dataAssembler = new DataAssembler(dataDomain.DomainUrl.Url, table, query);
                        return dataAssembler;
                    }
                }
            }
            return null;
        }

        public Column GetIdentityColumn()
        {
            if( _table != null )
                return _table.GetIdentityColumn();
            return null;
        }

        public Column[] GetPrimaryKeys()
        {
            if (_table != null)
                return _table.GetPrimaryKeys();
            return null;
        }

        public ColumnCollection GetColumns()
        {
            ColumnCollection columns = new ColumnCollection();
            ISqlScript sqlScript = SqlParserService.Parse(_select);
            if (sqlScript.Statements != null && sqlScript.Statements.Count > 0)
            {
                ISqlStatement statement = sqlScript.Statements[0];
                if (statement is ISelectStatement)
                {
                    ISelectStatement selectStatement = statement as ISelectStatement;
                    if (selectStatement.QueryExpression != null && selectStatement.QueryExpression is ISelectExpression)
                    {
                        ISelectExpression selectExpression = selectStatement.QueryExpression as ISelectExpression;
                        for (int i = 0; i < selectExpression.SelectList.Count; i++)
                        {
                            SelectColumn selectColumn = selectExpression.SelectList[i];
                            Column column = _table[selectColumn.Name];
                            if (column != null)
                                columns.Add(column);
                        }
                    }
                }
            }
            return columns;
        }

        public string GetDeleteCommandText(bool optimisticConcurrency)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ");
            sb.Append("`");
            sb.Append(_table.Name);
            sb.Append("`");
            sb.Append(" WHERE ");
            sb.Append(" ( ");
            Column[] columns = _table.Columns;
            for (int i = 0; i < columns.Length; i++)
            {
                Column column = columns[i];
                if (!column.IsBlob)
                {
                    if (i > 0)
                        sb.Append(" AND ");
                    sb.Append("(");
                    if (!column.IsNullable)
                    {
                        sb.Append("`");
                        sb.Append(column.Name);
                        sb.Append("`");
                        sb.Append(" = ?");
                    }
                    else
                    {
                        sb.Append("(");
                        sb.Append("? = 1 AND");
                        sb.Append("`");
                        sb.Append(column.Name);
                        sb.Append("`");
                        sb.Append(" IS NULL");
                        sb.Append(")");
                        sb.Append(" OR ");
                        sb.Append("(");
                        sb.Append("`");
                        sb.Append(column.Name);
                        sb.Append("`");
                        sb.Append(" = ?");
                        sb.Append(")");
                    }
                    sb.Append(")");
                }
            }
            sb.Append(" ) ");
            return sb.ToString();
        }

        public string GetInsertCommandText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append("`");
            sb.Append(_table.Name);
            sb.Append("`");
            sb.Append(" ");
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbColumns.Append(" ( ");
            sbValues.Append(" ( ");
            Column[] columns = _table.Columns;
            for (int i = 0; i < columns.Length; i++)
            {
                Column column = columns[i];
                if (column.IsIdentity)
                    continue;
                if (!column.IsBlob)
                {
                    if (i > 0)
                    {
                        sbColumns.Append(", ");
                        sbValues.Append(", ");
                    }
                    sbColumns.Append("`");
                    sbColumns.Append(column.Name);
                    sbColumns.Append("`");
                    sbValues.Append("?");
                }
            }
            sbColumns.Append(" ) ");
            sbValues.Append(" ) ");
            sb.Append(sbColumns.ToString());
            sb.Append(" VALUES ");
            sb.Append(sbValues.ToString());
            return sb.ToString();
        }

        public string GetUpdateCommandText(bool optimisticConcurrency)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ");
            sb.Append("`");
            sb.Append(_table.Name);
            sb.Append("`");
            sb.Append(" SET ");
            Column[] columns = _table.Columns;
            for (int i = 0; i < columns.Length; i++)
            {
                Column column = columns[i];
                if (column.IsIdentity)
                    continue;
                if (!column.IsBlob)
                {
                    if (i > 0)
                        sb.Append(", ");
                    sb.Append("`");
                    sb.Append(column.Name);
                    sb.Append("`");
                    sb.Append(" = ?");
                }
            }
            if (!optimisticConcurrency)
            {
				Column identityColumn = GetIdentityColumn();
                if (identityColumn != null)
                {
                    sb.Append(" WHERE ");
                    sb.Append("`");
                    sb.Append(identityColumn.Name);
                    sb.Append("`");
                    sb.Append(" = ?");
                    return sb.ToString();
                }
                Column[] primaryKeys = GetPrimaryKeys();
                if (primaryKeys != null && primaryKeys.Length > 0)
                {
                    sb.Append(" WHERE ");
                    for (int i = 0; i < primaryKeys.Length; i++)
                    {
                        Column column = primaryKeys[i];
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append("`");
                        sb.Append(column.Name);
                        sb.Append("`");
                        sb.Append(" = ?");
                    }
                }
                return sb.ToString();
            }
            else
            {
                sb.Append(" WHERE ");
                for (int i = 0; i < columns.Length; i++)
                {
                    Column column = columns[i];

                    if (!column.IsBlob)
                    {
                        if (i > 0)
                            sb.Append(" AND ");
                        sb.Append("(");
                        if (!column.IsNullable)
                        {
                            sb.Append("`");
                            sb.Append(column.Name);
                            sb.Append("`");
                            sb.Append(" = ?");
                        }
                        else
                        {
                            sb.Append("(");
                            sb.Append("? = 1 AND");
                            sb.Append("`");
                            sb.Append(column.Name);
                            sb.Append("`");
                            sb.Append(" IS NULL");
                            sb.Append(")");
                            sb.Append(" OR ");
                            sb.Append("(");
                            sb.Append("`");
                            sb.Append(column.Name);
                            sb.Append("`");
                            sb.Append(" = ?");
                            sb.Append(")");
                        }
                        sb.Append(")");
                    }
                }
                return sb.ToString();
            }
        }
    }
}
