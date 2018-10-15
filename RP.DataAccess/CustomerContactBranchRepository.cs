using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerContactBranchRepository : EFRepository<RP.Model.CustomerContactBranch>, ICustomerContactBranchRepository
	{
		public CustomerContactBranchRepository(DbContext context)
            : base(context)
		{
		}
	}
}
