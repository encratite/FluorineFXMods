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
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for Url.
	/// </summary>
	[Serializable]
	public class DomainUrl
	{
		protected string _url;
		protected string _user;
		protected string _password;
		protected string _database;
		protected string _host;
		protected string _protocol;
		protected int _port;
		protected ArrayList _parameters;


		public DomainUrl()
		{
			Clear();
		}
		/// <summary>
		/// Constructs an object from specified url.
		/// This will try to parse the url.
		/// </summary>
		/// <param name="url"></param>
		public DomainUrl(string url)
		{
			Clear();
			ParseUrl(url);
		}

		/// <summary>
		/// The database part of the url.
		/// Depending on url this can be:
		/// -name of the database to connect
		/// </summary>
		public string Database
		{
			get{ return _database; }
			set
			{ 
				if( _database != value )
				{
					_database = value; 
					//_url = string.Empty; 
				}
			}
		}
		/// <summary>
		/// The host part of the url.
		/// Depending on url this can be:
		/// -the DBMS server instance to connect
		/// -the web host to connect
		/// </summary>
		public string Host
		{
			get{ return _host; }
			set
			{ 
				if( _host != value )
				{
					_host = value;
					//_url = string.Empty;
				}
			}
		}
		/// <summary>
		/// Additional parameters specified in the url.
		/// </summary>
		[XmlElement(Type = typeof(UrlParameter))]		
		public ArrayList Parameters
		{
			get{ return _parameters; }
			set
			{ 
				if( _parameters != value )
				{
					_parameters = value;
					//_url = string.Empty;
				}
			}
		}
		/// <summary>
		/// Password specified in the url.
		/// </summary>
		public string Password
		{
			get{ return _password; }
			set
			{ 
				if( _password != value )
				{
					_password = value;
					//_url = string.Empty;
				}
			}
		}
		/// <summary>
		/// The port specified in the url.
		/// </summary>
		public int Port
		{
			get{ return _port; }
			set
			{ 
				if( _port != value )
				{
					_port = value;
					//_url = string.Empty;
				}
			}
		}
		/// <summary>
		/// The protocol specified in the url.
		/// The following protocols are accepted:
		/// http, mssql, oracle, db2.
		/// </summary>
		public string Protocol
		{
			get{ return _protocol; }
			set
			{
				if( _protocol != value )
				{
					_protocol = value;
					//_url = string.Empty;
				}
			}
		}
		/// <summary>
		/// The specified url.
		/// </summary>
		public string Url
		{
			get
			{ 
				string tempUrl = string.Empty;
				if( this.Protocol != null && this.Protocol != string.Empty )
				{
					tempUrl += this.Protocol + "://";
					if( this.User != null && this.User != string.Empty )
						tempUrl += string.Format("{0}:{1}@", this.User, this.Password);
					if( this.Host != null && this.Host != string.Empty )
						tempUrl += this.Host;
					if( this.Database !=  null && this.Database != string.Empty )
						tempUrl += string.Format("/{0}", this.Database);
					else
						tempUrl += "/";
				}
				return tempUrl;
				///todo: add parameters to url too
			}
			set
			{
				if( _url != value )
				{
					ParseUrl(value);
				}
			}
		}
		/// <summary>
		/// The user specified in the url.
		/// <b>Note</b> If the url represents a database connection and 
		/// user\password was not specified than Windows NT Authentication is used.
		/// </summary>
		public string User
		{
			get{ return _user; }
			set
			{
				if( _user != value )
				{
					_user = value; /*_url = string.Empty;*/
				}
			}
		}

		/// <summary>
		/// Clear all members of this object.
		/// </summary>
		public void Clear()
		{
			this._url = "";
			this._protocol = "";
			this._host = "";
			this._port = 0;
			this._database = "";
			this._user = "";
			this._password = "";
			this._parameters = null;
		}

		private void InternalParseUrl(string url)
		{
			string tempUrl;
			Regex regex;
			Match match;
			string user;
			string password;
			string database;
			string host;
			string protocol;
			int port;
			string parameters;
			ArrayList parametersCollection;
			string parameterPart;
			string[] parameter;
			char[] separator;
			IEnumerator enumerator;
			try
			{
				tempUrl = url;
				if (tempUrl.Length == 0)
					tempUrl = ":///";
 
				regex = new Regex(@"^(?<protocol>[\w\%]*)://((?'username'[\w\%]*)(:(?'password'[\w\%]*))?@)?(?'host'[\w\.\(\)\-\%\\\$]*)(:?(?'port'\d+))?/(?'database'[^?]*)?(\?(?'params'.*))?");
				match = regex.Match(tempUrl);
				if (!match.Success)
					throw new ArgumentOutOfRangeException();

				user = HttpUtility.UrlDecode(match.Result("${username}"));
				password = HttpUtility.UrlDecode(match.Result("${password}"));
				database = HttpUtility.UrlDecode(match.Result("${database}"));
				host = HttpUtility.UrlDecode(match.Result("${host}"));
				protocol = HttpUtility.UrlDecode(match.Result("${protocol}"));
				port = 0;
				if (match.Result("${port}").Length != 0)
				{
					port = int.Parse(match.Result("${port}"));
 
				}
				if (port < 0 || port > 65535)
					throw new ArgumentOutOfRangeException("url", "This URL cannot be parsed. Invalid Port number.");
 
				parameters = match.Result("${params}");
				parametersCollection = new ArrayList();
				if( parameters != null && parameters != string.Empty )
				{
					separator = new char[1]{ '&' };
					string[] splittedParameters = parameters.Split(separator);
					enumerator = splittedParameters.GetEnumerator();
					while (enumerator.MoveNext())
					{
						parameterPart = ((string)enumerator.Current);
						separator = new char[1]{ '=' };
						parameter = parameterPart.Split(separator, 2);
						if (parameter.Length != 2)
						{
							throw new ArgumentOutOfRangeException("url", "This URL cannot be parsed. Invalid parameter.");

						}
						UrlParameter urlParameter = new UrlParameter(HttpUtility.UrlDecode(parameter[0]), HttpUtility.UrlDecode(parameter[1]));
						parametersCollection.Add(urlParameter); 
					}
				}
				this._url = url;
				this._user = user;
				this._password = password;
				this._database = database;
				this._host = host;
				this._protocol = protocol;
				this._port = port;
				this._parameters = parametersCollection; 
			}
			catch (Exception ex)
			{
				if(ex is ArgumentOutOfRangeException)
					throw;
				throw new ArgumentOutOfRangeException("url", "This URL cannot be parsed.");
			}
		}

		/// <summary>
		/// Parse the url.
		/// </summary>
		/// <param name="url"></param>
		protected void ParseUrl(string url)
		{
			InternalParseUrl(url);
		}

		public UrlParameter GetUrlParameter(string name)
		{
			if( _parameters == null )
				return null;

			foreach(UrlParameter parameter in _parameters)
			{
				if( parameter.Name == name )
					return parameter;
			}
			return null;
		}

		public bool ContainsUrlParameter(string name)
		{
			if( _parameters == null )
				return false;

			foreach(UrlParameter parameter in _parameters)
			{
				if( parameter.Name == name )
					return true;
			}
			return false;
		}

		public UrlParameter AddUrlParameter(string name, string value)
		{
			if( _parameters == null )
				_parameters = new ArrayList();
			UrlParameter parameter = new UrlParameter(name, value);
			_parameters.Add( parameter );
			return parameter;
		}
	}
}
