using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CurrencyRepository : EFRepository<RP.Model.Currency>, ICurrencyRepository
	{
		public CurrencyRepository(DbContext context)
            : base(context)
		{
		}
	}
}
