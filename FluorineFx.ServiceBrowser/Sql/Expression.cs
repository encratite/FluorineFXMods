using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class Expression : IExpression
    {
        protected string _name;

        #region IExpression Members

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }
}
