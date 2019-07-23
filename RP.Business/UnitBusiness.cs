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
        public void CreateProductUnit(Unit unit, ProductUnit productUnit) {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    var existingProduct = uow.ProductRepository.All().Where(i => i.Id == productUnit.ProductId).FirstOrDefault();
                    if (existingProduct != null)
                    {
                        uow.UnitRepository.Add(unit);
                        uow.ProductUnitRepository.Add(productUnit);
                        uow.Commit();
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public void UpdateProductUnit(Unit unit, ProductUnit productUnit) {
            using (var uow = UnitOfWork.Create())
            {
                try
                {
                    var existingProduct = uow.ProductRepository.All().Where(i => i.Id == productUnit.ProductId).FirstOrDefault();
                    if (existingProduct != null)
                    {
                        uow.UnitRepository.UpdateUnit(unit);
                        uow.ProductUnitRepository.UpdateProductUnit(productUnit);
                        uow.Commit();
                    }
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    var msg = ex.Message;
                }
            }
        }
    }
}
