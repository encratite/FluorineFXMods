using System;
using System.IO;

namespace FluorineFx.ServiceBrowser.Sql
{
    class SqlParserService
    {
        public static ISqlScript Parse(string sql)
        {
            if (sql != null && sql != string.Empty)
            {
                SQLLexer lexer = new SQLLexer(new StringReader(sql));
                SQLParser parser = new SQLParser(lexer);
                SqlScript sqlScript = new SqlScript();
                parser.sql_script(sqlScript);
                return sqlScript;
            }
            else
                return null;
        }
    }
}
