using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffExpressDeliveryVehicleDimensionRepository : EFRepository<RP.Model.TariffExpressDeliveryVehicleDimension>, ITariffExpressDeliveryVehicleDimensionRepository
	{
		public TariffExpressDeliveryVehicleDimensionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
