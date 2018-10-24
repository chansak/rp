using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RP.Interfaces;
using RP.Utilities;
using RP.Website.Helpers;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RP.Website.Areas.Sale.Controllers
{
    public class DocumentController : Controller
    {
        public ActionResult Index(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            //int pageSize = AppSettingHelper.PageSize;
            //if (!string.IsNullOrWhiteSpace(keyword))
            //{
            //    keyword = keyword.Trim();
            //}

            //var documents = GenericFactory.Business.GetDocumentsList()
            //    .OrderByDescending(i=>i.CreatedDate)
            //    .ToList();
            //int totalCount = documents.Count;
            //var result = new List<DocumentListItemViewModel>();
            //result.AddRange(documents.Select(d => new DocumentListItemViewModel
            //{
            //    Id = d.Id.ToString(),
            //    IssueDate = d.IssueDate,
            //    CustomerType = d.Customer.CustomerType.CustomerTypeName,
            //    CustomerName = d.Customer.Name,
            //    DocumentCode = d.FileNumber,
            //    SaleUserName = d.Customer.Name,
            //    WorkflowStatus = (int)d.DocumentStatusId,
            //    WorkflowStatusName = "ลูกค้าเสนอราคา",
            //    BiddingStatus = (int)d.BiddingStatusId,
            //    BiddingStatusName = "รอยืนยัน",
            //    ExpiryDate = d.ExpiryDate
            //}));


            //RouteValueDictionary routeValues = new RouteValueDictionary();
            //routeValues.Add("searchBy", searchBy ?? "");
            //routeValues.Add("keyword", keyword ?? "");
            //routeValues.Add("sortBy", sortBy ?? "");
            //routeValues.Add("direction", direction);
            //var list = new PaginatedList<DocumentListItemViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            //var viewModel = new ListViewModel<DocumentListItemViewModel>()
            //{
            //    SearchBy = searchBy,
            //    Keyword = keyword,
            //    Direction = direction,
            //    SortBy = sortBy,
            //    Data = list
            //};
            //return View(viewModel);
            return View();
        }
        public ActionResult Search(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var documents = GenericFactory.Business.GetDocumentsListBySearch(searchBy, keyword)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
            int totalCount = documents.Count;
            var result = new List<DocumentListItemViewModel>();
            result.AddRange(documents.Select(d => new DocumentListItemViewModel
            {
                Id = d.Id.ToString(),
                IssueDate = d.IssueDate,
                CustomerType = d.Customer.CustomerType.CustomerTypeName,
                CustomerName = d.Customer.Name,
                DocumentCode = d.FileNumber,
                SaleUserName = d.Customer.Name,
                WorkflowStatus = (int)d.DocumentStatusId,
                WorkflowStatusName = "ลูกค้าเสนอราคา",
                BiddingStatus = (int)d.BiddingStatusId,
                BiddingStatusName = "รอยืนยัน",
                ExpiryDate = d.ExpiryDate
            }));


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<DocumentListItemViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<DocumentListItemViewModel>()
            {
                SearchBy = searchBy,
                Keyword = keyword,
                Direction = direction,
                SortBy = sortBy,
                Data = list
            };
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateDocument(FormCollection formCollection)
        {
            try
            {
                var json = formCollection["document"].ToString().Replace(@"\", "");
                var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                var document = model.ToEntity();
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                GenericFactory.Business.CreateDocument(document, customerCode);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        public ActionResult Edit(string id)
        {
            ViewBag.DocumentId = id;
            return View();
        }
        [HttpPost]
        public ActionResult GetDocumentDetail(string id)
        {
            var document = GenericFactory.Business.GetDocument(id);
            var viewModel = document.ToViewModel();
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}