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
using FluorineFx.Configuration;
namespace FluorineFx.Messaging.Config
{
    /// <summary>
    /// Contains the properties for configuring services.
    /// This is the <b>service</b> element in the services-config.xml file.
    /// </summary>
	public sealed class ServiceSettings
	{
		Hashtable		_supportedMessageTypes;
        DestinationSettingsCollection _destinationSettings;
        AdapterSettingsCollection _adapterSettings;
		AdapterSettings	_defaultAdapterSettings;
        ServiceConfigSettings _serviceConfigSettings;
        string _id;
        string _class;
		object _objLock = new object();


        internal ServiceSettings(ServiceConfigSettings serviceConfigSettings)
		{
            _serviceConfigSettings = serviceConfigSettings;
			_supportedMessageTypes = new Hashtable(1);
            _destinationSettings = new DestinationSettingsCollection();
            _adapterSettings = new AdapterSettingsCollection();
		}

        internal ServiceSettings(ServiceConfigSettings serviceConfigSettings, string id, string @class)
        {
            _serviceConfigSettings = serviceConfigSettings;
            _supportedMessageTypes = new Hashtable(1);
            _destinationSettings = new DestinationSettingsCollection();
            _adapterSettings = new AdapterSettingsCollection();
            _id = id;
            _class = @class;
        }

		internal void Init(string configPath)
		{
			XmlDocument servicesXml = new XmlDocument();
			servicesXml.Load(configPath);
			XmlElement root = servicesXml.DocumentElement;
			Init(root);
		}

        internal void Init(XmlNode serviceElement)
		{
			_id = serviceElement.Attributes["id"].Value;
			_class = serviceElement.Attributes["class"].Value;
			string messageTypes = serviceElement.Attributes["messageTypes"].Value;
			string[] messageTypesList = messageTypes.Split(new char[]{','}); 
			foreach(string messageType in messageTypesList)
			{
				string type = FluorineConfiguration.Instance.ClassMappings.GetType(messageType);
				_supportedMessageTypes[messageType] = type;
			}
			//Read adapters
			XmlNode adaptersNode = serviceElement.SelectSingleNode("adapters");
			if( adaptersNode != null )
			{
				foreach(XmlNode adapterNode in adaptersNode.SelectNodes("*"))
				{
                    AdapterSettings adapterSettings = new AdapterSettings(adapterNode);
                    _adapterSettings.Add(adapterSettings);
                    if( adapterSettings.Default )
						_defaultAdapterSettings = adapterSettings;
				}
			}
			else
			{
                AdapterSettings adapterSettings = new AdapterSettings("dotnet", typeof(FluorineFx.Remoting.RemotingAdapter).FullName, true);
				_defaultAdapterSettings = adapterSettings;
                _adapterSettings.Add(adapterSettings);
			}
			//Read destinations
			XmlNodeList destinationNodeList = serviceElement.SelectNodes("destination");
			foreach(XmlNode destinationNode in destinationNodeList)
			{
                DestinationSettings destinationSettings = new DestinationSettings(this, destinationNode);
                this.DestinationSettings.Add(destinationSettings);
			}
		}
        /// <summary>
        /// Gets the service identity.
        /// </summary>
        public string Id { get { return _id; } }
        /// <summary>
        /// Gets the service type.
        /// </summary>
        public string Class { get { return _class; } }
        /// <summary>
        /// Gets a dictionary of supported message types.
        /// </summary>
		public Hashtable SupportedMessageTypes{ get{ return _supportedMessageTypes; } }
        /// <summary>
        /// Gets the collection of destination settings.
        /// </summary>
        public DestinationSettingsCollection DestinationSettings { get { return _destinationSettings; } }
        /// <summary>
        /// Gets the collection of adapter settings.
        /// </summary>
        public AdapterSettingsCollection AdapterSettings { get { return _adapterSettings; } }
        /// <summary>
        /// Gets or sets the default adapter.
        /// </summary>
		public AdapterSettings DefaultAdapter
		{ 
			get{ return _defaultAdapterSettings; } 
			set{ _defaultAdapterSettings = value; }
		}
        /// <summary>
        /// Gets the ServiceConfigSettings reference.
        /// </summary>
        public ServiceConfigSettings ServiceConfigSettings { get { return _serviceConfigSettings; } }

        internal DestinationSettings CreateDestinationSettings(string id, string source)
		{
			lock(_objLock)
			{
				if( !this.DestinationSettings.ContainsKey(id) )
				{
                    AdapterSettings adapterSettings = new AdapterSettings("dotnet", typeof(FluorineFx.Remoting.RemotingAdapter).FullName, false);
					DestinationSettings destinationSettings = new DestinationSettings(this, id, adapterSettings, source);
					this.DestinationSettings.Add(destinationSettings);
					return destinationSettings;
				}
				else
					return this.DestinationSettings[id] as DestinationSettings;
			}
		}
	}

    /// <summary>
    /// Strongly typed ServiceSettings collection.
    /// </summary>
    public sealed class ServiceSettingsCollection : CollectionBase
    {
        Hashtable _serviceDictionary;
        /// <summary>
        /// Initializes a new instance of the ServiceSettingsCollection class.
        /// </summary>
        public ServiceSettingsCollection()
        {
            _serviceDictionary = new Hashtable();
        }
        /// <summary>
        /// Adds a ServiceSettings to the collection.
        /// </summary>
        /// <param name="value">The ServiceSettings to add to the collection.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(ServiceSettings value)
        {
            _serviceDictionary[value.Id] = value;
            return List.Add(value);
        }
        /// <summary>
        /// Determines the index of a specific item in the collection. 
        /// </summary>
        /// <param name="value">The ServiceSettings to locate in the collection.</param>
        /// <returns>The index of value if found in the collection; otherwise, -1.</returns>
        public int IndexOf(ServiceSettings value)
        {
            return List.IndexOf(value);
        }
        /// <summary>
        /// Inserts a ServiceSettings item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The ServiceSettings to insert into the collection.</param>
        public void Insert(int index, ServiceSettings value)
        {
            _serviceDictionary[value.Id] = value;
            List.Insert(index, value);
        }
        /// <summary>
        /// Removes the first occurrence of a specific ServiceSettings from the collection.
        /// </summary>
        /// <param name="value">The ServiceSettings to remove from the collection.</param>
        public void Remove(ServiceSettings value)
        {
            _serviceDictionary.Remove(value.Id);
            List.Remove(value);
        }
        /// <summary>
        /// Determines whether the collection contains a specific ServiceSettings value.
        /// </summary>
        /// <param name="value">The ServiceSettings to locate in the collection.</param>
        /// <returns>true if the ServiceSettings is found in the collection; otherwise, false.</returns>
        public bool Contains(ServiceSettings value)
        {
            return List.Contains(value);
        }
        /// <summary>
        /// Gets or sets the ServiceSettings element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public ServiceSettings this[int index]
        {
            get
            {
                return List[index] as ServiceSettings;
            }
            set
            {
                List[index] = value;
            }
        }
        /// <summary>
        /// Gets or sets the ServiceSettings element with the specified key.
        /// </summary>
        /// <param name="key">The id of the ServiceSettings element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public ServiceSettings this[string key]
        {
            get
            {
                return _serviceDictionary[key] as ServiceSettings;
            }
            set
            {
                _serviceDictionary[key] = value;
            }
        }
    }
}
