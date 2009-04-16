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
using System.Threading;
#if !(NET_1_1)
using System.Collections.Generic;
#endif

namespace FluorineFx.Collections.Generic
{
    /// <summary>
    /// A thread-safe version of IDictionary in which all operations that change the dictionary are implemented by 
    /// making a new copy of the underlying Hashtable.
    /// </summary>
    class CopyOnWriteDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection
    {
        Dictionary<TKey, TValue> _dictionary;

        /// <summary>
        /// Initializes a new instance of CopyOnWriteDictionary.
        /// </summary>
        public CopyOnWriteDictionary()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }
        /// <summary>
        /// Initializes a new, empty instance of the CopyOnWriteDictionary class using the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The approximate number of elements that the CopyOnWriteDictionary object can initially contain.</param>
        public CopyOnWriteDictionary(int capacity)
        {
            _dictionary = new Dictionary<TKey, TValue>(capacity);
        }
        /// <summary>
        /// Initializes a new instance of the CopyOnWriteDictionary class by copying the elements from the specified dictionary to the new CopyOnWriteDictionary object. The new CopyOnWriteDictionary object has an initial capacity equal to the number of elements copied.
        /// </summary>
        /// <param name="d">The IDictionary object to copy to a new CopyOnWriteDictionary object.</param>
        public CopyOnWriteDictionary(IDictionary<TKey, TValue> d)
        {
            _dictionary = new Dictionary<TKey, TValue>(d);
        }
#if !(NET_1_1)
        /// <summary>
        /// Initializes a new, empty instance of the CopyOnWriteDictionary class using the default initial capacity and load factor, and the specified IEqualityComparer object.
        /// </summary>
        /// <param name="equalityComparer">The IEqualityComparer object that defines the hash code provider and the comparer to use with the CopyOnWriteDictionary object.</param>
        public CopyOnWriteDictionary(IEqualityComparer<TKey> equalityComparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(equalityComparer);
        }
#endif

        #region IDictionary<TKey,TValue> Members

        /// <summary>
        /// Adds an element with the specified key and value into the CopyOnWriteDictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null reference (Nothing in Visual Basic).</param>
        public void Add(TKey key, TValue value)
        {
            lock (this.SyncRoot)
            {
                Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_dictionary);
                dictionary.Add(key, value);
                _dictionary = dictionary;
            }
        }
        /// <summary>
        /// Determines whether the CopyOnWriteDictionary contains a specific key.
        /// </summary>
        /// <param name="key">The key to locate in the CopyOnWriteDictionary.</param>
        /// <returns>true if the CopyOnWriteDictionary contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }

        public bool Remove(TKey key)
        {
            lock (this.SyncRoot)
            {
                if (ContainsKey(key))
                {
                    Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_dictionary);
                    dictionary.Remove(key);
                    _dictionary = dictionary;
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return _dictionary.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                lock (this.SyncRoot)
                {
                    Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_dictionary);
                    dictionary[key] = value;
                    _dictionary = dictionary;
                }
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        /// <summary>
        /// Removes all elements from the CopyOnWriteDictionary.
        /// </summary>
        public void Clear()
        {
            lock (this.SyncRoot)
            {
                _dictionary = new Dictionary<TKey, TValue>();
            }
        }
        /// <summary>
        /// Determines whether the CopyOnWriteDictionary contains a specific key.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if the CopyOnWriteDictionary contains an element with the specified key; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        /// <summary>
        /// Returns an enumerator that iterates through the CopyOnWriteDictionary.
        /// </summary>
        /// <returns>An enumerator for the CopyOnWriteDictionary.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            (_dictionary as ICollection).CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get { return (_dictionary as ICollection).IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return (_dictionary as ICollection).SyncRoot; }
        }

        #endregion

        /// <summary>
        /// Adds an item to the dictionary if this CopyOnWriteDictionary does not yet contain this item.
        /// </summary>
        ///<param name="key">The <see cref="T:System.Object"></see> to use as the key of the element to add. </param>
        ///<param name="value">The <see cref="T:System.Object"></see> to use as the value of the element to add. </param>
        /// <returns>The value if added, otherwise the old value in the dictionary.</returns>
        public TValue AddIfAbsent(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                if (!_dictionary.ContainsKey(key))
                {
                    _dictionary.Add(key, value);
                    return value;
                }
                else
                {
                    return _dictionary[key];
                }
            }
        }

        public object RemoveAndGet(TKey key)
        {
            lock (this.SyncRoot)
            {
                if (ContainsKey(key))
                {
                    Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_dictionary);
                    dictionary.Remove(key);
                    object value = _dictionary[key];
                    _dictionary = dictionary;
                    return value;
                }
            }
            return null;
        }
    }
}
