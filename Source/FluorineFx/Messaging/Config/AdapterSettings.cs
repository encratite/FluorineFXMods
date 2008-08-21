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
    /// Contains the properties for configuring service adapters.
    /// This is the <b>adapter</b> element in the services-config.xml file.
    /// </summary>
	public sealed class AdapterSettings : Hashtable
	{
        string _id;
        string _class;
        bool _defaultAdapter;

        internal AdapterSettings(string id, string adapterClass, bool defaultAdapter)
        {
            _id = id;
            _class = adapterClass;
            _defaultAdapter = defaultAdapter;
        }

        internal AdapterSettings(XmlNode adapterNode)
		{
            _id = adapterNode.Attributes["id"].Value;
            _class = adapterNode.Attributes["class"].Value;
            if (adapterNode.Attributes["default"] != null && adapterNode.Attributes["default"].Value == "true")
                _defaultAdapter = true;
		}
        /// <summary>
        /// Gets the identity of the adapter.
        /// </summary>
        public string Id
        {
            get { return _id; }
        }
        /// <summary>
        /// Gets the adapter type.
        /// </summary>
        public string Class
        {
            get { return _class; }
        }
        /// <summary>
        /// Gets whether the adapter is configured as the default adapter.
        /// </summary>
        public bool Default
        {
            get { return _defaultAdapter; }
        }
	}

    /// <summary>
    /// Strongly typed AdapterSettings collection.
    /// </summary>
    public sealed class AdapterSettingsCollection : CollectionBase
    {
        Hashtable _adapterDictionary;

        /// <summary>
        /// Initializes a new instance of the AdapterSettingsCollection class.
        /// </summary>
        public AdapterSettingsCollection()
        {
            _adapterDictionary = new Hashtable();
        }
        /// <summary>
        /// Adds a AdapterSettings to the collection.
        /// </summary>
        /// <param name="value">The AdapterSettings to add to the collection.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(AdapterSettings value)
        {
            _adapterDictionary[value.Id] = value;
            return List.Add(value);
        }
        /// <summary>
        /// Determines the index of a specific item in the collection. 
        /// </summary>
        /// <param name="value">The AdapterSettings to locate in the collection.</param>
        /// <returns>The index of value if found in the collection; otherwise, -1.</returns>
        public int IndexOf(AdapterSettings value)
        {
            return List.IndexOf(value);
        }
        /// <summary>
        /// Inserts a AdapterSettings item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The AdapterSettings to insert into the collection.</param>
        public void Insert(int index, AdapterSettings value)
        {
            _adapterDictionary[value.Id] = value;
            List.Insert(index, value);
        }
        /// <summary>
        /// Removes the first occurrence of a specific AdapterSettings from the collection.
        /// </summary>
        /// <param name="value">The AdapterSettings to remove from the collection.</param>
        public void Remove(AdapterSettings value)
        {
            _adapterDictionary.Remove(value.Id);
            List.Remove(value);
        }
        /// <summary>
        /// Determines whether the collection contains a specific AdapterSettings value.
        /// </summary>
        /// <param name="value">The AdapterSettings to locate in the collection.</param>
        /// <returns>true if the AdapterSettings is found in the collection; otherwise, false.</returns>
        public bool Contains(AdapterSettings value)
        {
            return List.Contains(value);
        }
        /// <summary>
        /// Gets or sets the AdapterSettings element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public AdapterSettings this[int index]
        {
            get
            {
                return List[index] as AdapterSettings;
            }
            set
            {
                List[index] = value;
            }
        }
        /// <summary>
        /// Gets or sets the AdapterSettings element with the specified key.
        /// </summary>
        /// <param name="key">The id of the AdapterSettings element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public AdapterSettings this[string key]
        {
            get
            {
                return _adapterDictionary[key] as AdapterSettings;
            }
            set
            {
                _adapterDictionary[key] = value;
            }
        }
    }
}
