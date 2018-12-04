using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class AspNetUserLoginRepository : EFRepository<RP.Model.AspNetUserLogin>, IAspNetUserLoginRepository
	{
		public AspNetUserLoginRepository(DbContext context)
            : base(context)
		{
		}
	}
}
