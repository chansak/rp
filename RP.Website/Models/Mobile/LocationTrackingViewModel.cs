using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class LocationTrackingViewModel
    {
        public string UserId { get; set; }
        public Location Location { get; set; }
    }
    public class Location {
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}