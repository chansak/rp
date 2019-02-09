using RP.Website.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Attributes
{
    public class TokenValidationAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = HttpContext.Current.Request.Headers["Token"];
            if (token != null) {
                return TokenValidator.IsValid(token);
            }
            else
            {
                return false;
            }
        }
    }
}