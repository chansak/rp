using System;
using System.Collections.Generic;
using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IProductOptionRepository : IRepository<RP.Model.ProductOption>
	{
        void UpdateProductOption(Model.ProductOption option);
    }
}
