using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public static class DateJobsExtension
    {
        public static bool HasWeightCalculationJob(this DateTime date) {
            return true;
        }
    }
}
