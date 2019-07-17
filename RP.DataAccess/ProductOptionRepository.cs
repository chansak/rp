using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
    public class ProductOptionRepository : EFRepository<RP.Model.ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(DbContext context)
            : base(context)
        {
        }
        public override IQueryable<Model.ProductOption> All()
        {
            return ObjectSet.
                Include(i => i.Product).
                Include(i=>i.Product.ProductCategory)
                .AsQueryable();
        }
        Model.ProductOption GetProductOptionById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id).
               Include(i => i.Product).FirstOrDefault();
        }
        public void UpdateProductOption(Model.ProductOption option)
        {
            var existing = this.GetById(option.Id);
            existing.OptionName = option.OptionName;
            existing.ProductId = option.ProductId;
        }
    }
}
