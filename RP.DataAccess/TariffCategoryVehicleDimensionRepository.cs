using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffCategoryVehicleDimensionRepository : EFRepository<RP.Model.TariffCategoryVehicleDimension>, ITariffCategoryVehicleDimensionRepository
	{
		public TariffCategoryVehicleDimensionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
