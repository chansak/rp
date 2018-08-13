using System;

namespace RP.Website.Models
{
    public class QuotationDeliveryViewModel
    {
        public string Id { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string DeliveryAddress { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public ContactViewModel DeliveryContact { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}