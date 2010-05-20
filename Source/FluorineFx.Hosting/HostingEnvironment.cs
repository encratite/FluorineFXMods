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
using System.Threading;
using System.Runtime.Remoting;

namespace FluorineFx.Hosting
{
    [Flags]
    internal enum HostingEnvironmentFlags
    {
        //ClientBuildManager = 8,
        Default = 0,
        DontCallAppInitialize = 4,
        HideFromAppManager = 1,
        ThrowHostingInitErrors = 2
    }

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class HostingEnvironment : MarshalByRefObject
	{
		//private string _appConfigPath;
		private bool _appDomainShutdownStarted;
		private IApplicationHost _appHost;
		private string _appId;
		private ApplicationManager _appManager;
		private string _appPhysicalPath;
		private VirtualPath _appVirtualPath;
		private static HostingEnvironment _theHostingEnvironment;
		private bool _removedFromAppManager;
		private static bool _hasBeenRemovedFromAppManangerTable;
		private bool _shutdownInitated;
		private bool _shutdownInProgress;
		private WaitCallback _initiateShutdownWorkItemCallback;
        private readonly Dictionary<IRegisteredObject, IRegisteredObject> _registeredObjects;
        private readonly Dictionary<string, IRegisteredObject> _wellKnownObjects;

		private readonly EventHandler _onAppDomainUnload;

		public HostingEnvironment()
		{
            _registeredObjects = new Dictionary<IRegisteredObject, IRegisteredObject>();
            _wellKnownObjects = new Dictionary<string, IRegisteredObject>();
			if(_theHostingEnvironment != null)
				throw new InvalidOperationException("Only one HostingEnvironment allowed");
			_theHostingEnvironment = this;
			_onAppDomainUnload = new EventHandler(OnAppDomainUnload);
			Thread.GetDomain().DomainUnload += _onAppDomainUnload;
		}

        public override object InitializeLifetimeService()
        {
            return null;// never expires
        }

        internal void IsUnloaded()
        {
        }

        public static bool IsHosted
        {
            get
            {
                return (_theHostingEnvironment != null);
            }
        }

        public static ApplicationShutdownReason ShutdownReason
        {
            get { return FluorineRuntime.ShutdownReason; }
        }

        public static string ApplicationId
        {
            get
            {
                if (_theHostingEnvironment == null)
                    return null;
                return _theHostingEnvironment._appId;
            }
        }

        public static string ApplicationPhysicalPath
        {
            get
            {
                if (_theHostingEnvironment == null)
                    return null;
                return _theHostingEnvironment._appPhysicalPath;
            }
        }

        public static VirtualPath ApplicationVirtualPathObject
        {
            get
            {
                if (_theHostingEnvironment == null)
                    return null;
                return _theHostingEnvironment._appVirtualPath;
            }
        }

		internal static bool ShutdownInitiated
		{
			get
			{
				if (_theHostingEnvironment == null)
					return false;
				return _theHostingEnvironment._shutdownInitated;
			}
		}

		internal static bool ShutdownInProgress
		{
			get
			{
				if (_theHostingEnvironment == null)
					return false;
				return _theHostingEnvironment._shutdownInProgress;
			}
		}

		private void OnAppDomainUnload(object unusedObject, EventArgs unusedEventArgs)
		{
			Thread.GetDomain().DomainUnload -= _onAppDomainUnload;
			if (!_removedFromAppManager)
			{
				RemoveThisAppDomainFromAppManagerTableOnce();
			}
            StopRegisteredObjects(true);
			if(_appManager != null)
			{
				_appManager.HostingEnvironmentShutdownComplete(_appId, _appHost);
			}
		}

		private void RemoveThisAppDomainFromAppManagerTableOnce()
		{
			bool remove = false;
			if(!_removedFromAppManager)
			{
				lock (this)
				{
					if (!_removedFromAppManager)
					{
						remove = true;
						_removedFromAppManager = true;
					}
				}
			}
			if (remove && _appManager != null)
			{
				_appManager.HostingEnvironmentShutdownInitiated(_appId, this);
			}
		}

		internal ObjectHandle CreateInstance(Type type)
		{
			return new ObjectHandle(Activator.CreateInstance(type));
		}

		internal bool HasBeenRemovedFromAppManagerTable
		{
			get
			{
				return _hasBeenRemovedFromAppManangerTable;
			}
			set
			{
				_hasBeenRemovedFromAppManangerTable = value;
			}
		}

		internal void Initialize(ApplicationManager appManager, IApplicationHost appHost)
		{
			_appManager = appManager;
			_appId = FluorineRuntime.AppDomainAppIdInternal;
			_appVirtualPath = FluorineRuntime.AppDomainAppVirtualPathObject;
			_appPhysicalPath = FluorineRuntime.AppDomainAppPathInternal;
			_appHost = appHost;
			_initiateShutdownWorkItemCallback = new WaitCallback(InitiateShutdownWorkItemCallback);
		}

		public static void InitiateShutdown()
		{
			if (_theHostingEnvironment != null)
				_theHostingEnvironment.InitiateShutdownInternal();
		}

		internal void InitiateShutdownInternal()
		{
			bool shutdown = false;
			if (!_shutdownInitated)
			{
				lock (this)
				{
					if (!_shutdownInitated)
					{
						_shutdownInProgress = true;
						shutdown = true;
						_shutdownInitated = true;
					}
				}
			}
		    if (!shutdown) return;
		    //HostingEnvironment initiated shutdown
		    FluorineRuntime.SetShutdownReason(ApplicationShutdownReason.HostingEnvironment, "HostingEnvironment initiated shutdown");
		    RemoveThisAppDomainFromAppManagerTableOnce();
		    ThreadPool.QueueUserWorkItem(_initiateShutdownWorkItemCallback);
		}

		private void InitiateShutdownWorkItemCallback(object state)
		{
			ShutdownThisAppDomainOnce();
		}

		private void ShutdownThisAppDomainOnce()
		{
			bool shutdown = false;
			if (!_appDomainShutdownStarted)
			{
				lock (this)
				{
					if (!_appDomainShutdownStarted)
					{
						shutdown = true;
						_appDomainShutdownStarted = true;
					}
				}
			}
			if(shutdown)
			{
                FluorineRuntime.SetUserForcedShutdown();
				_shutdownInProgress = false;
				FluorineRuntime.ShutdownAppDomain(ApplicationShutdownReason.HostingEnvironment, SR.GetString(SR.HostingEnvRestart));
			}
		}

        public static void RegisterObject(IRegisteredObject obj)
        {
            if (_theHostingEnvironment != null)
            {
                _theHostingEnvironment.RegisterRunningObjectInternal(obj);
            }
        }

        public static void UnregisterObject(IRegisteredObject obj)
        {
            if (_theHostingEnvironment != null)
            {
                _theHostingEnvironment.UnregisterRunningObjectInternal(obj);
            }
        }

        private void RegisterRunningObjectInternal(IRegisteredObject obj)
        {
            lock (this)
            {
                _registeredObjects[obj] = obj;
            }
        }

        private void UnregisterRunningObjectInternal(IRegisteredObject obj)
        {
            bool shutdown = false;
            lock (this)
            {
                string fullName = obj.GetType().FullName;
                if (_wellKnownObjects.ContainsKey(fullName) && _wellKnownObjects[fullName] == obj)
                    _wellKnownObjects.Remove(fullName);
                if (_registeredObjects.ContainsKey(obj))
                    _registeredObjects.Remove(obj);
                if (_registeredObjects.Count == 0)
                    shutdown = true;
            }
            if (shutdown)
                InitiateShutdownInternal();
        }

        internal ApplicationInfo GetApplicationInfo()
        {
            return new ApplicationInfo(_appId, _appVirtualPath, _appPhysicalPath);
        }

        private bool IsWellKnownObject(object obj)
        {
            bool found = false;
            string fullName = obj.GetType().FullName;
            lock (this)
            {
                if (_wellKnownObjects.ContainsKey(fullName) && _wellKnownObjects[fullName] == obj)
                    found = true;
            }
            return found;
        }

        internal void StopWellKnownObject(Type type)
        {
            IRegisteredObject obj;
            string fullName = type.FullName;
            lock (this)
            {
                _wellKnownObjects.TryGetValue(fullName, out obj);
                if (obj != null)
                {
                    _wellKnownObjects.Remove(fullName);
                    obj.Stop(false);
                }
            }
        }

        private void StopRegisteredObjects(bool immediate)
        {
            if (_registeredObjects.Count > 0)
            {
                ArrayList list = new ArrayList();
                lock (this)
                {
                    foreach (KeyValuePair<IRegisteredObject, IRegisteredObject> entry in _registeredObjects)
                    {
                        object key = entry.Key;
                        if (IsWellKnownObject(key))
                            list.Insert(0, key);
                        else
                            list.Add(key);
                    }
                }
                foreach (IRegisteredObject obj in list)
                {
                    try
                    {
                        obj.Stop(immediate);
                    }
                    catch
                    {
                    }
                }
            }
        }

        internal ObjectHandle FindWellKnownObject(Type type)
        {
            IRegisteredObject obj;
            string fullName = type.FullName;
            lock (this)
            {
                _wellKnownObjects.TryGetValue(fullName, out obj);
            }
            if (obj == null)
                return null;
            return new ObjectHandle(obj);
        }

        internal ObjectHandle CreateWellKnownObjectInstance(Type type, bool failIfExists)
        {
            IRegisteredObject obj;
            string fullName = type.FullName;
            bool exists = false;
            lock (this)
            {
                _wellKnownObjects.TryGetValue(fullName, out obj);
                if (obj == null)
                {
                    obj = (IRegisteredObject)Activator.CreateInstance(type);
                    _wellKnownObjects[fullName] = obj;
                }
                else
                {
                    exists = true;
                }
            }
            if (exists && failIfExists)
            {
                throw new InvalidOperationException(SR.GetString(SR.WellknownObjectAlreadyExists, new object[] { fullName }));
            }
            return new ObjectHandle(obj);
        }
	}
}
