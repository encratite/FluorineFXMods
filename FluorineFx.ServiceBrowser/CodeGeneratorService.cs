/*
	Fluorine .NET Flash Remoting Gateway open source library 
	Copyright (C) 2005 Zoltan Csibi, zoltan@TheSilentGroup.com
	
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
using System.Reflection;
using System.IO;
using System.Web;
using System.Security;
using System.Security.Permissions;

using FluorineFx;
using FluorineFx.Configuration;
using FluorineFx.Context;

using FluorineFx.CodeGenerator;
using FluorineFx.Management;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// CodeGeneratorService.
	/// </summary>
	[RemotingService("FluorineFx CodeGeneratorService")]
	sealed public class CodeGeneratorService
	{
		/// <summary>
		/// Initializes a new instance of the ServiceBrowser class.
		/// </summary>
		public CodeGeneratorService()
		{
		}

		public static IList GetCodeTemplates()
		{
            string templateFolder = HttpContext.Current.Server.MapPath("templates");
			TemplateBrowser templateBrowser = new TemplateBrowser(templateFolder);
			TemplateInfo[] templateInfos = templateBrowser.ReadTemplates();

			return templateInfos;
		}

		public void SaveCode(HttpApplication httpApplication)
		{
			ManagementService managementService = new ManagementService();
			Project project = managementService.GetProject();

			HttpRequest httpRequest = httpApplication.Request;
			//string serviceName = httpRequest.QueryString["service"];
			//string uid = httpRequest.QueryString["uid"];
			string location = httpRequest.QueryString["location"];
			string templateFolder = Path.Combine("templates", location);
            templateFolder = HttpContext.Current.Server.MapPath(templateFolder);
			string serviceName = httpRequest.QueryString["service"];

			TemplateInfo templateInfo = new TemplateInfo(string.Empty, templateFolder);
			Hashtable context = new Hashtable();
			context["Project"] = project;
			context["Service"] = serviceName;

			string trace = httpRequest.QueryString["trace"];
			TemplateEngineSettings settings = TemplateEngineSettings.Default;
			if( trace != null )
				settings.Trace = true;

			WebTemplateGeneratorHost host = new WebTemplateGeneratorHost(context);

            try
            {
                // See if we're running in full trust
                new SecurityPermission(PermissionState.Unrestricted).Demand();

			    TemplateEngineProxy proxy = new TemplateEngineProxy();
			    proxy.Execute(templateInfo, host, settings);
            }
            catch (SecurityException)
            {
                host.Open();
                host.AddFile("", "error.txt", "Security error. Code generation is not available in Medium Trust environment.");
                host.Close();
            }

			byte[] buffer = host.GetBuffer();

			httpApplication.Response.Clear();
			httpApplication.Response.Buffer = true;
			httpApplication.Response.ContentType = "application/zip";//"binary/octet-stream";
			httpApplication.Response.AppendHeader("Content-Length", buffer.Length.ToString());
			httpApplication.Response.AppendHeader("Content-Disposition", "attachment; filename=template.zip");
            httpApplication.Response.Cache.SetCacheability(HttpCacheability.NoCache);
						 
            if( buffer.Length > 0 )
			    httpApplication.Response.OutputStream.Write( buffer, 0, buffer.Length );
            try
            {
                httpApplication.Response.Flush();
            }
            catch (SecurityException)
            {
            }
		}

		public static ASObject GetCodePreview(string location, string serviceName, string methodName)
		{
			ManagementService managementService = new ManagementService();
			Project project = managementService.GetProject();

			string templateFolder = Path.Combine("templates", location);
            templateFolder = HttpContext.Current.Server.MapPath(templateFolder);
			TemplateInfo templateInfo = new TemplateInfo(string.Empty, templateFolder);
			Hashtable context = new Hashtable();
			context["Project"] = project;
			context["Service"] = serviceName;
			context["Method"] = methodName;

            string preview;
            try
            {
                // See if we're running in full trust
                new SecurityPermission(PermissionState.Unrestricted).Demand();

                WebTemplateGeneratorHost host = new WebTemplateGeneratorHost(context);
                TemplateEngineProxy proxy = new TemplateEngineProxy();
                preview = proxy.Preview(templateInfo, host, TemplateEngineSettings.Default);
            }
            catch (SecurityException)
            {
                preview = "Security error. Code generation is not available in Medium Trust environment.";
            }

			ASObject asoCodePreview = new ASObject();
			asoCodePreview["code"] = preview;
			return asoCodePreview;
		}
	}
}
