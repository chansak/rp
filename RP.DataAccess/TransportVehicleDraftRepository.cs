using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportVehicleDraftRepository : EFRepository<RP.Model.TransportVehicleDraft>, ITransportVehicleDraftRepository
	{
		public TransportVehicleDraftRepository(DbContext context)
            : base(context)
		{
		}
	}
}
