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
using System.Runtime.Serialization;

namespace FluorineFx.Management
{
    /// <summary>
    /// Summary description for AttributeCollection.
    /// </summary>
    [Serializable]
    public class AttributeCollection : NameObjectCollectionBase
    {
		public AttributeCollection()
		{
		}

        protected AttributeCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}

		public void Add( string name, AttributeDescriptor value )  
		{
			base.BaseAdd(name, value);
		}

        public void Add(AttributeDescriptor value)
        {
            base.BaseAdd(value.Name, value);
        }

		public void Clear()
		{
			base.BaseClear();
		}

        public AttributeDescriptor Get(int index)
		{
            return (AttributeDescriptor)base.BaseGet(index);
		}

        public AttributeDescriptor Get(string name)
		{
            return (AttributeDescriptor)base.BaseGet(name);
		}

		public string GetKey(int index)
		{
			return base.BaseGetKey(index);
		}

		public void Remove(string name)
		{
			base.BaseRemove(name);
		}

		public void RemoveAt(int index)
		{
			base.BaseRemoveAt(index);
		}

		public bool Contains(string name)
		{
			return Get(name) != null;
		}

		public ICollection AllKeys
		{
			get
			{
				return base.BaseGetAllKeys();
			}
		}

        public AttributeDescriptor this[int index]
		{
			get
			{
				return this.Get(index);
			}
		}

        public AttributeDescriptor this[string name]
		{
			get
			{
				return this.Get(name);
			}
		}

		public new IEnumerator GetEnumerator()
		{
            return new AttributeEnumerator(this);
		}
    }

    [Serializable]
    internal class AttributeEnumerator : IEnumerator
    {
        private AttributeCollection _coll;
        private int _pos;

        internal AttributeEnumerator(AttributeCollection coll)
        {
            _coll = coll;
            _pos = -1;
        }

        public bool MoveNext()
        {
            if (_pos < _coll.Count - 1)
            {
                _pos++;
                return true;
            }
            _pos = _coll.Count;
            return false;
        }

        public void Reset()
        {
            _pos = -1;
        }

        public object Current
        {
            get
            {
                if ((_pos < 0) || (_pos >= _coll.Count))
                {
                    throw new InvalidOperationException();
                }
                return _coll.Get(_pos);
            }
        }
    }
}
