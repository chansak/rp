

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RP.Interfaces;
using System.Data.Entity;

namespace RP.DataAccess
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private DbContext context;
        public EFUnitOfWork()
        {
            context = new RPContext();
        }

        public IUnitOfWork Create()
        {
            return new EFUnitOfWork();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {

        }

        public string ConnectionString
        {
            get;
            set;
        }

        public DateTime GetDBUtcDateTime()
        {
            return context.Database.SqlQuery<DateTime>("SELECT GETUTCDATE()").FirstOrDefault();
        }

		private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

		IBuEmailTypeRepository _BuEmailTypeRepository;
		public IBuEmailTypeRepository BuEmailTypeRepository
		{
			get
			{
				if (_BuEmailTypeRepository == null)
					_BuEmailTypeRepository = new BuEmailTypeRepository(context);
				
				return _BuEmailTypeRepository;
			}
		}
		IBUNotificationEmailRepository _BUNotificationEmailRepository;
		public IBUNotificationEmailRepository BUNotificationEmailRepository
		{
			get
			{
				if (_BUNotificationEmailRepository == null)
					_BUNotificationEmailRepository = new BUNotificationEmailRepository(context);
				
				return _BUNotificationEmailRepository;
			}
		}
		IBusinessUnitRepository _BusinessUnitRepository;
		public IBusinessUnitRepository BusinessUnitRepository
		{
			get
			{
				if (_BusinessUnitRepository == null)
					_BusinessUnitRepository = new BusinessUnitRepository(context);
				
				return _BusinessUnitRepository;
			}
		}
		IBuSupplierRepository _BuSupplierRepository;
		public IBuSupplierRepository BuSupplierRepository
		{
			get
			{
				if (_BuSupplierRepository == null)
					_BuSupplierRepository = new BuSupplierRepository(context);
				
				return _BuSupplierRepository;
			}
		}
		ICountryRepository _CountryRepository;
		public ICountryRepository CountryRepository
		{
			get
			{
				if (_CountryRepository == null)
					_CountryRepository = new CountryRepository(context);
				
				return _CountryRepository;
			}
		}
		ICurrencyRepository _CurrencyRepository;
		public ICurrencyRepository CurrencyRepository
		{
			get
			{
				if (_CurrencyRepository == null)
					_CurrencyRepository = new CurrencyRepository(context);
				
				return _CurrencyRepository;
			}
		}
		ICurrencyRateRepository _CurrencyRateRepository;
		public ICurrencyRateRepository CurrencyRateRepository
		{
			get
			{
				if (_CurrencyRateRepository == null)
					_CurrencyRateRepository = new CurrencyRateRepository(context);
				
				return _CurrencyRateRepository;
			}
		}
		IQuoteRepository _QuoteRepository;
		public IQuoteRepository QuoteRepository
		{
			get
			{
				if (_QuoteRepository == null)
					_QuoteRepository = new QuoteRepository(context);
				
				return _QuoteRepository;
			}
		}
		IQuoteHistoryRepository _QuoteHistoryRepository;
		public IQuoteHistoryRepository QuoteHistoryRepository
		{
			get
			{
				if (_QuoteHistoryRepository == null)
					_QuoteHistoryRepository = new QuoteHistoryRepository(context);
				
				return _QuoteHistoryRepository;
			}
		}
		IRoleRepository _RoleRepository;
		public IRoleRepository RoleRepository
		{
			get
			{
				if (_RoleRepository == null)
					_RoleRepository = new RoleRepository(context);
				
				return _RoleRepository;
			}
		}
		IRouteRepository _RouteRepository;
		public IRouteRepository RouteRepository
		{
			get
			{
				if (_RouteRepository == null)
					_RouteRepository = new RouteRepository(context);
				
				return _RouteRepository;
			}
		}
		IRouteSupplierRepository _RouteSupplierRepository;
		public IRouteSupplierRepository RouteSupplierRepository
		{
			get
			{
				if (_RouteSupplierRepository == null)
					_RouteSupplierRepository = new RouteSupplierRepository(context);
				
				return _RouteSupplierRepository;
			}
		}
		IRunningThreadRepository _RunningThreadRepository;
		public IRunningThreadRepository RunningThreadRepository
		{
			get
			{
				if (_RunningThreadRepository == null)
					_RunningThreadRepository = new RunningThreadRepository(context);
				
				return _RunningThreadRepository;
			}
		}
		ISupplierRepository _SupplierRepository;
		public ISupplierRepository SupplierRepository
		{
			get
			{
				if (_SupplierRepository == null)
					_SupplierRepository = new SupplierRepository(context);
				
				return _SupplierRepository;
			}
		}
		ISupplierEmailRepository _SupplierEmailRepository;
		public ISupplierEmailRepository SupplierEmailRepository
		{
			get
			{
				if (_SupplierEmailRepository == null)
					_SupplierEmailRepository = new SupplierEmailRepository(context);
				
				return _SupplierEmailRepository;
			}
		}
		ISupplierEmailTypeRepository _SupplierEmailTypeRepository;
		public ISupplierEmailTypeRepository SupplierEmailTypeRepository
		{
			get
			{
				if (_SupplierEmailTypeRepository == null)
					_SupplierEmailTypeRepository = new SupplierEmailTypeRepository(context);
				
				return _SupplierEmailTypeRepository;
			}
		}
		ISupplierNotificationRepository _SupplierNotificationRepository;
		public ISupplierNotificationRepository SupplierNotificationRepository
		{
			get
			{
				if (_SupplierNotificationRepository == null)
					_SupplierNotificationRepository = new SupplierNotificationRepository(context);
				
				return _SupplierNotificationRepository;
			}
		}
		ISupplierTypeRepository _SupplierTypeRepository;
		public ISupplierTypeRepository SupplierTypeRepository
		{
			get
			{
				if (_SupplierTypeRepository == null)
					_SupplierTypeRepository = new SupplierTypeRepository(context);
				
				return _SupplierTypeRepository;
			}
		}
		IsysdiagramRepository _sysdiagramRepository;
		public IsysdiagramRepository sysdiagramRepository
		{
			get
			{
				if (_sysdiagramRepository == null)
					_sysdiagramRepository = new sysdiagramRepository(context);
				
				return _sysdiagramRepository;
			}
		}
		ITariffRepository _TariffRepository;
		public ITariffRepository TariffRepository
		{
			get
			{
				if (_TariffRepository == null)
					_TariffRepository = new TariffRepository(context);
				
				return _TariffRepository;
			}
		}
		ITariffCategoryRepository _TariffCategoryRepository;
		public ITariffCategoryRepository TariffCategoryRepository
		{
			get
			{
				if (_TariffCategoryRepository == null)
					_TariffCategoryRepository = new TariffCategoryRepository(context);
				
				return _TariffCategoryRepository;
			}
		}
		ITariffCategoryVehicleDimensionRepository _TariffCategoryVehicleDimensionRepository;
		public ITariffCategoryVehicleDimensionRepository TariffCategoryVehicleDimensionRepository
		{
			get
			{
				if (_TariffCategoryVehicleDimensionRepository == null)
					_TariffCategoryVehicleDimensionRepository = new TariffCategoryVehicleDimensionRepository(context);
				
				return _TariffCategoryVehicleDimensionRepository;
			}
		}
		ITariffCategoryVehicleTypeRepository _TariffCategoryVehicleTypeRepository;
		public ITariffCategoryVehicleTypeRepository TariffCategoryVehicleTypeRepository
		{
			get
			{
				if (_TariffCategoryVehicleTypeRepository == null)
					_TariffCategoryVehicleTypeRepository = new TariffCategoryVehicleTypeRepository(context);
				
				return _TariffCategoryVehicleTypeRepository;
			}
		}
		ITariffExpressDeliveryRepository _TariffExpressDeliveryRepository;
		public ITariffExpressDeliveryRepository TariffExpressDeliveryRepository
		{
			get
			{
				if (_TariffExpressDeliveryRepository == null)
					_TariffExpressDeliveryRepository = new TariffExpressDeliveryRepository(context);
				
				return _TariffExpressDeliveryRepository;
			}
		}
		ITariffExpressDeliveryVehicleDimensionRepository _TariffExpressDeliveryVehicleDimensionRepository;
		public ITariffExpressDeliveryVehicleDimensionRepository TariffExpressDeliveryVehicleDimensionRepository
		{
			get
			{
				if (_TariffExpressDeliveryVehicleDimensionRepository == null)
					_TariffExpressDeliveryVehicleDimensionRepository = new TariffExpressDeliveryVehicleDimensionRepository(context);
				
				return _TariffExpressDeliveryVehicleDimensionRepository;
			}
		}
		ITariffMinimumKmRepository _TariffMinimumKmRepository;
		public ITariffMinimumKmRepository TariffMinimumKmRepository
		{
			get
			{
				if (_TariffMinimumKmRepository == null)
					_TariffMinimumKmRepository = new TariffMinimumKmRepository(context);
				
				return _TariffMinimumKmRepository;
			}
		}
		ITariffMinimumKmCountryRepository _TariffMinimumKmCountryRepository;
		public ITariffMinimumKmCountryRepository TariffMinimumKmCountryRepository
		{
			get
			{
				if (_TariffMinimumKmCountryRepository == null)
					_TariffMinimumKmCountryRepository = new TariffMinimumKmCountryRepository(context);
				
				return _TariffMinimumKmCountryRepository;
			}
		}
		ITariffSurchargeRepository _TariffSurchargeRepository;
		public ITariffSurchargeRepository TariffSurchargeRepository
		{
			get
			{
				if (_TariffSurchargeRepository == null)
					_TariffSurchargeRepository = new TariffSurchargeRepository(context);
				
				return _TariffSurchargeRepository;
			}
		}
		ITariffSurchargeCountryRepository _TariffSurchargeCountryRepository;
		public ITariffSurchargeCountryRepository TariffSurchargeCountryRepository
		{
			get
			{
				if (_TariffSurchargeCountryRepository == null)
					_TariffSurchargeCountryRepository = new TariffSurchargeCountryRepository(context);
				
				return _TariffSurchargeCountryRepository;
			}
		}
		ITemp_Supplier_ConfirmationRepository _Temp_Supplier_ConfirmationRepository;
		public ITemp_Supplier_ConfirmationRepository Temp_Supplier_ConfirmationRepository
		{
			get
			{
				if (_Temp_Supplier_ConfirmationRepository == null)
					_Temp_Supplier_ConfirmationRepository = new Temp_Supplier_ConfirmationRepository(context);
				
				return _Temp_Supplier_ConfirmationRepository;
			}
		}
		ITemp_TransportRepository _Temp_TransportRepository;
		public ITemp_TransportRepository Temp_TransportRepository
		{
			get
			{
				if (_Temp_TransportRepository == null)
					_Temp_TransportRepository = new Temp_TransportRepository(context);
				
				return _Temp_TransportRepository;
			}
		}
		ITimeZoneRepository _TimeZoneRepository;
		public ITimeZoneRepository TimeZoneRepository
		{
			get
			{
				if (_TimeZoneRepository == null)
					_TimeZoneRepository = new TimeZoneRepository(context);
				
				return _TimeZoneRepository;
			}
		}
		ITransportRepository _TransportRepository;
		public ITransportRepository TransportRepository
		{
			get
			{
				if (_TransportRepository == null)
					_TransportRepository = new TransportRepository(context);
				
				return _TransportRepository;
			}
		}
		ITransportAdditionalItemRepository _TransportAdditionalItemRepository;
		public ITransportAdditionalItemRepository TransportAdditionalItemRepository
		{
			get
			{
				if (_TransportAdditionalItemRepository == null)
					_TransportAdditionalItemRepository = new TransportAdditionalItemRepository(context);
				
				return _TransportAdditionalItemRepository;
			}
		}
		ITransportAdditionalItemDraftRepository _TransportAdditionalItemDraftRepository;
		public ITransportAdditionalItemDraftRepository TransportAdditionalItemDraftRepository
		{
			get
			{
				if (_TransportAdditionalItemDraftRepository == null)
					_TransportAdditionalItemDraftRepository = new TransportAdditionalItemDraftRepository(context);
				
				return _TransportAdditionalItemDraftRepository;
			}
		}
		ITransportAssignedToSupplierCountRepository _TransportAssignedToSupplierCountRepository;
		public ITransportAssignedToSupplierCountRepository TransportAssignedToSupplierCountRepository
		{
			get
			{
				if (_TransportAssignedToSupplierCountRepository == null)
					_TransportAssignedToSupplierCountRepository = new TransportAssignedToSupplierCountRepository(context);
				
				return _TransportAssignedToSupplierCountRepository;
			}
		}
		ITransportCommentRepository _TransportCommentRepository;
		public ITransportCommentRepository TransportCommentRepository
		{
			get
			{
				if (_TransportCommentRepository == null)
					_TransportCommentRepository = new TransportCommentRepository(context);
				
				return _TransportCommentRepository;
			}
		}
		ITransportCountRepository _TransportCountRepository;
		public ITransportCountRepository TransportCountRepository
		{
			get
			{
				if (_TransportCountRepository == null)
					_TransportCountRepository = new TransportCountRepository(context);
				
				return _TransportCountRepository;
			}
		}
		ITransportDraftRepository _TransportDraftRepository;
		public ITransportDraftRepository TransportDraftRepository
		{
			get
			{
				if (_TransportDraftRepository == null)
					_TransportDraftRepository = new TransportDraftRepository(context);
				
				return _TransportDraftRepository;
			}
		}
		ITransportFollowupRepository _TransportFollowupRepository;
		public ITransportFollowupRepository TransportFollowupRepository
		{
			get
			{
				if (_TransportFollowupRepository == null)
					_TransportFollowupRepository = new TransportFollowupRepository(context);
				
				return _TransportFollowupRepository;
			}
		}
		ITransportFollowupStateRepository _TransportFollowupStateRepository;
		public ITransportFollowupStateRepository TransportFollowupStateRepository
		{
			get
			{
				if (_TransportFollowupStateRepository == null)
					_TransportFollowupStateRepository = new TransportFollowupStateRepository(context);
				
				return _TransportFollowupStateRepository;
			}
		}
		ITransportHistoryRepository _TransportHistoryRepository;
		public ITransportHistoryRepository TransportHistoryRepository
		{
			get
			{
				if (_TransportHistoryRepository == null)
					_TransportHistoryRepository = new TransportHistoryRepository(context);
				
				return _TransportHistoryRepository;
			}
		}
		ITransportLocationRepository _TransportLocationRepository;
		public ITransportLocationRepository TransportLocationRepository
		{
			get
			{
				if (_TransportLocationRepository == null)
					_TransportLocationRepository = new TransportLocationRepository(context);
				
				return _TransportLocationRepository;
			}
		}
		ITransportLocationDraftRepository _TransportLocationDraftRepository;
		public ITransportLocationDraftRepository TransportLocationDraftRepository
		{
			get
			{
				if (_TransportLocationDraftRepository == null)
					_TransportLocationDraftRepository = new TransportLocationDraftRepository(context);
				
				return _TransportLocationDraftRepository;
			}
		}
		ITransportNotificationRepository _TransportNotificationRepository;
		public ITransportNotificationRepository TransportNotificationRepository
		{
			get
			{
				if (_TransportNotificationRepository == null)
					_TransportNotificationRepository = new TransportNotificationRepository(context);
				
				return _TransportNotificationRepository;
			}
		}
		ITransportQuoteRepository _TransportQuoteRepository;
		public ITransportQuoteRepository TransportQuoteRepository
		{
			get
			{
				if (_TransportQuoteRepository == null)
					_TransportQuoteRepository = new TransportQuoteRepository(context);
				
				return _TransportQuoteRepository;
			}
		}
		ITransportQuoteDeclineReasonRepository _TransportQuoteDeclineReasonRepository;
		public ITransportQuoteDeclineReasonRepository TransportQuoteDeclineReasonRepository
		{
			get
			{
				if (_TransportQuoteDeclineReasonRepository == null)
					_TransportQuoteDeclineReasonRepository = new TransportQuoteDeclineReasonRepository(context);
				
				return _TransportQuoteDeclineReasonRepository;
			}
		}
		ITransportQuoteDeclineTypeRepository _TransportQuoteDeclineTypeRepository;
		public ITransportQuoteDeclineTypeRepository TransportQuoteDeclineTypeRepository
		{
			get
			{
				if (_TransportQuoteDeclineTypeRepository == null)
					_TransportQuoteDeclineTypeRepository = new TransportQuoteDeclineTypeRepository(context);
				
				return _TransportQuoteDeclineTypeRepository;
			}
		}
		ITransportQuoteStatuRepository _TransportQuoteStatuRepository;
		public ITransportQuoteStatuRepository TransportQuoteStatuRepository
		{
			get
			{
				if (_TransportQuoteStatuRepository == null)
					_TransportQuoteStatuRepository = new TransportQuoteStatuRepository(context);
				
				return _TransportQuoteStatuRepository;
			}
		}
		ITransportReferenceRepository _TransportReferenceRepository;
		public ITransportReferenceRepository TransportReferenceRepository
		{
			get
			{
				if (_TransportReferenceRepository == null)
					_TransportReferenceRepository = new TransportReferenceRepository(context);
				
				return _TransportReferenceRepository;
			}
		}
		ITransportReferenceDraftRepository _TransportReferenceDraftRepository;
		public ITransportReferenceDraftRepository TransportReferenceDraftRepository
		{
			get
			{
				if (_TransportReferenceDraftRepository == null)
					_TransportReferenceDraftRepository = new TransportReferenceDraftRepository(context);
				
				return _TransportReferenceDraftRepository;
			}
		}
		ITransportStatuRepository _TransportStatuRepository;
		public ITransportStatuRepository TransportStatuRepository
		{
			get
			{
				if (_TransportStatuRepository == null)
					_TransportStatuRepository = new TransportStatuRepository(context);
				
				return _TransportStatuRepository;
			}
		}
		ITransportSupplierRepository _TransportSupplierRepository;
		public ITransportSupplierRepository TransportSupplierRepository
		{
			get
			{
				if (_TransportSupplierRepository == null)
					_TransportSupplierRepository = new TransportSupplierRepository(context);
				
				return _TransportSupplierRepository;
			}
		}
		ITransportVehicleRepository _TransportVehicleRepository;
		public ITransportVehicleRepository TransportVehicleRepository
		{
			get
			{
				if (_TransportVehicleRepository == null)
					_TransportVehicleRepository = new TransportVehicleRepository(context);
				
				return _TransportVehicleRepository;
			}
		}
		ITransportVehicleDraftRepository _TransportVehicleDraftRepository;
		public ITransportVehicleDraftRepository TransportVehicleDraftRepository
		{
			get
			{
				if (_TransportVehicleDraftRepository == null)
					_TransportVehicleDraftRepository = new TransportVehicleDraftRepository(context);
				
				return _TransportVehicleDraftRepository;
			}
		}
		IUnityVehicleMappingRepository _UnityVehicleMappingRepository;
		public IUnityVehicleMappingRepository UnityVehicleMappingRepository
		{
			get
			{
				if (_UnityVehicleMappingRepository == null)
					_UnityVehicleMappingRepository = new UnityVehicleMappingRepository(context);
				
				return _UnityVehicleMappingRepository;
			}
		}
		IUserRepository _UserRepository;
		public IUserRepository UserRepository
		{
			get
			{
				if (_UserRepository == null)
					_UserRepository = new UserRepository(context);
				
				return _UserRepository;
			}
		}
		IVehicleConditionRepository _VehicleConditionRepository;
		public IVehicleConditionRepository VehicleConditionRepository
		{
			get
			{
				if (_VehicleConditionRepository == null)
					_VehicleConditionRepository = new VehicleConditionRepository(context);
				
				return _VehicleConditionRepository;
			}
		}
		IVehicleDimensionRepository _VehicleDimensionRepository;
		public IVehicleDimensionRepository VehicleDimensionRepository
		{
			get
			{
				if (_VehicleDimensionRepository == null)
					_VehicleDimensionRepository = new VehicleDimensionRepository(context);
				
				return _VehicleDimensionRepository;
			}
		}
		IVehicleMakeRepository _VehicleMakeRepository;
		public IVehicleMakeRepository VehicleMakeRepository
		{
			get
			{
				if (_VehicleMakeRepository == null)
					_VehicleMakeRepository = new VehicleMakeRepository(context);
				
				return _VehicleMakeRepository;
			}
		}
		IVehicleModelRepository _VehicleModelRepository;
		public IVehicleModelRepository VehicleModelRepository
		{
			get
			{
				if (_VehicleModelRepository == null)
					_VehicleModelRepository = new VehicleModelRepository(context);
				
				return _VehicleModelRepository;
			}
		}
		IVehicleTypeRepository _VehicleTypeRepository;
		public IVehicleTypeRepository VehicleTypeRepository
		{
			get
			{
				if (_VehicleTypeRepository == null)
					_VehicleTypeRepository = new VehicleTypeRepository(context);
				
				return _VehicleTypeRepository;
			}
		}
	}
}


