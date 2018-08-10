using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportNotificationRepository : EFRepository<RP.Model.TransportNotification>, ITransportNotificationRepository
	{
		public TransportNotificationRepository(DbContext context)
            : base(context)
		{
		}
	}
}
