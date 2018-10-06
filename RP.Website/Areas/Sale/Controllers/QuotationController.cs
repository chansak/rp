using RP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Areas.Sale.Controllers
{
    public class QuotationController : Controller
    {
        public ActionResult Index()
        {
            var documents = GenericFactory.Business.GetDocumentsList();
            return View();
        }
        public ActionResult AddNew() {
            return View();
        }
        public ActionResult Edit(string id) {
            var document = GenericFactory.Business.GetDocument(id);
            return View();
        }
    }
}