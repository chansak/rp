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
    public partial class CustomerContact
    {
        public CustomerContact()
        {
            this.Documents = new HashSet<Document>();
            this.Documents1 = new HashSet<Document>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.Guid BranchId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerContactBranch CustomerContactBranch { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Document> Documents1 { get; set; }
    }
    
}
