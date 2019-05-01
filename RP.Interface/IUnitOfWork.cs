
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
		IAspNetRoleRepository AspNetRoleRepository  { get; }
		IAspNetUserRepository AspNetUserRepository  { get; }
		IAspNetUserClaimRepository AspNetUserClaimRepository  { get; }
		IAspNetUserLoginRepository AspNetUserLoginRepository  { get; }
		IColorRepository ColorRepository  { get; }
		ICustomerRepository CustomerRepository  { get; }
		ICustomerAddressRepository CustomerAddressRepository  { get; }
		ICustomerBranchRepository CustomerBranchRepository  { get; }
		ICustomerContactRepository CustomerContactRepository  { get; }
		ICustomerContactBranchRepository CustomerContactBranchRepository  { get; }
		ICustomerTypeRepository CustomerTypeRepository  { get; }
		IDeliveryConditionRepository DeliveryConditionRepository  { get; }
		IDepartmentRepository DepartmentRepository  { get; }
		IDocumentRepository DocumentRepository  { get; }
		IDocumentAttachmentRepository DocumentAttachmentRepository  { get; }
		IDocumentDeliveryRepository DocumentDeliveryRepository  { get; }
		IDocumentProductItemRepository DocumentProductItemRepository  { get; }
		IHistoryRepository HistoryRepository  { get; }
		ILocationTrackingRepository LocationTrackingRepository  { get; }
		IMaterialRepository MaterialRepository  { get; }
		IMaterialTypeRepository MaterialTypeRepository  { get; }
		IMaterialUnitRepository MaterialUnitRepository  { get; }
		IPatternImageRepository PatternImageRepository  { get; }
		IPatternPositionRepository PatternPositionRepository  { get; }
		IProductRepository ProductRepository  { get; }
		IProductCategoryRepository ProductCategoryRepository  { get; }
		IProductItemAttachmentRepository ProductItemAttachmentRepository  { get; }
		IProductItemPrintOptionalRepository ProductItemPrintOptionalRepository  { get; }
		IProductItemScreenOptionalRepository ProductItemScreenOptionalRepository  { get; }
		IProductItemSewOptionalRepository ProductItemSewOptionalRepository  { get; }
		IProductMaterialUsageRepository ProductMaterialUsageRepository  { get; }
		IProductOptionRepository ProductOptionRepository  { get; }
		IProductPreviewImageRepository ProductPreviewImageRepository  { get; }
		IProductPriceRepository ProductPriceRepository  { get; }
		IProductUnitRepository ProductUnitRepository  { get; }
		IRegionRepository RegionRepository  { get; }
		IRoleRepository RoleRepository  { get; }
		IStockRepository StockRepository  { get; }
		ITransportationTypeRepository TransportationTypeRepository  { get; }
		IUnitRepository UnitRepository  { get; }
		IUserRepository UserRepository  { get; }
		IWarehouseRepository WarehouseRepository  { get; }

	}
}

