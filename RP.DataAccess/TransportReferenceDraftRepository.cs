using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportReferenceDraftRepository : EFRepository<RP.Model.TransportReferenceDraft>, ITransportReferenceDraftRepository
	{
		public TransportReferenceDraftRepository(DbContext context)
            : base(context)
		{
		}
	}
}
