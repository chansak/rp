using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class MobilePatternImageViewModel
    {
        public string CustomerId { get; set; }

        //1=print,2=screen,3=sew
        public int PatternType { get; set; }
    }
}