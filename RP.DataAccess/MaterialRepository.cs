using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class MaterialRepository : EFRepository<RP.Model.Material>, IMaterialRepository
	{
		public MaterialRepository(DbContext context)
            : base(context)
		{
		}
        public override Model.Material GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id)
                .FirstOrDefault();
        }
    }
}
