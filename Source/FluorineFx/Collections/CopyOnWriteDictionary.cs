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

namespace FluorineFx.Collections
{
    /// <summary>
    /// A thread-safe version of IDictionary in which all operations that change the dictionary are implemented by 
    /// making a new copy of the underlying Hashtable.
    /// </summary>
    public class CopyOnWriteDictionary: IDictionary
    {
        Hashtable _dictionary;

        public CopyOnWriteDictionary()
        {
            _dictionary = new Hashtable();
        }

        public CopyOnWriteDictionary(int capacity)
        {
            _dictionary = new Hashtable(capacity);
        }

        public CopyOnWriteDictionary(IDictionary d)
        {
            _dictionary = new Hashtable(d);
        }

        #region IDictionary Members

        public void Add(object key, object value)
        {
            lock (this.SyncRoot)
            {
                Hashtable dictionary = new Hashtable(_dictionary);
                dictionary.Add(key, value);
                _dictionary = dictionary;
            }
        }

        public void Clear()
        {
            lock (this.SyncRoot)
            {
                _dictionary = new Hashtable();
            }
        }

        public bool Contains(object key)
        {
            return _dictionary.ContainsKey(key);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public bool IsFixedSize
        {
            get { return _dictionary.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return _dictionary.IsReadOnly; }
        }

        public ICollection Keys
        {
            get { return _dictionary.Keys; }
        }

        public void Remove(object key)
        {
            lock (this.SyncRoot)
            {
                if (Contains(key))
                {
                    Hashtable dictionary = new Hashtable(_dictionary);
                    dictionary.Remove(key);
                    _dictionary = dictionary;
                }
            }
        }

        public ICollection Values
        {
            get { return _dictionary.Values; }
        }

        public object this[object key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                lock (this.SyncRoot)
                {
                    Hashtable dictionary = new Hashtable(_dictionary);
                    dictionary[key] = value;
                    _dictionary = dictionary;
                }
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            _dictionary.CopyTo(array, index);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return _dictionary.SyncRoot; }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion
    }
}
