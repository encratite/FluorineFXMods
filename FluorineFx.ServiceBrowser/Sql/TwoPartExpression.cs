using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class TwoPartExpression : Expression, ITwoPartExpression
    {
        protected SqlOperator _operator = SqlOperator.Unknown;
        protected IExpression _lhs;
        protected IExpression _rhs;
        protected bool _not = false;

        #region ITwoPartExpression Members

        public IExpression Lhs
        {
            get
            {
                return _lhs;
            }
            set
            {
                _lhs = value;
            }
        }

        public IExpression Rhs
        {
            get
            {
                return _rhs;
            }
            set
            {
                _rhs = value;
            }
        }

        public SqlOperator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
            }
        }

        public bool Not
        {
            get
            {
                return _not;
            }
            set
            {
                _not = value;
            }
        }

        #endregion
    }
}
