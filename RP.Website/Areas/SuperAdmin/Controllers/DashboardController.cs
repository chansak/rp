using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Areas.SuperAdmin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: SuperAdmin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}