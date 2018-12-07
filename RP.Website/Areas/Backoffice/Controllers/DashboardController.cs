using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Areas.Backoffice.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Backoffice/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}