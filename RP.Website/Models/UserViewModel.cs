using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string RoleName { get; set; }
    }
}