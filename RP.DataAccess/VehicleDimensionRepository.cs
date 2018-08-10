using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class VehicleDimensionRepository : EFRepository<RP.Model.VehicleDimension>, IVehicleDimensionRepository
	{
		public VehicleDimensionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
