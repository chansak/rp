using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DocumentDeliveryRepository : EFRepository<RP.Model.DocumentDelivery>, IDocumentDeliveryRepository
	{
		public DocumentDeliveryRepository(DbContext context)
            : base(context)
		{
		}
	}
}
