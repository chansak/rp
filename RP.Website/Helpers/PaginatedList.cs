using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RP.Website.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        #region Public Properties

        public const int DefaultPageSize = 10;

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public RouteValueDictionary RouteValues { get; set; }

        #endregion

        #region Constructor

        public PaginatedList(IList<T> source) : this(source, 0, DefaultPageSize) { }

        public PaginatedList(IList<T> source, int pageIndex) : this(source, pageIndex, DefaultPageSize) { }

        public PaginatedList(IList<T> source, int pageIndex, int pageSize) : this(source, pageIndex, pageSize, source.Count, false) { }

        public PaginatedList(IList<T> source, int pageIndex, int pageSize, int totalCount, bool isPaginated) : this(source, pageIndex, pageSize, totalCount, isPaginated, new RouteValueDictionary()) { }

        public PaginatedList(IList<T> source, int pageIndex, int pageSize, int totalCount, bool isPaginated, RouteValueDictionary routeValues)
        {
            PageSize = pageSize;
            TotalCount = totalCount;

            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            // Set page index
            if (pageIndex < 0)
                PageIndex = 0;
            else if (pageIndex >= TotalPages)
                PageIndex = TotalPages - 1;
            else
                PageIndex = pageIndex;

            if (isPaginated)
                this.AddRange(source);
            else
                this.AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));

            this.RouteValues = routeValues;
        }

        #endregion

        #region Public Methods

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }

        #endregion
    }
}