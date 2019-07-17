using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class ProductOptionViewModel
    {
        public string Id { get; set; }
        public string OptionName { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}