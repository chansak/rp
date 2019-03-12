using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class GeneralAndSaleInfoViewModel : BaseDocumentViewModel
    {
        public string DocumentCode { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string SaleUserId { get; set; }
    }
}