//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RP.Model
{
    public partial class ProductUnit
    {
        public ProductUnit()
        {
            this.DocumentProducItems = new HashSet<DocumentProducItem>();
            this.ProductPrices = new HashSet<ProductPrice>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DocumentProducItem> DocumentProducItems { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
    
}
