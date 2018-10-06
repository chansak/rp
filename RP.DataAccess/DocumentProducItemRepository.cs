using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DocumentProducItemRepository : EFRepository<RP.Model.DocumentProducItem>, IDocumentProducItemRepository
	{
		public DocumentProducItemRepository(DbContext context)
            : base(context)
		{
		}
	}
}
