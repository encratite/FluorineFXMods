using System;
using System.Text;

namespace FluorineFx.ServiceBrowser.Sql
{
    public class LikeExpression : Expression, ILikeExpression
    {
        protected IExpression _pattern;
        protected IExpression _escape;

        #region ILikeExpression Members

        public IExpression Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                _pattern = value;
            }
        }

        public IExpression Escape
        {
            get
            {
                return _escape;
            }
            set
            {
                _escape = value;
            }
        }

        #endregion

        #region IExpression Members

        public override string Name
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("LIKE ");
                if (_pattern != null)
                    sb.Append(_pattern.Name);
                if (_escape != null)
                {
                    sb.Append(" ESCAPE ");
                    sb.Append(_escape.Name);
                }
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
