using System;
using System.Collections;

namespace FluorineFx.ServiceBrowser.Sql
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class SelectColumnCollection : CollectionBase
    {
        public SelectColumnCollection()
        {
        }

        public int Add(SelectColumn value)
        {
            return List.Add(value);
        }

        public int IndexOf(SelectColumn value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, SelectColumn value)
        {
            List.Insert(index, value);
        }

        public void Remove(SelectColumn value)
        {
            List.Remove(value);
        }

        public bool Contains(SelectColumn value)
        {
            return List.Contains(value);
        }

        public SelectColumn this[int index]
        {
            get
            {
                return List[index] as SelectColumn;
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
