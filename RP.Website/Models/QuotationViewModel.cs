using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class QuotationViewModel
    {
        public string Id { get; set; }
        public string DocumentCode { get; set; }
        public DateTime QuotationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public List<ContactViewModel> Contacts { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public UserViewModel Sale { get; set; }
        public QuotationStatus QuotationStatus { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public WinOrLostStatus WinOrLostStatus { get; set; }
        public List<QuotationItemViewModel> Items { get; set; }
        public QuotationDeliveryViewModel Delivery { get; set; }
        public List<AttachFileViewModel> Files { get; set; }
    }
}