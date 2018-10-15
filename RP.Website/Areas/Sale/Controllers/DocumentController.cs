﻿using RP.Interfaces;
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
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var documents = GenericFactory.Business.GetDocumentsList();
            int totalCount = documents.Count;
            var result = new List<DocumentListItemViewModel>();
            result.AddRange(documents.Select(d => new DocumentListItemViewModel
            {
                Id = d.Id.ToString(),
                IssueDate = d.IssueDate.Value,
                CustomerType = d.Customer.CustomerType.CustomerTypeName,
                CustomerName = d.Customer.Name,
                DocumentCode = d.FileNumber,
                SaleUserName = "ชาญศักดิ์ คชเสน",
                WorkflowStatus = 1,
                WorkflowStatusName = "ลูกค้าเสนอราคา",
                BiddingStatus = 1,
                BiddingStatusName = "รอยืนยัน",
                ExpiryDate = d.ExpiryDate.Value
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
            var viewModel = new QuotationViewModel
            {
                DocumentCode = document.FileNumber
            };
            return View(viewModel);
        }
    }
}