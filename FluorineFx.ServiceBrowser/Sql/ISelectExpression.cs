using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ISelectExpression : IQueryExpression
    {
        ITableExpression TableExpression { get;set;}
        SelectColumnCollection SelectList { get;set;}
    }
}
