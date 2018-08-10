using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffSurchargeRepository : EFRepository<RP.Model.TariffSurcharge>, ITariffSurchargeRepository
	{
		public TariffSurchargeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
