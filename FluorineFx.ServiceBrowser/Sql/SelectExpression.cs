using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class SelectExpression : QueryExpression, ISelectExpression
    {
        protected ITableExpression _tableExpression;
        protected SelectColumnCollection _selectList;

        #region ISelectExpression Members

        public ITableExpression TableExpression
        {
            get
            {
                return _tableExpression;
            }
            set
            {
                _tableExpression = value;
            }
        }

        public SelectColumnCollection SelectList
        {
            get
            {
                return _selectList;
            }
            set
            {
                _selectList = value;
            }
        }

        #endregion

        #region IQueryExpression Members

        public override SqlTableCollection Tables
        {
            get
            {
                if (_tableExpression != null)
                    return _tableExpression.Tables;
                return null;
            }
        }

        public override string PrepareSql(DBMS convertTo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
