using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class SelectStatement : SqlStatement, ISelectStatement
    {
        protected IQueryExpression _queryExpression;
        protected SortSpecCollection _sortSpecs = new SortSpecCollection();

        #region ISelectStatement Members

        public IQueryExpression QueryExpression
        {
            get
            {
                return _queryExpression;
            }
            set
            {
                _queryExpression = value;
            }
        }

        public void AddSortSpec(IOrderBySortSpec sortSpec)
        {
            _sortSpecs.Add(sortSpec);
        }

        public SortSpecCollection SortSpecifications
        {
            get { return _sortSpecs; }
        }

        #endregion

        #region ISqlStatement Members

        public override SqlTableCollection Tables 
        {
            get
            {
                if (_queryExpression != null)
                    return _queryExpression.Tables;
                return null;
            }
        }

        public override string GetStatement()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
