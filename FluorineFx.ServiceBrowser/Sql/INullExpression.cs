using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface INullExpression : IExpression
    {
        bool Not { get; set;}
    }
}
