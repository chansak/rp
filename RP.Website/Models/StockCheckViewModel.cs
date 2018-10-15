using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class StockCheckViewModel
    {
        public string MaterialName { get; set; }
        public int MaterialInStock { get; set; }
        public int MaterialUsaged { get; set; }
        public int MaterialInStockAfterWithdraw { get; set; }
    }
}