using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportLocationRepository : EFRepository<RP.Model.TransportLocation>, ITransportLocationRepository
	{
		public TransportLocationRepository(DbContext context)
            : base(context)
		{
		}
	}
}
