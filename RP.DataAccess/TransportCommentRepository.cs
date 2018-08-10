using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportCommentRepository : EFRepository<RP.Model.TransportComment>, ITransportCommentRepository
	{
		public TransportCommentRepository(DbContext context)
            : base(context)
		{
		}
	}
}
