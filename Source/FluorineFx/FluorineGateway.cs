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
using System.Xml;
using System.Web;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using log4net;
using log4net.Config;
using FluorineFx.Browser;
using FluorineFx.Configuration;
using FluorineFx.Context;
using FluorineFx.HttpCompress;
using FluorineFx.Messaging;
using FluorineFx.Silverlight;

//Compressing http content based on "The open compression engine for ASP.NET"
//http://www.blowery.org/code/HttpCompressionModule.html
//http://www.ondotnet.com/pub/a/dotnet/2003/10/20/httpfilter.html
//http://aspnetresources.com/articles/HttpFilters.aspx
//
// Checks the Accept-Encoding HTTP header to determine if the
// client actually supports any notion of compression.  Currently
// the deflate (zlib) and gzip compression schemes are supported.
// Compress is not implemented because it uses lzw which requires a license from 
// Unisys.  For more information about the common compression types supported,
// see http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.11 for details.

namespace FluorineFx
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class FluorineGateway : IHttpModule, IRequiresSessionState
	{
		internal const string FluorineHttpCompressKey = "__@fluorinehttpcompress";
        internal const string FluorineMessageServerKey = "__@fluorinemessageserver";

		static int _unhandledExceptionCount = 0;
		static string _sourceName = null;
		static object _objLock = new object();
		static bool _initialized = false;

        static MessageServer messageServer;
        static IServiceBrowserRenderer serviceBrowserRenderer;

		/// <summary>
		/// Initializes a new instance of the FluorineGateway class.
		/// </summary>
		public FluorineGateway()
		{
		}


        private static string GetPageName(string requestPath)
        {
            if (requestPath.IndexOf('?') != -1)
                requestPath = requestPath.Substring(0, requestPath.IndexOf('?'));
            return requestPath.Remove(0, requestPath.LastIndexOf("/") + 1);
        }

		#region IHttpModule Members

		/// <summary>
		/// Initializes the module and prepares it to handle requests.
		/// </summary>
		/// <param name="application">An HttpApplication that provides access to the methods, properties, and events common to all application objects within an ASP.NET application.</param>
		public void Init(HttpApplication application)
		{
            /*
			try
			{
				ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                log4net.GlobalContext.Properties["ClientIP"] = "0.0.0.0";
                log.Info(__Res.GetString(__Res.Fluorine_InitModule));
			}
			catch { }
            */

			//http://support.microsoft.com/kb/911816
			// Do this one time for each AppDomain.
			if (!_initialized) 
			{
				lock (_objLock) 
				{
					if (!_initialized) 
					{ 
						try
						{
							// See if we're running in full trust
							new PermissionSet(PermissionState.Unrestricted).Demand();
							//LinkDemands and InheritenceDemands Occur at JIT Time
							//http://blogs.msdn.com/shawnfa/archive/2006/01/11/511716.aspx
							WireAppDomain();
						}
						catch(SecurityException)
						{
						}

						_initialized = true;
					}
				}
			}

			//Wire up the HttpApplication events.
			//
			//BeginRequest 
			//AuthenticateRequest 
			//AuthorizeRequest 
			//ResolveRequestCache 
			//A handler (a page corresponding to the request URL) is created at this point.
			//AcquireRequestState ** Session State ** 
			//PreRequestHandlerExecute 
			//[The handler is executed.] 
			//PostRequestHandlerExecute 
			//ReleaseRequestState 
			//Response filters, if any, filter the output.
			//UpdateRequestCache 
			//EndRequest 

			application.BeginRequest += new EventHandler(application_BeginRequest);
            if (!FluorineConfiguration.Instance.FluorineSettings.Runtime.AsyncHandler)
            {
                application.PreRequestHandlerExecute += new EventHandler(application_PreRequestHandlerExecute);
            }
            else
            {
                application.AddOnPreRequestHandlerExecuteAsync(new BeginEventHandler(BeginPreRequestHandlerExecute), new EndEventHandler(EndPreRequestHandlerExecute));
            }

			application.AuthenticateRequest += new EventHandler(application_AuthenticateRequest);
			
			//This implementation hooks the ReleaseRequestState and PreSendRequestHeaders events to 
			//figure out as late as possible if we should install the filter.
			//The Post Release Request State is the event most fitted for the task of adding a filter
			//Everything else is too soon or too late. At this point in the execution phase the entire 
			//response content is created and the page has fully executed but still has a few modules to go through
			//from an asp.net perspective.  We filter the content here and all of the javascript renders correctly.
			//application.PostReleaseRequestState += new EventHandler(this.CompressContent);
			application.ReleaseRequestState += new EventHandler(application_ReleaseRequestState);
			application.PreSendRequestHeaders += new EventHandler(application_PreSendRequestHeaders);
			application.EndRequest += new EventHandler(application_EndRequest);

            FluorineWebContext.Initialize();

            if (serviceBrowserRenderer == null)
            {
                lock (_objLock)
                {
                    if (serviceBrowserRenderer == null)
                    {
                        try
                        {
                            ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                            log.Info(__Res.GetString(__Res.ServiceBrowser_Aquire));
                        }
                        catch { }

                        try
                        {
                            Type type = ObjectFactory.Locate("FluorineFx.ServiceBrowser.ServiceBrowserRenderer");
                            if (type != null)
                            {
                                serviceBrowserRenderer = Activator.CreateInstance(type) as IServiceBrowserRenderer;
                                if (serviceBrowserRenderer != null)
                                {
                                    try
                                    {
                                        ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                                        log.Info(__Res.GetString(__Res.ServiceBrowser_Aquired));
                                    }
                                    catch { }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                                log.Fatal(__Res.GetString(__Res.ServiceBrowser_AquireFail), ex);
                            }
                            catch { }
                        }
                    }
                }
            }
            if (messageServer == null)
            {
                lock (_objLock)
                {
                    if (messageServer == null)
                    {
                        try
                        {
                            ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                            //log.Info("");
                            log.Info("************************************");
                            log.Info(__Res.GetString(__Res.Fluorine_Start));
                            log.Info(__Res.GetString(__Res.Fluorine_Version, Assembly.GetExecutingAssembly().GetName().Version));
                            log.Info("************************************");
                            log.Info(__Res.GetString(__Res.MessageServer_Create));
                        }
                        catch { }

                        messageServer = new MessageServer();
                        try
                        {
                            string configPath = Path.Combine(HttpRuntime.AppDomainAppPath, "WEB-INF");
                            configPath = Path.Combine(configPath, "flex");
                            messageServer.Init(configPath, serviceBrowserRenderer != null);
                            messageServer.Start();

                            try
                            {
                                ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                                log.Info(__Res.GetString(__Res.MessageServer_Started));
                            }
                            catch { }
                            HttpContext.Current.Application[FluorineMessageServerKey] = messageServer;
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                                log.Fatal(__Res.GetString(__Res.MessageServer_StartError), ex);
                            }
                            catch { }
                        }
                    }
                }
            }
		}

		/// <summary>
		/// Disposes of the resources (other than memory) used by the module that implements IHttpModule.
		/// </summary>
		public void Dispose()
		{
		}

		#endregion

        void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            try
            {
                lock (_objLock)
                {
                    if (messageServer != null)
                        messageServer.Stop();
                    messageServer = null;
                }
                ILog log = LogManager.GetLogger(typeof(FluorineGateway));
                log.Info("Stopped FluorineFx Gateway");
            }
            catch (Exception)
            { }
        }

		/// <summary>
		/// Occurs as the first event in the HTTP pipeline chain of execution when ASP.NET responds to a request.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void application_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			HttpRequest httpRequest = httpApplication.Request;

			if( serviceBrowserRenderer != null )
			{
				if( serviceBrowserRenderer.CanRender(httpRequest) )
				{
					CompressContent(httpApplication);

                    FluorineWebContext.Initialize();
					httpApplication.Response.Clear();
					//httpApplication.Response.ClearHeaders();
					serviceBrowserRenderer.Render(httpApplication);
					httpApplication.CompleteRequest();
					return;
				}
			}

            if (httpApplication.Request.ContentType == ContentType.AMF)
			{
				httpApplication.Context.SkipAuthorization = true;
			}
			//sessionState cookieless="true" requires to handle here an HTTP POST but Session is not available here
			//HandleXAmfEx(httpApplication);
		}

		/// <summary>
		/// Occurs just before ASP.NET begins executing a handler such as a page or XML Web service.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void application_PreRequestHandlerExecute(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			HandleXAmfEx(httpApplication);
            HandleSWX(httpApplication);
            HandleJSONRPC(httpApplication);
            HandleRtmpt(httpApplication);
		}

        IAsyncResult BeginPreRequestHandlerExecute(Object source, EventArgs e, AsyncCallback cb, Object state)
        {
            HttpApplication httpApplication = (HttpApplication)source;
            AsyncHandler asyncHandler = new AsyncHandler(cb, this, httpApplication, state);
            asyncHandler.Start();
            return asyncHandler;
        }

        void EndPreRequestHandlerExecute(IAsyncResult ar)
        {
            AsyncHandler asyncHandler = ar as AsyncHandler;
        }


        internal void HandleSWX(HttpApplication httpApplication)
        {
            string page = GetPageName(httpApplication.Request.RawUrl);
            if (page.ToLower() == "swxgateway.aspx")
            {
                httpApplication.Response.Clear();
                ILog log = null;
                try
                {
                    log = LogManager.GetLogger(typeof(FluorineGateway));
                    log4net.GlobalContext.Properties["ClientIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                catch { }
                if (log != null && log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Swx_Begin));

                try
                {
                    FluorineWebContext.Initialize();

                    SWX.SwxHandler swxHandler = new SWX.SwxHandler();
                    swxHandler.Handle(httpApplication);

                    if (log != null && log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Swx_End));

                    httpApplication.CompleteRequest();
                }
                catch (Exception ex)
                {
                    if (log != null)
                        log.Fatal(__Res.GetString(__Res.Swx_Fatal), ex);
                    httpApplication.Response.Clear();
                    httpApplication.Response.ClearHeaders();
                    httpApplication.Response.Status = __Res.GetString(__Res.Swx_Fatal404) + " " + ex.Message;
                    httpApplication.CompleteRequest();
                }
            }
        }

        internal void HandleJSONRPC(HttpApplication httpApplication)
        {
            string page = GetPageName(httpApplication.Request.RawUrl);
            if (page.ToLower() == "jsongateway.aspx")
            {
                httpApplication.Response.Clear();
                ILog log = null;
                try
                {
                    log = LogManager.GetLogger(typeof(FluorineGateway));
                    log4net.GlobalContext.Properties["ClientIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                catch { }
                if (log != null && log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Json_Begin));

                try
                {
                    FluorineWebContext.Initialize();

                    Json.Rpc.JsonRpcHandler handler = new FluorineFx.Json.Rpc.JsonRpcHandler(httpApplication.Context);
                    handler.ProcessRequest();

                    if (log != null && log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Json_End));

                    httpApplication.CompleteRequest();
                }
                catch (Exception ex)
                {
                    if (log != null)
                        log.Fatal(__Res.GetString(__Res.Json_Fatal), ex);
                    httpApplication.Response.Clear();
                    httpApplication.Response.ClearHeaders();
                    httpApplication.Response.Status = __Res.GetString(__Res.Json_Fatal404) + " " + ex.Message;
                    httpApplication.CompleteRequest();
                }
            }
        }

        internal void HandleXAmfEx(HttpApplication httpApplication)
		{
            if (httpApplication.Request.ContentType == ContentType.AMF)
			{
				CompressContent(httpApplication);
				httpApplication.Response.Clear();
                httpApplication.Response.ContentType = ContentType.AMF;

				ILog log = null;
				try
				{
					log = LogManager.GetLogger(typeof(FluorineGateway));
                    log4net.GlobalContext.Properties["ClientIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
				}
				catch{}
				if (log != null && log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Amf_Begin));

				try
				{
                    FluorineWebContext.Initialize();

					if (messageServer != null)
						messageServer.Service();
					else
					{
						if (log != null)
							log.Fatal(__Res.GetString(__Res.MessageServer_AccessFail));
					}

					if( log != null && log.IsDebugEnabled )
                        log.Debug(__Res.GetString(__Res.Amf_End));


					//http://support.microsoft.com/default.aspx?scid=kb;en-us;312629
					//httpApplication.Response.End();
					httpApplication.CompleteRequest();
				}
				catch(Exception ex)
				{
					if(log != null )
						log.Fatal(__Res.GetString(__Res.Amf_Fatal), ex);
					httpApplication.Response.Clear();
					httpApplication.Response.ClearHeaders();//FluorineHttpApplicationContext modifies headers
					httpApplication.Response.Status = __Res.GetString(__Res.Amf_Fatal404) + " " + ex.Message;
					httpApplication.CompleteRequest();
				}
			}
		}

        internal void HandleRtmpt(HttpApplication httpApplication)
        {
            if (httpApplication.Request.ContentType == ContentType.RTMPT)
            {
                httpApplication.Response.Clear();
                httpApplication.Response.ContentType = ContentType.RTMPT;

                ILog log = null;
                try
                {
                    log = LogManager.GetLogger(typeof(FluorineGateway));
                    log4net.GlobalContext.Properties["ClientIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                catch { }
                if (log != null && log.IsDebugEnabled)
                    log.Debug(__Res.GetString(__Res.Rtmpt_Begin));

                try
                {
                    FluorineWebContext.Initialize();

                    if (httpApplication.Request.Headers["RTMPT-command"] != null)
                    {
                        log.Debug(string.Format("ISAPI rewrite, original URL {0}", httpApplication.Request.Headers["RTMPT-command"]));
                    }


                    if (messageServer != null)
                        messageServer.ServiceRtmpt();
                    else
                    {
                        if (log != null)
                            log.Fatal(__Res.GetString(__Res.MessageServer_AccessFail));
                    }

                    if (log != null && log.IsDebugEnabled)
                        log.Debug(__Res.GetString(__Res.Rtmpt_End));

                    httpApplication.CompleteRequest();
                }
                catch (Exception ex)
                {
                    if (log != null)
                        log.Fatal(__Res.GetString(__Res.Rtmpt_Fatal), ex);
                    httpApplication.Response.Clear();
                    httpApplication.Response.ClearHeaders();
                    httpApplication.Response.Status = __Res.GetString(__Res.Rtmpt_Fatal404) + " " + ex.Message;
                    httpApplication.CompleteRequest();
                }
            }
        }

		/// <summary>
		/// Occurs when a security module has established the identity of the user.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void application_AuthenticateRequest(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
            if (httpApplication.Request.ContentType == ContentType.AMF)
			{
				httpApplication.Context.SkipAuthorization = true;
			}
		}

		private void application_ReleaseRequestState(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			CompressContent(httpApplication);
		}

		private void application_PreSendRequestHeaders(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			CompressContent(httpApplication);
		}

		private void application_EndRequest(object sender, EventArgs e)
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			if( httpApplication.Response.Filter is CompressingFilter || httpApplication.Response.Filter is ThresholdFilter)
			{
				CompressingFilter compressingFilter = null;
				if( httpApplication.Response.Filter is ThresholdFilter )
					compressingFilter = (httpApplication.Response.Filter as ThresholdFilter).CompressingFilter;
				else
					compressingFilter = httpApplication.Response.Filter as CompressingFilter;

				ILog log = null;
				try
				{
					log = LogManager.GetLogger(typeof(FluorineGateway));
				}
				catch{}
				if( compressingFilter != null && log != null && log.IsDebugEnabled )
				{
					float ratio = 0;
					if( compressingFilter.TotalIn != 0 )
						ratio = (compressingFilter.TotalOut * 100) / compressingFilter.TotalIn;
					string realPath = Path.GetFileName(httpApplication.Request.Path);
                    if (httpApplication.Request.ContentType == ContentType.AMF)
						realPath += "(x-amf)";
					string msg = __Res.GetString(__Res.Compress_Info, realPath, ratio);
					log.Debug(msg);
				}
			}
		}

		#region Compress

		/// <summary>
		/// EventHandler that gets ahold of the current request context and attempts to compress the output.
		/// </summary>
		/// <param name="httpApplication">The <see cref="HttpApplication"/> that is firing this event.</param>
		void CompressContent(HttpApplication httpApplication) 
		{
			// Only do this if we haven't already attempted an install.  This prevents PreSendRequestHeaders from
			// trying to add this item way to late.  We only want the first run through to do anything.
			// also, we use the context to store whether or not we've attempted an add, as it's thread-safe and
			// scoped to the request.  An instance of this module can service multiple requests at the same time,
			// so we cannot use a member variable.
			if(!httpApplication.Context.Items.Contains(FluorineHttpCompressKey)) 
			{

				// log the install attempt in the HttpContext
				// must do this first as several IF statements
				// below skip full processing of this method
				httpApplication.Context.Items.Add(FluorineHttpCompressKey, 1);

				// get the config settings
				HttpCompressSettings settings = FluorineConfiguration.Instance.HttpCompressSettings;

				if( settings.HandleRequest == HandleRequest.None )
				{
					// skip if no request can be handled
					return;
				}

                if (settings.HandleRequest == HandleRequest.Amf && httpApplication.Request.ContentType != ContentType.AMF)
				{
					// skip if only AMF is compressed and we do not have an AMF request
					return;
				}

				if(settings.CompressionLevel == CompressionLevels.None)
				{
					// skip if the CompressionLevel is set to 'None'
					return;
				}				

				//string realPath = httpApplication.Request.Path.Remove(0, httpApplication.Request.ApplicationPath.Length+1);
				string realPath = Path.GetFileName(httpApplication.Request.Path);
				if(settings.IsExcludedPath(realPath))
				{
					// skip if the file path excludes compression
					return;
				}

                if (httpApplication.Response.ContentType == null || settings.IsExcludedMimeType(httpApplication.Response.ContentType))
				{
					// skip if the MimeType excludes compression
					return;
				}

				// fix to handle caching appropriately
				// see http://www.pocketsoap.com/weblog/2003/07/1330.html
				// Note, this header is added only when the request
				// has the possibility of being compressed...
				// i.e. it is not added when the request is excluded from
				// compression by CompressionLevel, Path, or MimeType
				httpApplication.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;

				// grab an array of algorithm;q=x, algorith;q=x style values
				string acceptedTypes = httpApplication.Request.Headers["Accept-Encoding"];
				// if we couldn't find the header, bail out
				if(acceptedTypes == null)
				{
					return;
				}

				// the actual types could be , delimited.  split 'em out.
				string[] types = acceptedTypes.Split(',');

				CompressingFilter filter = GetFilterForScheme(types, httpApplication.Response.Filter, settings);

				if(filter == null)
				{
					// if we didn't find a filter, bail out
					return;
				}

				// if we get here, we found a viable filter.
				// set the filter and change the Content-Encoding header to match so the client can decode the response

                if (httpApplication.Request.ContentType == ContentType.AMF)
					httpApplication.Response.Filter = new ThresholdFilter(filter, httpApplication.Response.Filter, settings.Threshold);
				else
					httpApplication.Response.Filter = filter;
			}
		}

		/// <summary>
		/// Get ahold of a <see cref="CompressingFilter"/> for the given encoding scheme.
		/// If no encoding scheme can be found, it returns null.
		/// </summary>
		/// <remarks>
		/// See http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.3 for details
		/// on how clients are supposed to construct the Accept-Encoding header.  This
		/// implementation follows those rules, though we allow the server to override
		/// the preference given to different supported algorithms.  I'm doing this as 
		/// I would rather give the server control over the algorithm decision than 
		/// the client.  If the clients send up * as an accepted encoding with highest
		/// quality, we use the preferred algorithm as specified in the config file.
		/// </remarks>
		internal static CompressingFilter GetFilterForScheme(string[] schemes, Stream output, HttpCompressSettings prefs) 
		{
			bool foundDeflate = false;
			bool foundGZip = false;
			bool foundStar = false;
      
			float deflateQuality = 0f;
			float gZipQuality = 0f;
			float starQuality = 0f;

			bool isAcceptableDeflate;
			bool isAcceptableGZip;
			bool isAcceptableStar;

			for (int i = 0; i<schemes.Length;i++) 
			{
				string acceptEncodingValue = schemes[i].Trim().ToLower();

				if (acceptEncodingValue.StartsWith("deflate")) 
				{
					foundDeflate = true;
		  
					float newDeflateQuality = GetQuality(acceptEncodingValue);
					if (deflateQuality < newDeflateQuality)
						deflateQuality = newDeflateQuality;
				}

				else if (acceptEncodingValue.StartsWith("gzip") || acceptEncodingValue.StartsWith("x-gzip")) 
				{
					foundGZip = true;
		  
					float newGZipQuality = GetQuality(acceptEncodingValue);
					if (gZipQuality < newGZipQuality)
						gZipQuality = newGZipQuality;
				}
	    
				else if (acceptEncodingValue.StartsWith("*")) 
				{
					foundStar = true;
		  
					float newStarQuality = GetQuality(acceptEncodingValue);
					if (starQuality < newStarQuality)
						starQuality = newStarQuality;
				}
			}

			isAcceptableStar = foundStar && (starQuality > 0);
			isAcceptableDeflate = (foundDeflate && (deflateQuality > 0)) || (!foundDeflate && isAcceptableStar);
			isAcceptableGZip = (foundGZip && (gZipQuality > 0)) || (!foundGZip && isAcceptableStar);

			if (isAcceptableDeflate && !foundDeflate)
				deflateQuality = starQuality;

			if (isAcceptableGZip && !foundGZip)
				gZipQuality = starQuality;


			// do they support any of our compression methods?
			if(!(isAcceptableDeflate || isAcceptableGZip || isAcceptableStar)) 
			{
				return null;
			}
      
			// if deflate is better according to client
			if (isAcceptableDeflate && (!isAcceptableGZip || (deflateQuality > gZipQuality)))
				return new DeflateFilter(output, prefs.CompressionLevel);
      
			// if gzip is better according to client
			if (isAcceptableGZip && (!isAcceptableDeflate || (deflateQuality < gZipQuality)))
				return new GZipFilter(output);

			// if we're here, the client either didn't have a preference or they don't support compression
			if(isAcceptableDeflate && (prefs.PreferredAlgorithm == Algorithms.Deflate || prefs.PreferredAlgorithm == Algorithms.Default))
				return new DeflateFilter(output, prefs.CompressionLevel);
			if(isAcceptableGZip && prefs.PreferredAlgorithm == Algorithms.GZip)
				return new GZipFilter(output);

			if(isAcceptableDeflate || isAcceptableStar)
				return new DeflateFilter(output, prefs.CompressionLevel);
			if(isAcceptableGZip)
				return new GZipFilter(output);

			// return null.  we couldn't find a filter.
			return null;
		}
	
		static float GetQuality(string acceptEncodingValue) 
		{
			int qParam = acceptEncodingValue.IndexOf("q=");

			if (qParam >= 0) 
			{
				float val = 0.0f;
				try 
				{
					val = float.Parse(acceptEncodingValue.Substring(qParam+2, acceptEncodingValue.Length - (qParam+2)));
				} 
				catch(FormatException) 
				{
          
				}
				return val;
			} 
			else 
				return 1;
		}

		#endregion Compress

		#region kb911816

		private void WireAppDomain()
		{
			string webenginePath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "webengine.dll");
			if (File.Exists(webenginePath))
			{
				//This requires .NET Framework 2.0
				FileVersionInfo ver = FileVersionInfo.GetVersionInfo(webenginePath);
				_sourceName = string.Format(CultureInfo.InvariantCulture, "ASP.NET {0}.{1}.{2}.0", ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart);
				if (EventLog.SourceExists(_sourceName))
				{
					//This requires .NET Framework 2.0
					AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
				}
			}

            AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
            ILog log = LogManager.GetLogger(typeof(FluorineGateway));
            log.Info("Adding handler for the DomainUnload event");
            //If we do not have permission to handle DomainUnload but in this case the socket server will not start either
		}

		void OnUnhandledException(object o, UnhandledExceptionEventArgs e) 
		{
			// Let this occur one time for each AppDomain.
			if (Interlocked.Exchange(ref _unhandledExceptionCount, 1) != 0)
				return;

			StringBuilder message = new StringBuilder("\r\n\r\nUnhandledException logged by UnhandledExceptionModule.dll:\r\n\r\nappId=");

			string appId = (string) AppDomain.CurrentDomain.GetData(".appId");
			if (appId != null) 
				message.Append(appId);
            
			Exception currentException = null;
			for (currentException = (Exception)e.ExceptionObject; currentException != null; currentException = currentException.InnerException) 
			{
				message.AppendFormat("\r\n\r\ntype={0}\r\n\r\nmessage={1}\r\n\r\nstack=\r\n{2}\r\n\r\n",
					currentException.GetType().FullName, 
					currentException.Message,
					currentException.StackTrace);
			}
			EventLog Log = new EventLog();
			Log.Source = _sourceName;
			Log.WriteEntry(message.ToString(), EventLogEntryType.Error);

            ILog log = LogManager.GetLogger(typeof(FluorineGateway));
            log.Fatal(message.ToString());
        }

		#endregion kb911816
	}
}
