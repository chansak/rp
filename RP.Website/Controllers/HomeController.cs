using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Interfaces;
using RP.Model;
using RP.Website.Models;
using System;
using System.Globalization;
using System.Web.Mvc;


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
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
                var user = userManager.FindByName(model.UserName);
                var result = userManager.CheckPassword(user, model.Password);
                if (result)
                {
                    CurrentUser = user;
                    var roleName = this.CurrentUserRoleName;
                    switch (roleName)
                    {
                        case "Sale":
                            {
                                return RedirectToAction("Index", "Dashboard", new { Area = "Sale" });
                            }
                        case "Backoffice":
                            {
                                return RedirectToAction("Index", "Dashboard", new { Area = "Backoffice" });
                            }
                        case "Manager":
                            {
                                return RedirectToAction("Index", "Dashboard", new { Area = "Manager" });
                            }
                        case "Admin":
                            {
                                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                            }
                        case "SuperAdmin":
                            {
                                return RedirectToAction("Index", "Dashboard", new { Area = "SuperAdmin" });
                            }
                    }
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