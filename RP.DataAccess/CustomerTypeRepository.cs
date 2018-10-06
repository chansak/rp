using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerTypeRepository : EFRepository<RP.Model.CustomerType>, ICustomerTypeRepository
	{
		public CustomerTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
