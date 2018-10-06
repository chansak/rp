
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
		IColorRepository ColorRepository  { get; }
		ICompanyRepository CompanyRepository  { get; }
		ICustomerRepository CustomerRepository  { get; }
		ICustomerAddressRepository CustomerAddressRepository  { get; }
		ICustomerContactRepository CustomerContactRepository  { get; }
		ICustomerTypeRepository CustomerTypeRepository  { get; }
		IDeliveryConditionRepository DeliveryConditionRepository  { get; }
		IDeliveryContactRepository DeliveryContactRepository  { get; }
		IDocumentRepository DocumentRepository  { get; }
		IDocumentAttachmentRepository DocumentAttachmentRepository  { get; }
		IDocumentDeliveryRepository DocumentDeliveryRepository  { get; }
		IDocumentProducItemRepository DocumentProducItemRepository  { get; }
		IMaterialRepository MaterialRepository  { get; }
		IMaterialTypeRepository MaterialTypeRepository  { get; }
		IMaterialUnitRepository MaterialUnitRepository  { get; }
		IPatternPositionRepository PatternPositionRepository  { get; }
		IProductRepository ProductRepository  { get; }
		IProductItemAttachmentRepository ProductItemAttachmentRepository  { get; }
		IProductItemPrintOptionalRepository ProductItemPrintOptionalRepository  { get; }
		IProductItemScreenOptionalRepository ProductItemScreenOptionalRepository  { get; }
		IProductItemSewOptionalRepository ProductItemSewOptionalRepository  { get; }
		IProductMaterialUsageRepository ProductMaterialUsageRepository  { get; }
		IProductPriceRepository ProductPriceRepository  { get; }
		IProductUnitRepository ProductUnitRepository  { get; }
		IStockRepository StockRepository  { get; }
		ITransportationTypeRepository TransportationTypeRepository  { get; }
		IWarehouseRepository WarehouseRepository  { get; }

	}
}

