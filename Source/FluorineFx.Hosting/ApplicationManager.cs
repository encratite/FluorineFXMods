/*
	FluorineFx open source library 
	Copyright (C) 2007-2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Security.Policy;
using System.Security;
using log4net;

namespace FluorineFx.Hosting
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class ApplicationManager : MarshalByRefObject
	{
		private readonly ILog _log;

		private int _activeHostingEnvCount;
		private Dictionary<string,HostingEnvironment> _appDomains;
		private StringBuilder _appDomainsShutdownIds;
		private static readonly object ApplicationManagerStaticLock;
		private bool _shutdownInProgress;
		private static ApplicationManager _theAppManager;
		private static int _domainCount;
		private static readonly object DomainCountLock;

		static ApplicationManager()
		{
			ApplicationManagerStaticLock = new object();
			_domainCount = 0;
			DomainCountLock = new object();
		}

		internal ApplicationManager()
		{
			try
			{
				_log = LogManager.GetLogger(typeof(ApplicationManager));
			}
			catch{}

			_appDomains = new Dictionary<string, HostingEnvironment>();
			_appDomainsShutdownIds = new StringBuilder();
		}
 
		public static ApplicationManager GetApplicationManager()
		{
			if (_theAppManager == null)
			{
				lock(ApplicationManagerStaticLock)
				{
					if (_theAppManager == null)
						_theAppManager = new ApplicationManager();
				}
			}
			return _theAppManager;
		}

		public override Object InitializeLifetimeService()
		{
			return null; // never expires
		}

		private static string ConstructAppDomainId(string id)
		{
			int counter;
			lock(DomainCountLock)
			{
				_domainCount++;
				counter = _domainCount;
			}
			return (id + "-" + counter.ToString(NumberFormatInfo.InvariantInfo) + "-" + DateTime.UtcNow.ToFileTime().ToString());
		}

		internal ObjectHandle CreateInstanceInNewWorkerAppDomain(Type type, string appId, VirtualPath virtualPath, string physicalPath)
		{
			IApplicationHost appHost = new SimpleApplicationHost(virtualPath, physicalPath);
            HostingEnvironmentParameters hostingParameters = new HostingEnvironmentParameters();
            hostingParameters.HostingFlags = HostingEnvironmentFlags.HideFromAppManager;
            return CreateAppDomainWithHostingEnvironmentAndReportErrors(appId, appHost, hostingParameters).CreateInstance(type);
		}

        public IRegisteredObject CreateObject(string appId, Type type, string virtualPath, string physicalPath, bool failIfExists)
        {
            return CreateObject(appId, type, virtualPath, physicalPath, failIfExists, false);
        }

        public IRegisteredObject CreateObject(string appId, Type type, string virtualPath, string physicalPath, bool failIfExists, bool throwOnError)
        {
            if (appId == null)
                throw new ArgumentNullException("appId");
            SimpleApplicationHost appHost = new SimpleApplicationHost(VirtualPath.CreateAbsolute(virtualPath), physicalPath);
            HostingEnvironmentParameters hostingParameters = null;
            if (throwOnError)
            {
                hostingParameters = new HostingEnvironmentParameters();
                hostingParameters.HostingFlags = HostingEnvironmentFlags.ThrowHostingInitErrors;
            }
            return CreateObjectInternal(appId, type, appHost, failIfExists, hostingParameters);
        }

        public IRegisteredObject CreateObject(IApplicationHost appHost, Type type)
        {
            if (appHost == null)
                throw new ArgumentNullException("appHost");
            if (type == null)
                throw new ArgumentNullException("type");
            string appId = CreateSimpleAppId(VirtualPath.Create(appHost.GetVirtualPath()), appHost.GetPhysicalPath(), appHost.GetSiteName());
            return CreateObjectInternal(appId, type, appHost, false);
        }

        private static string CreateSimpleAppId(VirtualPath virtualPath, string physicalPath, string siteName)
        {
            string str = virtualPath.VirtualPathString + physicalPath;
            if (!string.IsNullOrEmpty(siteName))
                str = str + siteName;
            return str.GetHashCode().ToString("x", CultureInfo.InvariantCulture);
        }

        internal IRegisteredObject CreateObjectInternal(string appId, Type type, IApplicationHost appHost, bool failIfExists)
        {
            if (appId == null)
                throw new ArgumentNullException("appId");
            if (type == null)
                throw new ArgumentNullException("type");
            if (appHost == null)
                throw new ArgumentNullException("appHost");
            return CreateObjectInternal(appId, type, appHost, failIfExists, null);
        }

        internal IRegisteredObject CreateObjectInternal(string appId, Type type, IApplicationHost appHost, bool failIfExists, HostingEnvironmentParameters hostingParameters)
        {
            if (!typeof(IRegisteredObject).IsAssignableFrom(type))
            {
                throw new ArgumentException(SR.GetString(SR.NotIRegisteredObject, new object[] { type.FullName }), "type");
            }
            ObjectHandle handle = GetAppDomainWithHostingEnvironment(appId, appHost, hostingParameters).CreateWellKnownObjectInstance(type, failIfExists);
            if (handle == null)
                return null;
            return handle.Unwrap() as IRegisteredObject;
        }

        private HostingEnvironment CreateAppDomainWithHostingEnvironmentAndReportErrors(string appId, IApplicationHost appHost, HostingEnvironmentParameters hostingParameters)
		{
			HostingEnvironment environment;
			try
			{
                environment = CreateAppDomainWithHostingEnvironment(appId, appHost, hostingParameters);
			}
			catch(Exception exception)
			{
				if( _log.IsErrorEnabled )
					_log.Error(string.Format("Failed to initialize AppDomain {0}", appId), exception );
				throw;
			}
			return environment;
		}

        private HostingEnvironment CreateAppDomainWithHostingEnvironment(string appId, IApplicationHost appHost, HostingEnvironmentParameters hostingParameters)
		{
			string physicalPath = appHost.GetPhysicalPath();
			if(!StringUtil.StringEndsWith(physicalPath, Path.DirectorySeparatorChar))
				physicalPath = physicalPath + Path.DirectorySeparatorChar;

			string domainId = ConstructAppDomainId(appId);
			string tmp = appId.ToLower(CultureInfo.InvariantCulture) + physicalPath.ToLower(CultureInfo.InvariantCulture);
			string appName = tmp;
			VirtualPath appVPath = VirtualPath.Create(appHost.GetVirtualPath());
			Dictionary<string, string> dict = new Dictionary<string, string>(20);
			AppDomainSetup setup = new AppDomainSetup();
			PopulateDomainBindings(domainId, appId, appName, physicalPath, appVPath, setup, dict);
			AppDomain domain = null;
			Exception innerException = null;

			_log.Debug("DomainBindings " + domainId);
			_log.Debug("PhysicalPath = " + physicalPath);
			_log.Debug("VirtualPath = " + appVPath.VirtualPathString);
			try
			{
				domain = AppDomain.CreateDomain(domainId, GetDefaultDomainIdentity(), setup);
				foreach (KeyValuePair<string, string> entry in dict)
				{
					domain.SetData(entry.Key, entry.Value);
				}
			}
			catch(Exception exception)
			{
				innerException = exception;
			}
			if (domain == null)
				throw new SystemException("Cannot create AppDomain", innerException);

			Type type = typeof(HostingEnvironment);
			string fullName = type.Module.Assembly.FullName;
			string typeName = type.FullName;
			ObjectHandle handle = null;
			try
			{
				handle = domain.CreateInstance(fullName, typeName);
			}
			finally
			{
				if (handle == null)
				{
					_log.Debug("Unloading Domain " + domain.FriendlyName);
					AppDomain.Unload(domain);
				}
			}
			HostingEnvironment environment = (handle != null) ? (handle.Unwrap() as HostingEnvironment) : null;
			if (environment == null)
				throw new SystemException("Cannot create HostingEnvironment");

			environment.Initialize(this, appHost);
			_appDomains[appId] = environment;
			return environment;
		}

		private static void PopulateDomainBindings(string domainId, string appId, string appName, string appPath, VirtualPath appVPath, AppDomainSetup setup, IDictionary dict)
		{
			//setup.ShadowCopyFiles = "true";
			setup.ApplicationBase = appPath;
            if (Directory.Exists(Path.Combine(appPath, "bin")))
            {
                setup.PrivateBinPath = "bin";
                setup.PrivateBinPathProbe = "*";
            }
            setup.ApplicationName = appName;
			setup.ConfigurationFile = "Web.config";
			setup.DisallowCodeDownload = true;
			dict.Add(".appDomain", "*");
			dict.Add(".appId", appId);
			dict.Add(".appPath", appPath);
			dict.Add(".appVPath", appVPath.VirtualPathString);
			dict.Add(".domainId", domainId);
		}

		private static Evidence GetDefaultDomainIdentity()
		{
			Evidence evidence = new Evidence();
			bool zoneEvidence = false;
			IEnumerator hostEnumerator = AppDomain.CurrentDomain.Evidence.GetHostEnumerator();
			while (hostEnumerator.MoveNext())
			{
				if (hostEnumerator.Current is Zone)
					zoneEvidence = true;
				evidence.AddHost(hostEnumerator.Current);
			}
			hostEnumerator = AppDomain.CurrentDomain.Evidence.GetAssemblyEnumerator();
			while (hostEnumerator.MoveNext())
			{
				evidence.AddAssembly(hostEnumerator.Current);
			}
			if (!zoneEvidence)
				evidence.AddHost(new Zone(SecurityZone.MyComputer));
			return evidence;
		}

        private HostingEnvironment GetAppDomainWithHostingEnvironment(string appId, IApplicationHost appHost, HostingEnvironmentParameters hostingParameters)
        {
            HostingEnvironment environment;
            lock (this)
            {
                _appDomains.TryGetValue(appId, out environment);
                if (environment != null)
                {
                    try
                    {
                        environment.IsUnloaded();
                    }
                    catch (AppDomainUnloadedException)
                    {
                        environment = null;
                        //_appDomainsShutdowdIds.Append("Un:" + appId + ":" + DateTime.UtcNow.ToShortTimeString() + ";");
                    }
                }
                if (environment == null)
                {
                    environment = CreateAppDomainWithHostingEnvironmentAndReportErrors(appId, appHost, hostingParameters);
                    _appDomains[appId] = environment;
                }
            }
            return environment;
        }

		private HostingEnvironment FindAppDomainWithHostingEnvironment(string appId)
		{
			lock (this)
			{
                HostingEnvironment result;
				_appDomains.TryGetValue(appId, out result);
                return result;
			}
		}

		internal void HostingEnvironmentShutdownInitiated(string appId, HostingEnvironment env)
		{
			if (!_shutdownInProgress)
			{
				lock (this)
				{
					if(!env.HasBeenRemovedFromAppManagerTable)
					{
						env.HasBeenRemovedFromAppManagerTable = true;
                        if( _appDomains.ContainsKey(appId) )
						    _appDomains.Remove(appId);
					}
				}
			}
		}

		internal void HostingEnvironmentShutdownComplete(string appId, IApplicationHost appHost)
		{
			if (appHost != null)
			{
				MarshalByRefObject obj = appHost as MarshalByRefObject;
				if(obj != null)
				{
					RemotingServices.Disconnect(obj);
				}
			}
			Interlocked.Decrement(ref _activeHostingEnvCount);
		}

		public void ShutdownApplication(string appId)
		{
			if (appId == null)
				throw new ArgumentNullException("appId");
			HostingEnvironment environment = FindAppDomainWithHostingEnvironment(appId);
			if (environment != null)
				environment.InitiateShutdownInternal();
		}

		public void ShutdownAll()
		{
			_shutdownInProgress = true;
			lock (this)
			{
				foreach (KeyValuePair<string, HostingEnvironment> entry in _appDomains)
				{
				    if (entry.Value != null) entry.Value.InitiateShutdownInternal();
				}
				_appDomains = new Dictionary<string, HostingEnvironment>();
			}
			for (int i = 0; _activeHostingEnvCount > 0 && i < 3000; i++)
			{
				Thread.Sleep(100);
			}
		}

        public void StopObject(string appId, Type type)
        {
            if (appId == null)
                throw new ArgumentNullException("appId");
            if (type == null)
                throw new ArgumentNullException("type");
            HostingEnvironment environment = FindAppDomainWithHostingEnvironment(appId);
            if (environment != null)
                environment.StopWellKnownObject(type);
        }

        public ApplicationInfo[] GetRunningApplications()
        {
            ArrayList list = new ArrayList();
            lock (this)
            {
                foreach (KeyValuePair<string, HostingEnvironment> entry in _appDomains)
                {
                    if (entry.Value != null)
                    {
                        HostingEnvironment environment = entry.Value;
                        try
                        {
                            environment.IsUnloaded();
                            list.Add(environment.GetApplicationInfo());
                        }
                        catch (AppDomainUnloadedException)
                        {
                        }
                    }
                }
            }
            int count = list.Count;
            ApplicationInfo[] array = new ApplicationInfo[count];
            if (count > 0)
                list.CopyTo(array);
            return array;
        }

        public IRegisteredObject GetObject(string appId, Type type)
        {
            if (appId == null)
                throw new ArgumentNullException("appId");
            if (type == null)
                throw new ArgumentNullException("type");
            HostingEnvironment environment = FindAppDomainWithHostingEnvironment(appId);
            if (environment == null)
                return null;
            ObjectHandle handle = environment.FindWellKnownObject(type);
            if (handle == null)
                return null;
            return handle.Unwrap() as IRegisteredObject;
        }
	}
}
