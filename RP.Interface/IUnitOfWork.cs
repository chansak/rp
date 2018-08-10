
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RP.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
        void Rollback();
        string ConnectionString { get; set; }
        IUnitOfWork Create();
		DateTime GetDBUtcDateTime();
		IBuEmailTypeRepository BuEmailTypeRepository  { get; }
		IBUNotificationEmailRepository BUNotificationEmailRepository  { get; }
		IBusinessUnitRepository BusinessUnitRepository  { get; }
		IBuSupplierRepository BuSupplierRepository  { get; }
		ICountryRepository CountryRepository  { get; }
		ICurrencyRepository CurrencyRepository  { get; }
		ICurrencyRateRepository CurrencyRateRepository  { get; }
		IQuoteRepository QuoteRepository  { get; }
		IQuoteHistoryRepository QuoteHistoryRepository  { get; }
		IRoleRepository RoleRepository  { get; }
		IRouteRepository RouteRepository  { get; }
		IRouteSupplierRepository RouteSupplierRepository  { get; }
		IRunningThreadRepository RunningThreadRepository  { get; }
		ISupplierRepository SupplierRepository  { get; }
		ISupplierEmailRepository SupplierEmailRepository  { get; }
		ISupplierEmailTypeRepository SupplierEmailTypeRepository  { get; }
		ISupplierNotificationRepository SupplierNotificationRepository  { get; }
		ISupplierTypeRepository SupplierTypeRepository  { get; }
		IsysdiagramRepository sysdiagramRepository  { get; }
		ITariffRepository TariffRepository  { get; }
		ITariffCategoryRepository TariffCategoryRepository  { get; }
		ITariffCategoryVehicleDimensionRepository TariffCategoryVehicleDimensionRepository  { get; }
		ITariffCategoryVehicleTypeRepository TariffCategoryVehicleTypeRepository  { get; }
		ITariffExpressDeliveryRepository TariffExpressDeliveryRepository  { get; }
		ITariffExpressDeliveryVehicleDimensionRepository TariffExpressDeliveryVehicleDimensionRepository  { get; }
		ITariffMinimumKmRepository TariffMinimumKmRepository  { get; }
		ITariffMinimumKmCountryRepository TariffMinimumKmCountryRepository  { get; }
		ITariffSurchargeRepository TariffSurchargeRepository  { get; }
		ITariffSurchargeCountryRepository TariffSurchargeCountryRepository  { get; }
		ITemp_Supplier_ConfirmationRepository Temp_Supplier_ConfirmationRepository  { get; }
		ITemp_TransportRepository Temp_TransportRepository  { get; }
		ITimeZoneRepository TimeZoneRepository  { get; }
		ITransportRepository TransportRepository  { get; }
		ITransportAdditionalItemRepository TransportAdditionalItemRepository  { get; }
		ITransportAdditionalItemDraftRepository TransportAdditionalItemDraftRepository  { get; }
		ITransportAssignedToSupplierCountRepository TransportAssignedToSupplierCountRepository  { get; }
		ITransportCommentRepository TransportCommentRepository  { get; }
		ITransportCountRepository TransportCountRepository  { get; }
		ITransportDraftRepository TransportDraftRepository  { get; }
		ITransportFollowupRepository TransportFollowupRepository  { get; }
		ITransportFollowupStateRepository TransportFollowupStateRepository  { get; }
		ITransportHistoryRepository TransportHistoryRepository  { get; }
		ITransportLocationRepository TransportLocationRepository  { get; }
		ITransportLocationDraftRepository TransportLocationDraftRepository  { get; }
		ITransportNotificationRepository TransportNotificationRepository  { get; }
		ITransportQuoteRepository TransportQuoteRepository  { get; }
		ITransportQuoteDeclineReasonRepository TransportQuoteDeclineReasonRepository  { get; }
		ITransportQuoteDeclineTypeRepository TransportQuoteDeclineTypeRepository  { get; }
		ITransportQuoteStatuRepository TransportQuoteStatuRepository  { get; }
		ITransportReferenceRepository TransportReferenceRepository  { get; }
		ITransportReferenceDraftRepository TransportReferenceDraftRepository  { get; }
		ITransportStatuRepository TransportStatuRepository  { get; }
		ITransportSupplierRepository TransportSupplierRepository  { get; }
		ITransportVehicleRepository TransportVehicleRepository  { get; }
		ITransportVehicleDraftRepository TransportVehicleDraftRepository  { get; }
		IUnityVehicleMappingRepository UnityVehicleMappingRepository  { get; }
		IUserRepository UserRepository  { get; }
		IVehicleConditionRepository VehicleConditionRepository  { get; }
		IVehicleDimensionRepository VehicleDimensionRepository  { get; }
		IVehicleMakeRepository VehicleMakeRepository  { get; }
		IVehicleModelRepository VehicleModelRepository  { get; }
		IVehicleTypeRepository VehicleTypeRepository  { get; }

	}
}

