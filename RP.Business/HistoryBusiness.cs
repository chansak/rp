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
                uow.HistoryRepository.Add(history);
            }
        }
        public IList<History> GetHistoryByType(int type) {
            using (var uow = UnitOfWork.Create())
            {
                return uow.HistoryRepository.All().Where(i => i.HistoryTypeId == type).ToList();
            }
        }
    }
}
