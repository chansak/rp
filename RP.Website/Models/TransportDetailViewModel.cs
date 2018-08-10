using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class TransportDetailViewModel
    {
        public TransportDetailViewModel()
        {
        }

        public TransportDetailViewModel(int buId)
        {
            Id = null;
            BuId = buId;
            FileNumber = string.Empty;
            CustomerFirstName = string.Empty;
            CustomerLastName = string.Empty;
            CustomerPhone = string.Empty;
            Remarks = string.Empty;
            VehicleLicensePlate = string.Empty;
            VehicleTypeId = 2; // Default is Car.
            VehicleDimensionId = 2;
            VehicleBrand = string.Empty;
            VehicleModel = string.Empty;
            VehicleWidth = decimal.Zero;
            VehicleHeight = decimal.Zero;
            VehicleLength = decimal.Zero;
            VehicleWeight = decimal.Zero;
            VehicleKeyLocation = string.Empty;
            VehicleDocumentLocation = string.Empty;
            VehicleTransmission = string.Empty;
            VehicleConditionId = 0;
            PoliceReportLocation = string.Empty;
            OtherDocument = string.Empty;
            LuggageDescription = string.Empty;
            HasRoofBox = false;
            RoofBoxWidth = decimal.Zero;
            RoofBoxHeight = decimal.Zero;
            RoofBoxLength = decimal.Zero;
            RoofBoxWeight = decimal.Zero;
            RoofBoxKeyLocation = string.Empty;
            RoofBoxDescription = string.Empty;
            HasTrailer = false;
            TrailerWidth = decimal.Zero;
            TrailerHeight = decimal.Zero;
            TrailerLength = decimal.Zero;
            TrailerWeight = decimal.Zero;
            TrailerDescription = string.Empty;
            HasBikeRack = false;
            BikeRackWidth = decimal.Zero;
            BikeRackHeight = decimal.Zero;
            BikeRackLength = decimal.Zero;
            BikeRackWeight = decimal.Zero;
            BikeRackDescription = string.Empty;

            PickupGarageName = string.Empty;
            PickupAddress = string.Empty;
            PickupAddress2 = string.Empty;
            PickupZipCode = string.Empty;
            PickupCity = string.Empty;
            PickupProvince = string.Empty;
            PickupCountryId = 0;
            PickupState = string.Empty;
            PickupPhone = string.Empty;
            PickupOpeningHourWeekday = string.Empty;
            PickupOpeningHourSat = string.Empty;
            PickupOpeningHourSun = string.Empty;
            PickupStorageCost = decimal.Zero;
            PickupTowingCost = decimal.Zero;
            PickupRepairCost = decimal.Zero;
            PickupOtherCost = decimal.Zero;



            DeliveryGarageName = string.Empty;
            DeliveryAddress = string.Empty;
            DeliveryCity = string.Empty;
            DeliveryProvince = string.Empty;
            DeliveryState = string.Empty;
            DeliveryCountryId = 0;
            DeliveryZipCode = string.Empty;
            DeliveryPhone = string.Empty;
            DeliveryOpeningHourWeekday = string.Empty;
            DeliveryClosingHourWeekday = string.Empty;
            DeliveryOpeningHourSat = string.Empty;
            DeliveryOpeningHourSun = string.Empty;

            Distance = decimal.Zero;
            TcoDistance = decimal.Zero;
            RefCost = decimal.Zero;
            RefTco = decimal.Zero;
            RefHandicap = decimal.Zero;
            RefCurrencyRate = decimal.Zero;
            CreatedDate = DateTime.MinValue;
            LastUpdatedDate = DateTime.MinValue;
            PickupStorageStartDateString = string.Empty;
            ExpenditureId = string.Empty;
        }

        public int? Id { get; set; }
        public int BuId { get; set; }
        public string FileNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public bool IsBidding { get; set; }
        public string ExpirationDate { get; set; }
        public string ExpirationDateTimeString { get; set; }
        public int ExpirationHour { get; set; }
        public bool IsExpressDelivery { get; set; }
        public string Remarks { get; set; }
        public string VehicleLicensePlate { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public int? VehicleTypeId { get; set; }
        public int VehicleDimensionId { get; set; }
        public decimal? VehicleWidth { get; set; }
        public decimal? VehicleLength { get; set; }
        public decimal? VehicleHeight { get; set; }
        public decimal? VehicleWeight { get; set; }
        public string VehicleKeyLocation { get; set; }
        public string VehicleDocumentLocation { get; set; }
        public string VehicleTransmission { get; set; }
        public int? VehicleConditionId { get; set; }
        public string PoliceReportLocation { get; set; }
        public string OtherDocument { get; set; }
        public bool? IsRollable { get; set; }
        public bool HasLuggage { get; set; }
        public string LuggageDescription { get; set; }
        public bool HasRoofBox { get; set; }
        public decimal? RoofBoxWidth { get; set; }
        public decimal? RoofBoxLength { get; set; }
        public decimal? RoofBoxHeight { get; set; }
        public decimal? RoofBoxWeight { get; set; }
        public string RoofBoxKeyLocation { get; set; }
        public string RoofBoxDescription { get; set; }
        public bool HasTrailer { get; set; }
        public decimal? TrailerWidth { get; set; }
        public decimal? TrailerLength { get; set; }
        public decimal? TrailerHeight { get; set; }
        public decimal? TrailerWeight { get; set; }
        public string TrailerDescription { get; set; }
        public bool HasBikeRack { get; set; }
        public decimal? BikeRackWidth { get; set; }
        public decimal? BikeRackLength { get; set; }
        public decimal? BikeRackHeight { get; set; }
        public decimal? BikeRackWeight { get; set; }
        public string BikeRackDescription { get; set; }
        public string PickupGarageName { get; set; }
        public string PickupAddress { get; set; }
        public string PickupAddress2 { get; set; }
        public string PickupZipCode { get; set; }
        public string PickupCity { get; set; }
        public string PickupProvince { get; set; }
        public string PickupState { get; set; }
        public int? PickupCountryId { get; set; }
        public Nullable<decimal> PickupLatitude { get; set; }
        public Nullable<decimal> PickupLongitude { get; set; }
        public string PickupPhone { get; set; }
        public string PickupOpeningHourWeekday { get; set; }
        public string PickupOpeningHourSat { get; set; }
        public string PickupOpeningHourSun { get; set; }
        public Nullable<decimal> PickupStorageCost { get; set; }
        public Nullable<System.DateTime> PickupStorageStartDate { get; set; }
        public Nullable<decimal> PickupTowingCost { get; set; }
        public Nullable<decimal> PickupRepairCost { get; set; }
        public Nullable<decimal> PickupOtherCost { get; set; }

        public string PaymentType { get; set; }
        public string WayPoints { get; set; }

        public bool IsDifferentOrigin { get; set; }
        public string OriginCity { get; set; }
        public string OriginCountry { get; set; }
        public string OriginSupplierName { get; set; }
        public string DeliveryGarageName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryProvince { get; set; }
        public string DeliveryState { get; set; }
        public int? DeliveryCountryId { get; set; }
        public Nullable<decimal> DeliveryLatitude { get; set; }
        public Nullable<decimal> DeliveryLongitude { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryOpeningHourWeekday { get; set; }
        public string DeliveryClosingHourWeekday { get; set; }
        public string DeliveryOpeningHourSat { get; set; }
        public string DeliveryOpeningHourSun { get; set; }
        public decimal? Distance { get; set; }
        public decimal? TcoDistance { get; set; }
        public decimal? RefCost { get; set; }
        public int? RefDeliveryTime { get; set; }
        public decimal? RefTco { get; set; }
        public int? RefCurrencyId { get; set; }
        public decimal? RefHandicap { get; set; }
        public Nullable<System.DateTime> ExpirationDateTime { get; set; } // Hidden Field
        public Nullable<System.DateTime> EstimateDateArrival { get; set; } // Hidden Field
        public Nullable<System.DateTime> DefaultEstimateDateArrival { get; set; } // TextBox Calendar Field
        public Nullable<System.DateTime> RealDateArrival { get; set; }
        public Nullable<int> TransportStatusId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public decimal? RefCurrencyRate { get; set; }
        public string VehicleType { get; set; }
        public string VehicleCondition { get; set; }
        public string PickupCountry { get; set; }
        public string DeliveryCountry { get; set; }

        public string PickupStorageStartDateString { get; set; }
        public string DateArrival { get; set; }
        public string ExpenditureId { get; set; }

        public int ExpressDeliveryTime { get; set; }
    }
}