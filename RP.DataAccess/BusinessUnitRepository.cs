using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class BusinessUnitRepository : EFRepository<RP.Model.BusinessUnit>, IBusinessUnitRepository
	{
		public BusinessUnitRepository(DbContext context)
            : base(context)
		{
		}
	}
}
