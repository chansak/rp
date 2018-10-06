using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DeliveryContactRepository : EFRepository<RP.Model.DeliveryContact>, IDeliveryContactRepository
	{
		public DeliveryContactRepository(DbContext context)
            : base(context)
		{
		}
	}
}
