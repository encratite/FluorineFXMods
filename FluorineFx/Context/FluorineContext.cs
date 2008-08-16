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
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Collections.Specialized;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;
using log4net;
using FluorineFx.Security;
using FluorineFx.Messaging.Api;
using FluorineFx.Configuration;

namespace FluorineFx.Context
{
    sealed class WebSafeCallContext
    {
        private WebSafeCallContext()
        {
        }

        public static object GetData(string name)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
            {
                return CallContext.GetData(name);
            }
            else
            {
                return ctx.Items[name];
            }
        }

        public static void SetData(string name, object value)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
            {
                CallContext.SetData(name, value);
            }
            else
            {
                ctx.Items[name] = value;
            }
        }

        public static void FreeNamedDataSlot(string name)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
            {
                CallContext.FreeNamedDataSlot(name);
            }
            else
            {
                ctx.Items.Remove(name);
            }
        }
    }
	/// <summary>
	/// Similary to the ASP.NET HttpContext class you can access the Fluorine context for the current request from any code inside the same application domain.
	/// </summary>
    /// <remarks>For an AMF channel (Http request) the Fluorine context wrapps the underlying HttpContext.</remarks>
	public abstract class FluorineContext
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(FluorineContext));

        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineContextKey = "__@fluorinecontext";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineTicket = "fluorineauthticket";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorinePrincipalAttribute = "__@fluorineprincipal";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineSessionAttribute = "__@fluorinesession";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineConnectionKey = "__@fluorineconnection";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineClientKey = "__@fluorineclient";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineStreamIdKey = "__@fluorinestreamid";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineDataServiceTransaction = "__@fluorinedataservicetransaction";
        /// <summary>
		/// Global FlexClient Id value stored by FluorineFx.
		/// </summary>
		public const string FlexClientIdHeader = "DSId";

		internal FluorineContext()
		{
		}
		/// <summary>
		/// Gets the FluorineContext object for the current HTTP request.
		/// </summary>
		static public FluorineContext Current
		{
			get
			{
                FluorineContext context = null;
                HttpContext ctx = HttpContext.Current;
                if (ctx != null)
                    return ctx.Items[FluorineContext.FluorineContextKey] as FluorineContext;
                try
                {
                    // See if we're running in full trust
                    new SecurityPermission(PermissionState.Unrestricted).Demand();
                    context = WebSafeCallContext.GetData(FluorineContext.FluorineContextKey) as FluorineContext;
                }
                catch (SecurityException)
                {
                }
				return context;
			}
		}

		/// <summary>
		/// Gets a key-value collection that can be used to organize and share data between an IHttpModule and an IHttpHandler during an HTTP request.
		/// </summary>
		public abstract IDictionary Items { get; }
		/// <summary>
		/// Enables sharing of global information across multiple sessions and requests within an application.
		/// </summary>
		public abstract IApplicationState ApplicationState { get; }
		/// <summary>
		/// Gets or sets security information for the current HTTP request.
		/// </summary>
		public abstract IPrincipal User {get; set;}
		/// <summary>
		/// Gets the SessionState instance for the current request.
		/// </summary>
		public abstract ISessionState Session { get; }

		/// <summary>
		/// Gets the base directory for this <see cref="AppDomain"/>
		/// </summary>
		public virtual string ApplicationBaseDirectory
		{
			get{ return AppDomain.CurrentDomain.BaseDirectory; }
		}

		/// <summary>
		/// Converts a path into a fully qualified local file path.
		/// If the path is relative it is taken as relative from the application base directory.
		/// </summary>
		/// <param name="path">The path to convert.</param>
		/// <returns>The fully qualified path.</returns>
		public virtual string GetFullPath(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			string baseDirectory = "";
			try
			{
				string applicationBaseDirectory = this.ApplicationBaseDirectory;
				if (applicationBaseDirectory != null)
				{
					//applicationBaseDirectory may be a URI not a local file path
					Uri applicationBaseDirectoryUri = new Uri(applicationBaseDirectory);
					if (applicationBaseDirectoryUri.IsFile)
					{
						baseDirectory = applicationBaseDirectoryUri.LocalPath;
					}
				}
			}
			catch
			{
				// Ignore URI exceptions & SecurityExceptions
			}

			if (baseDirectory != null && baseDirectory.Length > 0)
			{
				// Note that Path.Combine will return the second path if it is rooted
				return Path.GetFullPath(Path.Combine(baseDirectory, path));
			}
			return Path.GetFullPath(path);
		}

		/// <summary>
		/// Gets the physical drive path of the application directory for the application hosted in the current application domain.
		/// </summary>
		public abstract string RootPath { get; }
		/// <summary>
		/// Gets the virtual path of the current request.
		/// </summary>
		public abstract string RequestPath { get; }
		/// <summary>
		/// Gets the ASP.NET application's virtual application root path on the server.
		/// </summary>
		public abstract string RequestApplicationPath { get; }

		public abstract string PhysicalApplicationPath { get; }

        public abstract string ApplicationPath { get; }

		/// <summary>
		/// Gets the absolute URI from the URL of the current request.
		/// </summary>
		public abstract string AbsoluteUri { get; }

		public abstract string ActivationMode{ get; }

		public abstract void StorePrincipal(IPrincipal principal, string userId, string password);

		public abstract IPrincipal RestorePrincipal(ILoginCommand loginCommand);

        public abstract void ClearPrincipal();

        /// <summary>
        /// Gets the current RtmpConnection object.
        /// </summary>
        public virtual FluorineFx.Messaging.Api.IConnection Connection
        {
            get { return null; }
        }
        /// <summary>
        /// Return an <see cref="FluorineFx.Context.IResource"/> handle for the
        /// </summary>
        /// <param name="location">The resource location.</param>
        /// <returns>An appropriate <see cref="FluorineFx.Context.IResource"/> handle.</returns>
        public abstract IResource GetResource(string location);

        internal virtual void SetCurrentClient(IClient client)
        {
        }

        public abstract IClient Client { get; }

        public string ClientId 
        {
            get
            {
                if (this.Client != null)
                    return this.Client.Id;
                return null;
            }
        }
	}
}
