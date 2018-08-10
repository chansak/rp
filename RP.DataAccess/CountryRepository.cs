using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CountryRepository : EFRepository<RP.Model.Country>, ICountryRepository
	{
		public CountryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
