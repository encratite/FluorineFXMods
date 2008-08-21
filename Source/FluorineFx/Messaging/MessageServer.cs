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
using System.Configuration;
using System.Web;
using System.Xml;
using System.IO;
using log4net;
using FluorineFx.Messaging.Config;
using FluorineFx.Messaging.Endpoints;
using FluorineFx.Messaging.Services;
using FluorineFx.Security;
using FluorineFx.Configuration;
using FluorineFx.Context;
using FluorineFx.Util;
using FluorineFx.Exceptions;
using FluorineFx.Messaging.Rtmpt;

namespace FluorineFx.Messaging
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class MessageServer : DisposableBase
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(MessageServer));

        ServiceConfigSettings _serviceConfigSettings;
		MessageBroker	_messageBroker;

		/// <summary>
		/// Initializes a new instance of the MessageServer class.
		/// </summary>
		public MessageServer()
		{
		}

        internal ServiceConfigSettings ServiceConfigSettings
        {
            get { return _serviceConfigSettings; }
        }

        public void Init(string configPath)
        {
            Init(configPath, false);
        }

		public void Init(string configPath, bool serviceBrowserAvailable)
		{
			_messageBroker = new MessageBroker(this);

            _serviceConfigSettings = ServiceConfigSettings.Load(configPath, "services-config.xml");
            foreach (ChannelSettings channelSettings in _serviceConfigSettings.ChannelsSettings)
            {
                Type type = ObjectFactory.Locate(channelSettings.Class);
                if (type != null)
                {
                    IEndpoint endpoint = ObjectFactory.CreateInstance(type, new object[] { _messageBroker, channelSettings }) as IEndpoint;
                    if (endpoint != null)
                        _messageBroker.AddEndpoint(endpoint);
                }
                else
                    log.Error(__Res.GetString(__Res.Type_InitError, channelSettings.Class));

                ChannelSettings rtmptChannelSettings = new ChannelSettings(RtmptEndpoint.FluorineRtmptEndpointId, null);
                IEndpoint rtmptEndpoint = new RtmptEndpoint(_messageBroker, rtmptChannelSettings);
                _messageBroker.AddEndpoint(rtmptEndpoint);
            }
            foreach (FactorySettings factorySettings in _serviceConfigSettings.FactoriesSettings)
            {
                Type type = ObjectFactory.Locate(factorySettings.ClassId);
                if (type != null)
                {
                    IFlexFactory flexFactory = ObjectFactory.CreateInstance(type, new object[0]) as IFlexFactory;
                    if (flexFactory != null)
                        _messageBroker.AddFactory(factorySettings.Id, flexFactory);
                }
                else
                    log.Error(__Res.GetString(__Res.Type_InitError, factorySettings.ClassId));
            }
            //Add the dotnet Factory
            _messageBroker.AddFactory("dotnet", new DotNetFactory());
            
            if (serviceBrowserAvailable)
            {
                if (_serviceConfigSettings.ServiceSettings[RemotingService.RemotingServiceId] != null)
                {
                    ServiceSettings remoteServiceSettings = _serviceConfigSettings.ServiceSettings[RemotingService.RemotingServiceId];
                    AdapterSettings adapterSettings = _serviceConfigSettings.ServiceSettings[RemotingService.RemotingServiceId].AdapterSettings["dotnet"];
                    InstallServiceBrowserDestinations(remoteServiceSettings, adapterSettings);
                }
            }
            foreach (ServiceSettings serviceSettings in _serviceConfigSettings.ServiceSettings)
            {
                Type type = ObjectFactory.Locate(serviceSettings.Class);//current assembly only
                if (type != null)
                {
                    IService service = ObjectFactory.CreateInstance(type, new object[] { _messageBroker, serviceSettings }) as IService;
                    if (service != null)
                        _messageBroker.AddService(service);
                }
                else
                    log.Error(__Res.GetString(__Res.Type_InitError, serviceSettings.Class));
            }
            if (_serviceConfigSettings.SecuritySettings != null)
            {
                if (_serviceConfigSettings.SecuritySettings.LoginCommands != null && _serviceConfigSettings.SecuritySettings.LoginCommands.Count > 0)
                {
                    string loginCommandClass = _serviceConfigSettings.SecuritySettings.LoginCommands.GetLoginCommand(LoginCommandSettings.FluorineLoginCommand);
                    Type type = ObjectFactory.Locate(loginCommandClass);
                    if (type != null)
                    {
                        ILoginCommand loginCommand = ObjectFactory.CreateInstance(type, new object[] { }) as ILoginCommand;
                        _messageBroker.LoginCommand = loginCommand;
                    }
                    else
                        log.Error(__Res.GetString(__Res.Type_InitError, loginCommandClass));
                }
            }
            InitAuthenticationService();
		}

        private void InstallServiceBrowserDestinations(ServiceSettings serviceSettings, AdapterSettings adapterSettings)
        {
            //ServiceBrowser destinations
            DestinationSettings destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.FluorineServiceBrowserDestination, adapterSettings, DestinationSettings.FluorineServiceBrowserDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);

            destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.FluorineManagementDestination, adapterSettings, DestinationSettings.FluorineManagementDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);

            destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.FluorineCodeGeneratorDestination, adapterSettings, DestinationSettings.FluorineCodeGeneratorDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);

            destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.FluorineSqlServiceDestination, adapterSettings, DestinationSettings.FluorineSqlServiceDestination);
            serviceSettings.DestinationSettings.Add(destinationSettings);
        }

		private void InitAuthenticationService()
		{
            ServiceSettings serviceSettings = new ServiceSettings(_serviceConfigSettings, AuthenticationService.ServiceId, typeof(AuthenticationService).FullName);
			string messageType = "flex.messaging.messages.AuthenticationMessage";
			string typeName = FluorineConfiguration.Instance.ClassMappings.GetType(messageType);
			serviceSettings.SupportedMessageTypes[messageType] = typeName;
            _serviceConfigSettings.ServiceSettings.Add(serviceSettings);
			AuthenticationService service = new AuthenticationService(_messageBroker, serviceSettings);
			_messageBroker.AddService(service);
		}

		public MessageBroker MessageBroker{ get { return _messageBroker; } }

		public void Start()
		{
			if (log.IsInfoEnabled)
				log.Info(__Res.GetString(__Res.MessageServer_Start));
            if (_messageBroker != null)
            {
                _messageBroker.Start();
            }
            else
                log.Error(__Res.GetString(__Res.MessageServer_StartError));
		}

		public void Stop()
		{
			if( _messageBroker != null )
			{
				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.MessageServer_Stop));
				if( _messageBroker != null )
				{
					_messageBroker.Stop();
					_messageBroker = null;
				}
			}
		}

		#region IDisposable Members

		protected override void Free()
		{
			if (_messageBroker != null)
			{
				Stop();
			}
		}

		protected override void FreeUnmanaged()
		{
			if (_messageBroker != null)
			{
				Stop();
			}
		}


		#endregion

		public void Service()
		{
			if( _messageBroker == null )
			{
                string msg = __Res.GetString(__Res.MessageBroker_NotAvailable);
                log.Fatal(msg);
                throw new FluorineException(msg);
			}

			//This is equivalent to request.getContextPath() (Java) or the HttpRequest.ApplicationPath (.Net).
			string contextPath = HttpContext.Current.Request.ApplicationPath;
			string endpointPath = HttpContext.Current.Request.Path;
			bool isSecure = HttpContext.Current.Request.IsSecureConnection;

			if( log.IsDebugEnabled )
				log.Debug( __Res.GetString(__Res.Endpoint_Bind, endpointPath, contextPath));

			//http://www.adobe.com/cfusion/knowledgebase/index.cfm?id=e329643d&pss=rss_flex_e329643d
			IEndpoint endpoint = _messageBroker.GetEndpoint(endpointPath, contextPath, isSecure);
			if( endpoint != null )
			{
				endpoint.Service();
			}
			else
			{
				string msg = __Res.GetString(__Res.Endpoint_BindFail, endpointPath, contextPath);
                log.Fatal(msg);
                _messageBroker.TraceChannelSettings();
                throw new FluorineException(msg);
			}
		}

        public void ServiceRtmpt()
        {
            IEndpoint endpoint = _messageBroker.GetEndpoint(RtmptEndpoint.FluorineRtmptEndpointId);
            if (endpoint != null)
            {
                endpoint.Service();
            }
            else
            {
                string msg = __Res.GetString(__Res.Endpoint_BindFail, RtmptEndpoint.FluorineRtmptEndpointId, "");
                log.Fatal(msg);
                _messageBroker.TraceChannelSettings();
                throw new FluorineException(msg);
            }
        }
	}
}
