using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class SupplierEmailRepository : EFRepository<RP.Model.SupplierEmail>, ISupplierEmailRepository
	{
		public SupplierEmailRepository(DbContext context)
            : base(context)
		{
		}
	}
}
