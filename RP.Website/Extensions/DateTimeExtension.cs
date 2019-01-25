using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public static class DateTimeExtension
    {
        public static string ToDateString(this DateTime date) {
            return date.ToString("dd/MM/yyyy");
        }
    }
}