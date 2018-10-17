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
        public Document GetDocument(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.DocumentRepository.GetById(id);
            }
        }
        public void CreateDocument(Document document, string customerCode) {
            using (var uow = UnitOfWork.Create())
            {
                uow.DocumentRepository.AddNewDocument(document,customerCode);
                uow.Commit();
            }
        }
    }
}
