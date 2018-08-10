using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportStatuRepository : EFRepository<RP.Model.TransportStatu>, ITransportStatuRepository
	{
		public TransportStatuRepository(DbContext context)
            : base(context)
		{
		}
	}
}
