using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportVehicleRepository : EFRepository<RP.Model.TransportVehicle>, ITransportVehicleRepository
	{
		public TransportVehicleRepository(DbContext context)
            : base(context)
		{
		}
	}
}
