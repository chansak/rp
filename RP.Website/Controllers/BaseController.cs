using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website
{
    public class BaseController : Controller
    {
        private RoleManager<IdentityRole> RoleManager {
            get {
                return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
            }
        }
        public ApplicationUser CurrentUser
        {
            get {
                return Session["CurrentUser"] as ApplicationUser;
            }
            set {
                Session["CurrentUser"] = value;
                Session["CurrentRoleName"] = CurrentUserRoleName;
            }
        }
        public string CurrentUserRoleName
        {
            get
            {
                var user = CurrentUser;
                var role = RoleManager.FindById(user.Roles.FirstOrDefault().RoleId);
                return role.Name;
            }
        }
    }
}