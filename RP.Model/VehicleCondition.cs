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
    public partial class VehicleCondition
    {
        public VehicleCondition()
        {
            this.TransportVehicles = new HashSet<TransportVehicle>();
            this.TransportVehicleDrafts = new HashSet<TransportVehicleDraft>();
            this.UnityVehicleMappings = new HashSet<UnityVehicleMapping>();
        }
    
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<TransportVehicle> TransportVehicles { get; set; }
        public virtual ICollection<TransportVehicleDraft> TransportVehicleDrafts { get; set; }
        public virtual ICollection<UnityVehicleMapping> UnityVehicleMappings { get; set; }
    }
    
}
