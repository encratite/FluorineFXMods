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
using System.Reflection;
// Import log4net classes.
using log4net;
using log4net.Config;

using FluorineFx.Invocation;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.Exceptions;

namespace FluorineFx.Messaging.Rtmp.Service
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ServiceInvoker : IServiceInvoker
	{
		public static string SERVICE_NAME = "serviceInvoker";
		
		private ILog	_log;
		//IServiceResolver
		private ArrayList _serviceResolvers = new ArrayList();

		public ServiceInvoker()
		{
			try
			{
				_log = LogManager.GetLogger(typeof(ServiceInvoker));
			}
			catch{}
		}

		public void SetServiceResolvers(ArrayList resolvers) 
		{
			_serviceResolvers = resolvers;
		}
		/// <summary>
		/// Lookup a handler for the passed service name in the given scope.
		/// </summary>
		/// <param name="scope"></param>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		private object GetServiceHandler(IScope scope, string serviceName) 
		{
			// Get application scope handler first
			object service = scope.Handler;
			if(serviceName == null || serviceName == string.Empty) 
			{
				// No service requested, return application scope handler
				return service;
			}

			// Search service resolver that knows about service name
			if( _serviceResolvers != null )
			{
				foreach(IServiceResolver resolver in _serviceResolvers) 
				{
					service = resolver.ResolveService(scope, serviceName);
					if (service != null) 
						return service;
				}
			}
			// Requested service does not exist.
			return null;
		}

		#region IServiceInvoker Members

		public bool Invoke(IServiceCall call, IScope scope)
		{
			string serviceName = call.ServiceName;
			_log.Debug("Service name " + serviceName);
			object service = GetServiceHandler(scope, serviceName);

			if (service == null) 
			{
				call.Exception = new ServiceNotFoundException(serviceName);
				call.Status = Call.STATUS_SERVICE_NOT_FOUND;
				_log.Warn("Service not found: " + serviceName);
				return false;
			} 
			else 
			{
				_log.Debug("Service found: " + serviceName);
			}
			return Invoke(call, service);
		}

		public bool Invoke(IServiceCall call, object service)
		{
            IConnection connection = FluorineFx.Context.FluorineContext.Current.Connection;
			string serviceMethod = call.ServiceMethodName;

			object[] args = call.Arguments;
			object[] argsWithConnection = null;
			if(args != null) 
			{
				argsWithConnection = new object[args.Length + 1];
				argsWithConnection[0] = connection;
				Array.Copy(args, 0, argsWithConnection, 1, args.Length);
			} 
			else 
			{
				argsWithConnection = new object[] { connection };
			}

			object[] arguments = null;
            // First, search for method with the connection as first parameter, exact parameter type match
            MethodInfo mi = MethodHandler.GetMethod(service.GetType(), serviceMethod, argsWithConnection, true, false, false);
            if (mi == null)
            {
                // Second, search for method without the connection as first parameter.
                mi = MethodHandler.GetMethod(service.GetType(), serviceMethod, args, true, false, false);
                if (mi == null)
                {
                    // Third, search for method with the connection as first parameter
                    mi = MethodHandler.GetMethod(service.GetType(), serviceMethod, argsWithConnection, false, false, false);
                    if (mi == null)
                    {
                        // Forth, search for method without the connection as first parameter.
                        mi = MethodHandler.GetMethod(service.GetType(), serviceMethod, args, false, false, false);
                        if (mi == null)
                        {
                            string msg = __Res.GetString(__Res.Invocation_NoSuitableMethod, serviceMethod);
                            call.Status = Call.STATUS_METHOD_NOT_FOUND;
                            call.Exception = new FluorineException(msg);//MissingMethodException(service.GetType().Name, serviceMethod);
                            //_log.Error("Method " + serviceMethod + " not found in " + service);
                            _log.Error(msg, call.Exception);
                            return false;
                        }
                        else
                            arguments = args;
                    }
                    else
                        arguments = argsWithConnection;
                }
                else
                    arguments = args;
            }
            else
                arguments = argsWithConnection;

            try
            {
                _log.Debug("Invoking method: " + mi.Name);
                ParameterInfo[] parameterInfos = mi.GetParameters();
                object[] parameters = new object[parameterInfos.Length];
                arguments.CopyTo(parameters, 0);
                TypeHelper.NarrowValues(parameters, parameterInfos);

                object result = null;
                if (mi.ReturnType == typeof(void))
                {
                    InvocationHandler invocationHandler = new InvocationHandler(mi);
                    invocationHandler.Invoke(service, parameters);
                    call.Status = Call.STATUS_SUCCESS_VOID;
                }
                else
                {
                    InvocationHandler invocationHandler = new InvocationHandler(mi);
                    result = invocationHandler.Invoke(service, parameters);
                    call.Status = result == null ? Call.STATUS_SUCCESS_NULL : Call.STATUS_SUCCESS_RESULT;
                }
                if (call is IPendingServiceCall)
                    (call as IPendingServiceCall).Result = result;
            }
            catch (System.Security.SecurityException exception)
            {
                call.Exception = exception;
                call.Status = Call.STATUS_ACCESS_DENIED;
                _log.Error("Error executing call: " + call);
                _log.Error("Service invocation error", exception);
                return false;
            }
            catch (TargetInvocationException exception)
            {
                call.Exception = exception;
                call.Status = Call.STATUS_INVOCATION_EXCEPTION;
                _log.Error("Error executing call: " + call);
                _log.Error("Service invocation error", exception);
                return false;
            }
            catch (Exception exception)
            {
                call.Exception = exception;
                call.Status = Call.STATUS_GENERAL_EXCEPTION;
                _log.Error("Error executing call: " + call);
                _log.Error("Service invocation error", exception);
                return false;
            }
            return true;
		}

		#endregion
	}
}
