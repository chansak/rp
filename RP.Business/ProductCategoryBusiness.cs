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
        public IList<ProductCategory> GetProductCategories()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductCategoryRepository.All().ToList();
            }
        }
        public IList<ProductCategory> GetAllProductCategories(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var data = uow.ProductCategoryRepository.All().AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "CategoryName":
                            {
                                data = data.Where(i => i.CategoryName.ToLower().Contains(keyword.ToLower()));
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
        public void CreateCategory(ProductCategory category)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.ProductCategoryRepository.Add(category);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public ProductCategory GetCategoryById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductCategoryRepository.All()
                    .FirstOrDefault(i => i.Id.ToString() == id);
            }
        }
        public void UpdateCategory(ProductCategory category)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.ProductCategoryRepository.UpdateCategory(category);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
    }
}
