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
        public Product GetProductsById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                //return uow.ProductRepository.GetById(id);
                return uow.ProductRepository.GetProductsById(id);
            }
        }
        public IList<Product> GetProductsByCategoryId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductRepository.All()
                    .Where(i => i.ProductCategoryId.ToString() == id)
                    .ToList();
            }
        }
        public IList<Product> GetAllProducts(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var data = uow.ProductRepository.All().AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "Name":
                            {
                                data = data.Where(i => i.Name.ToLower().Contains(keyword.ToLower()));
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
        public void CreateProduct(Product product)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    var productCategory = uow.ProductCategoryRepository.GetById(product.ProductCategoryId);
                    if (productCategory != null)
                    {
                        product.ProductCategoryId = productCategory.Id;
                        uow.ProductRepository.Add(product);
                        uow.Commit();
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public void UpdateProduct(Product category)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.ProductRepository.UpdateProduct(category);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public void DeleteProductById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                var categoryId = new Guid(id);
                var existing = uow.ProductRepository.GetById(categoryId);
                if (existing != null)
                {
                    uow.ProductRepository.Delete(existing);
                    uow.Commit();
                }
            }
        }
    }
}
