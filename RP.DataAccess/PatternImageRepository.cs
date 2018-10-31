using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using RP.Model;
using RP.Interfaces;

namespace RP.DataAccess
{
	public class PatternImageRepository : EFRepository<RP.Model.PatternImage>, IPatternImageRepository
	{
		public PatternImageRepository(DbContext context)
            : base(context)
		{
		}

        public void AddNewPattern(Model.PatternImage pattern)
        {
            var currentYear = DateTime.Now.Year;
            pattern.Year = currentYear;
            ObjectSet.Add(pattern);
        }

        public override Model.PatternImage GetById(string id)
        {
            return ObjectSet.Where(i => i.Id.ToString() == id)
                .FirstOrDefault();
        }
    }
}
