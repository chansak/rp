using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffRepository : EFRepository<RP.Model.Tariff>, ITariffRepository
	{
		public TariffRepository(DbContext context)
            : base(context)
		{
		}
	}
}
