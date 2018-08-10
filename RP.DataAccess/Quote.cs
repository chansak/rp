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
    
    public partial class Quote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quote()
        {
            this.QuoteHistories = new HashSet<QuoteHistory>();
            this.TransportQuoteDeclineReasons = new HashSet<TransportQuoteDeclineReason>();
            this.TransportQuotes = new HashSet<TransportQuote>();
        }
    
        public int Id { get; set; }
        public int TransportId { get; set; }
        public int SupplierId { get; set; }
        public decimal QuoteAmount { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }
        public int DeliveryDuration { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public bool IsRejected { get; set; }
        public Nullable<System.DateTime> RejectedDate { get; set; }
        public Nullable<System.DateTime> ExpectedPickUpDate { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Transport Transport { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteHistory> QuoteHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportQuoteDeclineReason> TransportQuoteDeclineReasons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportQuote> TransportQuotes { get; set; }
    }
}
