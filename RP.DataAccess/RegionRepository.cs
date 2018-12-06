using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class RegionRepository : EFRepository<RP.Model.Region>, IRegionRepository
	{
		public RegionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
