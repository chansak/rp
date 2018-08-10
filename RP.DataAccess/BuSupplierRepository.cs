using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class BuSupplierRepository : EFRepository<RP.Model.BuSupplier>, IBuSupplierRepository
	{
		public BuSupplierRepository(DbContext context)
            : base(context)
		{
		}
	}
}
