using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffMinimumKmCountryRepository : EFRepository<RP.Model.TariffMinimumKmCountry>, ITariffMinimumKmCountryRepository
	{
		public TariffMinimumKmCountryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
