using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportQuoteDeclineReasonRepository : EFRepository<RP.Model.TransportQuoteDeclineReason>, ITransportQuoteDeclineReasonRepository
	{
		public TransportQuoteDeclineReasonRepository(DbContext context)
            : base(context)
		{
		}
	}
}
