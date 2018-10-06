using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class PatternPositionRepository : EFRepository<RP.Model.PatternPosition>, IPatternPositionRepository
	{
		public PatternPositionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
