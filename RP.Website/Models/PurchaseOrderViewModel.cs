using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class PurchaseOrderViewModel
    {
        public string DocumentId { get; set; }
        public string PoNumber { get; set; }
        public DateTime PoDate { get; set; }
    }
}