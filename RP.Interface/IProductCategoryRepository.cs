using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IProductCategoryRepository : IRepository<RP.Model.ProductCategory>
	{
        void UpdateCategory(ProductCategory category);
    }
}
