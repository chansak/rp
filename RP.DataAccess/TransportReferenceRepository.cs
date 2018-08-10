using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportReferenceRepository : EFRepository<RP.Model.TransportReference>, ITransportReferenceRepository
	{
		public TransportReferenceRepository(DbContext context)
            : base(context)
		{
		}
	}
}
