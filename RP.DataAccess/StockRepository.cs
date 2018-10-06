using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class StockRepository : EFRepository<RP.Model.Stock>, IStockRepository
	{
		public StockRepository(DbContext context)
            : base(context)
		{
		}
	}
}
