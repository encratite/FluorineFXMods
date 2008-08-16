using System;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class TerminalExpression : IExpression, ITerminalExpression
    {
        protected object _value;

        #region ITerminalExpression Members

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        #endregion

        #region IExpression Members

        public virtual string Name
        {
            get
            {
                if( _value != null )
                    return _value.ToString();
                return null;
            }
            set
            {
                //NA
            }
        }

        #endregion
    }
}
