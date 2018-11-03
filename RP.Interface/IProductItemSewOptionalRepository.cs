using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IProductItemSewOptionalRepository : IRepository<RP.Model.ProductItemSewOptional>
	{
        ProductItemSewOptional GetByItemId(string id);

    }
}
