using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public abstract class SqlStatement : ISqlStatement
    {
        public abstract string GetStatement();

        public abstract SqlTableCollection Tables { get; }
    }
}
