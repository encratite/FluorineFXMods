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
using System.Collections.Specialized;

using FluorineFx.Util;
using FluorineFx.Collections;
using FluorineFx.Messaging.Api;

namespace FluorineFx.Messaging
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
	public class AttributeStore : DisposableBase, IAttributeStore
	{
		//protected SynchronizedHashtable _attributes;
        protected SortedList _attributes;

		public AttributeStore()
		{
            _attributes = new SortedList();
		}

		#region IAttributeStore Members

        /// <summary>
        /// Returns the attribute names.
        /// </summary>
        /// <returns>Collection of attribute names.</returns>
        public virtual ICollection GetAttributeNames()
		{
            lock (_attributes.SyncRoot)
            {
                return new ReadOnlyCollection(_attributes.Keys);
            }
		}
        /// <summary>
        /// Sets an attribute on this object.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The attribute value.</param>
        /// <returns>true if the attribute value changed otherwise false</returns>
		public virtual bool SetAttribute(string name, object value)
		{
			if(name == null )
				return false;
            /*
            if (value == null)
            {
                lock (_attributes.SyncRoot)
                {
                    // Remove value
                    if (_attributes.ContainsKey(name))
                    {
                        _attributes.Remove(name);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                lock (_attributes.SyncRoot)
                {
                    // Update with new value
                    object previous = _attributes[name];
                    _attributes[name] = value;
                    return (previous == null || value == previous || !value.Equals(previous));
                }
            }
            */
            lock (_attributes.SyncRoot)
            {
                // Update with new value
                object previous = _attributes[name];
                _attributes[name] = value;
                return (previous == null || value == previous || !value.Equals(previous));
            }
        }
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        public virtual void SetAttributes(IDictionary values)
		{
            lock (_attributes.SyncRoot)
            {
                foreach (DictionaryEntry entry in values)
                {
                    SetAttribute(entry.Key as string, entry.Value);
                }
            }
		}
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Attribute store.</param>
		public virtual void SetAttributes(IAttributeStore values)
		{
            lock (_attributes.SyncRoot)
            {
                foreach (string name in values.GetAttributeNames())
                {
                    object value = values.GetAttribute(name);
                    SetAttribute(name, value);
                }
            }
		}
        /// <summary>
        /// Returns the value for a given attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>The attribute value.</returns>
		public virtual object GetAttribute(string name)
		{
            if (name == null)
                return null;
            lock (_attributes.SyncRoot)
            {
                return _attributes[name];
            }
		}
        /// <summary>
        /// Returns the value for a given attribute and sets it if it doesn't exist.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="defaultValue">Attribute's default value.</param>
        /// <returns>The attribute value.</returns>
		public virtual object GetAttribute(string name, object defaultValue)
		{
            if (name == null)
                return null;
    	    if (defaultValue == null)
    		    throw new NullReferenceException("The default value may not be null.");
            lock (_attributes.SyncRoot)
            {
                if (_attributes.ContainsKey(name))
                    return _attributes[name];
                else
                {
                    _attributes[name] = defaultValue;
                    return null;
                }
            }
		}
        /// <summary>
        /// Checks whetner the object has an attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>true if a child scope exists, otherwise false.</returns>
		public virtual bool HasAttribute(string name)
		{
            if (name == null)
                return false;
            lock (_attributes.SyncRoot)
            {
                return _attributes.ContainsKey(name);
            }
		}
        /// <summary>
        /// Removes an attribute.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>true if the attribute was found and removed otherwise false.</returns>
		public virtual bool RemoveAttribute(string name)
		{
            lock (_attributes.SyncRoot)
            {
                if (HasAttribute(name))
                {
                    _attributes.Remove(name);
                    return true;
                }
                return false;
            }
		}
        /// <summary>
        /// Removes all attributes.
        /// </summary>
		public virtual void RemoveAttributes()
		{
            lock (_attributes.SyncRoot)
            {
                _attributes.Clear();
            }
		}
        /// <summary>
        /// Gets whether the attribute store is empty;
        /// </summary>
        public bool IsEmpty 
        {
            get
            {
                lock (_attributes.SyncRoot)
                {
                    return _attributes.Count == 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value by name.
        /// </summary>
        /// <param name="name">The key name of the value.</param>
        /// <returns>The value with the specified name.</returns>
        public Object this[string name] 
        {
            get
            {
                return GetAttribute(name);
            }
            set
            {
                SetAttribute(name, value);
            }
        }
        /// <summary>
        /// Gets or sets a value by numerical index.
        /// </summary>
        /// <param name="index">The numerical index of the value.</param>
        /// <returns>The value stored at the specified index.</returns>
        public Object this[int index] 
        {
            get
            {
                lock (_attributes.SyncRoot)
                {
                    return _attributes.GetByIndex(index);
                }
            }
            set
            {
                lock (_attributes.SyncRoot)
                {
                    _attributes.SetByIndex(index, value);
                }
            }
        }

        /// <summary>
        /// Deletes an item at a specified index from the attributes collection.
        /// </summary>
        /// <param name="index">The index of the item to remove from the attributes collection.</param>
        public void RemoveAt(int index)
        {
            _attributes.RemoveAt(index);
        }
        /// <summary>
        /// Gets the number of attributes in the collection.
        /// </summary>
        public int AttributesCount 
        {
            get { return _attributes.Count; }
        }
        /// <summary>
        /// Copies the collection of attribute values to a one-dimensional array, starting at the specified index in the array.
        /// </summary>
        /// <param name="array">The Array that receives the values.</param>
        /// <param name="index">The zero-based index in array from which copying starts.</param>
        public void CopyTo(Array array, int index)
        {
            _attributes.Values.CopyTo(array, index);
        }

		#endregion
    }
}
