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
    public partial class Customer
    {
        public Customer()
        {
            this.CustomerContacts = new HashSet<CustomerContact>();
            this.PatternImages = new HashSet<PatternImage>();
            this.CustomerBranches = new HashSet<CustomerBranch>();
            this.Documents = new HashSet<Document>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int CustomerTypeId { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<int> CustomerLevel { get; set; }
    
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual ICollection<PatternImage> PatternImages { get; set; }
        public virtual ICollection<CustomerBranch> CustomerBranches { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
    
}
