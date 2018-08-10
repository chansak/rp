using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffMinimumKmRepository : EFRepository<RP.Model.TariffMinimumKm>, ITariffMinimumKmRepository
	{
		public TariffMinimumKmRepository(DbContext context)
            : base(context)
		{
		}
	}
}
