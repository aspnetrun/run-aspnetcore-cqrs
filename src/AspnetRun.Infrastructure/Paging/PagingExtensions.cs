using AspnetRun.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspnetRun.Infrastructure.Paging
{
    public static class PagingExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, List<Tuple<SortingOption, Expression<Func<T, object>>>> orderByList)
        {
            if (orderByList == null)
                return query;

            orderByList = orderByList.OrderBy(ob => ob.Item1.Priority).ToList();

            IOrderedQueryable<T> orderedQuery = null;
            foreach (var orderBy in orderByList)
            {
                if (orderedQuery == null)
                {
                    orderedQuery = orderBy.Item1.Direction == SortingOption.SortingDirection.ASC ? query.OrderBy(orderBy.Item2) : query.OrderByDescending(orderBy.Item2);
                }
                else
                {
                    orderedQuery = orderBy.Item1.Direction == SortingOption.SortingDirection.ASC ? orderedQuery.ThenBy(orderBy.Item2) : orderedQuery.ThenByDescending(orderBy.Item2);
                }
            }

            return orderedQuery ?? query;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, List<Tuple<FilteringOption, Expression<Func<T, bool>>>> filterList)
        {
            if (filterList == null)
                return query;

            foreach (var filter in filterList)
            {
                query = query.Where(filter.Item2);
            }

            return query;
        }
    }
}
