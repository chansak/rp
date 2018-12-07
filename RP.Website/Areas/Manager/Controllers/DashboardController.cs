using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Areas.Manager.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Manager/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}