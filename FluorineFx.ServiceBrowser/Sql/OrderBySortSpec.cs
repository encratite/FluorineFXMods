using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class OrderBySortSpec : IOrderBySortSpec
    {
        string _sortKey;

        public string SortKey
        {
            get { return _sortKey; }
            set { _sortKey = value; }
        }
        SortKind _sortKind;

        public SortKind SortKind
        {
            get { return _sortKind; }
            set { _sortKind = value; }
        }
    }
}
