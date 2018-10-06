using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class MaterialTypeRepository : EFRepository<RP.Model.MaterialType>, IMaterialTypeRepository
	{
		public MaterialTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
