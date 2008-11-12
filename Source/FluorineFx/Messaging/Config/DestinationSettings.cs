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

namespace FluorineFx.Messaging.Config
{
	/// <summary>
    /// Contains the properties for configuring service adapters.
    /// This is the <b>destination</b> element in the services-config.xml file.
	/// </summary>
	public sealed class DestinationSettings : Hashtable
	{
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
		public const string FluorineDestination = "fluorine";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineServiceBrowserDestination = "FluorineFx.ServiceBrowser.FluorineServiceBrowser";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineManagementDestination = "FluorineFx.ServiceBrowser.ManagementService";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineCodeGeneratorDestination = "FluorineFx.ServiceBrowser.CodeGeneratorService";
        /// <summary>
        /// This member supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public const string FluorineSqlServiceDestination = "FluorineFx.ServiceBrowser.SqlService";

		ServiceSettings _serviceSettings;
        string[] _cachedRoles;
        string _id;
        AdapterSettings _adapter;
        Hashtable _properties;
        SecuritySettings _security;
        NetworkSettings _network;
        MetadataSettings _metadata;
        MsmqSettings _msmqSettings;
        ServerSettings _server;
        ChannelSettingsCollection _channels;

        XmlNode _propertiesNode;

        internal DestinationSettings(ServiceSettings serviceSettings, string id, AdapterSettings adapter, string source)
        {
            _serviceSettings = serviceSettings;
            _properties = new Hashtable();
            _channels = new ChannelSettingsCollection();
            _id = id;
            _adapter = adapter;
            _properties["source"] = source;
        }

