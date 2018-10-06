using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class MaterialUnitRepository : EFRepository<RP.Model.MaterialUnit>, IMaterialUnitRepository
	{
		public MaterialUnitRepository(DbContext context)
            : base(context)
		{
		}
	}
}
