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
using System.Threading;
using log4net;

namespace FluorineFx.Hosting
{
    public enum ApplicationShutdownReason
    {
        None,
        HostingEnvironment,
        //ChangeInGlobalAsax,
        ConfigurationChange,
        UnloadAppDomainCalled,
        //ChangeInSecurityPolicyFile,
        BinDirChangeOrDirectoryRename,
        //BrowsersDirChangeOrDirectoryRename,
        //CodeDirChangeOrDirectoryRename,
        //ResourcesDirChangeOrDirectoryRename,
        IdleTimeout,
        PhysicalApplicationPathChanged,
        //HttpRuntimeClose,
        FluorineRuntimeClose,
        InitializationError
        //MaxRecompilationsReached,
        //BuildManagerChange
    }

    delegate void HostUnloadEventHandler(object sender, HostUnloadEventArgs e);

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class FluorineRuntime
	{
		private static readonly ILog _log;

		private static readonly FluorineRuntime _theRuntime;

		private string _appDomainAppId;
		private string _appDomainAppPath;
		private VirtualPath _appDomainAppVPath;
		private string _appDomainId;
		private bool _shutdownInProgress;
		private WaitCallback _appDomainUnloadallback;
        private ApplicationShutdownReason _shutdownReason;
        private bool _userForcedShutdown;
        private string _shutDownMessage;
        internal static event HostUnloadEventHandler AppDomainShutdown;

		static FluorineRuntime()
		{
			try
			{
				_log = LogManager.GetLogger(typeof(FluorineRuntime));
			}
			catch{}

			_theRuntime = new FluorineRuntime();
			_theRuntime.Init();
		}

		internal static string GetAppDomainString(string key)
		{
			return (Thread.GetDomain().GetData(key) as string);
		}

        internal static ApplicationShutdownReason ShutdownReason
        {
            get { return _theRuntime._shutdownReason; }
        }

		private void Init()
		{
			try
			{
				if (GetAppDomainString(".appDomain") != null)
				{
					_appDomainAppId = GetAppDomainString(".appId");
					_appDomainAppPath = GetAppDomainString(".appPath");
					_appDomainAppVPath = VirtualPath.CreateNonRelativeTrailingSlash(GetAppDomainString(".appVPath"));
					_appDomainId = GetAppDomainString(".domainId");
                    _appDomainUnloadallback = new WaitCallback(ReleaseResourcesAndUnloadAppDomain);
				}
			}
			catch (Exception exception)
			{
				if(_log != null && _log.IsFatalEnabled )
					_log.Fatal(exception.Message, exception);
			}
		}

        internal static void OnAppDomainShutdown(HostUnloadEventArgs e)
        {
            if (AppDomainShutdown != null)
            {
                AppDomainShutdown(_theRuntime, e);
            }
        }

        private void Dispose()
        {
            //EndApplication();
        }

        public static void Close()
        {
            if (_theRuntime.InitiateShutdownOnce())
            {
                //Close is called
                SetShutdownReason(ApplicationShutdownReason.FluorineRuntimeClose, "FluorineRuntime.Close is called");
                if (HostingEnvironment.IsHosted)
                {
                    HostingEnvironment.InitiateShutdown();
                }
                else
                {
                    _theRuntime.Dispose();
                }
            }
        }

		internal static string AppDomainAppVirtualPathString
		{
			get
			{
				return VirtualPath.GetVirtualPathString(_theRuntime._appDomainAppVPath);
			}
		}

		internal static VirtualPath AppDomainAppVirtualPathObject
		{
			get
			{
				return _theRuntime._appDomainAppVPath;
			}
		}

		public static string AppDomainAppVirtualPath
		{
			get
			{
				return VirtualPath.GetVirtualPathStringNoTrailingSlash(_theRuntime._appDomainAppVPath);
			}
		}

		internal static string AppDomainAppIdInternal
		{
			get
			{
				return _theRuntime._appDomainAppId;
			}
		}

		internal static string AppDomainAppPathInternal
		{
			get
			{
				return _theRuntime._appDomainAppPath;
			}
		}

        public static string AppDomainAppPath
        {
            get
            {
                return AppDomainAppPathInternal;
            }
        }

        internal static void SetShutdownReason(ApplicationShutdownReason reason, string message)
        {
            if (_theRuntime._shutdownReason == ApplicationShutdownReason.None)
            {
                _theRuntime._shutdownReason = reason;
            }
            SetShutdownMessage(message);
        }

        internal static void SetShutdownMessage(string message)
        {
            if (message != null)
            {
                if (_theRuntime._shutDownMessage == null)
                {
                    _theRuntime._shutDownMessage = message;
                }
                else
                {
                    _theRuntime._shutDownMessage = _theRuntime._shutDownMessage + Environment.NewLine + message;
                }
            }
        }

		private bool InitiateShutdownOnce()
		{
			if(_shutdownInProgress)
				return false;
			lock (this)
			{
				if(_shutdownInProgress)
				{
					return false;
				}
				_shutdownInProgress = true;
			}
			return true;
		}

		internal static bool ShutdownAppDomain()
		{
			if (!HostingEnvironment.ShutdownInitiated)
			{
				HostingEnvironment.InitiateShutdown();
				return true;
			}
			if (HostingEnvironment.ShutdownInProgress)
			{
				return false;
			}
			if (!_theRuntime.InitiateShutdownOnce())
			{
				return false;
			}
            OnAppDomainShutdown(new HostUnloadEventArgs(_theRuntime._shutdownReason));
			ThreadPool.QueueUserWorkItem(_theRuntime._appDomainUnloadallback);
			return true;
		}

        internal static bool ShutdownAppDomain(ApplicationShutdownReason reason, string message)
        {
            return ShutdownAppDomainWithStackTrace(reason, message, null);
        }

        internal static bool ShutdownAppDomainWithStackTrace(ApplicationShutdownReason reason, string message, string stackTrace)
        {
            SetShutdownReason(reason, message);
            //return ShutdownAppDomain(stackTrace);
            return ShutdownAppDomain();
        }


        private void ReleaseResourcesAndUnloadAppDomain(object state)
		{
            try
            {
                Dispose();
            }
            catch
            {
            }
            if (_log != null && _log.IsDebugEnabled && !String.IsNullOrEmpty(_shutDownMessage))
            {
                string[] parts = _shutDownMessage.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                foreach(string part in parts)
                    _log.Debug(part);
                _log.Debug(string.Format("Shutting down runtime, forced:{0}", _userForcedShutdown));
            }

            Thread.Sleep(250);
			try
			{
				AppDomain.Unload(Thread.GetDomain());
			}
			catch (CannotUnloadAppDomainException exception)
			{
				if(_log != null && _log.IsErrorEnabled )
					_log.Error("Cannot Unload Exception", exception);
			}
			catch (Exception exception)
			{
				if(_log != null && _log.IsErrorEnabled )
					_log.Error("Unload Exception", exception);
				throw;
			}
		}

        internal static void SetUserForcedShutdown()
        {
            _theRuntime._userForcedShutdown = true;
        }

        public static void UnloadAppDomain()
        {
            _theRuntime._userForcedShutdown = true;
            //User code called UnloadAppDomain
            ShutdownAppDomain(ApplicationShutdownReason.UnloadAppDomainCalled, "User code called UnloadAppDomain");
        }
	}
}
