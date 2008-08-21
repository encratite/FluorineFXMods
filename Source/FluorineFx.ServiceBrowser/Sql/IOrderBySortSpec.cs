using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public enum SortKind
    {
        None = 0,
        Ascending = 1,
        Descending = 2
    }

    public interface IOrderBySortSpec
    {
        string SortKey { get;set;}
        SortKind SortKind { get; set;}
    }
}
