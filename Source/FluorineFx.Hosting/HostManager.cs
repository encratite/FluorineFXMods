using System;
using System.Collections;
using System.Timers;
using System.IO;
using log4net;

namespace FluorineFx.Hosting
{
    public delegate void ApplicationShutdownHandler(object sender, ApplicationShutdownEventArgs e);
    public delegate void ApplicationRestartHandler(object sender, ApplicationRestartEventArgs e);
    public delegate void ApplicationErrorHandler(object sender, ApplicationErrorEventArgs e);

    public class ApplicationShutdownEventArgs : EventArgs
    {
        private readonly ApplicationShutdownReason _reason;
        private readonly ApplicationInfo _applicationInfo;

        internal ApplicationShutdownEventArgs(ApplicationInfo applicationInfo, ApplicationShutdownReason reason)
        {
            _applicationInfo = applicationInfo;
            _reason = reason;
        }

        public ApplicationShutdownReason Reason
        {
            get
            {
                return _reason;
            }
        }

        public ApplicationInfo Application
        {
            get
            {
                return _applicationInfo;
            }
        }
    }

    public class ApplicationRestartEventArgs : EventArgs
    {
        private readonly ApplicationShutdownReason _reason;
        private readonly ApplicationInfo _applicationInfo;

        internal ApplicationRestartEventArgs(ApplicationInfo applicationInfo, ApplicationShutdownReason reason)
        {
            _applicationInfo = applicationInfo;
            _reason = reason;
        }

        public ApplicationShutdownReason Reason
        {
            get
            {
                return _reason;
            }
        }

        public ApplicationInfo Application
        {
            get
            {
                return _applicationInfo;
            }
        }
    }

    public class ApplicationErrorEventArgs : EventArgs
    {
        private readonly Exception _exception;
        private readonly ApplicationInfo _applicationInfo;

        internal ApplicationErrorEventArgs(ApplicationInfo applicationInfo, Exception exception)
        {
            _applicationInfo = applicationInfo;
            _exception = exception;
        }

        public Exception Exception
        {
            get
            {
                return _exception;
            }
        }

        public ApplicationInfo Application
        {
            get
            {
                return _applicationInfo;
            }
        }
    }

    internal class HostEvent
    {
        private readonly ApplicationShutdownReason _reason;
        private readonly ApplicationInfo _applicationInfo;

        /// <summary>
        /// Only delayed events that are unique will be fired.
        /// </summary>
        private bool _delayed;

        public HostEvent(ApplicationInfo applicationInfo, ApplicationShutdownReason reason)
        {
            _applicationInfo = applicationInfo;
            _reason = reason;
            _delayed = false;
        }

        public ApplicationInfo ApplicationInfo
        {
            get
            {
                return _applicationInfo;
            }
        }

        public ApplicationShutdownReason Reason
        {
            get
            {
                return _reason;
            }
        }

        public bool Delayed
        {
            get
            {
                return _delayed;
            }
            set
            {
                _delayed = value;
            }
        }

        public virtual bool IsDuplicate(object obj)
        {
            HostEvent hostEvent = obj as HostEvent;
            if (hostEvent == null)
            {
                return false; // this is not null so they are different 
            }
            ApplicationInfo applicationInfo1 = ApplicationInfo;
            ApplicationShutdownReason reason1 = Reason;
            ApplicationInfo applicationInfo2 = hostEvent.ApplicationInfo;
            ApplicationShutdownReason reason2 = hostEvent.Reason;
            return (applicationInfo1 != null && applicationInfo2 != null && applicationInfo1.Id == applicationInfo2.Id &&
                    reason1 == reason2);
        }
    }
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	//[ClassInterfaceAttribute(ClassInterfaceType.AutoDual)]
	[System.Runtime.InteropServices.ComVisible(true)]
	public class HostManager : MarshalByRefObject
	{
        private readonly ILog _log;
        private bool _singleDomain;
        private readonly object _objLock = new object();
        private readonly Timer _serverTimer;
        private readonly object _enterThread = new object(); // Only one timer event is processed at any given moment
        private readonly ArrayList _events;
        private string _applicationRoot;
        const string DefaultApplicationRoot = "applications";

