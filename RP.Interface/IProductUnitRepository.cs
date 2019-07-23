using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IProductUnitRepository : IRepository<RP.Model.ProductUnit>
	{
        void UpdateProductUnit(Model.ProductUnit unit);

    }
}
