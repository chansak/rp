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
                    data.Token = new TokenBuilder().Build(new Credentials { User = model.UserName, Password = model.Password });
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
                    var document = new DocumentListItemViewModel
                    {
                        Id = d.Id.ToString(),
                        CustomerType = d.Customer.CustomerType.CustomerTypeName,
                        CustomerName = d.Customer.Name,
                        DocumentCode = d.FileNumber,
                        SaleUserName = d.AspNetUser.DisplayName,
                        WorkflowStatus = (int)d.DocumentStatusId,
                        WorkflowStatusName = statusName,
                        BiddingStatus = (int)d.BiddingStatusId,
                        BiddingStatusName = "รอยืนยัน",
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
    }
}