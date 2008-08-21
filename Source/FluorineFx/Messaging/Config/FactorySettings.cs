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
    /// Contains the properties for configuring Flex factories.
    /// This is the <b>factories</b> element in the services-config.xml file.
    /// Flex factories are global, a single FlexFactory instance is created for each Flex-enabled web application.
	/// </summary>
	public sealed class FactorySettings : Hashtable
	{
		string _id;
		string _class;

		private FactorySettings()
		{
		}

		internal FactorySettings(XmlNode factoryDefinitionNode)
		{
			_id = factoryDefinitionNode.Attributes["id"].Value;
			_class = factoryDefinitionNode.Attributes["class"].Value;

			XmlNode propertiesNode = factoryDefinitionNode.SelectSingleNode("properties");
			if (propertiesNode != null)
			{
				foreach (XmlNode propertyNode in propertiesNode.SelectNodes("*"))
				{
					this[propertyNode.Name] = propertyNode.InnerXml;
				}
			}
		}
        /// <summary>
        /// Gets or sets the identity of the factory.
        /// </summary>
		public string Id
		{
			get { return _id; }
			set { _id = value; }
		}
        /// <summary>
        /// Gets the IFlexFactory type.
        /// </summary>
		public string ClassId
		{
			get { return _class; }
			set { _class = value; }
		}
	}

    /// <summary>
    /// Strongly typed FactorySettings collection.
    /// </summary>
    public sealed class FactorySettingsCollection : CollectionBase
    {
        /// <summary>
        /// Initializes a new instance of the FactorySettingsCollection class.
        /// </summary>
        public FactorySettingsCollection()
        {
        }
        /// <summary>
        /// Adds a FactorySettings to the collection.
        /// </summary>
        /// <param name="value">The FactorySettings to add to the collection.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(FactorySettings value)
        {
            return List.Add(value);
        }
        /// <summary>
        /// Determines the index of a specific item in the collection. 
        /// </summary>
        /// <param name="value">The FactorySettings to locate in the collection.</param>
        /// <returns>The index of value if found in the collection; otherwise, -1.</returns>
        public int IndexOf(FactorySettings value)
        {
            return List.IndexOf(value);
        }
        /// <summary>
        /// Inserts a FactorySettings item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The FactorySettings to insert into the collection.</param>
        public void Insert(int index, FactorySettings value)
        {
            List.Insert(index, value);
        }
        /// <summary>
        /// Removes the first occurrence of a specific FactorySettings from the collection.
        /// </summary>
        /// <param name="value">The FactorySettings to remove from the collection.</param>
        public void Remove(FactorySettings value)
        {
            List.Remove(value);
        }
        /// <summary>
        /// Determines whether the collection contains a specific FactorySettings value.
        /// </summary>
        /// <param name="value">The FactorySettings to locate in the collection.</param>
        /// <returns>true if the FactorySettings is found in the collection; otherwise, false.</returns>
        public bool Contains(FactorySettings value)
        {
            return List.Contains(value);
        }
        /// <summary>
        /// Gets or sets the FactorySettings element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public FactorySettings this[int index]
        {
            get
            {
                return List[index] as FactorySettings;
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
