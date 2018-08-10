using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class UnityVehicleMappingRepository : EFRepository<RP.Model.UnityVehicleMapping>, IUnityVehicleMappingRepository
	{
		public UnityVehicleMappingRepository(DbContext context)
            : base(context)
		{
		}
	}
}
