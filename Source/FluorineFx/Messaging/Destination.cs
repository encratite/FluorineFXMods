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
using System.Text;
using log4net;
using FluorineFx.Util;
using FluorineFx.Messaging.Services;
using FluorineFx.Messaging.Config;

namespace FluorineFx.Messaging
{
	/// <summary>
	/// The Destination class is a source and sink for messages sent through 
	/// a service destination and uses an adapter to process messages.
	/// </summary>
    [CLSCompliant(false)]
    public class Destination
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(Destination));

		protected IService				_service;
		protected DestinationSettings	_settings;
		protected ServiceAdapter		_adapter;
		private FactoryInstance			_factoryInstance;

        private Destination()
        {
        }
        
		internal Destination(IService service, DestinationSettings settings)
		{
			_service = service;
			_settings = settings;
		}
        /// <summary>
        /// Gets the Destination identity.
        /// </summary>
		public string Id
		{
			get{ return _settings.Id; }
		}
        /// <summary>
        /// Gets the Destination's factory property.
        /// </summary>
		public string FactoryId
		{
			get
			{
				if( _settings.Properties.Contains("factory") )
					return _settings.Properties["factory"] as string;
				return "dotnet";
			}
		}

		public IService Service{ get{ return _service; } }

		internal void Init(AdapterSettings adapterSettings)
		{
			if( adapterSettings != null )
			{
				string typeName = adapterSettings.Class;
				Type type = ObjectFactory.Locate(typeName);
				if( type != null )
				{
                    _adapter = ObjectFactory.CreateInstance(type) as ServiceAdapter;
					_adapter.Service = _service;
					_adapter.Destination = this;
					_adapter.AdapterSettings = adapterSettings;
					_adapter.DestinationSettings = _settings;
					_adapter.Init();

				}
                else
                    log.Error(__Res.GetString(__Res.Type_InitError, adapterSettings.Class));
			}
            MessageBroker messageBroker = this.Service.GetMessageBroker();
            messageBroker.RegisterDestination(this, _service);

            //If the source has application scope create an instance here, so the service can listen for SessionCreated events for the first request
            if (this.Scope == "application")
            {
                FactoryInstance factoryInstance = GetFactoryInstance();
                object inst = factoryInstance.Lookup();
            }
        }
        /// <summary>
        /// Gets the ServiceAdapter used by the Destination for message processing.
        /// </summary>
        public ServiceAdapter ServiceAdapter { get { return _adapter; } }
        /// <summary>
        /// Gets the Destination settings.
        /// </summary>
		public DestinationSettings DestinationSettings{ get{ return _settings; } }

        public string Source
        {
            get
            {
                if (_settings != null && _settings.Properties != null )
                {
                    return _settings.Properties["source"] as string;
                }
                return null;
            }
        }

        public string Scope
        {
            get
            {
                if (_settings != null && _settings.Properties != null )
                {
                    return _settings.Properties["scope"] as string;
                }
                return "request";
            }
        }

		internal virtual void Dump(DumpContext dumpContext)
		{
			dumpContext.AppendLine("Destination Id = " + this.Id);
		}

		public FactoryInstance GetFactoryInstance()
		{
			if( _factoryInstance != null )
				return _factoryInstance;

			MessageBroker messageBroker = this.Service.GetMessageBroker();
			IFlexFactory factory = messageBroker.GetFactory(this.FactoryId);
			Hashtable properties = _settings.Properties;
			_factoryInstance = factory.CreateFactoryInstance(this.Id, properties);
			return _factoryInstance;
		}

	}
}
