
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Interfaces;
using RP.Model;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace RP.Website.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            try
            {
                //Add Role
                //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
                //roleManager.Create(new IdentityRole { Name = "admin" });

                var roles = model.Roles;
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = GenericFactory.Business.AddNewUser(user, model.Password, roles.FirstOrDefault());
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}