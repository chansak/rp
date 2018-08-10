using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class RouteSupplierRepository : EFRepository<RP.Model.RouteSupplier>, IRouteSupplierRepository
	{
		public RouteSupplierRepository(DbContext context)
            : base(context)
		{
		}
	}
}
