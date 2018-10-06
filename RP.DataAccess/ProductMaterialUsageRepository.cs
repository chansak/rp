using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductMaterialUsageRepository : EFRepository<RP.Model.ProductMaterialUsage>, IProductMaterialUsageRepository
	{
		public ProductMaterialUsageRepository(DbContext context)
            : base(context)
		{
		}
	}
}
