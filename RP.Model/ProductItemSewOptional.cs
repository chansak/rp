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
    public partial class ProductItemSewOptional
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProductItemId { get; set; }
        public string PatternImagePath { get; set; }
        public Nullable<System.Guid> PatternPositionId { get; set; }
        public string Remark { get; set; }
    
        public virtual DocumentProductItem DocumentProductItem { get; set; }
        public virtual PatternPosition PatternPosition { get; set; }
    }
    
}
