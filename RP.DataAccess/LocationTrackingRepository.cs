using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class LocationTrackingRepository : EFRepository<RP.Model.LocationTracking>, ILocationTrackingRepository
	{
		public LocationTrackingRepository(DbContext context)
            : base(context)
		{
		}
	}
}
