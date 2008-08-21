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
using System.Collections;

namespace FluorineFx.Messaging.Config
{
    /// <summary>
    /// Contains the properties for configuring server settings for message destinations.
    /// This is the <b>server</b> element in the services-config.xml file.
    /// </summary>
    public sealed class ServerSettings : Hashtable
	{
		internal ServerSettings()
		{
		}

        internal ServerSettings(XmlNode severDefinitionNode)
		{
            foreach (XmlNode propertyNode in severDefinitionNode.SelectNodes("*"))
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
        /// Gets whether subtopics are allowed.
        /// </summary>
		public bool AllowSubtopics
		{
			get
            { 
                if( this.Contains("allow-subtopics") )
                    return (bool)this["allow-subtopics"];
                return false;
            }
		}
	}
}
