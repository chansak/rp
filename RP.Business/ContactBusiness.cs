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
        public IList<CustomerContact> GetContactByCustomerId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.CustomerContactRepository.All()
                    .Where(i => i.CustomerId.ToString() == id)
                    .ToList();
            }
        }
        public CustomerContact GetContactById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.CustomerContactRepository.GetById(id);
            }
        }
    }
}
