using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class QuoteHistoryRepository : EFRepository<RP.Model.QuoteHistory>, IQuoteHistoryRepository
	{
		public QuoteHistoryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
