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
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Threading;

using FluorineFx.Messaging;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Messages;
using FluorineFx.Security;
using FluorineFx.Messaging.Rtmp;

namespace FluorineFx.Context
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class FluorineRtmpContext : FluorineContext, ISessionState
	{
        IConnection _connection;
        Hashtable _items;

        internal static void Initialize(IConnection connection)
        {
            FluorineRtmpContext fluorineContext = new FluorineRtmpContext(connection);
            WebSafeCallContext.SetData(FluorineContext.FluorineContextKey, fluorineContext);
        }


		public FluorineRtmpContext(IConnection connection) : base()
		{
			_connection = connection;
		}

        public override IConnection Connection
		{
			get
			{
				return _connection;
			}
		}

		private Hashtable GetItems()
		{
			if( _items == null )
				_items = new Hashtable();
			return _items;
		}
		/// <summary>
		/// Gets a key-value collection that can be used to organize and share data between an IHttpModule and an IHttpHandler during an HTTP request.
		/// </summary>
		public override IDictionary Items
		{ 
			get{ return GetItems(); }
		}
		/// <summary>
		/// Gets or sets security information for the current HTTP request.
		/// </summary>
		public override IPrincipal User
		{ 
			get
			{
				return Thread.CurrentPrincipal;
			}
			set
			{
				Thread.CurrentPrincipal = value;
			}
		}
		/// <summary>
		/// Gets the physical drive path of the application directory for the application hosted in the current application domain.
		/// </summary>
		public override string RootPath
		{ 
			get
			{
				return HttpRuntime.AppDomainAppPath;
			}
		}

		/// <summary>
		/// Gets the virtual path of the current request.
		/// </summary>
		public override string RequestPath 
		{ 
			get { return null; }
		}
		/// <summary>
		/// Gets the ASP.NET application's virtual application root path on the server.
		/// </summary>
		public override string RequestApplicationPath
		{ 
			get { return null; }
		}

        public override string ApplicationPath
        {
            get
            {
                return null;
            }
        }

		/// <summary>
		/// Gets the absolute URI from the URL of the current request.
		/// </summary>
		public override string AbsoluteUri
		{ 
			get{ return null; }
		}
		/// <summary>
		/// Gets the SessionState instance for the current HTTP request.
		/// </summary>
		public override ISessionState Session
		{
			get
			{
                return this;
			}
		}

		public override string ActivationMode
		{
			get
			{
				return null;
			}
		}

		public override IApplicationState ApplicationState
		{
			get
			{
                return RtmpApplicationState.Instance;
			}
		}

		public override string PhysicalApplicationPath
		{
			get
			{
				//TODO
				return HttpRuntime.AppDomainAppPath;
			}
		}

        internal override string EncryptCredentials(FluorineFx.Messaging.Endpoints.IEndpoint endpoint, IPrincipal principal, string userId, string password)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

		public override void StorePrincipal(IPrincipal principal, string userId, string password)
		{
			_connection.SetAttribute(FluorineContext.FluorinePrincipalAttribute, principal);
		}

        internal override void StorePrincipal(IPrincipal principal, string key)
        {
            _connection.SetAttribute(key, principal);
        }

		public override IPrincipal RestorePrincipal(ILoginCommand loginCommand)
		{
			IPrincipal principal = _connection.GetAttribute(FluorineContext.FluorinePrincipalAttribute) as IPrincipal;
            if (principal != null)
                Thread.CurrentPrincipal = principal;
            return principal;
		}

        internal override IPrincipal RestorePrincipal(ILoginCommand loginCommand, string key)
        {
            IPrincipal principal = _connection.GetAttribute(key) as IPrincipal;
            if (principal != null)
                Thread.CurrentPrincipal = principal;
            return principal;
        }

        public override void ClearPrincipal()
        {
            _connection.RemoveAttribute(FluorineContext.FluorinePrincipalAttribute);
        }

        public override FluorineFx.Messaging.Api.IClient Client
        {
            get { return _connection.Client; }
        }
        /// <summary>
        /// Return an <see cref="FluorineFx.Context.IResource"/> handle for the
        /// </summary>
        /// <param name="location">The resource location.</param>
        /// <returns>An appropriate <see cref="FluorineFx.Context.IResource"/> handle.</returns>
        public override IResource GetResource(string location)
        {
            return new FileSystemResource(location);
        }

        #region SessionState Members

        public void Add(string name, object value)
        {
            _connection.SetAttribute(name, value);
        }

        public void Clear()
        {
            _connection.RemoveAttributes();
        }

        public void Remove(string name)
        {
            _connection.RemoveAttribute(name);
        }

        public void RemoveAll()
        {
            Clear();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public string SessionID
        {
            get { return _connection.ConnectionId; }
        }

        public object this[string name]
        {
            get
            {
                return _connection.GetAttribute(name);
            }
            set
            {
                _connection.SetAttribute(name, value);
            }
        }

        public object this[int index]
        {
            get
            {
                throw new NotSupportedException();
                //return _connection[index];
            }
            set
            {
                throw new NotSupportedException();
                //_connection[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
#if !(NET_1_1)
            object[] tmp = null;
            _connection.CopyTo(tmp, index);
            array = tmp;
#else
            _connection.CopyTo(array, index);
#endif
        }

        public int Count
        {
            get { return _connection.AttributesCount; }
        }
        /// <summary>
        /// Gets a value indicating whether access to the collection of session-state values is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            //Access to attributes is synchronized
            get { return true; }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the collection of session-state values.
        /// </summary>
        public object SyncRoot
        {
            get { return _connection.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _connection.GetAttributeNames().GetEnumerator();
        }

        #endregion
    }
}
