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
using System.Collections.Specialized;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using log4net;
using FluorineFx;
using FluorineFx.Util;
using FluorineFx.IO;
using FluorineFx.Collections;
using FluorineFx.Messaging.Api.Persistence;
using FluorineFx.Messaging.Api.Event;
using FluorineFx.Messaging.Api.SO;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Rtmp;

namespace FluorineFx.Messaging.Rtmp.SO
{
	/// <summary>
	/// Represents shared object on server-side (remote Shared Objects). Shared Objects in Flash are 
	/// like cookies that are stored on client side.
	/// These are shared by multiple clients and synchronized between them automatically on each data change.
	/// This is done asynchronously, used as events handling and is widely used in multiplayer Flash 
	/// online games.
	/// 
	/// Shared object can be persistent or transient. The difference is that first are saved to the disk 
	/// and can be accessed later on next connection, transient objects are not saved and get lost each 
	/// time they last client disconnects from it.
	/// 
	/// Shared Objects has name identifiers and path on server's HD (if persistent).
	/// 
	/// Shared Objects store data as simple map, that is, name-value pairs. Each value in turn can be 
	/// complex object or map.
	/// </summary>
    class SharedObject : AttributeStore, IPersistable
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(SharedObject));

		[NonSerialized]
		public const string TYPE = "SharedObject";

		protected string _name = string.Empty;
		protected string _path = string.Empty;
		protected long _lastModified = -1;
        /// <summary>
        /// Timestamp the scope was created.
        /// </summary>
        private long _creationTime;
		/// <summary>
		/// true if the SharedObject was stored by the persistence framework 
		/// </summary>
		protected bool _persistent = false;
		/// <summary>
		/// true if the client / server created the SO to be persistent
		/// </summary>
		protected bool _persistentSO = false;
		protected Hashtable _hashes = new Hashtable();

		protected IPersistenceStore _storage = null;
		protected int _version = 1;
		protected int _updateCounter = 0;
		protected bool _modified = false;
        protected SharedObjectMessage _ownerMessage;
        //Synchronization events (ISharedObjectEvent)
#if !(NET_1_1)
        private List<ISharedObjectEvent> _syncEvents = new List<ISharedObjectEvent>();
#else
        private ArrayList _syncEvents = new ArrayList();
#endif

        //Listeners (IEventListener)
        protected CopyOnWriteArray _listeners = new CopyOnWriteArray();
        /// <summary>
        /// Event listener, actually RTMP connection
        /// </summary>
		protected IEventListener _source = null;

		/// <summary>
        /// Initializes a new instance of the SharedObject class. This is used by the persistence framework.
		/// </summary>
		public SharedObject()
		{
			_ownerMessage = new SharedObjectMessage(null, null, -1, false);
            _persistentSO = false;
            _creationTime = System.Environment.TickCount;
		}
#if !(NET_1_1)
		/// <summary>
		/// Initializes a new instance of the SharedObject class.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="name"></param>
		/// <param name="path"></param>
		/// <param name="persistent"></param>
        public SharedObject(IDictionary<string, object> data, string name, string path, bool persistent)
		{
			base.SetAttributes(data);
			_name = name;
			_path = path;
			_persistentSO = persistent;
			_ownerMessage = new SharedObjectMessage(null, name, 0, persistent);
            _creationTime = System.Environment.TickCount;
		}
		/// <summary>
		/// Initializes a new instance of the SharedObject class.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="name"></param>
		/// <param name="path"></param>
		/// <param name="persistent"></param>
		/// <param name="storage"></param>
        public SharedObject(IDictionary<string, object> data, string name, string path, bool persistent, IPersistenceStore storage)
            : this(data, name, path, persistent)
        {
            this.Store = storage;
        }
#else
		/// <summary>
		/// Initializes a new instance of the SharedObject class.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="name"></param>
		/// <param name="path"></param>
		/// <param name="persistent"></param>
        public SharedObject(IDictionary data, string name, string path, bool persistent)
		{
			base.SetAttributes(data);
			_name = name;
			_path = path;
			_persistentSO = persistent;
			_ownerMessage = new SharedObjectMessage(null, name, 0, persistent);
            _creationTime = System.Environment.TickCount;
		}
		/// <summary>
		/// Initializes a new instance of the SharedObject class.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="name"></param>
		/// <param name="path"></param>
		/// <param name="persistent"></param>
		/// <param name="storage"></param>
        public SharedObject(IDictionary data, string name, string path, bool persistent, IPersistenceStore storage)
            : this(data, name, path, persistent)
        {
            this.Store = storage;
        }
