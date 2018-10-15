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
        public IList<ProductOption> GetOptionsByProductId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductOptionRepository.All().Where(i=>i.ProductId.ToString() == id).ToList();
            }
        }
    }
}
