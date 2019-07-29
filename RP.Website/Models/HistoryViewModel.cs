using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class HistoryViewModel
    {
        public string Id { get; set; }
        public string DocumentId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}