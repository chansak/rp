using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class QuoteRepository : EFRepository<RP.Model.Quote>, IQuoteRepository
	{
		public QuoteRepository(DbContext context)
            : base(context)
		{
		}
	}
}
