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
#if SILVERLIGHT
using System.Collections.Generic;
#endif

//TODO This class should have a generic version for !(NET_1_1)

namespace FluorineFx.Util
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    abstract class ObjectPool : DisposableBase
    {
        private bool _forceGC = true;
        private int _growth = 10;
#if SILVERLIGHT
        private Queue<object> _queue;
#else
        private Queue _queue;
#endif

        static ObjectPool()
        {
        }

        protected ObjectPool()
        {
        }

        #region IDisposable Members

        protected override void Free()
        {
            lock ((_queue as ICollection).SyncRoot)
            {
                while (_queue.Count > 0)
                {
                    object obj = _queue.Dequeue();
                    try
                    {
                        if (obj is IDisposable)
                            (obj as IDisposable).Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            base.Free();
        }

        #endregion IDisposable Members

        protected void Initialize(int capacity)
        {
            if (!IsDisposed)
            {
#if SILVERLIGHT
                _queue = new Queue<object>(capacity);
#else
                _queue = new Queue(capacity);
#endif
                lock ((_queue as ICollection).SyncRoot)
                {
                    AddObjects(capacity);
                }
                if (_forceGC)
                    GC.WaitForPendingFinalizers();
            }
        }

        protected void Initialize(int capacity, int growth)
        {
            if (!IsDisposed)
            {
                _growth = growth;
                Initialize(capacity);
            }
        }

        protected void Initialize(int capacity, int growth, bool forceGCOnGrowth)
        {
            if (!IsDisposed)
            {
                _forceGC = forceGCOnGrowth;
                Initialize(capacity, growth);
            }
        }

        private void AddObjects(int count)
        {
            if (!IsDisposed)
            {
                if (_forceGC)
                    GC.Collect();
                for (int i = 1; i <= count; i++)
                {
                    object obj = this.GetObject();
                    _queue.Enqueue(obj);
                }
                if (_forceGC)
                    GC.Collect();
            }
        }

        protected void CheckIn(object obj)
        {
            if (!IsDisposed)
            {
                lock ((_queue as ICollection).SyncRoot)
                {
                    _queue.Enqueue(obj);
                }
            }
        }

        protected object CheckOut()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("ObjectPool");

            object obj = null;
            lock ((_queue as ICollection).SyncRoot)
            {
                if (_queue.Count == 0)
                    this.AddObjects(_growth);
                obj = _queue.Dequeue();
            }
            if (_forceGC)
                GC.WaitForPendingFinalizers();
            return obj;
        }

        protected abstract object GetObject();

        protected int Length
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("ObjectPool");
                lock ((_queue as ICollection).SyncRoot)
                {
                    return _queue.Count;
                }
            }
        }

        public int Growth
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("ObjectPool");
                return _growth;
            }
        }

        protected object SyncRoot
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("ObjectPool");
                //return _queue.SyncRoot;
                return (_queue as ICollection).SyncRoot;
            }
        }
    }
}