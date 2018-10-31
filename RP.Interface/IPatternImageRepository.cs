using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IPatternImageRepository : IRepository<RP.Model.PatternImage>
	{
        void AddNewPattern(PatternImage pattern);

    }
}
