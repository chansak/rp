using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DepartmentRepository : EFRepository<RP.Model.Department>, IDepartmentRepository
	{
		public DepartmentRepository(DbContext context)
            : base(context)
		{
		}
	}
}
