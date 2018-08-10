using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportQuoteStatuRepository : EFRepository<RP.Model.TransportQuoteStatu>, ITransportQuoteStatuRepository
	{
		public TransportQuoteStatuRepository(DbContext context)
            : base(context)
		{
		}
	}
}
