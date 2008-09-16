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
using System.Reflection;
using System.Collections;
using System.Security.Principal;
using System.Web.Security;
using System.Threading;
using log4net;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Services;
using FluorineFx.Messaging.Config;
using FluorineFx.Security;
using FluorineFx.Context;
using FluorineFx.IO;

namespace FluorineFx.Messaging.Endpoints.Filter
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AuthenticationFilter : AbstractFilter
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationFilter));
		EndpointBase _endpoint;

		/// <summary>
		/// Initializes a new instance of the AuthenticationFilter class.
		/// </summary>
		/// <param name="endpoint"></param>
		public AuthenticationFilter(EndpointBase endpoint)
		{
			_endpoint = endpoint;
		}

		#region IFilter Members

		public override void Invoke(AMFContext context)
		{
            IPrincipal principal = null;
            MessageBroker messageBroker = _endpoint.GetMessageBroker();
            try
            {
                AMFHeader amfHeader = context.AMFMessage.GetHeader(AMFHeader.CredentialsHeader);
                if (amfHeader != null && amfHeader.Content != null)
                {
                    string userId = ((ASObject)amfHeader.Content)["userid"] as string;
                    string password = ((ASObject)amfHeader.Content)["password"] as string;
                    //Clear credentials header
                    ASObject asoObject = new ASObject();
                    asoObject["name"] = AMFHeader.CredentialsHeader;
                    asoObject["mustUnderstand"] = false;
                    asoObject["data"] = null;//clear
                    AMFHeader header = new AMFHeader(AMFHeader.RequestPersistentHeader, true, asoObject);
                    context.MessageOutput.AddHeader(header);
                    ILoginCommand loginCommand = _endpoint.GetMessageBroker().LoginCommand;
                    if (loginCommand != null)
                    {
                        Hashtable credentials = new Hashtable(1);
                        credentials["password"] = password;
                        principal = loginCommand.DoAuthentication(userId, credentials);
                        if (principal == null)
                            throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_AccessNotAllowed));
                    }
                    else
                        throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_LoginMissing));
                    FluorineContext.Current.StorePrincipal(principal, userId, password);
                    string key = FluorineContext.Current.EncryptCredentials(_endpoint, principal, userId, password);
                    FluorineContext.Current.StorePrincipal(principal, key);

                    ASObject asoObjectCredentialsId = new ASObject();
                    asoObjectCredentialsId["name"] = AMFHeader.CredentialsIdHeader;
                    asoObjectCredentialsId["mustUnderstand"] = false;
                    asoObjectCredentialsId["data"] = key;//set
                    AMFHeader headerCredentialsId = new AMFHeader(AMFHeader.RequestPersistentHeader, true, asoObjectCredentialsId);
                    context.MessageOutput.AddHeader(headerCredentialsId);
                }
                else
                {
                    amfHeader = context.AMFMessage.GetHeader(AMFHeader.CredentialsIdHeader);
                    if (amfHeader != null)
                    {
                        string key = amfHeader.Content as string;
                        if (key != null)
                            FluorineContext.Current.RestorePrincipal(messageBroker.LoginCommand, key);
                    }
                    else
                    {
                        principal = FluorineContext.Current.RestorePrincipal(messageBroker.LoginCommand);
                    }
                }
            }
            catch (UnauthorizedAccessException exception)
            {
                for (int i = 0; i < context.AMFMessage.BodyCount; i++)
                {
                    AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
                    ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
                    context.MessageOutput.AddBody(errorResponseBody);
                }
            }
            catch (Exception exception)
            {
                if (log != null && log.IsErrorEnabled)
                    log.Error(exception.Message, exception);
                for (int i = 0; i < context.AMFMessage.BodyCount; i++)
                {
                    AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
                    ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
                    context.MessageOutput.AddBody(errorResponseBody);
                }
            }
            FluorineContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;
		}

		#endregion

        /*
		void AuthenticateFlashClient(AMFContext context, AMFBody body)
		{
			MessageBroker messageBroker = _endpoint.GetMessageBroker();
			IPrincipal principal = FluorineContext.Current.RestorePrincipal(messageBroker.LoginCommand);

			if( principal == null )
			{
				//Check for Credentials Header
				AMFMessage amfMessage = context.AMFMessage;
				AMFHeader amfHeader = amfMessage.GetHeader( AMFHeader.CredentialsHeader );
				if( amfHeader != null && amfHeader.Content != null )
				{
					string userId = ((ASObject)amfHeader.Content)["userid"] as string;
					string password = ((ASObject)amfHeader.Content)["password"] as string;
					//Clear credentials header
					ASObject asoObject = new ASObject();
					asoObject["name"] = AMFHeader.CredentialsHeader;
					asoObject["mustUnderstand"] = false;
					asoObject["data"] = null;//clear
					AMFHeader header = new AMFHeader(AMFHeader.RequestPersistentHeader, true, asoObject);
					context.MessageOutput.AddHeader( header );

					ILoginCommand loginCommand = _endpoint.GetMessageBroker().LoginCommand;
					if( loginCommand != null )
					{
						Hashtable credentials = new Hashtable(1);
						credentials["password"] = password;
						principal = loginCommand.DoAuthentication(userId, credentials);
						if( principal == null )
							throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_AccessNotAllowed));
						FluorineContext.Current.StorePrincipal(principal, userId, password);
						// Attach the new principal object to the current Context object
						FluorineContext.Current.User = principal;
						Thread.CurrentPrincipal = principal;
					}
					else
                        throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_LoginMissing));
				}
			}
		}
        */
	}
}
