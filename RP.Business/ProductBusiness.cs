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
                return uow.ProductRepository.GetById(id);
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
    }
}
