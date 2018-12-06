using System;
using System.Collections.Generic;
using System.Linq;
using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface ICustomerBranchRepository : IRepository<RP.Model.CustomerBranch>
	{
        IQueryable<Model.CustomerBranch> GetCustomerBranches(string id);
    }
}