#endif

        #region IPersistable Members

        public bool IsPersistent
		{
			get
			{
				return _persistent;
			}
			set
			{
				_persistent = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}

		public long LastModified
		{
			get
			{
				return _lastModified;
			}
			set
			{
				_lastModified = value;
			}
		}

		[Transient]
		public IPersistenceStore Store
		{
			get
			{
				return _storage;
			}
			set
			{
				_storage = value;
			}
		}

        public void Serialize(AMFWriter writer)
		{
            writer.WriteString(this.Name);
            writer.WriteString(this.Path);
            writer.WriteData(ObjectEncoding.AMF0, _attributes);
		}

        public void Deserialize(AMFReader reader)
		{
            _name = reader.ReadData() as string;
            _path = reader.ReadData() as string;
            _attributes.Clear();
#if !(NET_1_1)
            _attributes = new Dictionary<string, object>(reader.ReadData() as IDictionary<string, object>);
#else
            _attributes = new Hashtable(reader.ReadData() as IDictionary);
#endif
			_persistent = true; _persistentSO = true;
            _ownerMessage.SetName(_name);
            _ownerMessage.SetIsPersistent(true);

		}

		#endregion

		[Transient]
		internal int UpdateCounter
		{
			get{ return _updateCounter; }
		}

		public bool IsPersistentObject
		{
			get{ return _persistentSO; }
			set{ _persistentSO = value; }
		}

	
		[Transient]
		public string Type
		{
			get{ return TYPE; }
		}

        /// <summary>
        /// Send update notification over data channel of RTMP connection
        /// </summary>
		private void SendUpdates() 
		{
			if(_ownerMessage.Events.Count!=0) 
			{
				if(_source != null) 
				{
                    RtmpConnection connection = _source as RtmpConnection;
					// Only send updates when issued through RTMP request
                    RtmpChannel channel = connection.GetChannel((byte)3);

                    // Send update to "owner" of this update request
                    SharedObjectMessage syncOwner;
                    if (connection.ObjectEncoding == ObjectEncoding.AMF0)
                        syncOwner = new SharedObjectMessage(null, _name, _version, this.IsPersistentObject);
                    else
                        syncOwner = new FlexSharedObjectMessage(null, _name, _version, this.IsPersistentObject);
                    syncOwner.AddEvents(_ownerMessage.Events);

					if(channel != null) 
					{
						channel.Write(syncOwner);
					} 
					else 
					{
						log.Warn(__Res.GetString(__Res.Channel_NotFound));
					}
				}
				_ownerMessage.Events.Clear();
			}

			if(_syncEvents.Count!=0) 
			{
				// Synchronize updates with all registered clients of this shared
				foreach(IEventListener listener in _listeners) 
				{
					if(listener == _source) 
					{
						// Don't re-send update to active client
						continue;
					}
					if(!(listener is RtmpConnection))
					{
						log.Warn(__Res.GetString(__Res.SharedObject_SyncConnError));
						continue;
					}
					// Create a new sync message for every client to avoid
					// concurrent access through multiple threads
					// TODO: perhaps we could cache the generated message
                    RtmpConnection connection = listener as RtmpConnection;
                    SharedObjectMessage syncMessage;
                    if (connection.ObjectEncoding == ObjectEncoding.AMF0)
                        syncMessage = new SharedObjectMessage(null, _name, _version, this.IsPersistentObject);
                    else
                        syncMessage = new FlexSharedObjectMessage(null, _name, _version, this.IsPersistentObject);
					syncMessage.AddEvents(_syncEvents);

                    RtmpChannel channel = connection.GetChannel((byte)3);
					log.Debug(__Res.GetString(__Res.SharedObject_Sync, channel));
					channel.Write(syncMessage);
				}
				// Clear list of sync events
				_syncEvents.Clear();
			}
		}

		protected void NotifyModified() 
		{
			if(_updateCounter > 0) 
			{
				// Inside a BeginUpdate/EndUpdate block
				return;
			}

			if(_modified) 
			{
                _modified = false;
				// The client sent at least one update -> increase version of SO
				UpdateVersion();
				_lastModified = System.Environment.TickCount;
			}

			if(_modified && _storage != null) 
			{
				if(!_storage.Save(this)) 
					log.Error(__Res.GetString(__Res.SharedObject_StoreError));
			}
			SendUpdates();
		}

        /// <summary>
        /// Return an error message to the client.
        /// </summary>
        /// <param name="message">The error message.</param>
        internal void ReturnError(string message)
        {
            _ownerMessage.AddEvent(SharedObjectEventType.CLIENT_STATUS, message, "error");
        }
        /// <summary>
        /// Return an attribute value to the owner.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        internal void ReturnAttributeValue(string name)
        {
            _ownerMessage.AddEvent(SharedObjectEventType.CLIENT_UPDATE_DATA, name, GetAttribute(name));
        }

        public override object GetAttribute(string name, object value) 
		{
            if (name == null)
                return null;

            object result = base.GetAttribute(name, value);
            if (result == null)
            {
                // No previous value
                _modified = true;
                _ownerMessage.AddEvent(SharedObjectEventType.CLIENT_UPDATE_DATA, name, value);
                _syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_UPDATE_DATA, name, value));
                NotifyModified();
                result = value;
            }
            return result;
		}

		public override bool SetAttribute(string name, object value) 
		{
			_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_UPDATE_ATTRIBUTE, name, null);
            if (value == null && base.RemoveAttribute(name))
            {
                // Setting a null value removes the attribute
                _modified = true;
                _syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_DELETE_DATA, name, null));
                NotifyModified();
                return true;
            }
            else if (value != null && base.SetAttribute(name, value))
            {
                // only sync if the attribute changed
                _modified = true;
                _syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_UPDATE_DATA, name, value));
                NotifyModified();
                return true;
            }
            else
            {
                NotifyModified();
                return false;
            }
		}

