using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ItmCode.Common.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> combined = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    left.Body,
                    new ExpressionParameterReplacer(right.Parameters, left.Parameters).Visit(right.Body)
                    ), left.Parameters);

            return combined;
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> combined = Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    left.Body,
                    new ExpressionParameterReplacer(right.Parameters, left.Parameters).Visit(right.Body)
                    ), left.Parameters);

            return combined;
        }

        private class ExpressionParameterReplacer : ExpressionVisitor
        {
            private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }

            public ExpressionParameterReplacer
            (IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
                ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();

                for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                { ParameterReplacements.Add(fromParameters[i], toParameters[i]); }
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;

                if (ParameterReplacements.TryGetValue(node, out replacement))
                { node = replacement; }

                return base.VisitParameter(node);
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}