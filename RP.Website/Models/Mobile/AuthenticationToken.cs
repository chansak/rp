using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class AuthenticationToken
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}