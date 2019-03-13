using RP.Interfaces;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public DocumentProductItem GetProductItemByItemId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.DocumentProductItemRepository.GetById(id);
            }
        }
        public void DeleteProductItemsByDocument(Document document)
        {
            using (var uow = UnitOfWork.Create())
            {
                foreach (var item in document.DocumentProductItems)
                {
                    uow.DocumentProductItemRepository.Delete(item);
                }
                uow.Commit();
            }
        }
        public void MarkDeleteProductItemsByDocumentId(IUnitOfWork uow, string id)
        {

            var document = uow.DocumentRepository.GetById(id);
            foreach (var item in document.DocumentProductItems)
            {
                var existingItem = uow.DocumentProductItemRepository.GetById(item.Id);
                existingItem.IsDeleted = true;
            }
            uow.Commit();
        }
        public void MarkDeleteProductItemByItemId(string itemId) {
            using (var uow = UnitOfWork.Create())
            {
                var item = uow.DocumentProductItemRepository.GetById(itemId);
                item.IsDeleted = true;
                uow.Commit();
            }
        }
    }
}
