using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportHistoryRepository : EFRepository<RP.Model.TransportHistory>, ITransportHistoryRepository
	{
		public TransportHistoryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
