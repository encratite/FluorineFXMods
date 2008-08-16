using System;
using System.Text;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class NullExpression : Expression, INullExpression
    {
        protected bool _not;

        #region INullExpression Members

        public bool Not
        {
            get
            {
                return _not;
            }
            set
            {
                _not = value;
            }
        }

        #endregion

        #region IExpression Members

        public override string Name
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("IS ");
                if (_not)
                    sb.Append("NOT ");
                sb.Append("NULL");
                return sb.ToString();
            }
            set
            {
                //NA;
            }
        }

        #endregion
    }
}
