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
            int totalCount = 100;
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var documents = GenericFactory.Business.GetDocumentsList();
            var result = new List<DocumentListItemViewModel>();
            result.AddRange(documents.Select(t => new DocumentListItemViewModel
            {
                Id = t.Id.ToString(),
                IssueDate = t.IssueDate.Value,
                DocumentCode = t.FileNumber,
                CustomerCode = t.Customer.Name,
                CustomerName = t.Customer.Name,
                TotalAmount = 0,
                DocumentStatusName = 0,
                ExpiryDate = t.ExpiryDate.Value
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
            return View(viewModel);
        }
        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            var document = GenericFactory.Business.GetDocument(id);
            var viewModel = new QuotationViewModel {
                DocumentCode = document.FileNumber
            };
            return View(viewModel);
        }
    }
}