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
using System.IO;
using System.Collections;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using FluorineFx.IO;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Persistence;

namespace FluorineFx.Messaging
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [CLSCompliant(false)]
	public class PersistableAttributeStore : AttributeStore, IPersistable
	{
		protected bool		_persistent = true;
		protected string	_name;
		protected string	_path;
		protected string	_type;
		protected long		_lastModified = -1;
		protected IPersistenceStore _store = null;

		public PersistableAttributeStore(string type, string name, string path, bool persistent)
		{
			_name = name;
			_path = path;
			_type = type;
			_persistent = persistent;
		}

		public virtual string Type
		{
			get{ return _type; }
			set{ _type = value; }
		}

		#region IPersistable Members

		public virtual bool IsPersistent
		{
			get{ return _persistent; }
			set{ _persistent = value; }
		}

		public virtual string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		public virtual string Path
		{
			get{ return _path; }
			set{ _path = value; }
		}

		public virtual long LastModified
		{
			get{ return _lastModified; }
		}

		public virtual IPersistenceStore Store
		{
			get{ return _store; }
			set
			{
				_store = value;
				if( _store != null )
					_store.Load(this);
			}
		}

        public void Serialize(AMFWriter writer)
		{
            Hashtable persistentAttributes = new Hashtable();
            foreach (string attribute in this.GetAttributeNames())
            {
                if (attribute.StartsWith(Constants.TransientPrefix))
                    continue;
                persistentAttributes.Add(attribute, this[attribute]);
            }
            writer.WriteData(ObjectEncoding.AMF0, persistentAttributes);
		}

        public void Deserialize(AMFReader reader)
		{
            this.RemoveAttributes();
            IDictionary persistentAttributes = reader.ReadData() as IDictionary;
            this.SetAttributes(persistentAttributes);
		}

		#endregion

		protected void OnModified()
		{
			_lastModified = System.Environment.TickCount;
			if(_store != null) 
				_store.Save(this);
		}

		public override bool RemoveAttribute(string name)
		{
			bool result = base.RemoveAttribute (name);
			if(result && !name.StartsWith(Constants.TransientPrefix))
				OnModified();
			return result;
		}

		public override void RemoveAttributes()
		{
			base.RemoveAttributes();
			OnModified();
		}

		public override bool SetAttribute(string name, object value)
		{
			bool result = base.SetAttribute (name, value);
            if (result && !name.StartsWith(Constants.TransientPrefix))
				OnModified();
			return result;
		}

		public override void SetAttributes(IAttributeStore values)
		{
			base.SetAttributes (values);
			OnModified();
		}

#if !(NET_1_1)
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        public override void SetAttributes(IDictionary<string, object> values)
        {
            base.SetAttributes(values);
            OnModified();
        }
#else
        /// <summary>
        /// Sets multiple attributes on this object.
        /// </summary>
        /// <param name="values">Dictionary of attributes.</param>
        public override void SetAttributes(IDictionary values)
		{
			base.SetAttributes (values);
			OnModified();
		}
#endif
    }
}
