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
    public partial class CurrencyRate
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal Rate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    
        public virtual Currency Currency { get; set; }
    }
    
}
