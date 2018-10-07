using RP.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class ListViewModel<T> where T : class
    {
        public string SearchBy { get; set; }
        public string Keyword { get; set; }
        public string PageTitle { get; set; }
        public string SortBy { get; set; }
        public string Direction { get; set; }
        public PaginatedList<T> Data { get; set; }
    }
}