using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportQuoteRepository : EFRepository<RP.Model.TransportQuote>, ITransportQuoteRepository
	{
		public TransportQuoteRepository(DbContext context)
            : base(context)
		{
		}
	}
}
