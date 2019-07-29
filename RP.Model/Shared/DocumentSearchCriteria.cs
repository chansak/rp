using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public class DocumentSearchCriteria
    {
        public string DocumentCode { get; set; }
        public int CustomerType { get; set; }
        public string CustomerName { get; set; }
        public int DocumentYear { get; set; }
        public string ContactName { get; set; }
        public string ProductCategoryId { get; set; }
        public decimal QuotedPrice { get; set; }
    }
}
