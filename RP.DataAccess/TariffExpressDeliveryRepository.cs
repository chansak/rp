using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffExpressDeliveryRepository : EFRepository<RP.Model.TariffExpressDelivery>, ITariffExpressDeliveryRepository
	{
		public TariffExpressDeliveryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
