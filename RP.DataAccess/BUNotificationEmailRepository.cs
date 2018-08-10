using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class BUNotificationEmailRepository : EFRepository<RP.Model.BUNotificationEmail>, IBUNotificationEmailRepository
	{
		public BUNotificationEmailRepository(DbContext context)
            : base(context)
		{
		}
	}
}
