using RP.Interfaces;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public IList<ProductOption> GetOptionsByProductId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductOptionRepository.All().Where(i=>i.ProductId.ToString() == id).ToList();
            }
        }
        public IList<ProductOption> GetAllProductOptions(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var data = uow.ProductOptionRepository.All().AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "OptionName":
                            {
                                data = data.Where(i => i.OptionName.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                return data.ToList();
            }
        }
        public void CreateProductOption(ProductOption option)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.ProductOptionRepository.Add(option);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public ProductOption GetProductOptionById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductOptionRepository.All()
                    .FirstOrDefault(i => i.Id.ToString() == id);
            }
        }
        public void UpdateProductOption(ProductOption option)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.ProductOptionRepository.UpdateProductOption(option);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public void DeleteProductOptionById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                var optionId = new Guid(id);
                var existing = uow.ProductOptionRepository.GetById(optionId);
                if (existing != null)
                {
                    uow.ProductOptionRepository.Delete(existing);
                    uow.Commit();
                }
            }
        }
        public IList<ProductOption> GetAllProductOptions() {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductOptionRepository.All().ToList();
            }
        }
    }
}
