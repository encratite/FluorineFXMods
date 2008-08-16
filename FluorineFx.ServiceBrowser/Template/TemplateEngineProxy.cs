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
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Security.Permissions;
using System.Security;
using log4net;
using FluorineFx.Util;
using FluorineFx.ServiceBrowser;

namespace FluorineFx.CodeGenerator
{
	/// <summary>
	/// TemplateEngineProxy.
	/// </summary>
	public class TemplateEngineProxy : MarshalByRefObject, ITemplateEngine
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(TemplateEngineProxy));

		public TemplateEngineProxy()
		{
		}

		private AppDomain CreateTempAppDomain()
		{
			AppDomainSetup appDomainSetup = new AppDomainSetup();
			AppDomainSetup currentSetup = AppDomain.CurrentDomain.SetupInformation;

			appDomainSetup.ApplicationName = "TemplateEngineProxyDomain" + Guid.NewGuid().ToString("N");

			/*
			setup.ApplicationBase = currentSetup.ApplicationBase;
			// Set the config file to the current virtual directory web.config file
			setup.ConfigurationFile = currentSetup.ConfigurationFile;
			setup.PrivateBinPath = currentSetup.PrivateBinPath;
			setup.PrivateBinPathProbe = currentSetup.PrivateBinPathProbe;
			// Enable shadow copy
			setup.ShadowCopyFiles = currentSetup.ShadowCopyFiles;
			setup.ShadowCopyDirectories = null;
			//setup.ShadowCopyFiles = "false";
			//setup.CachePath = currentSetup.CachePath;
			// NOTE: Loader optimization option not supported by Mono.
			setup.LoaderOptimization = LoaderOptimization.MultiDomain;
			AppDomain temporaryDomain = AppDomain.CreateDomain(setup.ApplicationName, null, setup);
			*/

			appDomainSetup.ApplicationBase = currentSetup.ApplicationBase;
			appDomainSetup.PrivateBinPath = "bin";
			appDomainSetup.ConfigurationFile = currentSetup.ConfigurationFile;
			appDomainSetup.ShadowCopyFiles = @"true";
			appDomainSetup.ShadowCopyDirectories = null;
			// NOTE: Loader optimization option not supported by Mono.
			appDomainSetup.LoaderOptimization = LoaderOptimization.MultiDomain;
			// TODO: Might need to be more careful about how the Evidence is derived.
			Evidence evidence = AppDomain.CurrentDomain.Evidence;
			log.Debug(string.Format("AppDomainSetup: {0} {1}", appDomainSetup.ApplicationBase, appDomainSetup.ConfigurationFile));
			AppDomain temporaryDomain = AppDomain.CreateDomain(appDomainSetup.ApplicationName, evidence, appDomainSetup);
			ValidationUtils.ObjectNotNull(temporaryDomain, "temporaryDomain");
			return temporaryDomain;
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}


		#region ITemplateEngine Members

		public void Execute(TemplateInfo templateInfo, ITemplateGeneratorHost host)
		{
			Execute(templateInfo, host, TemplateEngineSettings.Default);
		}

		public void Execute(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings settings)
		{
			AppDomain temporaryDomain = CreateTempAppDomain();
			try
			{
				string baseDirectory = temporaryDomain.BaseDirectory;
				string assembly = Assembly.GetExecutingAssembly().GetName().FullName;
				string type = this.GetType().FullName;
				TemplateEngineProxy proxy = (TemplateEngineProxy)temporaryDomain.CreateInstanceAndUnwrap(assembly, type);
				proxy._Execute(templateInfo, host, settings);
			}
			finally
			{
				AppDomain.Unload(temporaryDomain);
			}
		}

		internal void _Execute(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings settings)
		{
			StartLogging();
			ILog log = LogManager.GetLogger(typeof(TemplateEngineProxy));
			log.Debug(string.Format("Entering AppDomain: {0} {1}", AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain.BaseDirectory));
			TemplateEngine templateEngine = new TemplateEngine();
			templateEngine.Execute(templateInfo, host, settings);
		}

		public string Preview(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings settings)
		{
			AppDomain temporaryDomain = CreateTempAppDomain();
			try
			{
				string assembly = Assembly.GetExecutingAssembly().GetName().FullName;
				string type = this.GetType().FullName;
				log.Debug(string.Format("CreateInstanceAndUnwrap {0} {1}", assembly, type));
				TemplateEngineProxy proxy = (TemplateEngineProxy)temporaryDomain.CreateInstanceAndUnwrap(assembly, type);
				if( proxy == null )
				{
					string msg = string.Format("Failed to locate the requested  type {0}", type);
					log.Debug(msg);
					throw new ServiceBrowserException(msg);
				}
				else
				{
					string result = proxy._Preview(templateInfo, host, settings);
					//log.Debug(result);
					return result;
				}
			}
			finally
			{
				AppDomain.Unload(temporaryDomain);
			}
		}

		internal string _Preview(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings settings)
		{
			StartLogging();
			ILog log = LogManager.GetLogger(typeof(TemplateEngineProxy));
			log.Debug(string.Format("Entering AppDomain: {0} {1}", AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain.BaseDirectory));
			TemplateEngine templateEngine = new TemplateEngine();
			ValidationUtils.ObjectNotNull(templateEngine, "templateEngine");
			return templateEngine.Preview(templateInfo, host, settings);
		}

		#endregion

		void StartLogging()
		{
			//Setup log4net for the current domain
			log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();
			log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%date [%thread] %-5level %logger - %message%newline");
			appender.Layout = layout;
			appender.File = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log\servicebrowser.log");
			appender.AppendToFile = true;
			appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Date;
			appender.DatePattern = "yyyyMMdd";
			layout.ActivateOptions();
			appender.ActivateOptions();
			log4net.Config.BasicConfigurator.Configure(appender);
		}
	}
}
