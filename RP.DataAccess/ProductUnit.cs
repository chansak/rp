//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RP.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductUnit()
        {
            this.ProductPrices = new HashSet<ProductPrice>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public Nullable<System.Guid> UnitId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Product Product { get; set; }
    }
}
