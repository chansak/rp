using System.Collections.Generic;

namespace RP.Website.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public PricePerUnit PricePerUnit { get; set; }
        public List<ProductImageViewModel> Images { get; set; }
    }
}