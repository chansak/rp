using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class HistoryRepository : EFRepository<RP.Model.History>, IHistoryRepository
	{
		public HistoryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
