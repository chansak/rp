using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportSupplierRepository : EFRepository<RP.Model.TransportSupplier>, ITransportSupplierRepository
	{
		public TransportSupplierRepository(DbContext context)
            : base(context)
		{
		}
	}
}
