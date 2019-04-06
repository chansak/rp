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
        public string DocumentCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string SaleUserName { get; set; }
        public int WorkflowStatus { get; set; }
        public string WorkflowStatusName { get; set; }
        public int BiddingStatus { get; set; }
        public string BiddingStatusName { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
        public int NumberOfComments { get; set; }
    }
}