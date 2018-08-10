using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class RoleRepository : EFRepository<RP.Model.Role>, IRoleRepository
	{
		public RoleRepository(DbContext context)
            : base(context)
		{
		}
	}
}
