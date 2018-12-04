

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

		IAspNetRoleRepository _AspNetRoleRepository;
		public IAspNetRoleRepository AspNetRoleRepository
		{
			get
			{
				if (_AspNetRoleRepository == null)
					_AspNetRoleRepository = new AspNetRoleRepository(context);
				
				return _AspNetRoleRepository;
			}
		}
		IAspNetUserRepository _AspNetUserRepository;
		public IAspNetUserRepository AspNetUserRepository
		{
			get
			{
				if (_AspNetUserRepository == null)
					_AspNetUserRepository = new AspNetUserRepository(context);
				
				return _AspNetUserRepository;
			}
		}
		IAspNetUserClaimRepository _AspNetUserClaimRepository;
		public IAspNetUserClaimRepository AspNetUserClaimRepository
		{
			get
			{
				if (_AspNetUserClaimRepository == null)
					_AspNetUserClaimRepository = new AspNetUserClaimRepository(context);
				
				return _AspNetUserClaimRepository;
			}
		}
		IAspNetUserLoginRepository _AspNetUserLoginRepository;
		public IAspNetUserLoginRepository AspNetUserLoginRepository
		{
			get
			{
				if (_AspNetUserLoginRepository == null)
					_AspNetUserLoginRepository = new AspNetUserLoginRepository(context);
				
				return _AspNetUserLoginRepository;
			}
		}
		IColorRepository _ColorRepository;
		public IColorRepository ColorRepository
		{
			get
			{
				if (_ColorRepository == null)
					_ColorRepository = new ColorRepository(context);
				
				return _ColorRepository;
			}
		}
		ICompanyRepository _CompanyRepository;
		public ICompanyRepository CompanyRepository
		{
			get
			{
				if (_CompanyRepository == null)
					_CompanyRepository = new CompanyRepository(context);
				
				return _CompanyRepository;
			}
		}
		ICustomerRepository _CustomerRepository;
		public ICustomerRepository CustomerRepository
		{
			get
			{
				if (_CustomerRepository == null)
					_CustomerRepository = new CustomerRepository(context);
				
				return _CustomerRepository;
			}
		}
		ICustomerAddressRepository _CustomerAddressRepository;
		public ICustomerAddressRepository CustomerAddressRepository
		{
			get
			{
				if (_CustomerAddressRepository == null)
					_CustomerAddressRepository = new CustomerAddressRepository(context);
				
				return _CustomerAddressRepository;
			}
		}
		ICustomerContactRepository _CustomerContactRepository;
		public ICustomerContactRepository CustomerContactRepository
		{
			get
			{
				if (_CustomerContactRepository == null)
					_CustomerContactRepository = new CustomerContactRepository(context);
				
				return _CustomerContactRepository;
			}
		}
		ICustomerContactBranchRepository _CustomerContactBranchRepository;
		public ICustomerContactBranchRepository CustomerContactBranchRepository
		{
			get
			{
				if (_CustomerContactBranchRepository == null)
					_CustomerContactBranchRepository = new CustomerContactBranchRepository(context);
				
				return _CustomerContactBranchRepository;
			}
		}
		ICustomerTypeRepository _CustomerTypeRepository;
		public ICustomerTypeRepository CustomerTypeRepository
		{
			get
			{
				if (_CustomerTypeRepository == null)
					_CustomerTypeRepository = new CustomerTypeRepository(context);
				
				return _CustomerTypeRepository;
			}
		}
		IDeliveryConditionRepository _DeliveryConditionRepository;
		public IDeliveryConditionRepository DeliveryConditionRepository
		{
			get
			{
				if (_DeliveryConditionRepository == null)
					_DeliveryConditionRepository = new DeliveryConditionRepository(context);
				
				return _DeliveryConditionRepository;
			}
		}
		IDepartmentRepository _DepartmentRepository;
		public IDepartmentRepository DepartmentRepository
		{
			get
			{
				if (_DepartmentRepository == null)
					_DepartmentRepository = new DepartmentRepository(context);
				
				return _DepartmentRepository;
			}
		}
		IDocumentRepository _DocumentRepository;
		public IDocumentRepository DocumentRepository
		{
			get
			{
				if (_DocumentRepository == null)
					_DocumentRepository = new DocumentRepository(context);
				
				return _DocumentRepository;
			}
		}
		IDocumentAttachmentRepository _DocumentAttachmentRepository;
		public IDocumentAttachmentRepository DocumentAttachmentRepository
		{
			get
			{
				if (_DocumentAttachmentRepository == null)
					_DocumentAttachmentRepository = new DocumentAttachmentRepository(context);
				
				return _DocumentAttachmentRepository;
			}
		}
		IDocumentDeliveryRepository _DocumentDeliveryRepository;
		public IDocumentDeliveryRepository DocumentDeliveryRepository
		{
			get
			{
				if (_DocumentDeliveryRepository == null)
					_DocumentDeliveryRepository = new DocumentDeliveryRepository(context);
				
				return _DocumentDeliveryRepository;
			}
		}
		IDocumentProductItemRepository _DocumentProductItemRepository;
		public IDocumentProductItemRepository DocumentProductItemRepository
		{
			get
			{
				if (_DocumentProductItemRepository == null)
					_DocumentProductItemRepository = new DocumentProductItemRepository(context);
				
				return _DocumentProductItemRepository;
			}
		}
		IMaterialRepository _MaterialRepository;
		public IMaterialRepository MaterialRepository
		{
			get
			{
				if (_MaterialRepository == null)
					_MaterialRepository = new MaterialRepository(context);
				
				return _MaterialRepository;
			}
		}
		IMaterialTypeRepository _MaterialTypeRepository;
		public IMaterialTypeRepository MaterialTypeRepository
		{
			get
			{
				if (_MaterialTypeRepository == null)
					_MaterialTypeRepository = new MaterialTypeRepository(context);
				
				return _MaterialTypeRepository;
			}
		}
		IMaterialUnitRepository _MaterialUnitRepository;
		public IMaterialUnitRepository MaterialUnitRepository
		{
			get
			{
				if (_MaterialUnitRepository == null)
					_MaterialUnitRepository = new MaterialUnitRepository(context);
				
				return _MaterialUnitRepository;
			}
		}
		IPatternImageRepository _PatternImageRepository;
		public IPatternImageRepository PatternImageRepository
		{
			get
			{
				if (_PatternImageRepository == null)
					_PatternImageRepository = new PatternImageRepository(context);
				
				return _PatternImageRepository;
			}
		}
		IPatternPositionRepository _PatternPositionRepository;
		public IPatternPositionRepository PatternPositionRepository
		{
			get
			{
				if (_PatternPositionRepository == null)
					_PatternPositionRepository = new PatternPositionRepository(context);
				
				return _PatternPositionRepository;
			}
		}
		IProductRepository _ProductRepository;
		public IProductRepository ProductRepository
		{
			get
			{
				if (_ProductRepository == null)
					_ProductRepository = new ProductRepository(context);
				
				return _ProductRepository;
			}
		}
		IProductCategoryRepository _ProductCategoryRepository;
		public IProductCategoryRepository ProductCategoryRepository
		{
			get
			{
				if (_ProductCategoryRepository == null)
					_ProductCategoryRepository = new ProductCategoryRepository(context);
				
				return _ProductCategoryRepository;
			}
		}
		IProductItemAttachmentRepository _ProductItemAttachmentRepository;
		public IProductItemAttachmentRepository ProductItemAttachmentRepository
		{
			get
			{
				if (_ProductItemAttachmentRepository == null)
					_ProductItemAttachmentRepository = new ProductItemAttachmentRepository(context);
				
				return _ProductItemAttachmentRepository;
			}
		}
		IProductItemPrintOptionalRepository _ProductItemPrintOptionalRepository;
		public IProductItemPrintOptionalRepository ProductItemPrintOptionalRepository
		{
			get
			{
				if (_ProductItemPrintOptionalRepository == null)
					_ProductItemPrintOptionalRepository = new ProductItemPrintOptionalRepository(context);
				
				return _ProductItemPrintOptionalRepository;
			}
		}
		IProductItemScreenOptionalRepository _ProductItemScreenOptionalRepository;
		public IProductItemScreenOptionalRepository ProductItemScreenOptionalRepository
		{
			get
			{
				if (_ProductItemScreenOptionalRepository == null)
					_ProductItemScreenOptionalRepository = new ProductItemScreenOptionalRepository(context);
				
				return _ProductItemScreenOptionalRepository;
			}
		}
		IProductItemSewOptionalRepository _ProductItemSewOptionalRepository;
		public IProductItemSewOptionalRepository ProductItemSewOptionalRepository
		{
			get
			{
				if (_ProductItemSewOptionalRepository == null)
					_ProductItemSewOptionalRepository = new ProductItemSewOptionalRepository(context);
				
				return _ProductItemSewOptionalRepository;
			}
		}
		IProductMaterialUsageRepository _ProductMaterialUsageRepository;
		public IProductMaterialUsageRepository ProductMaterialUsageRepository
		{
			get
			{
				if (_ProductMaterialUsageRepository == null)
					_ProductMaterialUsageRepository = new ProductMaterialUsageRepository(context);
				
				return _ProductMaterialUsageRepository;
			}
		}
		IProductOptionRepository _ProductOptionRepository;
		public IProductOptionRepository ProductOptionRepository
		{
			get
			{
				if (_ProductOptionRepository == null)
					_ProductOptionRepository = new ProductOptionRepository(context);
				
				return _ProductOptionRepository;
			}
		}
		IProductPriceRepository _ProductPriceRepository;
		public IProductPriceRepository ProductPriceRepository
		{
			get
			{
				if (_ProductPriceRepository == null)
					_ProductPriceRepository = new ProductPriceRepository(context);
				
				return _ProductPriceRepository;
			}
		}
		IProductUnitRepository _ProductUnitRepository;
		public IProductUnitRepository ProductUnitRepository
		{
			get
			{
				if (_ProductUnitRepository == null)
					_ProductUnitRepository = new ProductUnitRepository(context);
				
				return _ProductUnitRepository;
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
		IStockRepository _StockRepository;
		public IStockRepository StockRepository
		{
			get
			{
				if (_StockRepository == null)
					_StockRepository = new StockRepository(context);
				
				return _StockRepository;
			}
		}
		ITransportationTypeRepository _TransportationTypeRepository;
		public ITransportationTypeRepository TransportationTypeRepository
		{
			get
			{
				if (_TransportationTypeRepository == null)
					_TransportationTypeRepository = new TransportationTypeRepository(context);
				
				return _TransportationTypeRepository;
			}
		}
		IUnitRepository _UnitRepository;
		public IUnitRepository UnitRepository
		{
			get
			{
				if (_UnitRepository == null)
					_UnitRepository = new UnitRepository(context);
				
				return _UnitRepository;
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
		IWarehouseRepository _WarehouseRepository;
		public IWarehouseRepository WarehouseRepository
		{
			get
			{
				if (_WarehouseRepository == null)
					_WarehouseRepository = new WarehouseRepository(context);
				
				return _WarehouseRepository;
			}
		}
	}
}


