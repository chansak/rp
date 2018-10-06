using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportationTypeRepository : EFRepository<RP.Model.TransportationType>, ITransportationTypeRepository
	{
		public TransportationTypeRepository(DbContext context)
            : base(context)
		{
		}
	}
}
