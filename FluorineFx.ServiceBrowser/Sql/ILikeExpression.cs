using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ILikeExpression : IExpression
    {
        IExpression Pattern { get; set; }
        IExpression Escape { get; set; }
    }
}
