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
using System.Xml;
using System.Web;
using System.IO;
using System.Reflection;

using FluorineFx.Util;
using FluorineFx.Management;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;
using FluorineFx.Json;

namespace FluorineFx.ServiceBrowser
{
	/// <summary>
	/// The service browser.
	/// </summary>
	[RemotingService("FluorineFx ServiceBrowser Service")]
	public sealed class FluorineServiceBrowser
	{
		/// <summary>
		/// Initializes a new instance of the ServiceBrowser class.
		/// </summary>
		public FluorineServiceBrowser()
		{
		}

		public object pingBrowser()
		{
			return "success";
		}

		/// <summary>
		/// Returns the capabilities of the ServiceBrowser as currently implemented. 
		/// Universal Remoting enabled projects may choose to implement all or some of the capabilities of the front-end.
		/// </summary>
		/// <returns>
		/// An array of objects. Each object should be in the format {name:String, version:Number, data:*}. 
		/// </returns>
		public ASObject getCapabilities()
		{
			string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			ASObject result = new ASObject();
			// authentication: This Remoting implementation supports AMF0/AMF3 authentication
			ASObject asoAuthentication = new ASObject();
			asoAuthentication["name"] = "authentication";
			asoAuthentication["version"] = "FormsAuthentication";
			asoAuthentication["data"] = "true";
			result["authentication"] = asoAuthentication;
			// secure: The user of the service browser must authenticate him/herself with 
			// the unlock method before accessing it. 
			// The roles of all the methods except verifyLogin and getCapabilities should be set 
			// to admin.
			//ASObject secure = new ASObject();
			// codegen: This service browser supports code generation
			ASObject asoCodegen = new ASObject();
			asoCodegen["name"] = "codegen";
			asoCodegen["version"] = version;
			asoCodegen["data"] = CodeGeneratorService.GetCodeTemplates();//.ToArray(typeof(object)) as object[];
			result["codegen"] = asoCodegen;
			result["version"] = version;

			// codesave: This service browser supports code saving. 
			// data in this case may contain the enabled key. 
			// If enabled is set to false, indicates that the remote class has the remote code 
			// saving capability, but it is disabled because of a lack of permissions in the target directory.
			// if data is null, assume enabled is true.
			//ASObject codesave = new ASObject();

			return result;
		}

		/// <summary>
		/// Returns a list of remote services that are available.
		/// 
		/// {services:
		///		{
		///			"assembly1":
		///			{
		///				namespaces:
		///				{
		///					"com":
		///					{
		///						"packageName":
		///						[
		///							{name:"Class1",type:"service"},
		///							{name:"Class2",type:"service"}
		///						]
		///					}
		///					,
		///					"-":
		///					[
		///						{name:"Class1",type:"service"},
		///						{name:"Class2",type:"service"}
		///					]
		///				}
		///			}
		///		}
		///	webservices:
		///		{
		///		}
		///	}
		/// </summary>
		/// <returns>An array of array ready to be bound to a Tree.</returns>
		public Project getServices()
		{
			ManagementService managementService = new ManagementService();
			Project project = managementService.GetProject();
			//ASObject result = new ASObject();
			//result["services"] = GetLibraryServices();
			//result["webservices"] = GetWebServices();
			return project;
		}

		/// <summary>
		/// Returns all the data associated with a service, including description and method description.
		/// 
		/// {
		///		name:"com.myPackage.Class1",
		///		description:"This is a clazz that does stuff",
		///		methods:
		///		[
		///			{
		///				name: "methodName1",
		///				description: "a method that does stuff. Extra things like author tags and whatnot may be added to description",
		///				arguments: [
		///					{
		///						name:"arg1", 
		///						type:"* for untyped languages, type for typed languages", 
		///						description:"description if available"
		///					}],
		///				returns: {type:"*", description:"Could return anything"},
		///				extra: {roles:"admin, user"}
		///			}
		///		]
		///	}
		/// </summary>
		/// <param name="serviceName">serviceName, including the package name, such as com.myPackage.Class1</param>
		/// <returns></returns>
		public ASObject getService(string serviceName)
		{
			Type type = TypeHelper.Locate(serviceName);
			if( type != null )
			{
				return GetService(type);
			}
			return null;
		}

        private ASObject GetService(Type type)
        {
            ASObject result = new ASObject();
            result["name"] = type.FullName;
            result["description"] = TypeHelper.GetDescription(type);

            ArrayList methods = new ArrayList();
            foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (TypeHelper.SkipMethod(methodInfo))
                    continue;

                ASObject method = new ASObject();
                method["name"] = methodInfo.Name;
                method["description"] = TypeHelper.GetDescription(methodInfo);

                ArrayList parameters = new ArrayList();
                foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                {
                    ASObject parameter = new ASObject();
                    parameter["name"] = parameterInfo.Name;
                    parameter["type"] = parameterInfo.ParameterType.ToString();
                    parameter["description"] = "";
                    parameters.Add(parameter);
                }
                method["arguments"] = parameters.ToArray(typeof(object)) as object[];

                ASObject returnType = new ASObject();
                returnType["type"] = methodInfo.ReturnType.ToString();
                returnType["description"] = "";
                method["returns"] = returnType;

                methods.Add(method);
            }

            result["methods"] = methods.ToArray(typeof(object)) as object[];
            return result;
        }


		public ASObject previewCode(string codeTemplate, string serviceName, string methodName)
		{
			return CodeGeneratorService.GetCodePreview(codeTemplate, serviceName, methodName);
		}

        public object invokeService(string service, string operation, object[] args)
        {
            MessageBroker messageBroker = MessageBroker.GetMessageBroker(null);

            RemotingMessage remotingMessage = new RemotingMessage();
            remotingMessage.source = service;
            remotingMessage.operation = operation;
            string destinationId = messageBroker.GetDestinationId(remotingMessage);
            remotingMessage.destination = destinationId;
            if (args != null)
            {
                for(int i = 0; i <args.Length; i++)
                {
                    object obj = args[i];
                    if (obj is ASObject)
                    {
                        ASObject aso = obj as ASObject;
                        Type type = null;
                        //if (aso.ContainsKey("TypeName"))
                        //    type = TypeHelper.Locate(aso["TypeName"] as string);
                        if (aso.ContainsKey("__type"))
                            type = TypeHelper.Locate(aso["__type"] as string);
                        if (type != null)
                        {
                            string tmp = JavaScriptConvert.SerializeObject(obj);
                            args[i] = JavaScriptConvert.DeserializeObject(tmp, type);
                        }
                    }
                }
            }
            remotingMessage.body = args;
            remotingMessage.timestamp = Environment.TickCount;
            IMessage response = messageBroker.RouteMessage(remotingMessage);
            return response;
        }
	}
}
