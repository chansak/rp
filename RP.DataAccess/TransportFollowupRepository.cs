using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportFollowupRepository : EFRepository<RP.Model.TransportFollowup>, ITransportFollowupRepository
	{
		public TransportFollowupRepository(DbContext context)
            : base(context)
		{
		}
	}
}
