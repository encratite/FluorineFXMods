using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ISetCombinationExpression : IQueryExpression
    {
        CombineOperation Operator { get; set; }
        bool All { get; set; }
        bool Corresponding { get; set; }
        IQueryExpression Expression1 { get; set; }
        IQueryExpression Expression2 { get; set; }
    }
}
