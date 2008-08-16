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
using System.Web.Security;
using System.Web.Caching;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Threading;
using System.Security.Cryptography;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;
using FluorineFx.Security;

namespace FluorineFx.Context
{
    sealed class _TimeoutContext : FluorineContext
    {
        IConnection _connection;
        IClient _client;
        Hashtable _items;

        private _TimeoutContext()
            : base()
		{
		}

        internal _TimeoutContext(IConnection connection, IClient client)
            : base()
        {
            _client = client;
            _connection = connection;
        }

        private Hashtable GetItems()
        {
            if (_items == null)
                _items = new Hashtable();
            return _items;
        }

        public override IDictionary Items
        {
            get { return GetItems(); }
        }

        public override IApplicationState ApplicationState
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

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

        public override ISessionState Session
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string RootPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string RequestPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string RequestApplicationPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string PhysicalApplicationPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string ApplicationPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string AbsoluteUri
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override string ActivationMode
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public override void StorePrincipal(IPrincipal principal, string userId, string password)
        {
            //NA
        }

        public override IPrincipal RestorePrincipal(ILoginCommand loginCommand)
        {
            //NA
            return Thread.CurrentPrincipal;
        }

        public override void ClearPrincipal()
        {
            //NA
        }

        public override IResource GetResource(string location)
        {
            return new FileSystemResource(location);
        }

        public override IConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public override FluorineFx.Messaging.Api.IClient Client
        {
            get { return _client; }
        }
    }
}
