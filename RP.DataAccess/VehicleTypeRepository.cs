using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class VehicleTypeRepository : EFRepository<RP.Model.VehicleType>, IVehicleTypeRepository
	{
		public VehicleTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}

