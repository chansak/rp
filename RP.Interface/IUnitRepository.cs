using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IUnitRepository : IRepository<RP.Model.Unit>
	{
        void UpdateUnit(Model.Unit unit);

    }
}
