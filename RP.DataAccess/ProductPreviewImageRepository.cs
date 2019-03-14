using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductPreviewImageRepository : EFRepository<RP.Model.ProductPreviewImage>, IProductPreviewImageRepository
	{
		public ProductPreviewImageRepository(DbContext context)
            : base(context)
		{
		}
	}
}
