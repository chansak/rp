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
        public void AddHistory(History history)
        {
            using (var uow = UnitOfWork.Create())
            {
                history.CreatedDate = DateTime.Now;
                uow.HistoryRepository.Add(history);
                uow.Commit();
            }
        }
        public IList<History> GetHistoryByType(string documentId, int type)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.HistoryRepository.All().Where(i => i.DocumentId.ToString() == documentId && i.HistoryTypeId == type).ToList();
            }
        }
    }
}
