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
    public partial class Warehouse
    {
        public Warehouse()
        {
            this.DocumentProductItems = new HashSet<DocumentProductItem>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DocumentProductItem> DocumentProductItems { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
    
}