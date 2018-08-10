using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class Temp_TransportRepository : EFRepository<RP.Model.Temp_Transport>, ITemp_TransportRepository
	{
		public Temp_TransportRepository(DbContext context)
            : base(context)
		{
		}
	}
}
