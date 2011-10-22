using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Avalon.Common
{
    public class PropertyOf<T>
    {
        public static string Resolve(Expression<Func<T, object>> expression )
        {
            Expression candidate = null;

            if (expression.Body is UnaryExpression)
                candidate = (expression.Body as UnaryExpression).Operand;

            if (expression.Body is MemberExpression)
                candidate = expression.Body;

            return (candidate as MemberExpression).Member.Name;
        }
    }
}
