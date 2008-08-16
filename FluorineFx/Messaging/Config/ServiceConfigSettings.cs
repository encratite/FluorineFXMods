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
using System.Xml;
using System.Collections;
using System.IO;
using log4net;
using FluorineFx.Configuration;

namespace FluorineFx.Messaging.Config
{
    /// <summary>
    /// Represents a configuration class that contains information about the services-config.xml file.
	/// </summary>
	public sealed class ServiceConfigSettings
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(ServiceConfigSettings));

        ChannelSettingsCollection _channelSettingsCollection;
        FactorySettingsCollection _factorySettingsCollection;
        ServiceSettingsCollection _serviceSettingsCollection;
        SecuritySettings _securitySettings;
        FlexClientSettings _flexClientSettings;

        internal ServiceConfigSettings()
		{
            _channelSettingsCollection = new ChannelSettingsCollection();
            _factorySettingsCollection = new FactorySettingsCollection();
            _serviceSettingsCollection = new ServiceSettingsCollection();
		}

        /// <summary>
        /// Gets flex client settings.
        /// </summary>
        public FlexClientSettings FlexClientSettings
        {
            get { return _flexClientSettings; }
        }
        /// <summary>
        /// Gets security settings.
        /// </summary>
		public SecuritySettings SecuritySettings
		{
            get { return _securitySettings; }
		}
        /// <summary>
        /// Gets channel definitions.
        /// </summary>
        public ChannelSettingsCollection ChannelsSettings
		{
            get { return _channelSettingsCollection; }
		}
        /// <summary>
        /// Gets factory definitions.
        /// </summary>
        public FactorySettingsCollection FactoriesSettings
		{
            get { return _factorySettingsCollection; }
		}
        /// <summary>
        /// Gets service settings.
        /// </summary>
        public ServiceSettingsCollection ServiceSettings
		{
            get { return _serviceSettingsCollection; }
		}
        /// <summary>
        /// Loads a services-config.xml file.
        /// </summary>
        /// <param name="configPath">Path to the file.</param>
        /// <param name="configFileName">Service configuration file name.</param>
        /// <returns>A ServiceConfigSettings instance loaded from the specified file.</returns>
        public static ServiceConfigSettings Load(string configPath, string configFileName)
        {
            string servicesConfigFile = Path.Combine(configPath, configFileName);
            ServiceConfigSettings serviceConfigSettings = new ServiceConfigSettings();
            if (File.Exists(servicesConfigFile))
            {
                log.Debug(__Res.GetString(__Res.MessageServer_LoadingConfig, servicesConfigFile));
                XmlDocument servicesConfigXml = new XmlDocument();
                servicesConfigXml.Load(servicesConfigFile);
                XmlNodeList channelsNodeList = servicesConfigXml.SelectNodes("/services-config/channels/channel-definition");
                foreach (XmlNode channelDefinitionNode in channelsNodeList)
                {
                    XmlNode endPointNode = channelDefinitionNode.SelectSingleNode("endpoint");
                    string endpointClass = endPointNode.Attributes["class"].Value;
                    string endpointUri = endPointNode.Attributes["uri"].Value;

                    ChannelSettings channelSettings = new ChannelSettings(channelDefinitionNode);
                    serviceConfigSettings.ChannelsSettings.Add(channelSettings);
                }
                XmlNodeList factoriesNodeList = servicesConfigXml.SelectNodes("/services-config/factories/factory");
                foreach (XmlNode factoryDefinitionNode in factoriesNodeList)
                {
                    string factoryId = factoryDefinitionNode.Attributes["id"].Value;
                    string classId = factoryDefinitionNode.Attributes["class"].Value;

                    FactorySettings factorySettings = new FactorySettings(factoryDefinitionNode);
                    serviceConfigSettings.FactoriesSettings.Add(factorySettings);
                }
                XmlNodeList servicesIncludesNodeList = servicesConfigXml.SelectNodes("/services-config/services/service-include");
                foreach (XmlNode servicesIncludeNode in servicesIncludesNodeList)
                {
                    string filePath = servicesIncludeNode.Attributes["file-path"].Value;
                    filePath = Path.Combine(configPath, filePath);
                    log.Debug(__Res.GetString(__Res.MessageServer_LoadingServiceConfig, filePath));
                    ServiceSettings serviceSettings = new ServiceSettings(serviceConfigSettings);
                    serviceSettings.Init(filePath);

                    if (serviceSettings.Id == FluorineFx.Messaging.Services.RemotingService.RemotingServiceId)
                    {
                        AdapterSettings adapterSettings = serviceSettings.DefaultAdapter;
                        if (adapterSettings == null)
                        {
                            adapterSettings = new AdapterSettings("dotnet", typeof(FluorineFx.Remoting.RemotingAdapter).FullName, false);
                            serviceSettings.AdapterSettings.Add(adapterSettings);
                        }
                        //InstallServiceBrowserDestinations(serviceSettings, adapterSettings);
                    }
                    serviceConfigSettings.ServiceSettings.Add(serviceSettings);
                }
                XmlNodeList servicesNodeList = servicesConfigXml.SelectNodes("/services-config/services/service");
                foreach (XmlNode serviceNode in servicesNodeList)
                {
                    ServiceSettings serviceSettings = new ServiceSettings(serviceConfigSettings);
                    serviceSettings.Init(serviceNode);

                    if (serviceSettings.Id as string == FluorineFx.Messaging.Services.RemotingService.RemotingServiceId)
                    {
                        AdapterSettings adapterSettings = serviceSettings.DefaultAdapter;
                        if (adapterSettings == null)
                        {
                            adapterSettings = new AdapterSettings("dotnet", typeof(FluorineFx.Remoting.RemotingAdapter).FullName, false);
                            serviceSettings.AdapterSettings.Add(adapterSettings);
                        }
                        //InstallServiceBrowserDestinations(serviceSettings, adapterSettings);
                    }
                    serviceConfigSettings.ServiceSettings.Add(serviceSettings);
                }
                XmlNode securityNode = servicesConfigXml.SelectSingleNode("/services-config/security");
                if (securityNode != null)
                {
                    SecuritySettings securitySettings = new SecuritySettings(null, securityNode);
                    serviceConfigSettings._securitySettings = securitySettings;
                }
                XmlNode flexClientNode = servicesConfigXml.SelectSingleNode("/services-config/flex-client");
                if (flexClientNode != null)
                {
                    FlexClientSettings flexClientSettings = new FlexClientSettings(flexClientNode);
                    serviceConfigSettings._flexClientSettings = flexClientSettings;
                }
                else
                    serviceConfigSettings._flexClientSettings = new FlexClientSettings();
            }
            else
            {
                log.Debug(__Res.GetString(__Res.MessageServer_LoadingConfigDefault, servicesConfigFile));

                LoginCommandCollection loginCommandCollection = FluorineConfiguration.Instance.LoginCommands;
                if (loginCommandCollection != null)
                {
                    SecuritySettings securitySettings = new SecuritySettings(null);
                    LoginCommandSettings loginCommandSettings = new LoginCommandSettings();
                    loginCommandSettings.Server = LoginCommandSettings.FluorineLoginCommand;
                    loginCommandSettings.Type = loginCommandCollection.GetLoginCommand(LoginCommandSettings.FluorineLoginCommand);
                    securitySettings.LoginCommands.Add(loginCommandSettings);
                    serviceConfigSettings._securitySettings = securitySettings;
                }

                //Create a default amf channel
                ChannelSettings channelSettings = new ChannelSettings("my-amf", "flex.messaging.endpoints.AMFEndpoint", @"http://{server.name}:{server.port}/{context.root}/Gateway.aspx");
                serviceConfigSettings.ChannelsSettings.Add(channelSettings);

                ServiceSettings serviceSettings = new ServiceSettings(serviceConfigSettings, FluorineFx.Messaging.Services.RemotingService.RemotingServiceId, typeof(FluorineFx.Messaging.Services.RemotingService).FullName);
                string messageType = "flex.messaging.messages.RemotingMessage";
                string typeName = FluorineConfiguration.Instance.ClassMappings.GetType(messageType);
                serviceSettings.SupportedMessageTypes[messageType] = typeName;
                serviceConfigSettings.ServiceSettings.Add(serviceSettings);

                AdapterSettings adapterSettings = new AdapterSettings("dotnet", typeof(FluorineFx.Remoting.RemotingAdapter).FullName, true);
                serviceSettings.DefaultAdapter = adapterSettings;

                DestinationSettings destinationSettings = new DestinationSettings(serviceSettings, DestinationSettings.FluorineDestination, adapterSettings, "*");
                serviceSettings.DestinationSettings.Add(destinationSettings);

                serviceConfigSettings._flexClientSettings = new FlexClientSettings();
            }
            return serviceConfigSettings;
        }
	}
}
