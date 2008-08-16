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
using System.Web;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// The ContentType enumeration has several constant strings that represent the various
	/// MIME content types used for the response stream of ASP.NET.
	/// </summary>
	public struct ContentType
	{
		/// <summary>
		/// Content type for "image/gif"
		/// </summary>
		public const string ImageGif = "image/gif";
		/// <summary>
		/// Content type for "image/bmp"
		/// </summary>
		public const string ImageBmp = "image/bmp";
		/// <summary>
		/// Content type for "image/jpeg"
		/// </summary>
		public const string ImageJpeg = "image/jpeg";
		/// <summary>
		/// Content type for "image/png"
		/// </summary>
		public const string ImagePng = "image/png";
		/// <summary>
		/// Content type for "text/html"
		/// </summary>
		public const string TextHtml = "text/html";
		/// <summary>
		/// Content type for "text/xml"
		/// </summary>
		public const string TextXml = "text/xml";
		/// <summary>
		/// Content type for "text/x-component"
		/// </summary>
		public const string TextComponent = "text/x-component";

		public const string Css = "text/css";
		public const string Javascript = "text/javascript";
		/// <summary>
		/// Content type for "text/xml"
		/// </summary>
		public const string TextAS = "text/as";
		/// <summary>
		/// Content type for swf
		/// </summary>
		public const string Swf = "application/x-shockwave-flash";
		
	}

	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class WebResource
	{
		/// <summary>
		/// Initializes a new instance of the WebResource class.
		/// </summary>
		public WebResource()
		{
		}

		/// <summary>
		///	Compose a full url to be used when referencing the specified name.
		/// </summary>
		/// <param name="resourceName">Name of the embedded resource.</param>
		/// <param name="contentType"></param>
		/// <returns>Url to retrieve this particular resource.</returns>
		public static string GetWebResourceUrl(string resourceName, string contentType)
		{
			return string.Concat("FluorineWebResource.axd?r=", HttpUtility.UrlEncode(resourceName), "&t=", HttpUtility.UrlEncode(contentType));
			//FluorineWebResource.axd?r=treenodedot.gif&t=image/gif
		}

		/// <summary>
		/// Load a resource.
		/// </summary>
		/// <param name="resourceName">The name of the resource to load.</param>
		/// <param name="contentType">The content type.</param>
		/// <returns>A <see cref="System.IO.Stream"/> for the embedded resource.</returns>
		public static Stream Load(string resourceName, string contentType)
		{
			try
			{
				Assembly resourceAssembly = Assembly.GetExecutingAssembly();

				// Lookup cached names
				string[] names = HttpContext.Current.Application["FluorineServiceBrowserResourceNames"] as string[];
				if (null == names)
				{
					// Get the names of all the resources in the assembly
					names = resourceAssembly.GetManifestResourceNames();
					Array.Sort(names, CaseInsensitiveComparer.Default);
					HttpContext.Current.Application["FluorineServiceBrowserResourceNames"] = names;
				}

				if (contentType.Length == 0)
					throw new ArgumentException(resourceName);

				// Check for resource requested
				if (names.Length > 0)
				{
					// Find the resource in the names array
					string fullResourceName = resourceAssembly.GetName().Name + ".Resource." + resourceName;
					int index = Array.BinarySearch(names, fullResourceName, CaseInsensitiveComparer.Default);

					if (index > -1)
					{
						Stream resourceStream = resourceAssembly.GetManifestResourceStream(fullResourceName);
						return resourceStream;
					}
					else
					{
						throw new ArgumentException(resourceName);
					}
				}
				else
				{
					throw new ArgumentException(resourceName);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw;
			}
			finally
			{
			}
		}

		public static void WriteResourceToOutputStream(HttpApplication application, string resourceName, string contentType, bool cache)
		{
			// Get the resource
			using (Stream resourceStream = Load(resourceName, contentType))
			{
				HttpResponse response = application.Response;
				response.Clear();
				if (cache)
				{
					response.Cache.SetExpires(DateTime.Now.AddSeconds(5));
					response.Cache.SetCacheability(HttpCacheability.Public);
				}

				response.ContentType = contentType;

				int bytesRead, bufferSize = 1024;
				byte[] buffer = new byte[bufferSize];
				do
				{
					bytesRead = resourceStream.Read(buffer, 0, bufferSize);
					response.OutputStream.Write(buffer, 0, bytesRead);
				} 
				while (bytesRead > 0);
				response.OutputStream.Flush();
				application.CompleteRequest();
			}
		}
	}
}
