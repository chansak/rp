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
	}
}
