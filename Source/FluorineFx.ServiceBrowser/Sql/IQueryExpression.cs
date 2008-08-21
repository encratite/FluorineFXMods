using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface IQueryExpression
    {
        SqlTableCollection Tables { get;}
        string PrepareSql(DBMS convertTo);
    }
}
