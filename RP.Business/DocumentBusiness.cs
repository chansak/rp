using System.Collections.Generic;
using RP.Interfaces;
using RP.Model;
using System.Linq;

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
        public IList<Document> GetDocumentsListBySearch(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var documents = uow.DocumentRepository.All().ToList();
                var result = new List<Document>();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "CustomerName":
                            {
                                result.AddRange(documents.Where(i => i.Customer.Name.ToLower().Contains(keyword.ToLower())));
                                break;
                            }
                        case "DocumentCode":
                            {
                                result.AddRange(documents.Where(i => i.FileNumber.ToLower().Contains(keyword.ToLower())));
                                break;
                            }
                        default:
                            {
                                result.AddRange(documents);
                                break;
                            }
                    }
                }
                else {
                    result.AddRange(documents);
                }
                return result;
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
                uow.DocumentRepository.AddNewDocument(document, customerCode);
                uow.Commit();
            }
        }
    }
}
