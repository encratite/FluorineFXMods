using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ISqlStatement
    {
        string GetStatement();
        SqlTableCollection Tables { get;}
    }
}
