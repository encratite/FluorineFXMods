using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class SelectColumn
    {
        string _name;

        public string Name
        {
            get 
            {
                if (_expression != null)
                {
                    return _expression.Name;
                }
                return _name; 
            }
            set { _name = value; }
        }
        string _alias;

        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }
        IExpression _expression;

        public IExpression Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }
    }
}
