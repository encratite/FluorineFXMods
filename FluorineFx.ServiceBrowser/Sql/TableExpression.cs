using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class TableExpression : QueryExpression, ITableExpression
    {
        protected QueryExpressionCollection _from;
        protected IExpression _where;

        #region ITableExpression Members

        public QueryExpressionCollection From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        public void AddFromTableRef(IQueryExpression tableRef)
        {
            _from.Add(tableRef);
        }

        public IExpression Where
        {
            get
            {
                return _where;
            }
            set
            {
                _where = value;
            }
        }

        #endregion

        #region IQueryExpression Members

        public override SqlTableCollection Tables
        {
            get
            {
                if (_tables == null )
                {
                    _tables = new SqlTableCollection();
                    if (_from != null)
                    {
                        for (int i = 0; i < _from.Count; i++)
                        {
                            SqlTableCollection tmp = _from[i].Tables;
                            _tables.AddRange(tmp);
                        }
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
