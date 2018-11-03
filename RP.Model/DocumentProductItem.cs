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
    public partial class DocumentProductItem
    {
        public DocumentProductItem()
        {
            this.ProductItemAttachments = new HashSet<ProductItemAttachment>();
            this.ProductItemPrintOptionals = new HashSet<ProductItemPrintOptional>();
            this.ProductItemScreenOptionals = new HashSet<ProductItemScreenOptional>();
            this.ProductItemSewOptionals = new HashSet<ProductItemSewOptional>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> DocumentId { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public Nullable<System.Guid> ProductUnitId { get; set; }
        public int Amount { get; set; }
        public decimal PricePerUnit { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> DiscountPercentage { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.Guid> FromWarehouseId { get; set; }
        public Nullable<System.Guid> ProductOptionId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<ProductItemAttachment> ProductItemAttachments { get; set; }
        public virtual ICollection<ProductItemPrintOptional> ProductItemPrintOptionals { get; set; }
        public virtual ICollection<ProductItemScreenOptional> ProductItemScreenOptionals { get; set; }
        public virtual ICollection<ProductItemSewOptional> ProductItemSewOptionals { get; set; }
        public virtual Document Document { get; set; }
    }
    
}
