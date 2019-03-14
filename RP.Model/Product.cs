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
    public partial class Product
    {
        public Product()
        {
            this.DocumentProductItems = new HashSet<DocumentProductItem>();
            this.ProductOptions = new HashSet<ProductOption>();
            this.ProductMaterialUsages = new HashSet<ProductMaterialUsage>();
            this.ProductPrices = new HashSet<ProductPrice>();
            this.ProductPreviewImages = new HashSet<ProductPreviewImage>();
        }
    
        public System.Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public System.Guid ProductCategoryId { get; set; }
    
        public virtual ICollection<DocumentProductItem> DocumentProductItems { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductMaterialUsage> ProductMaterialUsages { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<ProductPreviewImage> ProductPreviewImages { get; set; }
    }
    
}
