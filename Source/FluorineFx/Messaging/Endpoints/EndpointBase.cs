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
using System.Text;
using System.Collections;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.Caching;
using System.Threading;
using FluorineFx.Util;
using FluorineFx.Messaging;
using FluorineFx.Messaging.Config;
using FluorineFx.Messaging.Messages;
using FluorineFx.Messaging.Services;
using FluorineFx.Security;
using FluorineFx.Messaging.Api;

namespace FluorineFx.Messaging.Endpoints
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class EndpointBase : IEndpoint
	{
		protected MessageBroker _messageBroker;
		protected ChannelSettings _channelSettings;
		string _id;

		public EndpointBase(MessageBroker messageBroker, ChannelSettings channelSettings)
		{
			_messageBroker = messageBroker;
			_channelSettings = channelSettings;
			_id = _channelSettings.Id;
		}

		#region IEndpoint Members

		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public MessageBroker GetMessageBroker()
		{
			return _messageBroker;
		}

		public ChannelSettings GetSettings()
		{
			return _channelSettings;
		}

		public virtual void Start()
		{
		}

		public virtual void Stop()
		{
		}

		public virtual void Push(IMessage message, MessageClient messageClient)
		{
			throw new NotSupportedException();
		}

		public virtual void Service()
		{
		}

		public virtual IMessage ServiceMessage(IMessage message)
		{
			ValidationUtils.ArgumentNotNull(message, "message");
			IMessage response = null;
			response = _messageBroker.RouteMessage(message, this);
			return response;
		}

		public virtual bool IsSecure()
		{
			return false;
		}

		#endregion


	}
}
