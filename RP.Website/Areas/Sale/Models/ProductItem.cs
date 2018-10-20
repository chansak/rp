﻿namespace RP.Website.Models
{
    public class ProductItemViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUnitId { get; set; }
        public string ProductUnitName { get; set; }
        public int Amount { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}