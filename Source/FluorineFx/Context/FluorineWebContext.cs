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

using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;
using FluorineFx.Security;

namespace FluorineFx.Context
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class FluorineWebContext : FluorineContext
	{
		internal FluorineWebContext() : base()
		{
		}

        internal static void Initialize()
        {
            HttpContext.Current.Items[FluorineContext.FluorineContextKey] = new FluorineWebContext();
        }

		/// <summary>
		/// Gets a key-value collection that can be used to organize and share data between an IHttpModule and an IHttpHandler during an HTTP request.
		/// </summary>
		public override IDictionary Items
		{ 
			get{ return HttpContext.Current.Items; }
		}
		/// <summary>
		/// Enables sharing of global information across multiple sessions and requests within an ASP.NET application.
		/// </summary>
		public override IApplicationState ApplicationState
		{
			get
			{
				return new HttpApplicationStateWrapper();
			}
		}
		/// <summary>
		/// Gets or sets security information for the current HTTP request.
		/// </summary>
		public override IPrincipal User
		{ 
			get
			{
				return HttpContext.Current.User;
			}
			set
			{
				HttpContext.Current.User = value;
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
			get { return HttpContext.Current.Request.Path; }
		}
		/// <summary>
		/// Gets the ASP.NET application's virtual application root path on the server.
		/// </summary>
		public override string RequestApplicationPath
		{ 
			get { return HttpContext.Current.Request.ApplicationPath; }
		}

		public override string PhysicalApplicationPath
		{ 
			get
			{
				return HttpContext.Current.Request.PhysicalApplicationPath;
			}
		}

        public override string ApplicationPath 
        {
            get
            {
                string applicationPath = "";
                //if (httpApplication.Request.Url != null)
                // Nick Farina: We need to cast to object first because the mono framework doesn't 
                // have the Uri.operator!=() method that the MS compiler adds. 
                if ((object)HttpContext.Current.Request.Url != null)
                    applicationPath = HttpContext.Current.Request.Url.AbsoluteUri.Substring(
                        0, HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf(
                        HttpContext.Current.Request.ApplicationPath.ToLower(),
                        HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf(
                        HttpContext.Current.Request.Url.Authority.ToLower()) +
                        HttpContext.Current.Request.Url.Authority.Length) +
                        HttpContext.Current.Request.ApplicationPath.Length);
                return applicationPath;
            }
        }
		/// <summary>
		/// Gets the absolute URI from the URL of the current request.
		/// </summary>
		public override string AbsoluteUri
		{ 
			get{ return HttpContext.Current.Request.Url.AbsoluteUri; }
		}
		/// <summary>
		/// Gets the SessionState instance for the current HTTP request.
		/// </summary>
		public override ISessionState Session
		{
			get
			{
                 return HttpSessionStateWrapper.CreateSessionWrapper(HttpContext.Current.Session);
			}
		}

		public override string ActivationMode
		{ 
			get
			{
				//if( Environment.UserInteractive )
				//	return null;
				try
				{
					if( HttpContext.Current != null )
						return HttpContext.Current.Request.QueryString["activate"] as string;
				}
				catch(HttpException)//Request is not available in this context
				{
				}
				return null;
			}
		}

		public override void StorePrincipal(IPrincipal principal, string userId, string password)
		{
			string uniqueKey = Guid.NewGuid().ToString("N");
			// Get the cookie created by the FormsAuthentication API
			// Notice that this cookie will have all the attributes according to   
			// the ones in the config file setting.
			// This does not set the cookie as part of the outgoing response.

			HttpCookie cookie = FormsAuthentication.GetAuthCookie(userId, false );
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

			string cacheKey = string.Join("|", new string[] {GenericLoginCommand.FluorineTicket, uniqueKey, userId, password});
			// Store the Guid inside the Forms Ticket with all the attributes aligned with 
			// the config Forms section.
			FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
				ticket.Version,
				ticket.Name,
				ticket.IssueDate,
				ticket.Expiration,
				ticket.IsPersistent,
				cacheKey,
				ticket.CookiePath);
			// Add the encrypted ticket to the cookie as data.
			cookie.Value = FormsAuthentication.Encrypt(newTicket);
			// Update the outgoing cookies collection.
			HttpContext.Current.Response.Cookies.Add(cookie);
			// Add the principal to the Cache with the expiration item sync with the FormsAuthentication ticket timeout
			HttpRuntime.Cache.Insert( cacheKey, principal, null, 
				Cache.NoAbsoluteExpiration,
				newTicket.Expiration.Subtract( newTicket.IssueDate ), 
				CacheItemPriority.Default, null );
		}

		public static string GetFormsAuthCookieName()
		{
			string formsCookieName = Environment.UserInteractive ? ".ASPXAUTH" : FormsAuthentication.FormsCookieName;
			return formsCookieName;
		}

		public override IPrincipal RestorePrincipal(ILoginCommand loginCommand)
		{
			IPrincipal principal = null;

			//User already authenticated
			if(HttpContext.Current != null && HttpContext.Current.Request.IsAuthenticated)
			{
				
				if (HttpContext.Current.User.Identity is FormsIdentity)
				{
					FormsIdentity formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
					if( formsIdentity.Ticket.UserData == null || !formsIdentity.Ticket.UserData.StartsWith(FluorineContext.FluorineTicket) )
						return HttpContext.Current.User;
					//Let fluorine get the correct principal
				}
				else
					return HttpContext.Current.User;
			}

			HttpCookie authCookie = HttpContext.Current.Request.Cookies.Get(GetFormsAuthCookieName());
			if( authCookie != null )
			{
				/*
				FormsAuthenticationTicket ticket = null;
				try 
				{
					ticket = FormsAuthentication.Decrypt( authCookie.Value );
				}
				catch(CryptographicException)
				{
				}
				*/
				FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt( authCookie.Value );
				if( ticket != null )
				{
					principal = HttpContext.Current.Cache[ticket.UserData] as IPrincipal;
					if( principal == null )
					{
						if( ticket.UserData != null && ticket.UserData.StartsWith(FluorineContext.FluorineTicket) )
						{
							//Get the principal as the cache lost the data
							string[] userData = ticket.UserData.Split(new char[] {'|'});
							string userId = userData[2];
							string password = userData[3];
							if( loginCommand != null )
							{
								Hashtable credentials = new Hashtable(1);
								credentials["password"] = password;
								principal = loginCommand.DoAuthentication(userId, credentials);
								if( principal == null )
									throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_AuthenticationFailed));
								StorePrincipal(principal, userId, password);
							}
							else
								throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_LoginMissing));
						}
					}
				}
				else
				{
					//This is not our cookie so rely on application's authentication
					principal = Thread.CurrentPrincipal;
				}
			}
			if( principal != null )
			{
                this.User = principal;
				Thread.CurrentPrincipal = principal;
			}
			return principal;
		}

        public override void ClearPrincipal()
        {
			HttpCookie authCookie = HttpContext.Current.Request.Cookies.Get(GetFormsAuthCookieName());
			if( authCookie != null )
			{
				FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt( authCookie.Value );
				if( ticket != null && ticket.UserData != null && ticket.UserData.StartsWith(FluorineContext.FluorineTicket) )
				{
					HttpRuntime.Cache.Remove(ticket.UserData);
				}
			}
            FormsAuthentication.SignOut();
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

        public override FluorineFx.Messaging.Api.IConnection Connection
        {
            get
            {
                return this.Items[FluorineContext.FluorineConnectionKey] as FluorineFx.Messaging.Api.IConnection;
            }
        }

        internal void SetConnection(FluorineFx.Messaging.Api.IConnection connection)
        {
            this.Items[FluorineContext.FluorineConnectionKey] = connection;
        }

        internal override void SetCurrentClient(FluorineFx.Messaging.Api.IClient client)
        {
            this.Items[FluorineContext.FluorineClientKey] = client;
        }

        public override FluorineFx.Messaging.Api.IClient Client
        {
            get 
            { 
                return this.Items[FluorineContext.FluorineClientKey] as FluorineFx.Messaging.Api.IClient; 
            }
        }
	}
}
