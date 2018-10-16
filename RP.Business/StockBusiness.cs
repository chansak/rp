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
        public IList<Stock> GetStockCheck(string warehouseId, string materialId, string materialUnitId)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.StockRepository.All()
                    .Where(i => 
                        i.WarehouseId.ToString() == warehouseId &&
                        i.MaterialId.ToString() == materialId && 
                        i.MaterialUnitId.ToString() == materialUnitId)
                    .ToList();
            }
        }
    }
}
