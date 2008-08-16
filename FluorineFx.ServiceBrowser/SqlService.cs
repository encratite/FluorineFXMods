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
using System.IO;
using System.Collections;
using System.Web;
using System.Web.Caching;

using FluorineFx;
using FluorineFx.Configuration;
using FluorineFx.Context;
using FluorineFx.Management;
using FluorineFx.Management.Data;
using FluorineFx.Management.Data.Database;
using FluorineFx.Management.Data.Database.Access;
using FluorineFx.Management.Data.Database.OleDb;
using FluorineFx.Management.Web;

namespace FluorineFx.ServiceBrowser
{
    /// <summary>
    /// SqlService.
    /// </summary>
    [RemotingService("FluorineFx SqlService")]
    public class SqlService
    {
        public object SubmitQuery(string url, string sql)
        {
            Hashtable result = new Hashtable();
            try
            {
                DomainUrl domainUrl = new DomainUrl(url);
                Driver driver = DriverFactory.GetDriver(domainUrl);
                using (IDbConnection dbConnection = driver.OpenConnection())
                {
                    IDbCommand command = driver.GetDbCommand(sql, dbConnection);
                    IDbDataAdapter adapter = driver.GetDbDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    ASObject asoResult = new ASObject();
                    DataTable dataTable = dataSet.Tables[0];
                    ArrayList rows = new ArrayList(dataTable.Rows.Count);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow dataRow = dataTable.Rows[i];
                        ASObject asoRow = new ASObject();
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            DataColumn column = dataTable.Columns[j];
                            asoRow.Add(column.ColumnName, dataRow[column]);
                        }
                        rows.Add(asoRow);
                    }
                    result["result"] = rows;
                }
            }
            catch (Exception ex)
            {
                result["message"] = ex.Message;
            }
            return result;
        }

        public object ParseQuery(string url, string sql)
        {
            ASObject aso = new ASObject();
            try
            {
                FluorineFx.ServiceBrowser.Sql.ISqlScript sqlScript = FluorineFx.ServiceBrowser.Sql.SqlParserService.Parse(sql);
                aso["message"] = "Sql statement was parsed and found to be a valid";
            }
            catch (antlr.RecognitionException ex)
            {
                aso["message"] = "The specified SQL statement failed to be parsed: " + ex.ToString();
            }
            catch (Exception ex)
            {
                aso["message"] = "The specified SQL statement failed to be parsed: " + ex.Message;
            }
            return aso;
        }
    }
}
