using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IProductRepository : IRepository<RP.Model.Product>
	{
        void UpdateProduct(Model.Product product);
        Model.Product GetProductsById(string id);
    }
}
