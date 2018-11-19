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
                Include(i => i.Customer.CustomerType).
                Include(i => i.User)
                .AsQueryable();
        }
        public override Model.Document GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id && !i.IsDelete).
                Include(i => i.Customer).
                Include(i => i.DocumentProductItems).
                Include(i => i.DocumentProductItems.Select(p => p.Product)).
                Include(i=>i.DocumentProductItems.Select(p=>p.Product).Select(c=>c.ProductCategory)).
                Include(i => i.DocumentProductItems.Select(p => p.Unit)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemPrintOptionals)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemScreenOptionals)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemSewOptionals)).
                Include(i => i.DocumentDeliveries)
                .FirstOrDefault();
        }
        public void AddNewDocument(Model.Document document, string customerCode)
        {
            var currentYear = DateTime.Now.Year;
            var nextRunningNumber = (ObjectSet.Where(i => i.CreatedDate.Value.Year == currentYear).Count()) + 1;
            document.FileNumber = string.Format("{0}{1}{2}", customerCode, currentYear, ("0000" + nextRunningNumber).Substring(0, 5));
            document.CreatedDate = DateTime.Now;
            ObjectSet.Add(document);
        }
        public void UpdateDocument(Model.Document document)
        {
            var existingDocument = this.GetById(document.Id);
            existingDocument.CustomerId = document.CustomerId;
            existingDocument.ContactId = document.ContactId;
            existingDocument.UserId = document.UserId;
            if (document.DocumentProductItems.Count > 0) {
                foreach (var item in document.DocumentProductItems){
                    existingDocument.DocumentProductItems.Add(item);
                }
            }
            existingDocument.UpdatedDate = DateTime.Now;
        }
    }
}
