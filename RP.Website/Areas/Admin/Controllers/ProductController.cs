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
            var result = data.Select(d => new CategoryViewModel
            {
                Id = d.Id.ToString(),
                Name = d.CategoryName,
            }).OrderBy(o => o.Name).ToList();


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<CategoryViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<CategoryViewModel>()
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
        public JsonResult CreateCategory(CategoryViewModel model)
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
        public ActionResult UpdateCategory(CategoryViewModel model) {
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
        public ActionResult DeleteCategory(string id) {
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
    }
}