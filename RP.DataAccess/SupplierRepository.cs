using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class SupplierRepository : EFRepository<RP.Model.Supplier>, ISupplierRepository
	{
		public SupplierRepository(DbContext context)
            : base(context)
		{
		}
	}
}
