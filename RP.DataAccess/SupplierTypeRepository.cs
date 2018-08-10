using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class SupplierTypeRepository : EFRepository<RP.Model.SupplierType>, ISupplierTypeRepository
	{
		public SupplierTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
