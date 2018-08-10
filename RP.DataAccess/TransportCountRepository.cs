using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportCountRepository : EFRepository<RP.Model.TransportCount>, ITransportCountRepository
	{
		public TransportCountRepository(DbContext context)
            : base(context)
		{
		}
	}
}
