using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
    public class CustomerBranchRepository : EFRepository<RP.Model.CustomerBranch>, ICustomerBranchRepository
    {
        public CustomerBranchRepository(DbContext context)
            : base(context)
        {
        }
        public IQueryable<Model.CustomerBranch> GetCustomerBranches(string id)
        {
            return ObjectSet.Where(i => i.CustomerId.ToString() == id).AsQueryable();
        }
    }
}
