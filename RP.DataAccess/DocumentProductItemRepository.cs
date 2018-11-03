using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class DocumentProductItemRepository : EFRepository<RP.Model.DocumentProductItem>, IDocumentProductItemRepository
	{
		public DocumentProductItemRepository(DbContext context)
            : base(context)
		{
		}
        public override Model.DocumentProductItem GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id).
                Include(i=>i.Product).
                Include(i=>i.Unit)
                .FirstOrDefault();
        }
    }
}
