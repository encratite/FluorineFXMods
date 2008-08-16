using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public enum DBMS
    {
        Unknown = 0,
        MySql = 1,
        MSSqlServer = 2,
        SMSAccess = 3,
        Postgres = 4,
        Oracle = 5,
        Sybase = 6,
        DB2 = 7,
        CSV = 8
    };

    public enum SqlOperator
	{
		Unknown = 0,
		Equals = 1,
		NotEquals	= 2,
		LessThan = 3,
		GreaterThan = 4,
		LessThanOrEquals = 5,
		GreaterThanOrEquals = 6,
		BooleanTermOperator = 7, //OR
		BooleanFactorOperator = 8 //AND
	};

    public enum CombineOperation
	{
		Union	= 0,
		Except	= 1,
		Intersect = 2
	};

    public interface ISqlScript
    {
        void AddStatement(ISqlStatement statement);
        SqlStatementCollection Statements { get; }
    }
}
