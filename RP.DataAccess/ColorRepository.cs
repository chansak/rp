using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class ColorRepository : EFRepository<RP.Model.Color>, IColorRepository
	{
		public ColorRepository(DbContext context)
            : base(context)
		{
		}
        public override Model.Color GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id)
                .FirstOrDefault();
        }
    }
}
