/*
	FluorineFx open source library 
	Copyright (C) 2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Reflection;
using System.Security;

using FluorineFx;
using FluorineFx.IO;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Messages;
using FluorineFx.Invocation;
using FluorineFx.Util;
using FluorineFx.WCF.Channels;

namespace FluorineFx.WCF.Dispatcher
{
    class FluorineLegacyOperationInvoker : IOperationInvoker
    {
        ServiceEndpoint _endpoint;

        public FluorineLegacyOperationInvoker(ServiceEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        #region IOperationInvoker Members

        public object[] AllocateInputs()
        {
            FluorineLegacyOperationContext context = FluorineLegacyOperationContext.Current;
            return new object[1];
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            FluorineLegacyOperationContext context = FluorineLegacyOperationContext.Current;
            outputs = new object[0];
            object result = ProcessMessage(context.AMFMessage);
            Message message = Message.CreateMessage(MessageVersion.None, "*");
            message.Properties.Add("amf", result);
            return message;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronous
        {
            get { return true; }
        }

        #endregion

        object ProcessMessage(AMFMessage amfMessage)
        {
            // Apply AMF-based operation selector
            /*
            Dictionary<string, string> operationNameDictionary = new Dictionary<string, string>();
            foreach (OperationDescription operation in _endpoint.Contract.Operations)
            {
                try
                {
                    operationNameDictionary.Add(operation.Name.ToLower(), operation.Name);
                }
                catch (ArgumentException)
                {
                    throw new Exception(String.Format("The specified contract cannot be used with case insensitive URI dispatch because there is more than one operation named {0}", operation.Name));
                }
            }
            */

            //SessionMode, CallbackContract, ProtectionLevel

            AMFMessage output = new AMFMessage(amfMessage.Version);
            for (int i = 0; i < amfMessage.BodyCount; i++)
            {
                AMFBody amfBody = amfMessage.GetBodyAt(i);
                object content = amfBody.Content;
                if (content is IList)
                    content = (content as IList)[0];
                IMessage message = content as IMessage;
                if (message != null)
                {
                    //WCF should not assign client id for Flex...
                    if (message.clientId == null)
                        message.clientId = Guid.NewGuid().ToString("D");

                    //IMessage resultMessage = _endpoint.ServiceMessage(message);
                    IMessage responseMessage = null;
                    CommandMessage commandMessage = message as CommandMessage;
                    if (commandMessage != null && commandMessage.operation == CommandMessage.ClientPingOperation)
                    {
                        responseMessage = new AcknowledgeMessage();
                        responseMessage.body = true;
                    }
                    else
                    {
                        RemotingMessage remotingMessage = message as RemotingMessage;
                        string operation = remotingMessage.operation;
                        //TODO: you could use an alias for a contract to expose a different name to the clients in the metadata using the Name property of the ServiceContract attribute
                        string source = remotingMessage.source;
                        Type serviceType = TypeHelper.Locate(source);
                        Type contractInterface = serviceType.GetInterface(_endpoint.Contract.ContractType.FullName);
                        //WCF also lets you apply the ServiceContract attribute directly on the service class. Avoid using it.
                        //ServiceContractAttribute serviceContractAttribute = ReflectionUtils.GetAttribute(typeof(ServiceContractAttribute), type, true) as ServiceContractAttribute;
                        if (contractInterface != null)
                        {
                            object instance = Activator.CreateInstance(serviceType);
                            IList parameterList = remotingMessage.body as IList;
                            MethodInfo mi = MethodHandler.GetMethod(contractInterface, operation, parameterList, false, false);
                            //MethodInfo mi = MethodHandler.GetMethod(serviceType, operation, parameterList, false, false);
                            if (mi != null)
                            {
                                //TODO OperationContract attribute to alias it to a different publicly exposed name
                                OperationContractAttribute operationContractAttribute = ReflectionUtils.GetAttribute(typeof(OperationContractAttribute), mi, true) as OperationContractAttribute;
                                if (operationContractAttribute != null)
                                {
                                    //mi = MethodHandler.GetMethod(serviceType, operation, parameterList, false, false);
                                    ParameterInfo[] parameterInfos = mi.GetParameters();
                                    object[] args = new object[parameterInfos.Length];
                                    parameterList.CopyTo(args, 0);
                                    TypeHelper.NarrowValues(args, parameterInfos);
                                    object result = mi.Invoke(instance, args);
                                    if (!(result is IMessage))
                                    {
                                        responseMessage = new AcknowledgeMessage();
                                        responseMessage.body = result;
                                    }
                                    else
                                        responseMessage = result as IMessage;
                                }
                                else
                                    responseMessage = ErrorMessage.GetErrorMessage(remotingMessage, new SecurityException("Method in not part of an service contract"));
                            }
                            else
                                responseMessage = ErrorMessage.GetErrorMessage(remotingMessage, new SecurityException("Method in not part of an service contract"));
                        }
                        else
                            responseMessage = ErrorMessage.GetErrorMessage(remotingMessage, new SecurityException(String.Format("The specified contract {0} cannot be used with the source named {1} and operation named {2}", _endpoint.Contract.ContractType.Name, source, operation)));
                    }

                    if (responseMessage is AsyncMessage)
                    {
                        ((AsyncMessage)responseMessage).correlationId = message.messageId;
                    }
                    responseMessage.destination = message.destination;
                    responseMessage.clientId = message.clientId;

                    ResponseBody responseBody = new ResponseBody(amfBody, responseMessage);
                    output.AddBody(responseBody);
                }
            }
            return output;
        }
    }
}
