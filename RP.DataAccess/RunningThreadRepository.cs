using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class RunningThreadRepository : EFRepository<RP.Model.RunningThread>, IRunningThreadRepository
	{
		public RunningThreadRepository(DbContext context)
            : base(context)
		{
		}
	}
}
