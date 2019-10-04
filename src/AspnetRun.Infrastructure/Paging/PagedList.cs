using AspnetRun.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspnetRun.Infrastructure.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public PagedList(int pageIndex, int pageSize, int totalCount, int totalPages, IEnumerable<T> items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            Items = items;
        }

        public PagedList(IQueryable<T> query, PagingArgs pagingArgs,
            List<Tuple<SortingOption, Expression<Func<T, object>>>> orderByList = null,
            List<Tuple<FilteringOption, Expression<Func<T, bool>>>> filterList = null)
        {
            query = query.OrderBy(orderByList);
            query = query.Where(filterList);

            PageIndex = pagingArgs.PageIndex < 1 ? 1 : pagingArgs.PageIndex;
            PageSize = pagingArgs.PageSize < 1 ? 10 : pagingArgs.PageSize;

            TotalCount = 0;

            var items = pagingArgs.PagingStrategy == PagingStrategy.NoCount
                        ? query.Skip((PageIndex - 1) * PageSize).Take(PageSize + 1).ToList()
                        : (
                            (TotalCount = query.Count()) > 0
                            ? query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList()
                            : new List<T>()
                          );

            TotalCount = pagingArgs.PagingStrategy == PagingStrategy.NoCount
                ? (PageIndex - 1) * PageSize + items.Count
                : TotalCount;

            TotalPages = TotalCount / PageSize;

            if (TotalCount % PageSize > 0)
                TotalPages++;

            if (pagingArgs.PagingStrategy == PagingStrategy.NoCount && items.Count == PageSize + 1)
            {
                items.RemoveAt(PageSize);
            }

            Items = items;
        }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Has next page
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;

        /// <summary>
        /// Items
        /// </summary>
        public IEnumerable<T> Items { get; }
    }
}
