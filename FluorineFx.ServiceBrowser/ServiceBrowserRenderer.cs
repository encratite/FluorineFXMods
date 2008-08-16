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
using System.Xml;
using System.Collections;
using System.Web;
using System.Reflection;
using System.IO;
using System.Text;
using System.ComponentModel;

using FluorineFx;
using FluorineFx.Diagnostic;
using FluorineFx.Browser;
using FluorineFx.Util;
using FluorineFx.Configuration;
using FluorineFx.Context;

using FluorineFx.Management;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed public class ServiceBrowserRenderer : IServiceBrowserRenderer
	{
		public ServiceBrowserRenderer()
		{
		}

		#region IServiceBrowserRenderer Members

		public bool CanRender(HttpRequest httpRequest)
		{
			if( httpRequest.FilePath.EndsWith("FluorineWebResource.axd") )
				return true;

			//http://localhost/FluorineWeb/Fluorine.aspx
			if( httpRequest.FilePath.ToLower().EndsWith("fluorine.aspx") )
				return true;

			//http://localhost/FluorineWeb/FluorineCodeGenerator.aspx
			if( httpRequest.FilePath.ToLower().EndsWith("fluorinecodegenerator.aspx") )
				return true;

            //http://localhost/FluorineWeb/FluorineCodeGenerator.aspx
            if (httpRequest.FilePath.ToLower().EndsWith("fluorineprojectupload.aspx"))
                return true;
            if (httpRequest.FilePath.ToLower().EndsWith("fluorineprojectdownload.aspx"))
                return true;

			/*
			//http://localhost/FluorineWeb/Fluorine.aspx
			if( httpRequest.FilePath.EndsWith("Fluorine.aspx") 
				|| httpRequest.FilePath.EndsWith("FluorineNav.aspx") 
				|| httpRequest.FilePath.EndsWith("FluorineLog.aspx") )
				return true;
			*/
			//http://localhost/FluorineWeb/ServiceBrowser.aspx
			if( httpRequest.FilePath.ToLower().EndsWith("servicebrowser.aspx")
				|| httpRequest.FilePath.EndsWith("ServiceBrowserContents.aspx")
				|| httpRequest.FilePath.EndsWith("ServiceBrowserOverview.aspx")
				|| httpRequest.FilePath.EndsWith("ServiceBrowserTest.aspx")
				|| httpRequest.FilePath.EndsWith(".tpx.aspx") 
				|| httpRequest.FilePath.EndsWith(".wsx.aspx")
				|| httpRequest.FilePath.EndsWith(".pagex.aspx")
				|| httpRequest.FilePath.EndsWith(".error.aspx")
				)
				return true;
			return false;
		}

		public void Render(HttpApplication httpApplication)
		{
			HttpRequest httpRequest = httpApplication.Request;

			if( httpRequest.FilePath.EndsWith("FluorineWebResource.axd") )
			{
				WebResource.WriteResourceToOutputStream(httpApplication, httpRequest.QueryString["r"], httpRequest.QueryString["t"], false);
				return;
			}

			//http://localhost/FluorineWeb/Fluorine.aspx
			if( httpRequest.FilePath.ToLower().EndsWith("fluorine.aspx") )
			{
				HttpResponse httpResponse = httpApplication.Response;
				httpResponse.Write("<html>");
				httpResponse.Write("<head>");
				httpResponse.Write("<style>body { margin: 0px; overflow:hidden }</style>");
				httpResponse.Write("<script src=\""+ WebResource.GetWebResourceUrl("iframe.js", ContentType.Javascript) + "\" language=\"javascript\" type=\"text/javascript\"></script>");
				httpResponse.Write("<script src=\""+ WebResource.GetWebResourceUrl("swfobject.js", ContentType.Javascript) + "\" language=\"javascript\" type=\"text/javascript\"></script>");
				httpResponse.Write("</head>");
				httpResponse.Write("<body scroll=\"no\">");
				httpResponse.Write("<div id=\"flashcontent\">");
				httpResponse.Write("</div>");
				
				httpResponse.Write("<div id=\"myFrame\" name=\"myFrame\" style=\"position:absolute;background-color:transparent;border:0px;visibility:hidden;\"></div>");

				httpResponse.Write("<script type=\"text/javascript\">");
				httpResponse.Write("var url = \"" + WebResource.GetWebResourceUrl("FluorineFxBrowser.swf", ContentType.Swf) + "\";");
				httpResponse.Write("var so = new SWFObject(url, \"home\", \"100%\", \"100%\", \"9\", \"#ffffff\");");
				httpResponse.Write("so.addParam(\"allowScriptAccess\", \"always\");");
				httpResponse.Write("so.addParam(\"wmode\", \"opaque\");");
				httpResponse.Write("so.write(\"flashcontent\");");
				httpResponse.Write("</script>");
				httpResponse.Write("</body>");
				httpResponse.Write("</html>");
			}

			//http://localhost/FluorineWeb/FluorineCodeGenerator.aspx
			if( httpRequest.FilePath.ToLower().EndsWith("fluorinecodegenerator.aspx") )
			{
				SaveCode(httpApplication);
			}

            if (httpRequest.FilePath.ToLower().EndsWith("fluorineprojectdownload.aspx"))
            {
                DownloadProject(httpApplication);
            }

            if (httpRequest.FilePath.ToLower().EndsWith("fluorineprojectupload.aspx"))
            {
                UploadProject(httpApplication);
            }
        }

		#endregion

        public void SaveCode(HttpApplication httpApplication)
        {
            CodeGeneratorService codeGeneratorService = new CodeGeneratorService();
            codeGeneratorService.SaveCode(httpApplication);
        }

        public void DownloadProject(HttpApplication httpApplication)
        {
            ManagementService managementService = new ManagementService();
            managementService.DownloadProject(httpApplication);
        }

        public void UploadProject(HttpApplication httpApplication)
        {
            ManagementService managementService = new ManagementService();
            managementService.UploadProject(httpApplication);
        }

	}
}
