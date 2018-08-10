using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class SupplierEmailTypeRepository : EFRepository<RP.Model.SupplierEmailType>, ISupplierEmailTypeRepository
	{
		public SupplierEmailTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
