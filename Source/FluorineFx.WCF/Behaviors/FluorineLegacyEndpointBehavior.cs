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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using FluorineFx.WCF.Dispatcher;
using FluorineFx.WCF.Channels;

namespace FluorineFx.WCF.Behaviors
{
    sealed class FluorineLegacyEndpointBehavior : IEndpointBehavior
    {

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            if (endpoint == null)
                throw new ArgumentNullException("serviceEndpoint");

            if (endpointDispatcher == null)
                throw new ArgumentNullException("endpointDispatcher");

            endpointDispatcher.AddressFilter = new PrefixEndpointAddressMessageFilter(endpoint.Address);
            endpointDispatcher.ContractFilter = new MatchAllMessageFilter();
            FluorineLegacyOperationSelector operationSelector = new FluorineLegacyOperationSelector();
            endpointDispatcher.DispatchRuntime.OperationSelector = operationSelector;
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new FluorineLegacyDispatchMessageInspector());

            DispatchOperation dispatchOperation = new DispatchOperation(endpointDispatcher.DispatchRuntime, "Process", "*", "*");
            dispatchOperation.Invoker = new FluorineLegacyOperationInvoker(endpoint);
            dispatchOperation.DeserializeRequest = false;
            dispatchOperation.SerializeReply = false;
            endpointDispatcher.DispatchRuntime.UnhandledDispatchOperation = dispatchOperation;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        #endregion

    }
}
