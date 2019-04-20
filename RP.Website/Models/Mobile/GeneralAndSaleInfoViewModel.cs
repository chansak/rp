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

        public int ConfirmPriceDays { get; set; }
        public int DeliveryDays { get; set; }

        //วันที่สิ้นสุดการยืนราคา
        //public DateTime ExpirationDate { get; set; }
        //วันที่คาดว่าจะส่งสินค้า
        //public DateTime ExpectedDeliveryDate { get; set; }

        public string SaleUserId { get; set; }
    }
}