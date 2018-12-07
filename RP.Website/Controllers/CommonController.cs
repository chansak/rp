using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Interfaces;
using RP.Utilities;
using RP.Website.Enum;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult GetSaleUsers()
        {
            var result = new AjaxResultModel();
            var users = GenericFactory.Business.GetSaleUsersList();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
            var role = roleManager.FindByName(Roles.Sale);
            var data = new List<SaleUserViewModel>();
            foreach (var user in users)
            {
                var roles = user.AspNetRoles.ToList();
                if (roles.Where(i => i.Id == role.Id).Count() > 0)
                {
                    data.AddRange(users.Select(u => new SaleUserViewModel
                    {
                        Id = u.Id.ToString(),
                        Name = u.DisplayName,
                    }));
                }
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomers()
        {
            var result = new AjaxResultModel();
            var customers = GenericFactory.Business.GetCustomersList();
            var data = new List<CustomerViewModel>();
            data.AddRange(customers.Select(c => new CustomerViewModel
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                HospitalName = c.CustomerBranches.FirstOrDefault().CustomerBranchName,
                CustomerTypeName = c.CustomerType.CustomerTypeName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetContactByCustomerId(string id)
        {
            var result = new AjaxResultModel();
            var contacts = GenericFactory.Business.GetContactByCustomerId(id);
            var data = new List<ContactViewModel>();
            data.AddRange(contacts.Select(c => new ContactViewModel
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email,
                Fax = c.Fax,
                Mobile = c.Mobile
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductCategories()
        {
            var result = new AjaxResultModel();
            var categories = GenericFactory.Business.GetProductCategories();
            var data = new List<ProductCategoryViewModel>();
            data.AddRange(categories.Select(c => new ProductCategoryViewModel
            {
                Id = c.Id.ToString(),
                CategoryName = c.CategoryName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductsByCategoryId(string id)
        {
            var result = new AjaxResultModel();
            var products = GenericFactory.Business.GetProductsByCategoryId(id);
            var data = new List<ProductViewModel>();
            data.AddRange(products.Select(p => new ProductViewModel
            {
                Id = p.Id.ToString(),
                ProductCode = p.ProductCode,
                ProductName = p.Name
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetOptionsByProductId(string id)
        {
            var result = new AjaxResultModel();
            var products = GenericFactory.Business.GetOptionsByProductId(id);
            var data = new List<ProductOptionViewModel>();
            data.AddRange(products.Select(o => new ProductOptionViewModel
            {
                Id = o.Id.ToString(),
                OptionName = o.OptionName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUnitsByProductId(string id)
        {
            var result = new AjaxResultModel();
            var units = GenericFactory.Business.GetUnitsByProductId(id);
            var data = new List<UnitViewModel>();
            data.AddRange(units.Select(u => new UnitViewModel
            {
                Id = u.UnitId.ToString(),
                UnitName = u.Unit.UnitName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMaterialStockCheck(string productId, string productUnitId, string materialId, int amount)
        {
            var result = new AjaxResultModel();
            var data = new List<StockCheckViewModel>();
            var material = GenericFactory.Business.GetMaterialUsageByProductId(productId, productUnitId).FirstOrDefault();
            var selectedMaterial = GenericFactory.Business.GetMaterialById(materialId);
            var stock = GenericFactory.Business.GetStockCheck(AppSettingHelper.GetDefaultWarehouseId, materialId, material.MaterialUnitId.ToString()).FirstOrDefault();
            if (stock != null)
            {
                var usageAmount = material.Amount.Value;
                var totalAmount = stock.Amount.Value;
                data.Add(new StockCheckViewModel
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
                data.Add(new StockCheckViewModel
                {
                    MaterialName = selectedMaterial.Name,
                    MaterialInStock = 0,
                    MaterialUsaged = (usageAmount * amount),
                    MaterialInStockAfterWithdraw = (totalAmount - (usageAmount * amount))
                });
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPatternImages()
        {
            var result = new AjaxResultModel();
            var patterns = GenericFactory.Business.GetPatternImage();
            var data = new List<PatternImageViewModel>();
            foreach (var p1 in patterns)
            {
                var path = string.Format(@"../../../FileUpload/{0}",
                                                p1.PatternImagePath.Replace(@"\", @"/")
                                                .Split(new string[] { @"FileUpload" }, StringSplitOptions.None)[1]
                                                .Remove(0, 1));
                data.Add(new PatternImageViewModel
                {
                    Id = p1.Id.ToString(),
                    PatternName = p1.PatternName,
                    ImagePath = path
                });
            }

            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPatternPosition()
        {
            var result = new AjaxResultModel();
            var positions = GenericFactory.Business.GetPatternPosition();
            var data = new List<PatternPositionViewModel>();
            data.AddRange(positions.Select(p => new PatternPositionViewModel
            {
                Id = p.Id.ToString(),
                PositionName = p.PositionName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPatternColors()
        {
            var result = new AjaxResultModel();
            var positions = GenericFactory.Business.GetPatternColor();
            var data = new List<PatternColorViewModel>();
            data.AddRange(positions.Select(p => new PatternColorViewModel
            {
                Id = p.Id.ToString(),
                ColorCode = p.ColorCode,
                ColorName = p.ColorName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerById(string id)
        {
            try
            {
                var customer = GenericFactory.Business.GetCustomerById(id);
                var data = customer.ToViewModel();
                return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return new JsonCamelCaseResult(null, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetContactById(string id)
        {
            var contact = GenericFactory.Business.GetContactById(id);
            var data = contact.ToViewModel();
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSaleUserById(string id)
        {
            var user = GenericFactory.Business.GetSaleUserById(id);
            var data = user.ToViewModel();
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMaterials()
        {
            var materials = GenericFactory.Business.GetMaterials();
            var data = new List<MaterialViewModel>();
            data.AddRange(materials.Select(m => new MaterialViewModel
            {
                Id = m.Id.ToString(),
                MaterialName = m.Name
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductItemByItemId(string id)
        {
            var item = GenericFactory.Business.GetProductItemByItemId(id);
            var data = item.ToViewModel();
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerBranchByCustomerId(string id)
        {
            try
            {
                var customerBranches = GenericFactory.Business.GetCustomerBranches(id);
                var data = customerBranches.Select(i => new
                {
                    Id = i.Id.ToString(),
                    BranchName = i.CustomerBranchName
                });
                return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return new JsonCamelCaseResult(null, JsonRequestBehavior.AllowGet);
        }
    }
}