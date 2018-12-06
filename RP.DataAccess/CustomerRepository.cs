using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class CustomerRepository : EFRepository<RP.Model.Customer>, ICustomerRepository
	{
		public CustomerRepository(DbContext context)
            : base(context)
		{
		}
        public override IQueryable<Model.Customer> All()
        {
            return ObjectSet.
                //Include(i => i.Company).
                Include(i => i.CustomerType)
                .AsQueryable();
        }
        public override Model.Customer GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id && !i.IsDelete).
                Include(i=>i.CustomerType)
                .FirstOrDefault();
        }
    }
}
