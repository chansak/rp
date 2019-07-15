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
                Include(i => i.AspNetUser)
                .AsQueryable();
        }
        public override Model.Document GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id && !i.IsDelete).
                Include(i => i.Customer).
                Include(i => i.Customer.CustomerType).
                Include(i => i.Customer.CustomerBranches).
                Include(i => i.Customer.CustomerContacts).
                Include(i => i.AspNetUser).
                Include(i => i.DocumentProductItems).
                Include(i => i.DocumentProductItems.Select(p => p.Product)).
                Include(i => i.DocumentProductItems.Select(p => p.Product).Select(c => c.ProductCategory)).
                Include(i => i.DocumentProductItems.Select(p => p.Unit)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemPrintOptionals)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemScreenOptionals)).
                Include(i => i.DocumentProductItems.Select(p => p.ProductItemSewOptionals)).
                Include(i => i.DocumentDeliveries).
                Include(i => i.Histories)
                .FirstOrDefault();
        }
        public void AddNewDocument(Model.Document document, string customerCode)
        {
            var currentYear = DateTime.Now.Year;
            var nextRunningNumber = (ObjectSet.Where(i => i.CreatedDate.Value.Year == currentYear).Count()) + 1;
            var nexRunningText = ("0000" + nextRunningNumber);
            var fileNumber = nexRunningText.Substring(nexRunningText.Length - 5, 5);
            document.FileNumber = string.Format("{0}{1}{2}", customerCode, currentYear, fileNumber );
            document.CreatedDate = DateTime.Now;
            ObjectSet.Add(document);
        }
        public void UpdateDocument(Model.Document document)
        {
            var existingDocument = this.GetById(document.Id);
            existingDocument.DocumentStatusId = document.DocumentStatusId;
            existingDocument.CustomerId = document.CustomerId;
            existingDocument.ContactId = document.ContactId;
            existingDocument.UserId = document.UserId;
            existingDocument.ExpiryDate = document.ExpiryDate;
            existingDocument.PoNumber = document.PoNumber;
            existingDocument.RefPriceAndRemark = document.RefPriceAndRemark;
            existingDocument.IsDelete = document.IsDelete;
            existingDocument.ConfirmedPriceDays = document.ConfirmedPriceDays;
            existingDocument.DeliveryDays = document.DeliveryDays;
            if (document.DocumentProductItems.Count > 0)
            {
                foreach (var item in document.DocumentProductItems.Where(i => !i.IsDeleted))
                {
                    var exisingItem = existingDocument.DocumentProductItems.FirstOrDefault(i => i.Id == item.Id);
                    if (exisingItem == null)
                    {
                        existingDocument.DocumentProductItems.Add(item);
                    }
                }
            }
            existingDocument.DocumentDeliveries.FirstOrDefault().Address1 = document.DocumentDeliveries.FirstOrDefault().Address1;
            existingDocument.UpdatedDate = DateTime.Now;
        }
        public void UpdateDocumentStatus(Model.Document document)
        {
            var existingDocument = this.GetById(document.Id);
            existingDocument.DocumentStatusId = document.DocumentStatusId;
            existingDocument.UpdatedDate = DateTime.Now;
        }
    }
}
