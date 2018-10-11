using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductCategoryRepository : EFRepository<RP.Model.ProductCategory>, IProductCategoryRepository
	{
		public ProductCategoryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
