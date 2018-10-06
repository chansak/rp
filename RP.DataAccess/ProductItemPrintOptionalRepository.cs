using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductItemPrintOptionalRepository : EFRepository<RP.Model.ProductItemPrintOptional>, IProductItemPrintOptionalRepository
	{
		public ProductItemPrintOptionalRepository(DbContext context)
            : base(context)
		{
		}
	}
}
