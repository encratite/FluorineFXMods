/*
	Fluorine .NET Flash Remoting Gateway open source library 
	Copyright (C) 2005 Zoltan Csibi, zoltan@TheSilentGroup.com
	
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
using System.Data;
using System.Collections;
using System.Reflection;

using FluorineFx;
using FluorineFx.AMF3;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[RemotingService("Fluorine Diagnostic service")]
	public class DiagnosticService
	{
		/// <summary>
		/// Initializes a new instance of the DiagnosticService class.
		/// </summary>
		public DiagnosticService()
		{
		}

		public ASObject GetInformation()
		{
			ASObject info = new ASObject();
			info["name"] = "Fluorine .NET Flash Remoting Gateway";
			info["version"] = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			return info;
		}

		#region Echo

		public int EchoInteger(int value)
		{
			return value;
		}

		public double EchoDouble(double value)
		{
			return value;
		}

		public string EchoString(string value)
		{
			return value;
		}

		public DateTime EchoDate(DateTime value)
		{
			return value;
		}

		public Guid EchoGuid(Guid value)
		{
			return value;
		}

		public object EchoObject(object value)
		{
			return value;
		}

		public ByteArray EchoByteArray(ByteArray value)
		{
			return value;
		}

		public byte[] EchoByteArrayEx(byte[] value)
		{
			return value;
		}

		public IExternalizable EchoExternalizable(IExternalizable value)
		{
			return value;
		}

		public Array EchoArray(Array value)
		{
			return value;
		}

		public IList EchoList(IList value)
		{
			return value;
		}

		public XmlDocument EchoXmlDocument(XmlDocument value)
		{
			return value;
		}

		public ASObject EchoASObject(ASObject value)
		{
			return value;
		}

		public IDictionary EchoDictionary(IDictionary value)
		{
			return value;
		}

		#endregion Echo

		#region Data

		private DataSet _GetDataSet()
		{
			DataSet dataSet = new DataSet("mydataset");
			DataTable dataTable = dataSet.Tables.Add("mytable");
			dataTable.Columns.Add( "Col1" );
			dataTable.Columns.Add( "Col2" );
			dataTable.Rows.Add( new object[] {"cell1", 25} );
			dataTable.Rows.Add( new object[] {"cell1", 35} );
			return dataSet;
		}

		public DataTable GetDataTable()
		{
			return _GetDataSet().Tables["mytable"];
		}

		public DataSet GetDataSet()
		{
			return _GetDataSet();
		}

		[DataTableType("DataTable")]
		public DataTable GetDataTableAsArrayCollection()
		{
			return _GetDataSet().Tables["mytable"];
		}

		[DataSetType("DataSet")]
		[DataTableType("mytable", "DataTable")]
		public DataSet GetDataSetAsArrayCollection()
		{
			return _GetDataSet();
		}

		#endregion Echo

		#region Typed Object
		
		public class UserVO
		{
			public int userid;
			public string username;
			public EmailVO email;
			
			public UserVO()
			{
				userid = 0;
				username = null;
				email = null;
			}
		}

		public class EmailVO
		{
			private string _emailaddress;

			public string emailaddress
			{
				get{ return _emailaddress; }
				set{ _emailaddress = value; }
			}
		}

		public UserVO GetUser()
		{
			UserVO user = new UserVO();
			user.userid = 1;
			user.username = "User";
			EmailVO email = new EmailVO();
			email.emailaddress = "someaddress@com";
			user.email = email;
			return user;
		}

		public UserVO EchoUser(UserVO user)
		{
			return user;
		}

		#endregion Typed Object
	}
}
