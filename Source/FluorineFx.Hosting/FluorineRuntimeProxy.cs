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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using log4net;

namespace FluorineFx.Hosting
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class FluorineRuntimeProxy : MarshalByRefObject, IRegisteredObject
	{
        private readonly ILog _log;
        private string _virtualPath;
        private string _physicalDir;
        private string _appId;
        private bool _singleDomain;
        private string _binDir;
        private readonly List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();
        bool _appShutdown;
        private object _serverHandle;
        private EventHandler _onAppDomainUnload;
        private HostManager _hostManager;

        private WaitCallback _onAppDomainShutdown;
        private WaitCallback _onAppDomainUnloadedCallback;
        ApplicationShutdownReason _reason;
        ApplicationInfo _applicationInfo;

		public FluorineRuntimeProxy()
		{
			try
			{
				_log = LogManager.GetLogger(typeof(FluorineRuntimeProxy));
			}
			catch{}
            HostingEnvironment.RegisterObject(this);
		}

        public static FluorineRuntimeProxy Start(HostManager hostManager, string physicalPath, string virtualPath, string privateBinPath, string configFile, string shadowCopyAssemblies, bool singleDomain)
		{
			if(!StringUtil.StringEndsWith(physicalPath, Path.DirectorySeparatorChar))
				physicalPath = physicalPath + Path.DirectorySeparatorChar;

			// Copy this hosting DLL into the /bin directory of the application
			string fileName = Assembly.GetExecutingAssembly().Location;
            string binDirectory = Path.Combine(physicalPath, "Bin");
            if (!Directory.Exists(binDirectory))
                binDirectory = Path.Combine(physicalPath, "bin");
            if (!Directory.Exists(binDirectory))
                binDirectory = physicalPath; //Directory.CreateDirectory(binDirectory);
            try
			{
				string name = Path.GetFileName(fileName);
				File.Copy(fileName, Path.Combine(binDirectory, name), true);
			}
			catch{;}
			/*
			MakeShadowCopies(shadowCopyAssemblies, physicalPath);
			*/

#if NET_2_0
            TextWriter textWriter = new StreamWriter(Path.Combine(physicalPath, "web"));
            textWriter.Close();
            string configurationFile = Path.Combine(physicalPath, "web");
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(configurationFile);
            System.Net.Configuration.SettingsSection section = (System.Net.Configuration.SettingsSection)config.GetSection("system.net/settings");
            section.Socket.AlwaysUseCompletionPortsForAccept = true;
            section.Socket.AlwaysUseCompletionPortsForConnect = true;
            config.Save();
#endif
            FluorineRuntimeProxy host = null;
            if (!singleDomain)
                host = ApplicationHost.CreateApplicationHost(typeof(FluorineRuntimeProxy), virtualPath, physicalPath, privateBinPath) as FluorineRuntimeProxy;
            else
                host = new FluorineRuntimeProxy();
			if( host != null )
			{
                host.HostManager = hostManager;
                host.VirtualPath = virtualPath;
				host.PhysicalDir = physicalPath;
                host.SingleDomain = singleDomain;
                host.BinDir = binDirectory;
			}
            if (singleDomain)
            {
                //AppDomain.CurrentDomain.AppendPrivatePath(binDirectory);
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            }
			return host;
		}

        static string ProbeAssembly(string rootDir, string assemblyFileName)
        {
            if( File.Exists( Path.Combine(rootDir, assemblyFileName) ))
                return Path.Combine(rootDir, assemblyFileName);
            string binDirectory = Path.Combine(rootDir, "Bin");
            if (Directory.Exists(binDirectory))
            {
                string asmPath = Path.Combine(binDirectory, assemblyFileName);
                if (File.Exists(asmPath)) 
                    return asmPath;
            }
            binDirectory = Path.Combine(rootDir, "bin");
            if (Directory.Exists(binDirectory))
            {
                string asmPath = Path.Combine(binDirectory, assemblyFileName);
                if (File.Exists(asmPath)) 
                    return asmPath;
            }
            /*
            string applicationsPath = Path.Combine(rootDir, "applications");
            foreach (string dir in Directory.GetDirectories(applicationsPath))
            {
                string asmPath = Path.Combine(dir, assemblyFileName);
                if (File.Exists(asmPath))
                    return asmPath;
            }
            */
            return null;
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string[] asmName = args.Name.Split(',');
            string rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string asmPath = ProbeAssembly(rootDir, asmName[0] + ".dll");
            if (asmPath == null) 
                throw (new Exception("Assembly " + asmName[0] + " not found."));
            //return Assembly.LoadFile(asmPath, Assembly.GetExecutingAssembly().Evidence);
            byte[] asm = File.ReadAllBytes(asmPath);
            return Assembly.Load(asm);
        }

		/// <summary>
		/// Copies any assemblies marked for ShadowCopying into the BIN directory.
		/// Copies only if the assemblies in the source dir are newer.
		/// </summary>
		private static void MakeShadowCopies(string shadowCopyAssemblies, string physicalDir)
		{
			ILog log = null;
			try
			{
				log = LogManager.GetLogger(typeof(FluorineRuntimeProxy));
			}
			catch{}

			if(string.IsNullOrEmpty(shadowCopyAssemblies))
				return;

			string binDirectory = Path.Combine(physicalDir, "Bin");
			if(!Directory.Exists(binDirectory))
				binDirectory = Path.Combine(physicalDir, "bin");
			if(!Directory.Exists(binDirectory))
				binDirectory = physicalDir; //Directory.CreateDirectory(binDirectory);

			string[] assemblies = shadowCopyAssemblies.Split(';', ',');
			foreach (string asm in assemblies)
			{
				try
				{
					string assembly = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, asm);
					string targetFile = Path.Combine(binDirectory, assembly );//Path.GetFileName(assembly));
					if (File.Exists(targetFile))
					{
						// Compare Timestamps
						DateTime sourceTime = File.GetLastWriteTime(assembly);
						DateTime targetTime = File.GetLastWriteTime(targetFile);
						if (sourceTime == targetTime)
							continue;
					}
					log.Info("Copy " + assembly + " to " + targetFile);
					File.Copy(assembly, targetFile, true);
				}
				catch(Exception exception)
				{
					if( log!=null && log.IsErrorEnabled )
						log.Error(exception);
				}
			}
		}

		public override Object InitializeLifetimeService()
		{
            return null;// never expires
		}

		public string VirtualPath
		{
			get{ return _virtualPath; }
			set{ _virtualPath = value; }
		}

		public string PhysicalDir
		{
			get{ return _physicalDir; }
			set{ _physicalDir = value; }
		}

        public string BinDir
        {
            get { return _binDir; }
            set { _binDir = value; }
        }

		public string AppId
		{
			get{ return _appId; }
			set{ _appId = value; }
		}

        public bool SingleDomain
        {
            get { return _singleDomain; }
            set { _singleDomain = value; }
        }

        public HostManager HostManager
        {
            get { return _hostManager; }
            set { _hostManager = value; }
        }

		public void Start()
		{
			try
			{
                _onAppDomainUnload = new EventHandler(OnAppDomainUnload);
                _onAppDomainUnloadedCallback = new WaitCallback(OnAppDomainUnloadedCallback);
                _onAppDomainShutdown = new WaitCallback(OnAppDomainShutdownCallback);
                Thread.GetDomain().DomainUnload += _onAppDomainUnload;
                FluorineRuntime.AppDomainShutdown += new HostUnloadEventHandler(this.OnAppDomainShutdown);

				//string configPath = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + "web-inf" + System.IO.Path.DirectorySeparatorChar + "flex" + System.IO.Path.DirectorySeparatorChar;
                string configPath = Path.Combine(_physicalDir, "web-inf");
                configPath = Path.Combine(configPath, "flex");
                //Thread.GetDomain().SetData(".appVPath", _virtualPath);

				_serverHandle = AppDomain.CurrentDomain.CreateInstanceAndUnwrap("FluorineFx", "FluorineFx.Messaging.MessageServer");
				if( _serverHandle != null )
				{
					Type type = _serverHandle.GetType();
                    MethodInfo miInit = type.GetMethod("Init", new Type[] { typeof(string), typeof(bool) });
                    if (miInit != null)
                    {
                        miInit.Invoke(_serverHandle, new object[] { configPath, false });
                        MethodInfo miStart = type.GetMethod("Start");
                        miStart.Invoke(_serverHandle, new object[0]);
                        _log.Info("FluorineRuntimeProxy started.");
                    }
                    else
                        _log.Error("Could not load FluorineFx.Messaging.MessageServer.");
				}
				else
					_log.Error("Could not load FluorineFx.Messaging.MessageServer.");

                WatchLocationForRestart("Web.config");
                WatchLocationForRestart("web.config");
                WatchLocationForRestart("Web.Config");
                WatchLocationForRestart(_physicalDir, "*.dll");
                string binFolder = Path.Combine(_physicalDir, "bin");
                if( Directory.Exists(binFolder) )
                    WatchLocationForRestart(binFolder, "*.dll");
			}
			catch (Exception ex)
			{
				_log.Fatal("Failed to start FluorineRuntimeProxy.", ex);
			}

		}

        #region IRegisteredObject Members

        public void Stop(bool immediate)
        {
            if (!_appShutdown)
            {
                _appShutdown = true;
                if (_log != null && _log.IsInfoEnabled)
                    _log.Info("Stopping FluorineRuntimeProxy.");

                try
                {
                    if (_serverHandle != null)
                    {
                        Type type = _serverHandle.GetType();
                        MethodInfo miStop = type.GetMethod("Stop");
                        miStop.Invoke(_serverHandle, new object[0]);
                        _log.Info("FluorineRuntimeProxy stopped.");
                    }
                    //if( !_singleDomain )
                    //    ApplicationHost.ShutdownApplication(this.PhysicalDir);
                }
                catch (Exception ex)
                {
                    _log.Fatal("Failed to stop FluorineRuntimeProxy.", ex);
                }
                HostingEnvironment.UnregisterObject(this);
            }
        }

        #endregion

        static FileSystemWatcher CreateWatcher(string file, FileSystemEventHandler fseh, RenamedEventHandler reh)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetFullPath(Path.GetDirectoryName(file));
            watcher.Filter = Path.GetFileName(file);
            // This will enable the Modify flag for Linux/inotify
            watcher.NotifyFilter |= NotifyFilters.Size;
            watcher.Changed += fseh;
            watcher.Created += fseh;
            watcher.Deleted += fseh;
            watcher.Renamed += reh;
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        private void DisableWatchers()
        {
            lock (((ICollection) _watchers).SyncRoot)
            {
                foreach (FileSystemWatcher watcher in _watchers)
                    watcher.EnableRaisingEvents = false;
            }
        }

        private void EnableWatchers()
        {
            lock (((ICollection) _watchers).SyncRoot)
            {
                foreach (FileSystemWatcher watcher in _watchers)
                    watcher.EnableRaisingEvents = true;
            }
        }

        private void OnFileRenamed(object sender, RenamedEventArgs args)
        {
            OnFileChanged(sender, args);
        }

        private void OnFileChanged(object sender, FileSystemEventArgs args)
        {
            lock (((ICollection) _watchers).SyncRoot)
            {
                if (_appShutdown)
                    return;
                Stop(false);

                // Disable event raising to avoid concurrent restarts
                DisableWatchers();

                ApplicationShutdownReason reason = ApplicationShutdownReason.None;
                string name = new DirectoryInfo(args.FullPath).Name;
                string message = name + " dir change or directory rename";
                if (StringUtil.EqualsIgnoreCase(name, "web.config"))
                {
                    reason = ApplicationShutdownReason.ConfigurationChange;
                    message = "Config file change";
                }
                else if (StringUtil.EqualsIgnoreCase(name, "bin"))
                {
                    reason = ApplicationShutdownReason.BinDirChangeOrDirectoryRename;
                }
                else
                {
                    reason = ApplicationShutdownReason.ConfigurationChange;
                }
                if (args.ChangeType == WatcherChangeTypes.Created)
                {
                    FluorineRuntime.SetUserForcedShutdown();
                }
                // Restart application
                FluorineRuntime.ShutdownAppDomain(reason, message);
            }
        }

        internal bool WatchLocationForRestart(string filter)
        {
            return WatchLocationForRestart("", filter, false);
        }

        internal bool WatchLocationForRestart(string virtualPath, string filter)
        {
            return WatchLocationForRestart(virtualPath, filter, false);
        }

        internal bool WatchLocationForRestart(string virtualPath, string filter, bool watchSubdirs)
        {
            //Map the path to the physical one
            string physicalPath = FluorineRuntime.AppDomainAppPath;
            physicalPath = Path.Combine(physicalPath, virtualPath);
            bool isDir = Directory.Exists(physicalPath);
            bool isFile = isDir ? false : File.Exists(physicalPath);

            if (isDir || isFile)
            {
                // create the watcher
                FileSystemEventHandler fseh = new FileSystemEventHandler(OnFileChanged);
                RenamedEventHandler reh = new RenamedEventHandler(OnFileRenamed);
                FileSystemWatcher watcher = CreateWatcher(Path.Combine(physicalPath, filter), fseh, reh);
                if (isDir)
                    watcher.IncludeSubdirectories = watchSubdirs;

                lock (((ICollection) _watchers).SyncRoot)
                {
                    _watchers.Add(watcher);
                }
                return true;
            }
            return false;
        }

        private void OnAppDomainShutdown(object sender, HostUnloadEventArgs args)
        {
            //_hostManager.OnAppDomainShutdown(args.Reason);
            ThreadPool.QueueUserWorkItem(_onAppDomainShutdown, args.Reason);
        }

        private void OnAppDomainShutdownCallback(object obj)
        {
            _hostManager.OnAppDomainShutdown(new ApplicationInfo(HostingEnvironment.ApplicationId, HostingEnvironment.ApplicationVirtualPathObject, HostingEnvironment.ApplicationPhysicalPath), (ApplicationShutdownReason)obj);
        }

        internal void OnAppDomainUnload(object unusedObject, EventArgs unusedEventArgs)
        {
            Thread.GetDomain().DomainUnload -= _onAppDomainUnload;
            _reason = FluorineRuntime.ShutdownReason;
            _applicationInfo = new ApplicationInfo(HostingEnvironment.ApplicationId, HostingEnvironment.ApplicationVirtualPathObject, HostingEnvironment.ApplicationPhysicalPath);
            ThreadPool.QueueUserWorkItem(_onAppDomainUnloadedCallback);
        }

        private void OnAppDomainUnloadedCallback(object unused)
        {
            if (_hostManager != null)
            {
                _hostManager.OnAppDomainUnloaded(_applicationInfo, _reason);
                _hostManager = null;
            }
        }
    }
}
