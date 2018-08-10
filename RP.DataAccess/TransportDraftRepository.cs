using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportDraftRepository : EFRepository<RP.Model.TransportDraft>, ITransportDraftRepository
	{
		public TransportDraftRepository(DbContext context)
            : base(context)
		{
		}
	}
}
