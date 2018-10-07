using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DocumentRepository : EFRepository<RP.Model.Document>, IDocumentRepository
	{
		public DocumentRepository(DbContext context)
            : base(context)
		{
		}
	}
}
