using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    class SqlScript : ISqlScript
    {
        protected SqlStatementCollection _statements;

        public SqlScript()
        {
            _statements = new SqlStatementCollection();
        }

        #region ISqlScript Members

        public void AddStatement(ISqlStatement statement)
        {
            _statements.Add(statement);
        }

        public SqlStatementCollection Statements
        {
            get { return _statements; }
        }

        #endregion
    }
}
