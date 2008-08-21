using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public interface ITwoPartExpression : IExpression
    {
        IExpression Lhs { get;set;}
        IExpression Rhs { get;set;}
        SqlOperator Operator { get;set;}
        bool Not { get;set;}
    }
}
