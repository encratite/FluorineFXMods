using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class SetCombinationExpression : QueryExpression, ISetCombinationExpression
    {
        protected CombineOperation _operation = CombineOperation.Union;
        protected IQueryExpression _expression1;
        protected IQueryExpression _expression2;
        protected bool _all = false;
        protected bool _corresponding = false;

        #region ISetCombinationExpression Members

        public CombineOperation Operator
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
            }
        }

        public bool All
        {
            get
            {
                return _all;
            }
            set
            {
                _all = value;
            }
        }

        public bool Corresponding
        {
            get
            {
                return _corresponding;
            }
            set
            {
                _corresponding = value;
            }
        }

        public IQueryExpression Expression1
        {
            get
            {
                return _expression1;
            }
            set
            {
                _expression1 = value;
            }
        }

        public IQueryExpression Expression2
        {
            get
            {
                return _expression2;
            }
            set
            {
                _expression2 = value;
            }
        }

        #endregion

        #region IQueryExpression Members

        public override SqlTableCollection Tables
        {
            get
            {
                if (_tables == null)
                {
                    _tables = new SqlTableCollection();
                    if (_expression1 != null && _expression1.Tables != null)
                    {
                        _tables.AddRange(_expression1.Tables);
                    }
                    if (_expression2 != null && _expression2.Tables != null)
                    {
                        _tables.AddRange(_expression2.Tables);
                    }
                }
                return _tables;
            }
        }

        public override string PrepareSql(DBMS convertTo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
