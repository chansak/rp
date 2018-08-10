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
    
        public virtual DbSet<BuEmailType> BuEmailTypes { get; set; }
        public virtual DbSet<BUNotificationEmail> BUNotificationEmails { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<BuSupplier> BuSuppliers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteHistory> QuoteHistories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteSupplier> RouteSuppliers { get; set; }
        public virtual DbSet<RunningThread> RunningThreads { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierEmail> SupplierEmails { get; set; }
        public virtual DbSet<SupplierEmailType> SupplierEmailTypes { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffCategory> TariffCategories { get; set; }
        public virtual DbSet<TariffCategoryVehicleDimension> TariffCategoryVehicleDimensions { get; set; }
        public virtual DbSet<TariffCategoryVehicleType> TariffCategoryVehicleTypes { get; set; }
        public virtual DbSet<TariffExpressDelivery> TariffExpressDeliveries { get; set; }
        public virtual DbSet<TariffExpressDeliveryVehicleDimension> TariffExpressDeliveryVehicleDimensions { get; set; }
        public virtual DbSet<TariffMinimumKm> TariffMinimumKms { get; set; }
        public virtual DbSet<TariffMinimumKmCountry> TariffMinimumKmCountries { get; set; }
        public virtual DbSet<TariffSurcharge> TariffSurcharges { get; set; }
        public virtual DbSet<TariffSurchargeCountry> TariffSurchargeCountries { get; set; }
        public virtual DbSet<Temp_Supplier_Confirmation> Temp_Supplier_Confirmation { get; set; }
        public virtual DbSet<Temp_Transport> Temp_Transport { get; set; }
        public virtual DbSet<TimeZone> TimeZones { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TransportAdditionalItem> TransportAdditionalItems { get; set; }
        public virtual DbSet<TransportAdditionalItemDraft> TransportAdditionalItemDrafts { get; set; }
        public virtual DbSet<TransportAssignedToSupplierCount> TransportAssignedToSupplierCounts { get; set; }
        public virtual DbSet<TransportComment> TransportComments { get; set; }
        public virtual DbSet<TransportCount> TransportCounts { get; set; }
        public virtual DbSet<TransportDraft> TransportDrafts { get; set; }
        public virtual DbSet<TransportFollowup> TransportFollowups { get; set; }
        public virtual DbSet<TransportFollowupState> TransportFollowupStates { get; set; }
        public virtual DbSet<TransportHistory> TransportHistories { get; set; }
        public virtual DbSet<TransportLocation> TransportLocations { get; set; }
        public virtual DbSet<TransportLocationDraft> TransportLocationDrafts { get; set; }
        public virtual DbSet<TransportQuote> TransportQuotes { get; set; }
        public virtual DbSet<TransportQuoteDeclineReason> TransportQuoteDeclineReasons { get; set; }
        public virtual DbSet<TransportQuoteDeclineType> TransportQuoteDeclineTypes { get; set; }
        public virtual DbSet<TransportQuoteStatu> TransportQuoteStatus { get; set; }
        public virtual DbSet<TransportReference> TransportReferences { get; set; }
        public virtual DbSet<TransportReferenceDraft> TransportReferenceDrafts { get; set; }
        public virtual DbSet<TransportStatu> TransportStatus { get; set; }
        public virtual DbSet<TransportSupplier> TransportSuppliers { get; set; }
        public virtual DbSet<TransportVehicle> TransportVehicles { get; set; }
        public virtual DbSet<TransportVehicleDraft> TransportVehicleDrafts { get; set; }
        public virtual DbSet<UnityVehicleMapping> UnityVehicleMappings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VehicleCondition> VehicleConditions { get; set; }
        public virtual DbSet<VehicleDimension> VehicleDimensions { get; set; }
        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<SupplierNotification> SupplierNotifications { get; set; }
        public virtual DbSet<TransportNotification> TransportNotifications { get; set; }
    }
}
