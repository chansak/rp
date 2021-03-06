﻿using RP.Interfaces;
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
        public  IList<ProductMaterialUsage> GetMaterialUsageByProductId(string productId, string productUnitId)
        {
            using (var uow = UnitOfWork.Create())
            {
                    return uow.ProductMaterialUsageRepository.All().Where(i =>
                        i.ProductId.ToString() == productId &&
                        i.ProductUnitId.ToString() == productUnitId).ToList();
            }
        }
    }
}
