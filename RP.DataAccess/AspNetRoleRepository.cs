using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class AspNetRoleRepository : EFRepository<RP.Model.AspNetRole>, IAspNetRoleRepository
	{
		public AspNetRoleRepository(DbContext context)
            : base(context)
		{
		}
	}
}
