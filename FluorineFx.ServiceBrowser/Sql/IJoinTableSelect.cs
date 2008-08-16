using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface IJoinTableSelect : IQueryExpression
    {
        string TableName { get; set; }
    }
}
