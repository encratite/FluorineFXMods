using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    interface ISelectStatement : ISqlStatement
    {
        IQueryExpression QueryExpression { get; set; }
        void AddSortSpec(IOrderBySortSpec sortSpec);
        SortSpecCollection SortSpecifications { get; }
        //SelectSchema
    }
}
