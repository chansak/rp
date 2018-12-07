using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace RP.Website.Attributes
{
    public class LoggedOrAuthorizedAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public LoggedOrAuthorizedAttribute()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Match = false;
            var user = httpContext.Session["CurrentUser"] as ApplicationUser;
            var userRole = httpContext.Session["CurrentRoleName"] as string;
            var authorizedRoles = this.Roles.Split(',');
            if (user != null && userRole != null)
            {
                foreach (var role in authorizedRoles)
                {
                    if (userRole == role)
                    {
                        Match = true;
                        break;
                    }
                }
            }
            return Match;
        }
    }
}