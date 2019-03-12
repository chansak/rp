﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class ProductAndOptionViewModel : BaseDocumentViewModel
    {
        public string ItemId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUnitId { get; set; }
        public string ProductUnitName { get; set; }
        public int Amount { get; set; }
        public decimal PricePerUnit { get; set; }
        public PrintOptionViewModel PrintOption { get; set; }
        public ScreenOptionViewModel ScreenOption { get; set; }
        public SewOptionViewModel SewOption { get; set; }

        public string ProductCategoryId { get; set; }
        public string ProductOptionId { get; set; }

    }
}