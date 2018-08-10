using AutoMapper;
using RP.Interfaces;
using RP.Model;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RP.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/home/getTransportDetail/{id}")]
        public ActionResult GetTransportDetail(int id)
        {
            var transport = GenericFactory.Business.GetTransportById(id);
            return new JsonCamelCaseResult(transport.ToViewModel(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("/home/postTest")]
        public ActionResult PostTest(TestViewModel model) {
            //Content-Type : application/json
            return new JsonCamelCaseResult(null,JsonRequestBehavior.AllowGet);
        }
    }
}