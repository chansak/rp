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
        public override IQueryable<Model.Document> All()
        {
            return ObjectSet.
                Include(i => i.Customer).
                Include(i => i.Customer.CustomerType)
                .AsQueryable();
        }
        public override Model.Document GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id && !i.IsDelete.Value).
                Include(i => i.Customer)
                .FirstOrDefault();
        }
        public void AddNewDocument(Model.Document document, string customerCode)
        {
            var currentYear = DateTime.Now.Year;
            var nextRunningNumber = (ObjectSet.Where(i => i.CreatedDate.Value.Year == currentYear).Count()) + 1;
            document.Id = Guid.NewGuid();
            document.FileNumber = string.Format("{0}{1}{2}",customerCode, currentYear, ("0000"+ nextRunningNumber).Substring(0,5));
            document.CreatedDate = DateTime.Now;
            ObjectSet.Add(document);
        }
    }
}
