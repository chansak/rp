using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DeliveryConditionRepository : EFRepository<RP.Model.DeliveryCondition>, IDeliveryConditionRepository
	{
		public DeliveryConditionRepository(DbContext context)
            : base(context)
		{
		}
	}
}