        public event ApplicationShutdownHandler ApplicationShutdown;
        public event ApplicationRestartHandler ApplicationRestart;
        public event ApplicationErrorHandler ApplicationError;

		public HostManager()
		{
			try
			{
				_log = LogManager.GetLogger(typeof(HostManager));
			}
			catch{}
            _applicationRoot = DefaultApplicationRoot;
            _events = ArrayList.Synchronized(new ArrayList(32));
            _serverTimer = new Timer(1000);
            _serverTimer.Elapsed += new ElapsedEventHandler(this.ElapsedEventHandler);
            _serverTimer.AutoReset = true;
            _serverTimer.Enabled = false;
		}

        /// <summary>
        /// Gets an object that can be used to synchronize access to the HostManager.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return _objLock;
            }
        }

        /// <summary>
        /// Gets or sets the root directory for applications.
        /// </summary>
	    public string ApplicationRoot
	    {
	        get { return _applicationRoot; }
	        set { _applicationRoot = value; }
	    }

	    public void Start()
        {
            Start(false);
        }

        public void StartSingleDomain()
        {
            Start(true);
        }

        public void Start(bool singleDomain)
		{
			if (_log != null && _log.IsDebugEnabled)
				_log.Debug("Starting HostManager.");

            _singleDomain = singleDomain;
            lock (SyncRoot)
            {
                try
                {
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                    string shadowCopyAssemblyList = string.Empty;
                    /*
                    string assemblyFolder = Path.Combine("net", Environment.Version.Major + "." + Environment.Version.Minor);
                    string[] shadowCopyAssemblies = new string[]{"FluorineFx.Hosting.dll", "FluorineFx.dll", "log4net.dll", "ICSharpCode.SharpZipLib.dll"};
                    for( int i = 0; i < shadowCopyAssemblies.Length; i++)
                    {
                        if( i > 0 )
                            shadowCopyAssemblyList += ";";
                        shadowCopyAssemblyList += Path.Combine(assemblyFolder, shadowCopyAssemblies[i]);
                    }
                    */
                    //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "applications");
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ApplicationRoot);
                    if( Directory.Exists(path) )
                    {
                        foreach (string dir in Directory.GetDirectories(path))
                        {
                            string physicalPath = dir;
                            string virtualPath = string.Empty;
                            try
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                                string appName = directoryInfo.Name;
                                virtualPath = "/" + directoryInfo.Name;
                                if (_log != null) _log.Debug("Starting application " + appName);
                                //_log.Debug("PhysicalPath = " + physicalPath);
                                //_log.Debug("VirtualPath = " + virtualPath);

                                FluorineRuntimeProxy host = FluorineRuntimeProxy.Start(this, physicalPath, virtualPath, null, null, shadowCopyAssemblyList, singleDomain);
                                host.Start();
                                //_hosts.Add(physicalPath, host);
                            }
                            catch (Exception exception)
                            {
                                if (_log != null && _log.IsErrorEnabled)
                                    _log.Error("Error starting application " + virtualPath, exception);
                                if (ApplicationError != null)
                                    ApplicationError(this, new ApplicationErrorEventArgs(new ApplicationInfo(null, VirtualPath.Create(virtualPath), physicalPath), exception));
                            }
                        }
                    }
                    else
                    {
                        if (_log != null) _log.Debug(string.Format("Base directory {0} was not found.", path));
                    }
                    _serverTimer.Enabled = true;
                    if (_log != null) _log.Debug("HostManager started.");
                }
                catch (Exception ex)
                {
                    if (_log != null) _log.Fatal("Failed to start HostManager.", ex);
                }
            }
		}

		public void Shutdown()
		{
			if (_log != null && _log.IsDebugEnabled)
				_log.Debug("Stopping HostManager.");

            lock (SyncRoot)
            {
                _serverTimer.Enabled = false;
                try
                {
                    AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    foreach (ApplicationInfo applicationInfo in ApplicationManager.GetApplicationManager().GetRunningApplications())
                    {
                        IRegisteredObject registeredObject = ApplicationManager.GetApplicationManager().GetObject(applicationInfo.Id, typeof(FluorineRuntimeProxy));
                        if (registeredObject != null)
                            registeredObject.Stop(true);
                    }
                    ApplicationManager.GetApplicationManager().ShutdownAll();
                    if (_log != null && _log.IsDebugEnabled)
                        _log.Debug("Stopped HostManager.");
                }
                catch (Exception ex)
                {
                    if (_log != null) _log.Fatal("Failed to stop HostManager.", ex);
                }
            }
		}

	    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            /*
            // Prepare cooperative async shutdown from another thread
            Thread t = new Thread(delegate()
                                {
                                    Console.WriteLine("Asynchronous shutdown started");
                                    Environment.Exit(1);

                                });
            t.Start();
            t.Join(); // wait until we have exited
            */
        }

        public ApplicationInfo[] GetRunningApplications()
        {
            return ApplicationManager.GetApplicationManager().GetRunningApplications();
        }

        public void StartApplication(string path)
        {
            if (_log != null && _log.IsDebugEnabled)
                _log.Debug(string.Format("Starting application from {0}", path));

            lock (SyncRoot)
            {
                foreach (ApplicationInfo applicationInfo in ApplicationManager.GetApplicationManager().GetRunningApplications())
                {
                    if( applicationInfo.PhysicalPath == path )
                        throw new InvalidOperationException("Application already started");
                }
                //if (_hosts.ContainsKey(path))
                //    throw new InvalidOperationException("Application already started");
                string physicalPath = path;
                string virtualPath = string.Empty;
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    string appName = directoryInfo.Name;
                    virtualPath = "/" + directoryInfo.Name;
                    if (_log != null) _log.Debug("Starting application " + appName);
                    //_log.Debug("PhysicalPath = " + physicalPath);
                    //_log.Debug("VirtualPath = " + virtualPath);
                    string shadowCopyAssemblyList = string.Empty;

                    FluorineRuntimeProxy host = FluorineRuntimeProxy.Start(this, physicalPath, virtualPath, null, null, shadowCopyAssemblyList, _singleDomain);
                    host.Start();
                    //_hosts.Add(physicalPath, host);
                }
                catch (Exception exception)
                {
                    if (_log != null && _log.IsErrorEnabled)
                        _log.Error("Error starting application " + virtualPath, exception);
                    if (ApplicationError != null)
                        ApplicationError(this, new ApplicationErrorEventArgs(new ApplicationInfo(null, VirtualPath.Create(virtualPath), physicalPath), exception));
                    //throw;
                }
            }
        }

        public ApplicationInfo GetRunningApplication(string physicalPath)
        {
            foreach (ApplicationInfo applicationInfo in ApplicationManager.GetApplicationManager().GetRunningApplications())
            {
                if (applicationInfo.PhysicalPath == physicalPath)
                    return applicationInfo;
            }
            return null;
        }

        public void StopApplication(string appId)
        {
            if (_log != null && _log.IsDebugEnabled)
                _log.Debug(string.Format("Stopping application {0}", appId));

            lock (SyncRoot)
            {
                foreach (ApplicationInfo applicationInfo in ApplicationManager.GetApplicationManager().GetRunningApplications())
                {
                    if (applicationInfo.Id == appId)
                        ApplicationHost.ShutdownApplication(applicationInfo.PhysicalPath);
                }
            }
        }

        internal void OnAppDomainShutdown(ApplicationInfo applicationInfo, ApplicationShutdownReason reason)
        {
            _events.Add(new HostEvent(applicationInfo, reason));
        }

        internal void OnAppDomainUnloaded(ApplicationInfo applicationInfo, ApplicationShutdownReason reason)
        {
            /*
            if (reason == ApplicationShutdownReason.ConfigurationChange || reason == ApplicationShutdownReason.BinDirChangeOrDirectoryRename)
            {
                //StartApplication(applicationInfo.PhysicalPath);
                this._events.Add(new HostEvent(applicationInfo, reason));
            }
            */
            _events.Add(new HostEvent(applicationInfo, reason));
        }

        private void ElapsedEventHandler(Object sender, ElapsedEventArgs e)
        {
            // We don't fire the events inside the lock. We will queue them here until the code exits the locks.
            Queue eventsToBeFired = null;
            if (System.Threading.Monitor.TryEnter(_enterThread))
            {
                // Only one thread at a time is processing the events                
                try
                {
                    eventsToBeFired = new Queue(32);
                    // Lock the collection while processing the events
                    lock (_events.SyncRoot)
                    {
                        HostEvent current;
                        for (int i = 0; i < _events.Count; i++)
                        {
                            current = _events[i] as HostEvent;
                            if (current != null)
                            {
                                if (current.Delayed)
                                {
                                    // This event has been delayed already so we can fire it
                                    // We just need to remove any duplicates
                                    for (int j = i + 1; j < _events.Count; j++)
                                    {
                                        if (current.IsDuplicate(_events[j]))
                                        {
                                            // Removing later duplicates
                                            _events.RemoveAt(j);
                                            j--; // Don't skip next event
                                        }
                                    }
                                    // Add the event to the list of events to be fired
                                    eventsToBeFired.Enqueue(current);
                                    // Remove it from the current list
                                    _events.RemoveAt(i);
                                    i--; // Don't skip next event
                                }
                                else
                                {
                                    // This event was not delayed yet, so we will delay processing
                                    // this event for at least one timer interval
                                    current.Delayed = true;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(_enterThread);
                }
            }
            // Now fire all the events if any
            if( eventsToBeFired != null )
                RaiseEvents(eventsToBeFired);
        }

        private void RaiseEvents(Queue deQueue)
        {
            if ((deQueue != null) && (deQueue.Count > 0))
            {
                while (deQueue.Count > 0)
                {
                    HostEvent hostEvent = deQueue.Dequeue() as HostEvent;
                    if (hostEvent != null)
                    {
                        switch (hostEvent.Reason)
                        {
                            case ApplicationShutdownReason.ConfigurationChange:
                                if (_log != null && _log.IsDebugEnabled)
                                    _log.Debug(string.Format("Restarting application {0}", hostEvent.ApplicationInfo.PhysicalPath));
                                StartApplication(hostEvent.ApplicationInfo.PhysicalPath);
                                if (ApplicationRestart != null)
                                    ApplicationRestart(this, new ApplicationRestartEventArgs(hostEvent.ApplicationInfo, hostEvent.Reason));
                                break;
                            case ApplicationShutdownReason.BinDirChangeOrDirectoryRename:
                                if (_log != null && _log.IsDebugEnabled)
                                    _log.Debug(string.Format("Restarting application {0}", hostEvent.ApplicationInfo.PhysicalPath));
                                StartApplication(hostEvent.ApplicationInfo.PhysicalPath);
                                if (ApplicationRestart != null)
                                    ApplicationRestart(this, new ApplicationRestartEventArgs(hostEvent.ApplicationInfo, hostEvent.Reason));
                                break;
                            default:
                                if (ApplicationShutdown != null)
                                    ApplicationShutdown(this, new ApplicationShutdownEventArgs(hostEvent.ApplicationInfo, hostEvent.Reason));
                                break;
                        }
                    }
                }
            }
        }
	}
}
