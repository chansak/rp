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
    public partial class DocumentDelivery
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> DocumentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<System.Guid> TransportationTypeId { get; set; }
        public Nullable<System.Guid> ConditionId { get; set; }
    
        public virtual TransportationType TransportationType { get; set; }
        public virtual Document Document { get; set; }
    }
    
}
