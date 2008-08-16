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
using System.Xml;

namespace FluorineFx.Messaging.Config
{
	/// <summary>
    /// Contains the properties for configuring the destination network element.
    /// This is the <b>network</b> element in the services-config.xml file.
	/// </summary>
	public sealed class NetworkSettings : Hashtable
	{
        private NetworkSettings()
        {
        }

		internal NetworkSettings(XmlNode networkDefinitionNode)
		{
			foreach(XmlNode propertyNode in networkDefinitionNode.SelectNodes("*"))
			{
				if( propertyNode.InnerXml != null && propertyNode.InnerXml != string.Empty )
					this[propertyNode.Name] = propertyNode.InnerXml;
				else
				{
					if( propertyNode.Attributes != null )
					{
						foreach(XmlAttribute attribute in propertyNode.Attributes)
						{
							this[propertyNode.Name + "_" + attribute.Name] = attribute.Value;
						}
					}
				}
			}
		}
        /// <summary>
        /// Gets whether data paging is enabled for the destination.
        /// </summary>
		public bool PagingEnabled
		{
			get
			{
				if( this.ContainsKey("paging_enabled")  )
					return Convert.ToBoolean(this["paging_enabled"]);
				return false;
			}
		}
        /// <summary>
        /// Gets the paging size. When paging is enabled, this indicates the number of records to be sent to the client when the client-side DataService.fill() method is called.
        /// </summary>
		public int PagingSize
		{
			get
			{
				if( this.ContainsKey("paging_pageSize")  )
					return Convert.ToInt32(this["paging_pageSize"]);
				return 0;
			}
		}
        /// <summary>
        /// Gets the idle time in minutes before a subscriber is unsubscribed.
        /// The value to 0 (zero) means subscribers are not forced to unsubscribe automatically.
        /// </summary>
        /// <remarks>The default value is 20.</remarks>
		public int SessionTimeout
		{
			get
			{
				if( this.ContainsKey("session-timeout")  )
					return Convert.ToInt32(this["session-timeout"]);
				return 20;
			}
		}
	}
}
