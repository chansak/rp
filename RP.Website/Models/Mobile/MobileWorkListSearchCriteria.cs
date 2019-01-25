using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class MobileWorkListSearchCriteria
    {
        public string UserId { get; set; }
        public string SearchBy { get; set; }
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public string Direction { get; set; }
        public int Page { get; set; }
    }
}