#if !(NET_1_1)
        public override void SetAttributes(IDictionary<string, object> values)
		{
			if (values == null) 
				return;

			BeginUpdate();
            try
            {
                foreach (KeyValuePair<string, object> entry in values)
                {
                    SetAttribute(entry.Key, entry.Value);
                }
            }
            finally
            {
                EndUpdate();
            }
		}
#else
        public override void SetAttributes(IDictionary values) 
		{
			if (values == null) 
				return;

			BeginUpdate();
            try
            {
                foreach (DictionaryEntry entry in values)
                {
                    SetAttribute(entry.Key as string, entry.Value);
                }
            }
            finally
            {
                EndUpdate();
            }
		}
#endif

        public override void SetAttributes(IAttributeStore values) 
		{
			if (values == null) 
				return;

			BeginUpdate();
            try
            {
                foreach (string name in values.GetAttributeNames())
                {
                    SetAttribute(name, values.GetAttribute(name));
                }
            }
            finally
            {
                EndUpdate();
            }
		}

        public override bool RemoveAttribute(string name) 
		{
			// Send confirmation to client
			_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_DELETE_DATA, name, null);
            if (base.RemoveAttribute(name))
            {
                _modified = true;
                _syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_DELETE_DATA, name, null));
                NotifyModified();
                return true;
            }
            else
            {
                NotifyModified();
                return false;
            }
		}

		public void SendMessage(string handler, IList arguments) 
		{
			_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_SEND_MESSAGE, handler, arguments);
			_syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_SEND_MESSAGE, handler, arguments));
            _modified = true;
            NotifyModified();
		}

		public int Version
		{
			get{ return _version; }
			set{ _version = value; }
		}

		private void UpdateVersion() 
		{
			_version += 1;
		}

        public override void RemoveAttributes() 
		{
			// TODO: there must be a direct way to clear the SO on the client side...
		    ICollection names = GetAttributeNames();
            foreach (string key in names)
            {
                _ownerMessage.AddEvent(SharedObjectEventType.CLIENT_DELETE_DATA, key, null);
                _syncEvents.Add(new SharedObjectEvent(SharedObjectEventType.CLIENT_DELETE_DATA, key, null));
            }
            // Clear data
		    base.RemoveAttributes();
            // Mark as modified
            _modified = true;
            // Broadcast 'modified' event
            NotifyModified();
		}

		public virtual void Register(IEventListener listener) 
		{
			_listeners.Add(listener);
			// prepare response for new client
			_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_INITIAL_DATA, null, null);
			if(!this.IsPersistentObject)
			{
				_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_CLEAR_DATA, null, null);
			}
            if (!this.IsEmpty)
			{
				_ownerMessage.AddEvent(new SharedObjectEvent(SharedObjectEventType.CLIENT_UPDATE_DATA, null, _attributes));
			}
			// we call notifyModified here to send response if we're not in a
			// beginUpdate block
			NotifyModified();
		}

        public virtual void Unregister(IEventListener listener) 
		{
			_listeners.Remove(listener);
            CheckRelease();
		}

        /// <summary>
        /// Check if shared object must be released.
        /// </summary>
        protected void CheckRelease()
        {
            if (!this.IsPersistentObject && _listeners.Count == 0)
            {
                log.Info(__Res.GetString(__Res.SharedObject_Delete, _name));
                if (_storage != null)
                {
                    if (!_storage.Remove(this))
                        log.Error(__Res.GetString(__Res.SharedObject_DeleteError));
                }
                Close();
            }
        }
    
		[Transient]
		public ICollection Listeners
		{
			get{ return _listeners == null ? null : new ReadOnlyList(_listeners); }
		}

		public void BeginUpdate() 
		{
			BeginUpdate(_source);
		}

		public void BeginUpdate(IEventListener listener) 
		{
			_source = listener;
			_updateCounter += 1;
		}

		public void EndUpdate() 
		{
			_updateCounter -= 1;
			if(_updateCounter == 0) 
			{
				NotifyModified();
				_source = null;
			}
		}

		/// <summary>
		/// Deletes all the attributes and sends a clear event to all listeners. The
		/// persistent data object is also removed from a persistent shared object.
		/// </summary>
		/// <returns></returns>
		public bool Clear() 
		{
            base.RemoveAttributes();
			// Send confirmation to client
			_ownerMessage.AddEvent(SharedObjectEventType.CLIENT_CLEAR_DATA, _name, null);
            NotifyModified();
            return true;
		}

		/// <summary>
		/// Detaches a reference from this shared object, this will destroy the
		/// reference immediately. This is useful when you don't want to proxy a
		/// shared object any longer.
		/// </summary>
		public virtual void Close() 
		{
			// clear collections
            base.RemoveAttributes();
			_listeners.Clear();
			_syncEvents.Clear();
            _ownerMessage.Events.Clear();
		}
	}
}
