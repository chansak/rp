using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CurrencyRateRepository : EFRepository<RP.Model.CurrencyRate>, ICurrencyRateRepository
	{
		public CurrencyRateRepository(DbContext context)
            : base(context)
		{
		}
	}
}
