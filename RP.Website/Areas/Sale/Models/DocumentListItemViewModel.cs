using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class DocumentListItemViewModel
    {
        public string Id { get; set; }
        public int Priority { get; set; }
        public DateTime IssueDate { get; set; }
        public string DocumentCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public int DocumentStatusName { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}