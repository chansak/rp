﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RP.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPContext : DbContext
    {
        public RPContext()
            : base("name=RPContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<DeliveryCondition> DeliveryConditions { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentAttachment> DocumentAttachments { get; set; }
        public virtual DbSet<DocumentDelivery> DocumentDeliveries { get; set; }
        public virtual DbSet<DocumentProductItem> DocumentProductItems { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<MaterialUnit> MaterialUnits { get; set; }
        public virtual DbSet<PatternPosition> PatternPositions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductItemAttachment> ProductItemAttachments { get; set; }
        public virtual DbSet<ProductItemPrintOptional> ProductItemPrintOptionals { get; set; }
        public virtual DbSet<ProductItemScreenOptional> ProductItemScreenOptionals { get; set; }
        public virtual DbSet<ProductItemSewOptional> ProductItemSewOptionals { get; set; }
        public virtual DbSet<ProductMaterialUsage> ProductMaterialUsages { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductUnit> ProductUnits { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<TransportationType> TransportationTypes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }
    }
}