        internal DestinationSettings(ServiceSettings serviceSettings, XmlNode destinationNode)
        {
            _serviceSettings = serviceSettings;
            _properties = new Hashtable();
            _channels = new ChannelSettingsCollection();

            _id = destinationNode.Attributes["id"].Value;

            XmlNode adapterNode = destinationNode.SelectSingleNode("adapter");
            if (adapterNode != null)
            {
                string adapterRef = adapterNode.Attributes["ref"].Value;
                AdapterSettings adapterSettings = serviceSettings.AdapterSettings[adapterRef] as AdapterSettings;
                _adapter = adapterSettings;
            }

            _propertiesNode = destinationNode.SelectSingleNode("properties");
            if (_propertiesNode != null)
            {
                XmlNode sourceNode = _propertiesNode.SelectSingleNode("source");
                if (sourceNode != null)
                    _properties["source"] = sourceNode.InnerXml;
                XmlNode factoryNode = _propertiesNode.SelectSingleNode("factory");
                if (factoryNode != null)
                    _properties["factory"] = factoryNode.InnerXml;
                XmlNode attributeIdNode = _propertiesNode.SelectSingleNode("attribute-id");
                if (attributeIdNode != null)
                {
                    //If you specify an attribute-id element in the destination, you can control which attribute the component is stored in
                    //This lets more than one destination share the same instance.
                    _properties["attribute-id"] = attributeIdNode.InnerXml;
                }
                else
                {
                    //Stored using the destination name as the attribute
                    _properties["attribute-id"] = _id;
                }

                XmlNode scopeNode = _propertiesNode.SelectSingleNode("scope");
                if (scopeNode != null)
                {
                    _properties["scope"] = scopeNode.InnerXml;
                }

                XmlNode networkNode = _propertiesNode.SelectSingleNode("network");
                if (networkNode != null)
                {
                    NetworkSettings networkSettings = new NetworkSettings(networkNode);
                    _network = networkSettings;
                }
                XmlNode metadataNode = _propertiesNode.SelectSingleNode("metadata");
                if (metadataNode != null)
                {
                    MetadataSettings metadataSettings = new MetadataSettings(metadataNode);
                    _metadata = metadataSettings;
                }
                XmlNode serverNode = _propertiesNode.SelectSingleNode("server");
                if (serverNode != null)
                {
                    ServerSettings serverSettings = new ServerSettings(serverNode);
                    _server = serverSettings;
                }
                XmlNode msmqNode = _propertiesNode.SelectSingleNode("msmq");
                if (msmqNode != null)
                {
                    MsmqSettings msmqSettings = new MsmqSettings(msmqNode);
                    _msmqSettings = msmqSettings;
                }
            }
            XmlNode securityNode = destinationNode.SelectSingleNode("security");
            if (securityNode != null)
            {
                SecuritySettings securitySettings = new SecuritySettings(this, securityNode);
                _security = securitySettings;
            }
            else
                _security = new SecuritySettings(this);
            XmlNode channelsNode = destinationNode.SelectSingleNode("channels");
            if (channelsNode != null)
            {
                XmlNodeList channelNodeList = channelsNode.SelectNodes("channel");
                foreach (XmlNode channelNode in channelNodeList)
                {
                    string channelRef = channelNode.Attributes["ref"].Value;
                    if (channelRef != null)
                    {
                        ChannelSettings channelSettings = _serviceSettings.ServiceConfigSettings.ChannelsSettings[channelRef] as ChannelSettings;
                        _channels.Add(channelSettings);
                    }
                    else
                    {
                        ChannelSettings channelSettings = new ChannelSettings(channelNode);
                        _channels.Add(channelSettings);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the properties XmlNode object. Custom adapters can use this object to query additional settings.
        /// </summary>
        public XmlNode PropertiesNode
        {
            get { return _propertiesNode; }
        }

        /// <summary>
        /// Gets the identity of the destination.
        /// </summary>
		public string Id
		{
			get{ return _id; }
		}
        /// <summary>
        /// Gets the service settings of the destination.
        /// </summary>
		public ServiceSettings ServiceSettings
		{
			get{ return _serviceSettings; }
		}
        /// <summary>
        /// Gets the referenced adapter settings of the destination.
        /// </summary>
		public AdapterSettings Adapter
		{
			get{ return _adapter; }
		}
        /// <summary>
        /// Gets destination properties.
        /// </summary>
		public Hashtable Properties
		{
            get { return _properties; }
		}
        /// <summary>
        /// Gets security settings of the destination.
        /// </summary>
        public SecuritySettings SecuritySettings
		{
            get { return _security; }
		}
        /// <summary>
        /// Gets network settings of the destination. 
        /// </summary>
        public NetworkSettings NetworkSettings
		{ 
			get
			{
                return _network;
			}
		}
        /// <summary>
        /// Gets MSMQ settings of the destination if applicable.
        /// </summary>
        public MsmqSettings MsmqSettings
		{ 
			get
			{
                return _msmqSettings;
			}
		}
        /// <summary>
        /// Gets metadat settings of the destination.
        /// </summary>
        public MetadataSettings MetadataSettings
		{ 
			get
			{
                return _metadata;
			}
		}
        /// <summary>
        /// Gets server settings of the destination.
        /// </summary>
        public ServerSettings ServerSettings
        {
            get
            {
                return _server;
            }
        }
        /// <summary>
        /// Gets channel definitions of the destination.
        /// </summary>
        public ChannelSettingsCollection Channels
		{
			get{ return _channels; }
		}
        /// <summary>
        /// Returns the specified roles for a secure destination.
        /// </summary>
        /// <returns>List of role names.</returns>
        public string[] GetRoles()
        {
            if (_cachedRoles == null)
            {
                if (this.SecuritySettings != null)
                {
                    _cachedRoles = this.SecuritySettings.GetRoles();
                }
                else
                    _cachedRoles = new string[0];
            }
            return _cachedRoles;
        }
	}

    /// <summary>
    /// Strongly typed DestinationSettings collection.
    /// </summary>
    public sealed class DestinationSettingsCollection : CollectionBase
    {
        Hashtable _destinationDictionary;
        /// <summary>
        /// Initializes a new instance of the DestinationSettingsCollection class.
        /// </summary>
        public DestinationSettingsCollection()
        {
            _destinationDictionary = new Hashtable();
        }
        /// <summary>
        /// Adds a DestinationSettings to the collection.
        /// </summary>
        /// <param name="value">The DestinationSettings to add to the collection.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(DestinationSettings value)
        {
            _destinationDictionary[value.Id] = value;
            return List.Add(value);
        }
        /// <summary>
        /// Determines the index of a specific item in the collection. 
        /// </summary>
        /// <param name="value">The DestinationSettings to locate in the collection.</param>
        /// <returns>The index of value if found in the collection; otherwise, -1.</returns>
        public int IndexOf(DestinationSettings value)
        {
            return List.IndexOf(value);
        }
        /// <summary>
        /// Inserts a DestinationSettings item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The DestinationSettings to insert into the collection.</param>
        public void Insert(int index, DestinationSettings value)
        {
            _destinationDictionary[value.Id] = value;
            List.Insert(index, value);
        }
        /// <summary>
        /// Removes the first occurrence of a specific DestinationSettings from the collection.
        /// </summary>
        /// <param name="value">The DestinationSettings to remove from the collection.</param>
        public void Remove(DestinationSettings value)
        {
            _destinationDictionary.Remove(value.Id);
            List.Remove(value);
        }
        /// <summary>
        /// Determines whether the collection contains a specific DestinationSettings value.
        /// </summary>
        /// <param name="value">The DestinationSettings to locate in the collection.</param>
        /// <returns>true if the DestinationSettings is found in the collection; otherwise, false.</returns>
        public bool Contains(DestinationSettings value)
        {
            return List.Contains(value);
        }
        /// <summary>
        /// Determines whether the collection contains a destination with a specific identity.
        /// </summary>
        /// <param name="key">The destination identity.</param>
        /// <returns>true if the DestinationSettings is found in the collection; otherwise, false.</returns>
        public bool ContainsKey(string key)
        {
            return _destinationDictionary.ContainsKey(key);
        }
        /// <summary>
        /// Gets or sets the DestinationSettings element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>        
        public DestinationSettings this[int index]
        {
            get
            {
                return List[index] as DestinationSettings;
            }
            set
            {
                List[index] = value;
            }
        }
        /// <summary>
        /// Gets or sets the DestinationSettings element with the specified key.
        /// </summary>
        /// <param name="key">The id of the DestinationSettings element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public DestinationSettings this[string key]
        {
            get
            {
                return _destinationDictionary[key] as DestinationSettings;
            }
            set
            {
                _destinationDictionary[key] = value;
            }
        }
    }
}
