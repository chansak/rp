using AutoMapper;
using RP.Interfaces;
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
    public class HomeController : Controller
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
                return RedirectToAction("Index", "Document", new { Area = "Sale" });
            }
            catch (Exception ex) {
                var msg = ex.Message;
            }
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}