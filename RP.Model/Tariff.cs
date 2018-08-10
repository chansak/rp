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
    public partial class Tariff
    {
        public Tariff()
        {
            this.TariffCategories = new HashSet<TariffCategory>();
            this.TariffExpressDeliveries = new HashSet<TariffExpressDelivery>();
            this.TariffMinimumKms = new HashSet<TariffMinimumKm>();
            this.TariffSurcharges = new HashSet<TariffSurcharge>();
        }
    
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int BuId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public decimal ExpressDeliveryPrice { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Penalty { get; set; }
    
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<TariffCategory> TariffCategories { get; set; }
        public virtual ICollection<TariffExpressDelivery> TariffExpressDeliveries { get; set; }
        public virtual ICollection<TariffMinimumKm> TariffMinimumKms { get; set; }
        public virtual ICollection<TariffSurcharge> TariffSurcharges { get; set; }
    }
    
}
