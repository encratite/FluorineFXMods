using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class SqlTable
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
