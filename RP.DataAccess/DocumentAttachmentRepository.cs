using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DocumentAttachmentRepository : EFRepository<RP.Model.DocumentAttachment>, IDocumentAttachmentRepository
	{
		public DocumentAttachmentRepository(DbContext context)
            : base(context)
		{
		}
	}
}
