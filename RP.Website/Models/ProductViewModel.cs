using System.Collections.Generic;

namespace RP.Website.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public string ProductCategoryName { get; set; }
        public string ProductCategoryId { get; set; }
    }
}