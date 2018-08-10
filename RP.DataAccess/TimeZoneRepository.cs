using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TimeZoneRepository : EFRepository<RP.Model.TimeZone>, ITimeZoneRepository
	{
		public TimeZoneRepository(DbContext context)
            : base(context)
		{
		}
	}
}
