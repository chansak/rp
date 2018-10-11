using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductItemSewOptionalRepository : EFRepository<RP.Model.ProductItemSewOptional>, IProductItemSewOptionalRepository
	{
		public ProductItemSewOptionalRepository(DbContext context)
            : base(context)
		{
		}
	}
}