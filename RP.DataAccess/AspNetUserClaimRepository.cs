using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class AspNetUserClaimRepository : EFRepository<RP.Model.AspNetUserClaim>, IAspNetUserClaimRepository
	{
		public AspNetUserClaimRepository(DbContext context)
            : base(context)
		{
		}
	}
}
