using RP.Interfaces;
using RP.Model;
using RP.Utilities;
using RP.Website.Extensions;
using RP.Website.Helpers;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RP.Website.Areas.Manager.Controllers
{
    public class ApprovalDocumentController : Controller
    {
        public ActionResult Index(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            return View();
        }
        public ActionResult Search(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var documents = GenericFactory.Business.GetApprovalDocumentsListBySearch(searchBy, keyword)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
            int totalCount = documents.Count;
            var result = new List<DocumentListItemViewModel>();
            foreach (var d in documents)
            {
                var documentStatus = (WorkflowStatus)d.DocumentStatusId;
                var statusName = documentStatus.ToWorkFlowStatusName();
                var document = new DocumentListItemViewModel
                {
                    Id = d.Id.ToString(),
                    CustomerType = d.Customer.CustomerType.CustomerTypeName,
                    CustomerName = d.Customer.Name,
                    DocumentCode = d.FileNumber,
                    SaleUserName = d.User.DisplayName,
                    WorkflowStatus = (int)d.DocumentStatusId,
                    WorkflowStatusName = statusName,
                    BiddingStatus = (int)d.BiddingStatusId,
                    BiddingStatusName = "รอยืนยัน",
                };
                result.Add(document);
            }


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
        public ActionResult Read(string id)
        {
            ViewBag.DocumentId = id;
            return View();
        }
        [HttpPost]
        public ActionResult ApprovedRequest(string id)
        {
            var result = false;
            var document = GenericFactory.Business.GetDocument(id);
            document.DocumentStatusId = (int)WorkflowStatus.Approved;
            GenericFactory.Business.UpdateDocumentStatus(document);
            return new JsonCamelCaseResult(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RejectedRequest(string id)
        {
            var result = false;
            var document = GenericFactory.Business.GetDocument(id);
            document.DocumentStatusId = (int)WorkflowStatus.RequestForMoreInfoForBackoffice;
            GenericFactory.Business.UpdateDocumentStatus(document);
            return new JsonCamelCaseResult(result, JsonRequestBehavior.AllowGet);
        }
    }
}