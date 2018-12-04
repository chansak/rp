using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Model;
using RP.Model.Enum;
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
            get { return Session["CurrentUser"] as ApplicationUser; }
            set { Session["CurrentUser"] = value; }
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
        public UserRoles CurrentUserRole
        {
            get
            {
                UserRoles userRole = UserRoles.undefined ;
                var user = CurrentUser;
                var role = RoleManager.FindById(user.Roles.FirstOrDefault().RoleId);
                switch (role.Name)
                {
                    case "Admin":
                        {
                            userRole = UserRoles.Admin;
                            break;
                        }
                    case "Sale":
                        {
                            userRole = UserRoles.Sale;
                            break;
                        }
                    case "Manager":
                        {
                            userRole = UserRoles.Manager;
                            break;
                        }
                    case "SuperAdmin":
                        {
                            userRole = UserRoles.SuperAdmin;
                            break;
                        }
                    default:
                        {
                            userRole = UserRoles.undefined;
                            break;
                        }
                }
                return userRole;
            }
        }

    }
}