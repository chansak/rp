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
        public override IQueryable<Model.Stock> All()
        {
            return ObjectSet.
                Include(i=>i.Material).
                Include(i => i.MaterialUnit)
                .AsQueryable();
        }
    }
}
