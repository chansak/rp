using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportFollowupStateRepository : EFRepository<RP.Model.TransportFollowupState>, ITransportFollowupStateRepository
	{
		public TransportFollowupStateRepository(DbContext context)
            : base(context)
		{
		}
	}
}
