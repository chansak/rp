﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Controllers
{
    public class QuotationController : Controller
    {
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNew() {
            return View();
        }
    }
}