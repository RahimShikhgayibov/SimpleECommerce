using System.Linq.Expressions;

namespace SimpleECommerce.Application.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.AndAlso(
            Expression.Invoke(left, parameter),
            Expression.Invoke(right, parameter)
        );
        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }
}