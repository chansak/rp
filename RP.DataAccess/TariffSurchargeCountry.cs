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
    
    public partial class TariffSurchargeCountry
    {
        public int Id { get; set; }
        public int TariffSurchargeId { get; set; }
        public int CountryId { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual TariffSurcharge TariffSurcharge { get; set; }
    }
}
