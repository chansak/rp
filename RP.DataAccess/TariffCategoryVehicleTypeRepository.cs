using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffCategoryVehicleTypeRepository : EFRepository<RP.Model.TariffCategoryVehicleType>, ITariffCategoryVehicleTypeRepository
	{
		public TariffCategoryVehicleTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
