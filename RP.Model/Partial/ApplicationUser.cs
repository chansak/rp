using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
