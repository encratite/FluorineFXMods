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
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using FluorineFx;
using FluorineFx.IO;

namespace FluorineFx.WCF.Dispatcher
{
    /// <summary>
    /// This OperationSelector always selects the "UnhandledDispatchOperation" operation.
    /// Dispatching is based on AMF messages and not on SOAP action values.
    /// </summary>
    class FluorineLegacyOperationSelector : IDispatchOperationSelector
    {
        public FluorineLegacyOperationSelector()
        {
        }

        #region IDispatchOperationSelector Members

        /// <summary>
        /// Always returns "*" (i.e. the unhandled dispatch operation)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SelectOperation(ref System.ServiceModel.Channels.Message message)
        {
            return "*";
        }

        #endregion
    }
}
