using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TariffCategoryRepository : EFRepository<RP.Model.TariffCategory>, ITariffCategoryRepository
	{
		public TariffCategoryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
