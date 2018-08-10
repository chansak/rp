using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class RouteRepository : EFRepository<RP.Model.Route>, IRouteRepository
	{
		public RouteRepository(DbContext context)
            : base(context)
		{
		}
	}
}
