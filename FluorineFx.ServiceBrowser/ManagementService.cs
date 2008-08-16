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
using System.IO;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security;
using log4net;
using FluorineFx;
using FluorineFx.Configuration;
using FluorineFx.Context;
using FluorineFx.Management;
using FluorineFx.Management.Data;
using FluorineFx.Management.Data.Database;
using FluorineFx.Management.Data.Database.Access;
using FluorineFx.Management.Data.Database.OleDb;
using FluorineFx.Management.Web;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// ManagementService.
	/// </summary>
	[RemotingService("FluorineFx ManagementService")]
	public class ManagementService
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(ManagementService));

		public const string FluorineProjectSessionKey = "FluorineFxProject";

		public ManagementService()
		{
		}

		public Project GetProject()
		{
			//Project project = FluorineContext.Current.Session[FluorineProjectSessionKey] as Project;
			Project project = HttpContext.Current.Application[FluorineProjectSessionKey] as Project;
			if( project == null )
			{
				string[] lac = TypeHelper.GetLacLocations();

                project = new Project(FluorineContext.Current.ApplicationPath, FluorineContext.Current.AbsoluteUri, HttpContext.Current.Server.MapPath(FluorineContext.Current.RequestApplicationPath), /*FluorineContext.Current.RequestApplicationPath,*/ lac);
                Type[] excludeTypes = new Type[] { typeof(System.Web.UI.Page), typeof(System.Web.HttpApplication) };
                Type[] attributes = new Type[] { typeof(FluorineFx.RemotingServiceAttribute), typeof(FluorineFx.TransferObjectAttribute) };
                project.Build(excludeTypes, attributes, false);
                
                string safeName = Management.Util.GetSafeString(FluorineContext.Current.RequestApplicationPath);
				project.Package = safeName;
                //If we have assemblies pick up the first namespace as the package
                foreach (AssemblyDescriptor assemblyDescriptor in project.Assemblies)
                {
                    if( assemblyDescriptor.Namespaces.Count > 0 )
                        project.Package = assemblyDescriptor.Namespaces[0].Name;
                }
				project.Name = safeName;
				project.ContextRoot = FluorineContext.Current.RequestApplicationPath;
				project.Locked = true;

                string baseDirectory = Path.Combine(FluorineContext.Current.ApplicationBaseDirectory, "apps");
                if (Directory.Exists(baseDirectory))
                {
                    foreach (string appDirectory in Directory.GetDirectories(baseDirectory))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(appDirectory);
                        string appName = directoryInfo.Name;
                        string appConfigFile = Path.Combine(appDirectory, "app.config");
                        ApplicationConfiguration configuration = ApplicationConfiguration.Load(appConfigFile);

                        Application application = new Application();
                        application.Name = appName;
                        application.Directory = directoryInfo.Name;
                        application.ApplicationHandler = configuration.ApplicationHandler.Type;

                        project.AddApplication(application);
                    }
                }
				//FluorineContext.Current.Session[FluorineProjectSessionKey] = project;
				HttpContext.Current.Application.Add(FluorineProjectSessionKey, project); 
			}
			return project;
		}

        public void RefreshProject()
        {
            Project project = HttpContext.Current.Application[FluorineProjectSessionKey] as Project;
            if (project != null)
            {
                string[] lac = TypeHelper.GetLacLocations();

                project.ApplicationUrl = FluorineContext.Current.ApplicationPath;
                project.Url = FluorineContext.Current.AbsoluteUri;
                project.ApplicationRoot = HttpContext.Current.Server.MapPath(FluorineContext.Current.RequestApplicationPath);
                project.AssemblyPaths = lac;
                Type[] excludeTypes = new Type[] { typeof(System.Web.UI.Page), typeof(System.Web.HttpApplication) };
                Type[] attributes = new Type[] { typeof(FluorineFx.RemotingServiceAttribute), typeof(FluorineFx.TransferObjectAttribute) };
                project.Build(excludeTypes, attributes, false);

                project.ContextRoot = FluorineContext.Current.RequestApplicationPath;

                project.ClearApplications();
                string baseDirectory = Path.Combine(FluorineContext.Current.ApplicationBaseDirectory, "apps");
                if (Directory.Exists(baseDirectory))
                {
                    foreach (string appDirectory in Directory.GetDirectories(baseDirectory))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(appDirectory);
                        string appName = directoryInfo.Name;
                        string appConfigFile = Path.Combine(appDirectory, "app.config");
                        ApplicationConfiguration configuration = ApplicationConfiguration.Load(appConfigFile);

                        Application application = new Application();
                        application.Name = appName;
                        application.Directory = directoryInfo.Name;
                        application.ApplicationHandler = configuration.ApplicationHandler.Type;

                        project.AddApplication(application);
                    }
                }
            }
        }

		public Project ConnectToDatabase(string name, string url)
		{
            Project project = GetProject() as Project;
			if( project != null )
			{
				DomainUrl domainUrl = new DomainUrl(url);
				DomainBuilder builder = DomainBuilderFactory.GetDomainBuilder(domainUrl);
				DataDomain dataDomain = builder.BuildDomain();
                dataDomain.Name = name;
				project.AddDataDomain(dataDomain);
				return project;
			}
			return null;
		}

        public DataDomain RemoveDataDomain(string url)
        {
            Project project = GetProject() as Project;
            if (project != null)
            {
                DataDomain dataDomain = project.GetDataDomain(url);
                project.RemoveDataDomain(url);
                return dataDomain;
            }
            return null;
        }

        public DataAssembler CreateDataAssembler(string url, string query)
        {
            Project project = GetProject() as Project;
            if (project != null)
            {
                return project.CreateDataAssembler(url, query);
            }
            return null;
        }

        public DataAssembler RemoveDataAssembler(string id)
        {
            Project project = GetProject() as Project;
            if (project != null)
            {
                return project.RemoveDataAssembler(id);
            }
            return null;
        }

        public Project UpdateProject(Hashtable projectData)
        {
            Project project = GetProject() as Project;
            if (project != null && projectData != null)
            {
                if (projectData.Contains("package"))
                    project.Package = projectData["package"] as string;
                if (projectData.Contains("name"))
                    project.Name = projectData["name"] as string;
                return project;
            }
            return null;
        }

        public void DownloadProject(HttpApplication httpApplication)
        {
            Project project = GetProject();
            if (project != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                /*
                IFormatter formatter = new SoapFormatter();
                formatter.Serialize(memoryStream, project);
                */
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Project));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, System.Text.Encoding.UTF8);
                    xs.Serialize(xmlTextWriter, project);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }


                byte[] buffer = memoryStream.ToArray();

                httpApplication.Response.Clear();
                httpApplication.Response.Buffer = true;
                httpApplication.Response.ContentType = "text/xml";//"binary/octet-stream";
                httpApplication.Response.AppendHeader("Content-Length", buffer.Length.ToString());
                httpApplication.Response.AppendHeader("Content-Disposition", "attachment; filename=" + project.Name + ".fxproj");
                httpApplication.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                if (buffer.Length > 0)
                    httpApplication.Response.OutputStream.Write(buffer, 0, buffer.Length);
                try
                {
                    httpApplication.Response.Flush();
                }
                catch (SecurityException)
                {
                }
            }
        }

        public void UploadProject(HttpApplication httpApplication)
        {
            if (httpApplication.Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFile httpPostedFile = httpApplication.Request.Files[0];

                    XmlSerializer xs = new XmlSerializer(typeof(Project));
                    Project project = xs.Deserialize(httpPostedFile.InputStream) as Project;
                    /*
                    IFormatter formatter = new SoapFormatter();
                    Project project = formatter.Deserialize(httpPostedFile.InputStream) as Project;
                    */
                    HttpContext.Current.Application[FluorineProjectSessionKey] = project;
                    RefreshProject();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }
            }
        }
	}
}
