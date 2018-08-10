using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportAssignedToSupplierCountRepository : EFRepository<RP.Model.TransportAssignedToSupplierCount>, ITransportAssignedToSupplierCountRepository
	{
		public TransportAssignedToSupplierCountRepository(DbContext context)
            : base(context)
		{
		}
	}
}
