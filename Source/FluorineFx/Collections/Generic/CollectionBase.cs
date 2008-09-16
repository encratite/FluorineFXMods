using System;
using System.Collections;
using System.Collections.Generic;

#if !(NET_1_1)

namespace FluorineFx.Collections.Generic
{
    public class CollectionBase<T> :
        IList<T>, IList,
        ICollection<T>, ICollection,
        IEnumerable<T>, IEnumerable
    {

        private List<T> _innerList;

        public CollectionBase() : this(10) { }

        public CollectionBase(int initialCapacity)
        {
            _innerList = new List<T>(initialCapacity);
        }

        public virtual void Clear()
        {
            if (!this.OnClear()) { return; }
            this._innerList.Clear();
            this.OnClearComplete();
        }

        #region Notification Events
        protected virtual bool OnClear()
        {
            return true;
        }

        protected virtual void OnClearComplete()
        {
        }

        protected virtual bool OnInsert(int index, T value)
        {
            return true;
        }

        protected virtual void OnInsertComplete(
            int index, T value)
        {
        }

        protected virtual bool OnRemove(
            int index, T value)
        {

            return true;
        }

        protected virtual void OnRemoveComplete(
            int index, T value)
        {
        }

        protected virtual bool OnSet(
            int index, T oldValue, T value)
        {

            return true;
        }

        protected virtual void OnSetComplete(
            int index, T oldValue, T value)
        {
        }

        protected virtual bool OnValidate(T value)
        {
            return true;
        }
        #endregion

        #region IList<T> Members
        public virtual int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            if (!OnValidate(item)) return;
            if (!OnInsert(index, item)) return;
            _innerList.Insert(index, item);
            OnInsertComplete(index, item);
        }

        public virtual void RemoveAt(int index)
        {
            T value = _innerList[index];

            if (!OnValidate(value)) return;
            if (!OnRemove(index, value)) return;
            _innerList.RemoveAt(index);
            OnRemoveComplete(index, value);
        }

        public virtual T this[int index]
        {
            get
            {
                return _innerList[index];
            }

            set
            {
                T oldValue = _innerList[index];

                if (!OnValidate(value)) return;
                if (!OnSet(index, oldValue, value)) return;
                _innerList[index] = value;
                OnSetComplete(index, oldValue, value);
            }
        }
        #endregion

        #region ICollection<T> Members
        public virtual void Add(T item)
        {
            if (!OnValidate(item)) return;
            if (!OnInsert(_innerList.Count, item)) return;
            _innerList.Add(item);
            OnInsertComplete(_innerList.Count - 1, item);
        }

        public virtual bool Contains(T item)
        {
            return _innerList.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }
        public virtual int Count
        {
            get { return _innerList.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return ((ICollection<T>)_innerList).IsReadOnly; }
        }

        public virtual bool Remove(T item)
        {
            int index = _innerList.IndexOf(item);

            if (index < 0) return false;

            if (!OnValidate(item)) return false;
            if (!OnRemove(index, item)) return false;
            _innerList.Remove(item);
            OnRemoveComplete(index, item);
            return true;
        }
        #endregion

        #region IEnumerable<T> Members
        public virtual IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
        #endregion

        #region IList Members
        public virtual int Add(object value)
        {
            int index = _innerList.Count;

            if (!OnValidate((T)value)) return -1;
            if (!OnInsert(index, (T)value)) return -1;

            index = ((IList)_innerList).Add(value);
            OnInsertComplete(index, (T)value);
            return index;
        }

        public virtual bool Contains(object value)
        {
            return ((IList)_innerList).Contains(value);
        }

        public virtual int IndexOf(object value)
        {
            return ((IList)_innerList).IndexOf(value);
        }

        public virtual void Insert(int index, object value)
        {
            if (!OnValidate((T)value)) return;
            if (!OnInsert(index, (T)value)) return;
            ((IList)_innerList).Insert(index, value);
            OnInsertComplete(index, (T)value);
        }

        public virtual bool IsFixedSize
        {
            get { return ((IList)_innerList).IsFixedSize; }
        }

        public virtual void Remove(object value)
        {
            int index = _innerList.IndexOf((T)value);

            if (index < 0) return;

            if (!OnValidate((T)value)) return;
            if (!OnRemove(index, (T)value)) return;
            ((IList)_innerList).Remove(value);
            OnRemoveComplete(index, (T)value);
        }

        object IList.this[int index]
        {
            get
            {
                return _innerList[index];
            }

            set
            {
                T oldValue = _innerList[index];
                if (!OnValidate((T)value)) return;
                if (!OnSet(index, oldValue, (T)value)) return;
                _innerList[index] = (T)value;
                OnSetComplete(index, oldValue, (T)value);
            }
        }
        #endregion

        #region ICollection Members
        public virtual void CopyTo(Array array, int index)
        {
            ((ICollection)_innerList).CopyTo(array, index);
        }
        public virtual bool IsSynchronized
        {
            get { return ((ICollection)_innerList).IsSynchronized; }
        }

        public virtual object SyncRoot
        {
            get { return ((ICollection)_innerList).SyncRoot; }
        }
        #endregion

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_innerList).GetEnumerator();
        }
        #endregion
    }
}

#endif
