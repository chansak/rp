using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
    public class AspNetUserRepository : EFRepository<RP.Model.AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(DbContext context)
            : base(context)
        {

        }
        public override IQueryable<Model.AspNetUser> All()
        {
            return ObjectSet.
                Include(i => i.AspNetRoles)
                .AsQueryable();
        }
    }
}
