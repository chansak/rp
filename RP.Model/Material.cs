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
    public partial class Material
    {
        public Material()
        {
            this.Stocks = new HashSet<Stock>();
            this.ProductMaterialUsages = new HashSet<ProductMaterialUsage>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<System.Guid> MaterialTypeId { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<ProductMaterialUsage> ProductMaterialUsages { get; set; }
    }
    
}
