using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerList()
        {
            return View();
        }
        public ActionResult AddNewCustomer() {
            return View();
        }
    }
}