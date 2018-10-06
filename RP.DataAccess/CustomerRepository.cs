using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerRepository : EFRepository<RP.Model.Customer>, ICustomerRepository
	{
		public CustomerRepository(DbContext context)
            : base(context)
		{
		}
	}
}
