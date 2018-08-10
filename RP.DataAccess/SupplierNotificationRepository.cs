using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class SupplierNotificationRepository : EFRepository<RP.Model.SupplierNotification>, ISupplierNotificationRepository
	{
		public SupplierNotificationRepository(DbContext context)
            : base(context)
		{
		}
	}
}
