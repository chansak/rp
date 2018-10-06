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
	}
}
