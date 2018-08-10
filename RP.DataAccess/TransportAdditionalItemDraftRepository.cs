using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class TransportAdditionalItemDraftRepository : EFRepository<RP.Model.TransportAdditionalItemDraft>, ITransportAdditionalItemDraftRepository
	{
		public TransportAdditionalItemDraftRepository(DbContext context)
            : base(context)
		{
		}
	}
}
