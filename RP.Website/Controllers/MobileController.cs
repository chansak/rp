using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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


namespace RP.Website.Controllers
{
    public class MobileController : Controller
    {
        public const string PRINT_NEWPATTERN = "printFile";
        public const string SCREEN_NEWPATTERN = "screenFile";
        public const string SEW_NEWPATTERN = "sewFile";

        #region Public services
        private UserManager<ApplicationUser> UserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
            }

        }
        private RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
            }
        }
        public string CurrentUserId
        {
            get
            {
                var token = HttpContext.Request.Headers["Token"];
                var cacheToken = (AuthenticationToken)GlobalCachingProvider.Instance.GetItem(token);
                return cacheToken.UserId;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginViewModel model)
        {
            var data = new MobileWithTokenResponseModel();
            var response = new AuthenticationToken();
            try
            {
                var user = UserManager.FindByName(model.UserName);
                var result = UserManager.CheckPassword(user, model.Password);
                if (result)
                {
                    var role = RoleManager.FindById(user.Roles.FirstOrDefault().RoleId);
                    data.Datas = new MobileUserAccountViewModel
                    {
                        Id = user.Id,
                        DisplayName = user.DisplayName,
                        RoleName = role.Name
                    };
                    data.Token = new TokenBuilder().Build(new Credentials { UserId = user.Id, UserName = model.UserName, Password = model.Password });
                }
                else
                {
                    data.Status = false;
                    data.ErrorCode = "001";
                    data.ErrorMessage = "";
                    data.MessageId = "";
                    data.TimeStamp = "";
                }
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult GetWorkList(MobileWorkListSearchCriteria criteria)
        {
            var data = new MobileResponseModel();
            int pageSize = AppSettingHelper.PageSize;
            try
            {
                if (!string.IsNullOrWhiteSpace(criteria.Keyword))
                {
                    criteria.Keyword = criteria.Keyword.Trim();
                }

                var items = GenericFactory.Business.GetDocumentsListBySearch(criteria.SearchBy, criteria.Keyword, criteria.UserId)
                    .OrderByDescending(i => i.CreatedDate)
                    .ToList();
                var allowedStatus = new List<int>();
                allowedStatus.Add((int)WorkflowStatus.Draft);
                allowedStatus.Add((int)WorkflowStatus.RequestForMoreInfoForSale);
                var documents = items.Where(i => allowedStatus.Contains(i.DocumentStatusId.Value)).ToList();
                int totalCount = documents.Count;
                var result = new List<DocumentListItemViewModel>();
                foreach (var d in documents)
                {
                    var documentStatus = (WorkflowStatus)d.DocumentStatusId;
                    var statusName = documentStatus.ToWorkFlowStatusName();
                    var biddingStatus = (d.BiddingStatusId.HasValue) ?(BiddingStatus)d.BiddingStatusId:BiddingStatus.undefined;
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
                        BiddingStatus = (d.BiddingStatusId.HasValue)? (int)d.BiddingStatusId:0,
                        BiddingStatusName = biddingStatusName,
                    };
                    result.Add(document);
                }
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetCustomers()
        {
            var data = new MobileResponseModel();
            try
            {
                var items = GenericFactory.Business.GetCustomersList();
                var result = new List<CustomerViewModel>();
                result.AddRange(items.Select(c => new CustomerViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    HospitalName = c.CustomerBranches.FirstOrDefault().CustomerBranchName,
                    CustomerTypeName = c.CustomerType.CustomerTypeName
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetFabricType()
        {
            var data = new MobileResponseModel();
            try
            {
                var materials = GenericFactory.Business.GetMaterials();
                var result = new List<MaterialViewModel>();
                result.AddRange(materials.Select(m => new MaterialViewModel
                {
                    Id = m.Id.ToString(),
                    MaterialName = m.Name
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetCustomerBranchByCustomerId(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var customerBranches = GenericFactory.Business.GetCustomerBranches(id);
                var result = customerBranches.Select(i => new
                {
                    Id = i.Id.ToString(),
                    BranchName = i.CustomerBranchName
                });
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetContact(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var contacts = GenericFactory.Business.GetContactByCustomerId(id);
                var result = new List<ContactViewModel>();
                result.AddRange(contacts.Select(c => new ContactViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    Fax = c.Fax,
                    Mobile = c.Mobile
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetCategoriesProduct()
        {
            var data = new MobileResponseModel();
            try
            {
                var categories = GenericFactory.Business.GetProductCategories();
                var result = new List<ProductCategoryViewModel>();
                result.AddRange(categories.Select(c => new ProductCategoryViewModel
                {
                    Id = c.Id.ToString(),
                    CategoryName = c.CategoryName
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetProducts(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var products = GenericFactory.Business.GetProductsByCategoryId(id);
                var result = new List<ProductViewModel>();
                result.AddRange(products.Select(p => new ProductViewModel
                {
                    Id = p.Id.ToString(),
                    ProductCode = p.ProductCode,
                    ProductName = p.Name
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetUnitByProduct(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var units = GenericFactory.Business.GetUnitsByProductId(id);
                var result = new List<UnitViewModel>();
                result.AddRange(units.Select(u => new UnitViewModel
                {
                    Id = u.UnitId.ToString(),
                    UnitName = u.Unit.UnitName
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult CheckStock(MobileCalculateDateViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                var productId = model.ProductId;
                var productUnitId = model.ProductUnitId;
                var materialId = model.MaterialId;
                var amount = model.Amount;
                var result = new List<StockCheckViewModel>();
                var material = GenericFactory.Business.GetMaterialUsageByProductId(productId, productUnitId).FirstOrDefault();
                var selectedMaterial = GenericFactory.Business.GetMaterialById(materialId);
                var stock = GenericFactory.Business.GetStockCheck(AppSettingHelper.GetDefaultWarehouseId, materialId, material.MaterialUnitId.ToString()).FirstOrDefault();
                if (stock != null)
                {
                    var usageAmount = material.Amount.Value;
                    var totalAmount = stock.Amount.Value;
                    result.Add(new StockCheckViewModel
                    {
                        MaterialName = string.Format("{0}", stock.Material.Name, stock.Material.MaterialCode),
                        MaterialInStock = totalAmount,
                        MaterialUsaged = (usageAmount * amount),
                        MaterialInStockAfterWithdraw = (totalAmount - (usageAmount * amount))
                    });
                }
                else
                {
                    var usageAmount = material.Amount.Value;
                    var totalAmount = 0;
                    result.Add(new StockCheckViewModel
                    {
                        MaterialName = selectedMaterial.Name,
                        MaterialInStock = 0,
                        MaterialUsaged = (usageAmount * amount),
                        MaterialInStockAfterWithdraw = (totalAmount - (usageAmount * amount))
                    });
                }
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetOptionsByProductId(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var products = GenericFactory.Business.GetOptionsByProductId(id);
                var result = new List<ProductOptionViewModel>();
                result.AddRange(products.Select(o => new ProductOptionViewModel
                {
                    Id = o.Id.ToString(),
                    OptionName = o.OptionName
                }));
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult AddOrUpdateDocument(FormCollection formCollection)
        {
            var data = new MobileResponseModel();
            try
            {
                var json = formCollection["document"].ToString().Replace(@"\", "");
                var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                var document = model.ToEntity();
                document.BiddingStatusId = model.IsDraft ? (int)WorkflowStatus.Draft : (int)WorkflowStatus.RequestForPrice;
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                if (string.IsNullOrEmpty(document.Id.ToString()))
                {
                    //Insert
                    this.CreateDocument(document, customerCode);
                }
                else
                {
                    //Update
                    this.UpdateDocument(document, customerCode);
                }
                data.Datas = new
                {
                    Id = document.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetDocumentDetail(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(id);
                var result = document.ToViewModel();
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [TokenValidation]
        public ActionResult UpdateLocation(LocationTrackingViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                GenericFactory.Business.UpdateLocation(new LocationTracking
                {
                    Id = Guid.NewGuid(),
                    UserId = model.UserId,
                    Latitude = Decimal.Parse(model.Location.Lat),
                    Longitude = decimal.Parse(model.Location.Long),
                    TimeStamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [TokenValidation]
        public ActionResult GetProductItemsByDocumentId(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(id);
                var result = document.DocumentProductItems.Where(i => !i.IsDeleted).Select(i => i.ToViewModel()).ToList();
                data.Datas = result;
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";

            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult AddOrUpdateGeneralAndSaleInfo(GeneralAndSaleInfoViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(model.Id);
                var customerCode = "";
                if (document != null)
                {
                    document.BiddingStatusId = model.IsDraft ? (int)WorkflowStatus.Draft : (int)WorkflowStatus.RequestForPrice;
                    document.ExpiryDate = model.ExpirationDate;
                    document.UserId = model.SaleUserId;
                    document.CustomerId = new Guid(AppSettingHelper.DummyCustomerId);
                    document.ContactId = new Guid(AppSettingHelper.DummyContactId);
                    this.UpdateDocument(document, customerCode);
                }
                else
                {
                    var _documentId = Guid.NewGuid();
                    document = new Document
                    {
                        Id = _documentId,
                        DocumentStatusId = model.IsDraft ? (int)WorkflowStatus.Draft : (int)WorkflowStatus.RequestForPrice,
                        ExpiryDate = model.ExpirationDate,
                        UserId = model.SaleUserId,
                        CustomerId = new Guid(AppSettingHelper.DummyCustomerId),
                        ContactId = new Guid(AppSettingHelper.DummyContactId)
                    };
                    var delivery = new DocumentDelivery
                    {
                        Id = Guid.NewGuid(),
                        DocumentId = _documentId,
                        Address1 = ""
                    };
                    document.DocumentDeliveries.Add(delivery);
                    this.CreateDocument(document, customerCode);
                }
                data.Datas = new
                {
                    Id = document.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult AddOrUpdateCustomerAndContact(CustomerAndContactViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(model.Id);
                var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
                document.BiddingStatusId = model.IsDraft ? (int)WorkflowStatus.Draft : (int)WorkflowStatus.RequestForPrice;
                document.CustomerId = new Guid(model.CustomerId);
                document.ContactId = new Guid(model.ContactId);
                this.UpdateDocument(document, customerCode);

                data.Datas = new
                {
                    Id = document.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult AddOrUpdateProductItem(ProductAndOptionViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                //var json = formCollection["document"].ToString().Replace(@"\", "");
                //var model = JsonConvert.DeserializeObject<ProductAndOptionViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                if (model.ItemId != null)
                {
                    GenericFactory.Business.MarkDeleteProductItemByItemId(model.ItemId);
                }
                var document = GenericFactory.Business.GetDocument(model.Id);
                document.DocumentProductItems.Add(model.ToViewModel());
                this.UpdateDocument(document, document.FileNumber);

                data.Datas = new
                {
                    Id = document.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public ActionResult AddOrUpdateDelivery(DeliveryViewModel model)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(model.Id);
                document.DocumentDeliveries.FirstOrDefault().Address1 = model.DeliveryAddress;
                this.UpdateDocument(document, document.FileNumber);

                data.Datas = new
                {
                    Id = document.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [TokenValidation]
        public void DeleteDocument(string id)
        {
            var data = new MobileResponseModel();
            try
            {
                var document = GenericFactory.Business.GetDocument(id);
                if (document != null)
                {
                    document.IsDelete = true;
                    this.UpdateDocument(document, document.FileNumber);
                }
            }
            catch (Exception ex)
            {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            //return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region Private method
        private JsonResult CreateDocument(Document document, string customerCode)
        {
            try
            {
                Create(document, customerCode);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        private JsonResult UpdateDocument(Document document, string customerCode)
        {
            try
            {
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
                GenericFactory.Business.UpdateDocument(document);

                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        private void Create(Document document, string customerCode)
        {
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
            document.CreatedBy = this.CurrentUserId;
            GenericFactory.Business.CreateDocument(document, customerCode);
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
        #endregion

        #region OBSOLETE
        //[HttpPost]
        //[TokenValidation]
        //public ActionResult CreateDraftDocument(DocumentViewModel model)
        //{
        //    var data = new MobileResponseModel();
        //    try
        //    {
        //        var document = model.ToEntity();
        //        document.DocumentStatusId = (int)WorkflowStatus.Draft;
        //        var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
        //        Create(document, customerCode);
        //        data.Datas = new
        //        {
        //            documentId = document.Id
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        data.Status = false;
        //        data.ErrorCode = "001";
        //        data.ErrorMessage = ex.Message;
        //        data.MessageId = "";
        //        data.TimeStamp = "";
        //    }
        //    return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        //}
        //private JsonResult CreateDraftDocument(FormCollection formCollection)
        //{
        //    try
        //    {
        //        var json = formCollection["document"].ToString().Replace(@"\", "");
        //        var model = JsonConvert.DeserializeObject<DocumentViewModel>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
        //        var document = model.ToEntity();
        //        document.DocumentStatusId = (int)WorkflowStatus.Draft;
        //        var customerCode = GenericFactory.Business.GetCustomerById(model.CustomerId).CustomerCode;
        //        Create(document, customerCode);
        //        return Json("");
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message;
        //    }
        //    return Json(null);
        //}
        #endregion
    }
}