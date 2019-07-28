using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RP.Interfaces;
using RP.Model;
using RP.Utilities;
using RP.Website.Attributes;
using RP.Website.Extensions;
using RP.Website.Helpers;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RP.Website.Areas.Manager.Controllers
{
    [LoggedOrAuthorized(Roles = Roles.Manager)]
    public class DocumentController : BaseController
    {
        public const string PRINT_NEWPATTERN = "printFile";
        public const string SCREEN_NEWPATTERN = "screenFile";
        public const string SEW_NEWPATTERN = "sewFile";
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

            var documents = GenericFactory.Business.GetDocumentsListBySearch(searchBy, keyword)
                .OrderByDescending(i => i.CreatedDate)
                .ToList();
            int totalCount = documents.Count;
            var result = new List<DocumentListItemViewModel>();
            foreach (var d in documents)
            {
                var documentStatus = (WorkflowStatus)d.DocumentStatusId;
                var statusName = documentStatus.ToWorkFlowStatusName();
                var biddingStatus = (d.BiddingStatusId.HasValue) ? (BiddingStatus)d.BiddingStatusId : BiddingStatus.undefined;
                var biddingStatusName = biddingStatus.ToBiddingStatusName();
                var document = new DocumentListItemViewModel
                {
                    Id = d.Id.ToString(),
                    CustomerType = d.Customer.CustomerType.CustomerTypeName,
                    CustomerName = d.Customer.Name,
                    DocumentCode = d.FileNumber,
                    SaleUserName = d.AspNetUser.DisplayName,
                    WorkflowStatus = (int)d.DocumentStatusId,
                    WorkflowStatusName = statusName,
                    BiddingStatus = (d.BiddingStatusId.HasValue) ? (int)d.BiddingStatusId : 0,
                    BiddingStatusName = biddingStatusName,
                    WeightPoint = d.WeightPoint ?? 0
                };
                result.Add(document);
            }


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<DocumentListItemViewModel>(
                result.OrderByDescending(d => d.WeightPoint).ThenByDescending(o => o.WorkflowStatus).ToList(),
                page ?? 0,
                pageSize,
                totalCount,
                true,
                routeValues);
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
                document.DocumentStatusId = (int)WorkflowStatus.RequestForPrice;
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                Create(document, customerCode);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        [HttpPost]
        public JsonResult CreateDraftDocument(FormCollection formCollection)
        {
            try
            {
                var json = formCollection["document"].ToString().Replace(@"\", "");
                var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                var document = model.ToEntity();
                document.DocumentStatusId = (int)WorkflowStatus.Draft;
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                Create(document, customerCode);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        private void Create(Document document,string customerCode) {
            if (document.DocumentProductItems.Count > 0)
            {
                foreach (var item in document.DocumentProductItems)
                {
                    if (item.ProductItemPrintOptionals.Count > 0)
                    {
                        var printOption = item.ProductItemPrintOptionals.FirstOrDefault();
                        var status = (ItemOptionStatus)printOption.OptionalStatusId;
                        if (status == ItemOptionStatus.NewPattern)
                        {
                            var newPatternId = Guid.NewGuid();
                            printOption.PatternId = newPatternId;
                            HttpPostedFileBase file = Request.Files[PRINT_NEWPATTERN];
                            this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                        }
                    }
                    if (item.ProductItemScreenOptionals.Count > 0)
                    {
                        var screenOption = item.ProductItemScreenOptionals.FirstOrDefault();
                        var status = (ItemOptionStatus)screenOption.OptionalStatusId;
                        if (status == ItemOptionStatus.NewPattern)
                        {
                            var newPatternId = Guid.NewGuid();
                            screenOption.PatternId = newPatternId;
                            HttpPostedFileBase file = Request.Files[SCREEN_NEWPATTERN];
                            this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                        }
                    }
                    if (item.ProductItemSewOptionals.Count > 0)
                    {
                        var sewOption = item.ProductItemSewOptionals.FirstOrDefault();
                        var status = (ItemOptionStatus)sewOption.OptionalStatusId;
                        if (status == ItemOptionStatus.NewPattern)
                        {
                            var newPatternId = Guid.NewGuid();
                            sewOption.PatternId = newPatternId;
                            HttpPostedFileBase file = Request.Files[SEW_NEWPATTERN];
                            this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                        }
                    }
                }
            }
            document.CreatedBy = this.CurrentUser.Id;
            GenericFactory.Business.CreateDocument(document, customerCode);
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
        private bool SaveAttachFiles(string customerId, string patternId, HttpPostedFileBase file)
        {
            try
            {
                var directory = HttpContext.Server.MapPath("~/FileUpload/pattern/");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                var subDirectory = Path.Combine(directory, customerId.ToString());
                if (!Directory.Exists(subDirectory))
                {
                    Directory.CreateDirectory(subDirectory);
                }
                var filesDirectory = Path.Combine(subDirectory, patternId.ToString());
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }
                var path = Path.Combine(filesDirectory, file.FileName);
                file.SaveAs(path);
                GenericFactory.Business.CreateNewPattern(new PatternImage
                {
                    Id = new Guid(patternId),
                    CustomerId = new Guid(customerId),
                    PatternName = file.FileName,
                    PatternImagePath = path
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPost]
        public ActionResult IsExistingItem(string id)
        {
            var item = GenericFactory.Business.GetProductItemByItemId(id);
            var isExisting = (item != null) ? true : false;
            return new JsonCamelCaseResult(isExisting, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateDocument(FormCollection formCollection)
        {
            try
            {
                var json = formCollection["document"].ToString().Replace(@"\", "");
                var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                var document = model.ToEntity();
                document.DocumentStatusId = (int)WorkflowStatus.RequestForPrice;
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                if (document.DocumentProductItems.Count > 0)
                {
                    foreach (var item in document.DocumentProductItems)
                    {
                        if (item.ProductItemPrintOptionals.Count > 0)
                        {
                            var printOption = item.ProductItemPrintOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)printOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                printOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[PRINT_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                        if (item.ProductItemScreenOptionals.Count > 0)
                        {
                            var screenOption = item.ProductItemScreenOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)screenOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                screenOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[SCREEN_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                        if (item.ProductItemSewOptionals.Count > 0)
                        {
                            var sewOption = item.ProductItemSewOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)sewOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                sewOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[SEW_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                    }
                }
                GenericFactory.Business.UpdateDocumentWithMarkDeleteItems(document);

                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        public JsonResult UpdateDocumentWithComments(FormCollection formCollection)
        {
            try
            {
                var json = formCollection["document"].ToString().Replace(@"\", "");
                var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                var document = model.ToEntity();
                document.DocumentStatusId = (int)WorkflowStatus.RequestForPrice;
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                if (document.DocumentProductItems.Count > 0)
                {
                    foreach (var item in document.DocumentProductItems)
                    {
                        if (item.ProductItemPrintOptionals.Count > 0)
                        {
                            var printOption = item.ProductItemPrintOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)printOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                printOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[PRINT_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                        if (item.ProductItemScreenOptionals.Count > 0)
                        {
                            var screenOption = item.ProductItemScreenOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)screenOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                screenOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[SCREEN_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                        if (item.ProductItemSewOptionals.Count > 0)
                        {
                            var sewOption = item.ProductItemSewOptionals.FirstOrDefault();
                            var status = (ItemOptionStatus)sewOption.OptionalStatusId;
                            if (status == ItemOptionStatus.NewPattern)
                            {
                                var newPatternId = Guid.NewGuid();
                                sewOption.PatternId = newPatternId;
                                HttpPostedFileBase file = Request.Files[SEW_NEWPATTERN];
                                this.SaveAttachFiles(document.CustomerId.ToString(), newPatternId.ToString(), file);
                            }
                        }
                    }
                }
                GenericFactory.Business.UpdateDocumentWithMarkDeleteItems(document);

                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        [HttpPost]
        public ActionResult RequestApprove(string id)
        {
            var result = false;
            var document = GenericFactory.Business.GetDocument(id);
            document.DocumentStatusId = (int)WorkflowStatus.RequestedForApproval;
            GenericFactory.Business.UpdateDocumentStatus(document);
            return new JsonCamelCaseResult(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GotPO(string id)
        {
            var result = false;
            var document = GenericFactory.Business.GetDocument(id);
            document.DocumentStatusId = (int)WorkflowStatus.PurchaseOrder;
            GenericFactory.Business.UpdateDocumentStatus(document);
            return new JsonCamelCaseResult(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCurrentWorkflowStatus(string id)
        {
            var document = GenericFactory.Business.GetDocument(id);
            var workflowStatusId = document.DocumentStatusId;
            return new JsonCamelCaseResult(workflowStatusId, JsonRequestBehavior.AllowGet);
        }
    }
}