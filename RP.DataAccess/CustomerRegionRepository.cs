using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerRegionRepository : EFRepository<RP.Model.CustomerRegion>, ICustomerRegionRepository
	{
		public CustomerRegionRepository(DbContext context)
            : base(context)
		{
		}
	}
}

