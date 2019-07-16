using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductRepository : EFRepository<RP.Model.Product>, IProductRepository
	{
		public ProductRepository(DbContext context)
            : base(context)
		{
		}
        public override IQueryable<Model.Product> All()
        {
            return ObjectSet.
                Include(i => i.ProductCategory)
                .AsQueryable();
        }
        public void UpdateProduct(Model.Product product)
        {
            var existing = this.GetById(product.Id);
            existing.Name = product.Name;
            existing.ProductCategoryId = product.ProductCategoryId;
        }
        public Model.Product GetProductsById(string id) {
            var productId = new Guid(id);
            return this.All().Where(i => i.Id == productId).FirstOrDefault();
        }
    }
}
