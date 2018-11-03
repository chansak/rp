using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductItemScreenOptionalRepository : EFRepository<RP.Model.ProductItemScreenOptional>, IProductItemScreenOptionalRepository
	{
		public ProductItemScreenOptionalRepository(DbContext context)
            : base(context)
		{
		}
        public Model.ProductItemScreenOptional GetByItemId(string id)
        {
            return ObjectSet.Where(i => i.ProductItemId.ToString() == id)
                .FirstOrDefault();
        }
    }
}
