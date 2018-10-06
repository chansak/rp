using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductPriceRepository : EFRepository<RP.Model.ProductPrice>, IProductPriceRepository
	{
		public ProductPriceRepository(DbContext context)
            : base(context)
		{
		}
	}
}
