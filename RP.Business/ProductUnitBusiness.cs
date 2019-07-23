using RP.DataAccess;
using RP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public IList<RP.Model.ProductUnit> GetUnitsByProductId(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductUnitRepository.All().Where(i => i.ProductId.ToString() == id).ToList();
            }
        }
        public IList<RP.Model.ProductUnit> GetAllProductUnit(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var data = uow.ProductUnitRepository.All().AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "UnitName":
                            {
                                data = data.Where(i => i.Unit.UnitName.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                return data.ToList();
            }
        }
        public RP.Model.ProductUnit GetProductUnitById(string id) {
            using (var uow = UnitOfWork.Create())
            {
                return uow.ProductUnitRepository.All()
                    .Where(i => i.Id.ToString() == id).FirstOrDefault();
            }
        }
    }
}
