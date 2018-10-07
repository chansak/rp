using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class WarehouseRepository : EFRepository<RP.Model.Warehouse>, IWarehouseRepository
	{
		public WarehouseRepository(DbContext context)
            : base(context)
		{
		}
	}
}



