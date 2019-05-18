using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class DocumentViewModel
    {
        public string Id { get; set; }
        public string DocumentCode { get; set; }
        public string IssuedDate { get; set; }
        public string ExpirationDate { get; set; }
        public string ExpectedDeliveryDate { get; set; }

        public int ConfirmPriceDays { get; set; }
        public int DeliveryDays { get; set; }

        public string SaleUserId { get; set; }
        public string CustomerId { get; set; }
        public string ContactId { get; set; }
        public List<ProductItemViewModel> Items { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryContactId { get; set; }
        public string Remark { get; set; }
        //public string Comments { get; set; }
        public string CreatedDate { get; set; }
        public int DocumentStatusId { get; set; }
        public string PoNumber { get; set; }
        //public string CustomerBranchId { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDraft { get; set; }

        public string SaleName { get; set; }
        public string SaleCode { get; set; }
        public string SaleBranch { get; set; }

        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string HospitalName { get; set; }

        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactFax { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }

        //public List<HistoryViewModel> Histories { get; set; }
    }
}