using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class QueryExpression : IQueryExpression
    {
        protected SqlTableCollection _tables;

        #region IQueryExpression Members

        public virtual SqlTableCollection Tables
        {
            get { return _tables; }
        }

        public virtual string PrepareSql(DBMS convertTo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
