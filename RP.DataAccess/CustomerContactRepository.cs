using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerContactRepository : EFRepository<RP.Model.CustomerContact>, ICustomerContactRepository
	{
		public CustomerContactRepository(DbContext context)
            : base(context)
		{
		}
	}
}
