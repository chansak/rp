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
    public partial class Color
    {
        public Color()
        {
            this.ProductItemScreenOptionals = new HashSet<ProductItemScreenOptional>();
        }
    
        public System.Guid Id { get; set; }
        public string ColorCode { get; set; }
    
        public virtual ICollection<ProductItemScreenOptional> ProductItemScreenOptionals { get; set; }
    }
    
}
