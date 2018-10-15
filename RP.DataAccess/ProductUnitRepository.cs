using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductUnitRepository : EFRepository<RP.Model.ProductUnit>, IProductUnitRepository
	{
		public ProductUnitRepository(DbContext context)
            : base(context)
		{
		}
        public override IQueryable<Model.ProductUnit> All()
        {
            return ObjectSet.
                Include(i => i.Unit)
                .AsQueryable();
        }
    }
}
