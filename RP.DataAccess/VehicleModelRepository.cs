using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class VehicleModelRepository : EFRepository<RP.Model.VehicleModel>, IVehicleModelRepository
	{
		public VehicleModelRepository(DbContext context)
            : base(context)
		{
		}
	}
}
