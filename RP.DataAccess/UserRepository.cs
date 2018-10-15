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
        public override IQueryable<Model.User> All()
        {
            return ObjectSet.
                Include(i => i.Department)
                .AsQueryable();
        }
    }
}
