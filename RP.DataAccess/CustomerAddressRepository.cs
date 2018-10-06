using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerAddressRepository : EFRepository<RP.Model.CustomerAddress>, ICustomerAddressRepository
	{
		public CustomerAddressRepository(DbContext context)
            : base(context)
		{
		}
	}
}
