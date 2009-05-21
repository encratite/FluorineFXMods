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
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
#if !FXCLIENT
using System.Web;
using FluorineFx.HttpCompress;
#endif


namespace FluorineFx.Configuration
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum RemotingServiceAttributeConstraint
	{
#if !SILVERLIGHT
		[XmlEnum(Name = "browse")]
#endif
        Browse = 1,
#if !SILVERLIGHT
		[XmlEnum(Name = "access")]
#endif
        Access = 2
	}

    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
	public enum TimezoneCompensation
	{
#if !SILVERLIGHT
		[XmlEnum(Name = "none")]
#endif
		None = 0,
#if !SILVERLIGHT
		[XmlEnum(Name = "auto")]
#endif
        Auto = 1,
#if !SILVERLIGHT
        [XmlEnum(Name = "server")]
#endif
        Server = 2,
#if !SILVERLIGHT
        [XmlEnum(Name = "ignoreUTCKind")]
#endif
        IgnoreUTCKind = 3
	}

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class FluorineConfiguration
	{
		static object _objLock = new object();
		static FluorineConfiguration _instance;

		static FluorineSettings		_fluorineSettings;
#if !FXCLIENT
        static CacheMap				_cacheMap = new CacheMap();
#endif
        static bool					_fullTrust;


		private FluorineConfiguration()
		{
		}

		static public FluorineConfiguration Instance
		{
			get
			{
				if( _instance == null )
				{
					lock (_objLock) 
					{
						if( _instance == null )
						{
                            FluorineConfiguration instance = new FluorineConfiguration();
#if (NET_1_1)
							_fluorineSettings = ConfigurationSettings.GetConfig("fluorinefx/settings") as FluorineSettings;
#else
#if SILVERLIGHT
                            _fluorineSettings = new FluorineSettings();
#else
							_fluorineSettings = ConfigurationManager.GetSection("fluorinefx/settings") as FluorineSettings;
#endif
#endif
                            if (_fluorineSettings == null)
                                _fluorineSettings = new FluorineSettings();
#if !FXCLIENT
							if( _fluorineSettings != null && _fluorineSettings.Cache != null )
							{
								foreach(CachedService cachedService in _fluorineSettings.Cache)
								{
									_cacheMap.AddCacheDescriptor( cachedService.Type, cachedService.Timeout, cachedService.SlidingExpiration);
								}
							}
#endif
                            _fullTrust = CheckApplicationPermissions();
                            System.Threading.Thread.MemoryBarrier();
                            _instance = instance;
						}
					}
				}
				return _instance;
			}
		}

		public FluorineSettings FluorineSettings
		{ 
			get
			{
				return _fluorineSettings;
			}
        }
#if !FXCLIENT
		internal ServiceCollection ServiceMap
		{ 
			get
			{
				if( _fluorineSettings != null )
					return _fluorineSettings.Services;
				return null;
			}
		}
#endif
        internal ClassMappingCollection ClassMappings
		{
			get
			{
				return _fluorineSettings.ClassMappings;
			}
        }

#if !FXCLIENT
		internal string GetServiceName(string serviceLocation)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetServiceName(serviceLocation);
			return serviceLocation;
		}

		internal string GetServiceLocation(string serviceName)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetServiceLocation(serviceName);
			return serviceName;
		}

		internal string GetMethodName(string serviceLocation, string method)
		{
			if( this.ServiceMap != null )
				return this.ServiceMap.GetMethodName(serviceLocation, method);
			return method;
		}
#endif
        internal string GetMappedTypeName(string customClass)
		{
			if( this.ClassMappings != null )
				return this.ClassMappings.GetType(customClass);
			else
				return customClass;
		}

		internal string GetCustomClass(string type)
		{
			if( this.ClassMappings != null )
				return this.ClassMappings.GetCustomClass(type);
			else
				return type;
        }

#if !FXCLIENT
		internal CacheMap CacheMap
		{	
			get
			{
				return _cacheMap;
			}
		}


        public bool WsdlGenerateProxyClasses
		{ 
			get
			{ 
				if( _fluorineSettings != null )
					return _fluorineSettings.WsdlGenerateProxyClasses;
				return false;
			}
		}

        public string WsdlProxyNamespace
		{
			get
			{ 
				if( _fluorineSettings != null )
					return _fluorineSettings.WsdlProxyNamespace;
				return "FluorineFx.Proxy"; 
			}
		}

        public ImportNamespaceCollection ImportNamespaces
		{ 
			get
			{ 
				if( _fluorineSettings != null )
					return _fluorineSettings.ImportNamespaces;
				return null; 
			}
		}
#endif

        public NullableTypeCollection NullableValues
		{ 
			get
			{ 
				if( _fluorineSettings != null )
					return _fluorineSettings.Nullables;
				return null;
			}
		}

		public bool AcceptNullValueTypes
		{ 
			get
			{
				if( _fluorineSettings != null )
					return _fluorineSettings.AcceptNullValueTypes;
				return false;
			}
        }

#if !FXCLIENT
        public RemotingServiceAttributeConstraint RemotingServiceAttributeConstraint
		{
			get
			{
				if( _fluorineSettings != null )
					return _fluorineSettings.RemotingServiceAttribute;
				return RemotingServiceAttributeConstraint.Access;
			}
		}
#endif

        public TimezoneCompensation TimezoneCompensation
        {
            get 
            {
				if( _fluorineSettings != null )
					return _fluorineSettings.TimezoneCompensation;
				return TimezoneCompensation.None;
            }
        }
#if !FXCLIENT
        public HttpCompressSettings HttpCompressSettings
        {
            get
            {
				if( _fluorineSettings != null && _fluorineSettings.HttpCompressSettings != null )				
					return _fluorineSettings.HttpCompressSettings;
				else
					return HttpCompressSettings.Default;
            }
        }
#endif

#if !FXCLIENT
        internal LoginCommandCollection LoginCommands
        {
            get
            {
				if( _fluorineSettings != null )
					return _fluorineSettings.LoginCommands;
				return null;
            }
        }
#endif

        public OptimizerSettings OptimizerSettings
		{
			get
			{
				if( _fluorineSettings != null )
					return _fluorineSettings.Optimizer;
				return null;
			}
        }

#if !FXCLIENT
        internal SwxSettings SwxSettings
		{
			get
			{
				if( _fluorineSettings != null )
					return _fluorineSettings.SwxSettings;
				return null;
			}
		}
#endif

        public bool FullTrust
		{
			get{ return _fullTrust; }
		}

		private static bool CheckApplicationPermissions()
        {
#if !FXCLIENT
			try
			{
				// See if we're running in full trust
				new PermissionSet(PermissionState.Unrestricted).Demand();
				return true;
			}
			catch (SecurityException)
			{
			}
#endif
            return false;
		}
	}
}
