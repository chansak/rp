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
    public partial class RouteSupplier
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int SupplierId { get; set; }
    
        public virtual Route Route { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
    
}
