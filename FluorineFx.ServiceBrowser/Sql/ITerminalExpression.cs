using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ITerminalExpression : IExpression
    {
        object Value { get; set; }
    }
}
