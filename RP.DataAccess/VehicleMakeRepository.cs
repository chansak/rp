using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class VehicleMakeRepository : EFRepository<RP.Model.VehicleMake>, IVehicleMakeRepository
	{
		public VehicleMakeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
