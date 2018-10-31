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
    
    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            this.DocumentAttachments = new HashSet<DocumentAttachment>();
            this.DocumentDeliveries = new HashSet<DocumentDelivery>();
            this.DocumentProductItems = new HashSet<DocumentProductItem>();
        }
    
        public System.Guid Id { get; set; }
        public string FileNumber { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public Nullable<System.Guid> ContactId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<int> DocumentStatusId { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.Guid> DeliveryContactId { get; set; }
        public Nullable<int> BiddingStatusId { get; set; }
        public Nullable<int> ConfirmedPriceDays { get; set; }
        public Nullable<int> DocumentType { get; set; }
        public string RefPriceAndRemark { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentAttachment> DocumentAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentDelivery> DocumentDeliveries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentProductItem> DocumentProductItems { get; set; }
    }
}
