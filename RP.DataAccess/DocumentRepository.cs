using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;
using System.Globalization;

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
        public IQueryable<Model.Document> PODocuments()
        {
            return ObjectSet.
                Include(i => i.DocumentProductItems).
                Include(i => i.Customer)
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
            var currentDate = DateTime.Now;
            var currentYear = currentDate.Year;
            var currentTH = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
            var currentYearTH = currentTH.Split('/').Last().Replace("/", "");
            var currentMonth = currentDate.Month.ToString("d2");
            var nextRunningNumber = (ObjectSet.Where(i => i.CreatedDate.Value.Year == currentDate.Year).Count()) + 1;
            var nexRunningText = ("000000" + nextRunningNumber);
            var fileNumber = nexRunningText.Substring(nexRunningText.Length - 6, 6);
            var sub1 = fileNumber.Substring(0, 3);
            var sub2 = fileNumber.Substring(3, 3);

            document.FileNumber = string.Format("{0}{1}-{2}-{3}", currentYearTH, currentMonth, sub1, sub2);
            var documentStatus = (WorkflowStatus)document.DocumentStatusId;
            switch (documentStatus)
            {
                case WorkflowStatus.RequestForPrice:
                    {
                        document.IssueDate = currentDate;
                        break;
                    }
            }
            document.CreatedDate = currentDate;
            ObjectSet.Add(document);
        }
        public void UpdateDocument(Model.Document document)
        {
            var currentDate = DateTime.Now;
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
            existingDocument.WeightPoint = document.WeightPoint;
            var documentStatus = (WorkflowStatus)document.DocumentStatusId;
            switch (documentStatus)
            {
                case WorkflowStatus.RequestForPrice:
                    {
                        existingDocument.IssueDate = currentDate;
                        break;
                    }
            }
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
            existingDocument.UpdatedDate = currentDate;
        }
        public void UpdateDocumentStatus(Model.Document document)
        {
            var currentDate = DateTime.Now;
            var existingDocument = this.GetById(document.Id);
            existingDocument.DocumentStatusId = document.DocumentStatusId;
            var documentStatus = (WorkflowStatus)document.DocumentStatusId;
            switch (documentStatus)
            {
                case WorkflowStatus.RequestForPrice:
                    {
                        existingDocument.IssueDate = currentDate;
                        break;
                    }
                case WorkflowStatus.Quotation:
                    {
                        break;
                    }
                case WorkflowStatus.PurchaseOrder:
                    {
                        existingDocument.PoDate = currentDate;
                        existingDocument.PoNumber = document.PoNumber;
                        existingDocument.ExpiryDate = document.ExpiryDate;
                        existingDocument.ExpectedDeliveryDate = document.ExpectedDeliveryDate;
                        existingDocument.BiddingStatusId = (int)BiddingStatus.undefined;
                        break;
                    }
            }
            existingDocument.UpdatedDate = currentDate;
        }
        public void UpdateDocumentWeightPoint(Model.Document document)
        {
            var existingDocument = this.GetById(document.Id);
            existingDocument.WeightPoint = document.WeightPoint;
            existingDocument.UpdatedDate = DateTime.Now;
        }
        public void UpdateWinLoss(Model.Document document)
        {
            var existingDocument = this.GetById(document.Id);
            existingDocument.BiddingStatusId = document.BiddingStatusId;
            existingDocument.UpdatedDate = DateTime.Now;
        }
    }
}
