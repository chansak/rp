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
    public partial class Stock
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> WarehouseId { get; set; }
        public Nullable<System.Guid> MaterialId { get; set; }
        public Nullable<System.Guid> MaterialUnitId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual MaterialUnit MaterialUnit { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Material Material { get; set; }
    }
    
}
