using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class JoinTableSelect : QueryExpression, IJoinTableSelect
    {
        protected string _tableName;

        #region IJoinTableSelect Members

        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
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
                    SqlTable table = new SqlTable();
                    table.Name = _tableName;
                    _tables.Add(table);
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
