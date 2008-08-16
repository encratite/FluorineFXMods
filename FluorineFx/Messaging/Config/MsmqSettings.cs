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
    /// Contains the properties for configuring MSQM service adapters.
    /// This is the <b>msmq</b> element in the services-config.xml file.
    /// </summary>
    public sealed class MsmqSettings : Hashtable
    {
        public const string BinaryMessageFormatter = "BinaryMessageFormatter";
        public const string XmlMessageFormatter = "XmlMessageFormatter";

        private MsmqSettings()
        {
        }

        internal MsmqSettings(XmlNode msmqDefinitionNode)
		{
            foreach (XmlNode propertyNode in msmqDefinitionNode.SelectNodes("*"))
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
        /// Gets the name of the MSMQ queue.
        /// </summary>
        public string Name
        {
            get
            {
                if (this.ContainsKey("name"))
                    return this["name"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the message formatter type.
        /// </summary>
        public string Formatter
        {
            get
            {
                if (this.ContainsKey("formatter"))
                    return this["formatter"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the message label.
        /// </summary>
        public string Label
        {
            get
            {
                if (this.ContainsKey("label"))
                    return this["label"] as string;
                return null;
            }
        }
    }
}
