using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class Temp_Supplier_ConfirmationRepository : EFRepository<RP.Model.Temp_Supplier_Confirmation>, ITemp_Supplier_ConfirmationRepository
	{
		public Temp_Supplier_ConfirmationRepository(DbContext context)
            : base(context)
		{
		}
	}
}
