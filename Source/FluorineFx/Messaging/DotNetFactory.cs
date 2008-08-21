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

using FluorineFx.Context;

namespace FluorineFx.Messaging
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DotNetFactory : IFlexFactory
	{
		public DotNetFactory()
		{
		}

		#region IFlexFactory Members

		public FactoryInstance CreateFactoryInstance(string id, Hashtable properties)
		{
			DotNetFactoryInstance factoryInstance = new DotNetFactoryInstance(this, id, properties);
			factoryInstance.Source = properties["source"] as string;
			factoryInstance.Scope = properties["scope"] as string;
			if( factoryInstance.Scope == null )
				factoryInstance.Scope = "request";
			factoryInstance.AttributeId = properties["attribute-id"] as string;
			return factoryInstance;
		}

		public object Lookup(FactoryInstance factoryInstance)
		{
			DotNetFactoryInstance dotNetFactoryInstance = factoryInstance as DotNetFactoryInstance;
			switch(dotNetFactoryInstance.Scope)
			{
				case "application":
					return dotNetFactoryInstance.ApplicationInstance;
				case "session":
					if( FluorineContext.Current.Session != null )
					{
						object instance = FluorineContext.Current.Session[dotNetFactoryInstance.AttributeId];
						if( instance == null )
						{
							instance = dotNetFactoryInstance.CreateInstance();
							FluorineContext.Current.Session[dotNetFactoryInstance.AttributeId] = instance;
						}
                        return instance;
                    }
					break;
				default:
					return dotNetFactoryInstance.CreateInstance();
			}
			return null;
		}

		#endregion
	}
}
