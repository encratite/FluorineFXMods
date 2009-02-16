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
using FluorineFx.Util;

namespace FluorineFx.Messaging.Config
{
    public sealed class SerializationSettings : Hashtable
    {
        const string LegacyCollectionKey = "legacy-collection";
        const string LegacyThrowableKey = "legacy-throwable";

        /// <summary>
        /// Initializes a new instance of the SerializationSettings class.
        /// </summary>
        internal SerializationSettings()
        {
        }
        /// <summary>
        /// Initializes a new instance of the ChannelSettings class.
        /// </summary>
        /// <param name="channelDefinitionNode"></param>
        internal SerializationSettings(XmlNode serializationNode)
        {
            foreach (XmlNode propertyNode in serializationNode.SelectNodes("*"))
            {
                this[propertyNode.Name] = propertyNode.InnerXml;
            }
        }

        public bool IsLegacyCollection
        {
            get
            {
                if (!this.ContainsKey(LegacyCollectionKey))
                    return false;
                string value = this[LegacyCollectionKey] as string;
                bool isLegacy = System.Convert.ToBoolean(value);
                return isLegacy;
            }
        }

        public bool IsLegacyThrowable
        {
            get
            {
                //Exception instances are serialized as AMF status-info objects by default
                if (!this.ContainsKey(LegacyThrowableKey))
                    return true;
                string value = this[LegacyThrowableKey] as string;
                bool isLegacy = System.Convert.ToBoolean(value);
                return isLegacy;
            }
        }
    }
}
