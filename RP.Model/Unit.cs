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
    public partial class Unit
    {
        public Unit()
        {
            this.DocumentProductItems = new HashSet<DocumentProductItem>();
            this.ProductMaterialUsages = new HashSet<ProductMaterialUsage>();
            this.ProductUnits = new HashSet<ProductUnit>();
        }
    
        public System.Guid Id { get; set; }
        public string UnitName { get; set; }
    
        public virtual ICollection<DocumentProductItem> DocumentProductItems { get; set; }
        public virtual ICollection<ProductMaterialUsage> ProductMaterialUsages { get; set; }
        public virtual ICollection<ProductUnit> ProductUnits { get; set; }
    }
    
}
