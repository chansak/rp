using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class UserRepository : EFRepository<RP.Model.User>, IUserRepository
	{
		public UserRepository(DbContext context)
            : base(context)
		{
		}
	}
}
