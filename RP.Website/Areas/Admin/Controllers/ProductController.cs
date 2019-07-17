using RP.Interfaces;
using RP.Utilities;
using RP.Website.Attributes;
using RP.Website.Helpers;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RP.Website.Areas.Admin.Controllers
{
    [LoggedOrAuthorized(Roles = Roles.Admin)]
    public class ProductController : BaseController
    {
        #region Product Category
        public ActionResult CategoryList(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            return View("~/Areas/Admin/Views/ProductCategory/Index.cshtml");
        }
        public ActionResult SearchCategory(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var data = GenericFactory.Business.GetAllProductCategories(searchBy, keyword)
                .ToList();

            int totalCount = data.Count;
            var result = data.Select(d => new ProductCategoryViewModel
            {
                Id = d.Id.ToString(),
                CategoryName = d.CategoryName,
            }).OrderBy(o => o.CategoryName).ToList();


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<ProductCategoryViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<ProductCategoryViewModel>()
            {
                SearchBy = searchBy,
                Keyword = keyword,
                Direction = direction,
                SortBy = sortBy,
                Data = list
            };
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNewCategory()
        {
            return View("~/Areas/Admin/Views/ProductCategory/AddNew.cshtml");
        }
        [HttpPost]
        public JsonResult CreateCategory(ProductCategoryViewModel model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();
                var category = model.ToEntity();
                GenericFactory.Business.CreateCategory(category);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        public ActionResult EditCategory(string id)
        {
            ViewBag.Id = id;
            return View("~/Areas/Admin/Views/ProductCategory/Edit.cshtml");
        }
        [HttpPost]
        public ActionResult GetCategoryById(string id)
        {
            var data = GenericFactory.Business.GetCategoryById(id);
            var category = data.ToViewModel();
            return new JsonCamelCaseResult(category, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateCategory(ProductCategoryViewModel model)
        {
            try
            {
                var category = model.ToEntity();
                GenericFactory.Business.UpdateCategory(category);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        [HttpPost]
        public ActionResult DeleteCategory(string id)
        {
            try
            {
                GenericFactory.Business.DeleteCategoryById(id);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        #endregion

        #region Product
        public ActionResult ProductList(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            return View("~/Areas/Admin/Views/Product/Index.cshtml");
        }
        public ActionResult SearchProduct(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var data = GenericFactory.Business.GetAllProducts(searchBy, keyword)
                .ToList();

            int totalCount = data.Count;
            var result = data.Select(d => new ProductViewModel
            {
                Id = d.Id.ToString(),
                ProductName = d.Name,
                ProductCategoryName = d.ProductCategory.CategoryName,
            }).OrderBy(o => o.ProductName).ToList();


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<ProductViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<ProductViewModel>()
            {
                SearchBy = searchBy,
                Keyword = keyword,
                Direction = direction,
                SortBy = sortBy,
                Data = list
            };
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNewProduct()
        {
            return View("~/Areas/Admin/Views/Product/AddNew.cshtml");
        }
        [HttpPost]
        public JsonResult CreateProduct(ProductViewModel model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();
                var product = model.ToEntity();
                GenericFactory.Business.CreateProduct(product);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        public ActionResult EditProduct(string id)
        {
            ViewBag.Id = id;
            return View("~/Areas/Admin/Views/Product/Edit.cshtml");
        }
        [HttpPost]
        public ActionResult GetProductById(string id)
        {
            var data = GenericFactory.Business.GetProductsById(id);
            var product = data.ToViewModel();
            return new JsonCamelCaseResult(product, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductViewModel model)
        {
            try
            {
                var product = model.ToEntity();
                GenericFactory.Business.UpdateProduct(product);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        [HttpPost]
        public ActionResult DeleteProduct(string id)
        {
            try
            {
                GenericFactory.Business.DeleteProductById(id);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        #endregion

        #region Product Option
        public ActionResult ProductOptionList(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            return View("~/Areas/Admin/Views/ProductOption/Index.cshtml");
        }
        public ActionResult SearchProductOption(string searchBy, string keyword, string sortBy, string direction, int? page)
        {
            int pageSize = AppSettingHelper.PageSize;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
            }

            var data = GenericFactory.Business.GetAllProductOptions(searchBy, keyword)
                .ToList();

            int totalCount = data.Count;
            var result = data.Select(d => new ProductOptionViewModel
            {
                Id = d.Id.ToString(),
                OptionName = d.OptionName,
                ProductId = d.ProductId.ToString(),
                ProductName = d.Product.Name,
                ProductCategoryId = d.Product.ProductCategoryId.ToString(),
                ProductCategoryName = d.Product.ProductCategory.CategoryName
            }).OrderBy(o => o.ProductCategoryName).ThenBy(o => o.ProductName).ThenBy(o=>o.OptionName).ToList();


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<ProductOptionViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<ProductOptionViewModel>()
            {
                SearchBy = searchBy,
                Keyword = keyword,
                Direction = direction,
                SortBy = sortBy,
                Data = list
            };
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNewProductOption()
        {
            return View("~/Areas/Admin/Views/ProductOption/AddNew.cshtml");
        }
        [HttpPost]
        public JsonResult CreateProductOption(ProductOptionViewModel model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();
                var option = model.ToEntity();
                GenericFactory.Business.CreateProductOption(option);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        public ActionResult EditProductOption(string id)
        {
            ViewBag.Id = id;
            return View("~/Areas/Admin/Views/ProductOption/Edit.cshtml");
        }
        [HttpPost]
        public ActionResult GetProductOptionById(string id)
        {
            var data = GenericFactory.Business.GetProductOptionById(id);
            var option = data.ToViewModel();
            return new JsonCamelCaseResult(option, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateProductOption(ProductOptionViewModel model)
        {
            try
            {
                var option = model.ToEntity();
                GenericFactory.Business.UpdateProductOption(option);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        [HttpPost]
        public ActionResult DeleteProductOption(string id)
        {
            try
            {
                GenericFactory.Business.DeleteProductOptionById(id);
                return Json("");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return Json(null);
        }
        #endregion
    }
}