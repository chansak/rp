using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportAdditionalItemRepository : EFRepository<RP.Model.TransportAdditionalItem>, ITransportAdditionalItemRepository
	{
		public TransportAdditionalItemRepository(DbContext context)
            : base(context)
		{
		}
	}
}
