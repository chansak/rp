using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportLocationDraftRepository : EFRepository<RP.Model.TransportLocationDraft>, ITransportLocationDraftRepository
	{
		public TransportLocationDraftRepository(DbContext context)
            : base(context)
		{
		}
	}
}
