using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Interfaces;
using RP.Model;
//using RP.Model;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RP.Website.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
                //roleManager.Create(new IdentityRole { Name = "admin" });

                //var user = new ApplicationUser() { UserName = model.UserName };
                //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
                //var result = userManager.Create(user, model.Password);


                //var account = new List<string>();
                //account.Add(model.UserName);
                //Roles.AddUsersToRole(account.ToArray(), "admin");
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
                var user = userManager.FindByName(model.UserName);
                var result = userManager.CheckPassword(user, model.Password);
                if (result)
                {
                    CurrentUser = user;
                    return RedirectToAction("Index", "Document", new { Area = "Sale" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Area = "" });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}