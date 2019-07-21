﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
    }
}
