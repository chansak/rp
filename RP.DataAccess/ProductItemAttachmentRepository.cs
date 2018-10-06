using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ProductItemAttachmentRepository : EFRepository<RP.Model.ProductItemAttachment>, IProductItemAttachmentRepository
	{
		public ProductItemAttachmentRepository(DbContext context)
            : base(context)
		{
		}
	}
}
