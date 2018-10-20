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
        public IList<User> GetSaleUsersList()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.UserRepository.All().ToList();
            }
        }
        public User GetSaleUserById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.UserRepository.GetById(id);
            }
        }
    }
}
