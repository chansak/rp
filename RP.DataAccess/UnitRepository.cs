using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class UnitRepository : EFRepository<RP.Model.Unit>, IUnitRepository
	{
		public UnitRepository(DbContext context)
            : base(context)
		{
		}
        public void UpdateUnit(Model.Unit unit)
        {
            var existing = this.GetById(unit.Id);
            existing.UnitName = unit.UnitName;
        }
    }
}
