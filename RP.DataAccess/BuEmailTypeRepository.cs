using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class BuEmailTypeRepository : EFRepository<RP.Model.BuEmailType>, IBuEmailTypeRepository
	{
		public BuEmailTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
