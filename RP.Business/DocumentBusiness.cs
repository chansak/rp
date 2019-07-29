using System.Collections.Generic;
using RP.Interfaces;
using RP.Model;
using System.Linq;
using System;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public IList<Document> GetDocumentsList()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.DocumentRepository.All().ToList();
            }
        }
        public IList<Document> GetDocumentsListBySearch(string searchBy, string keyword, string userId = null)
        {
            using (var uow = UnitOfWork.Create())
            {
                var documents = uow.DocumentRepository.All().AsEnumerable();
                if (userId != null)
                {
                    documents = documents.Where(i => i.UserId.ToLower() == userId.ToLower());
                }
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "CustomerName":
                            {
                                documents = documents.Where(i => i.Customer.Name.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        case "DocumentCode":
                            {
                                documents = documents.Where(i => i.FileNumber.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                var d = documents.ToList();
                return d.Where(i => !i.IsDelete).ToList();
            }
        }
        public IList<Document> GetDocumentsListBySearch(DocumentSearchCriteria criteria, string userId = null)
        {
            using (var uow = UnitOfWork.Create())
            {
                var documents = uow.DocumentRepository.All().AsEnumerable();
                if (userId != null)
                {
                    documents = documents.Where(i => i.UserId.ToLower() == userId.ToLower());
                }
                if (!string.IsNullOrWhiteSpace(criteria.CustomerName))
                {
                    documents = documents.Where(i => i.Customer.Name.ToLower().Contains(criteria.CustomerName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(criteria.DocumentCode))
                {
                    documents = documents.Where(i => i.FileNumber.ToLower().Contains(criteria.DocumentCode.ToLower()));
                }

                if (criteria.CustomerType != 0)
                {
                    documents = documents.Where(i => i.Customer.CustomerTypeId == criteria.CustomerType);
                }
                if (criteria.DocumentYear != 0)
                {
                    documents = documents.Where(i => i.IssueDate.Value.Year == criteria.DocumentYear);
                }
                if (!string.IsNullOrWhiteSpace(criteria.ContactName))
                {
                    documents = documents.Where(i => i.CustomerContact.Name.ToLower().Contains(criteria.ContactName.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(criteria.ProductCategoryId))
                {
                    documents = documents.Where(doc => doc.DocumentProductItems.Any(i => i.Product.ProductCategoryId.ToString().Contains(criteria.ProductCategoryId)));
                }
                if (criteria.QuotedPrice != 0)
                {
                    documents = documents.Where(doc => doc.DocumentProductItems.Any(i => (i.Amount * i.PricePerUnit) == criteria.QuotedPrice));
                }
                var d = documents.ToList();
                return d.Where(i => !i.IsDelete).ToList();
            }
        }
        public Document GetDocument(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.DocumentRepository.GetById(id);
            }
        }
        public void CreateDocument(Document document, string customerCode)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.DocumentRepository.AddNewDocument(document, customerCode);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public void DeleteProductItemsByDocumentId(string documentId)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    this.MarkDeleteProductItemsByDocumentId(uow, documentId);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public void UpdateDocumentWithMarkDeleteItems(Document document, string comment = "")
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    this.MarkDeleteProductItemsByDocumentId(uow, document.Id.ToString());
                    uow.DocumentRepository.UpdateDocument(document);
                    uow.HistoryRepository.Add(new History
                    {
                        Id = Guid.NewGuid(),
                        DocumentId = document.Id,
                        HistoryTypeId = 1,
                        Text = comment,
                        UserId = document.UserId,
                        CreatedDate = DateTime.Now
                    });
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public void UpdateDocument(Document document)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.DocumentRepository.UpdateDocument(document);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public void UpdateDocumentStatus(Document document)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.DocumentRepository.UpdateDocumentStatus(document);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
        public IList<Document> GetApprovalDocumentsListBySearch(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var documents = uow.DocumentRepository.All().Where(i => i.DocumentStatusId == (int)WorkflowStatus.RequestedForApproval).AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "CustomerName":
                            {
                                documents = documents.Where(i => i.Customer.Name.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        case "DocumentCode":
                            {
                                documents = documents.Where(i => i.FileNumber.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                return documents.ToList();
            }
        }
        public IList<Document> AlreadyGotPODocumentsList()
        {
            using (var uow = UnitOfWork.Create())
            {
                var data = uow.DocumentRepository.PODocuments().ToList();
                return uow.DocumentRepository.PODocuments()
                    .Where(d => d.DocumentStatusId == (int)WorkflowStatus.PurchaseOrder
                    && d.PoNumber != null
                    && d.PoDate != null).ToList();
            }
        }
        public void UpdateDocumentWeightPoint(Document document)
        {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    uow.DocumentRepository.UpdateDocumentWeightPoint(document);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
    }
}
