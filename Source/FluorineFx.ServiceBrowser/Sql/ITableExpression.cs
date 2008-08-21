using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ITableExpression : IQueryExpression
    {
        QueryExpressionCollection From { get; set; }
        void AddFromTableRef(IQueryExpression tableRef);
        IExpression Where { get;set;}
    }
}
