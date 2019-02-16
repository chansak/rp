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
    public class UsersController : BaseController
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

            var users = GenericFactory.Business.GetAllUsers(searchBy, keyword)
                .ToList();

            int totalCount = users.Count;
            var result = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                DisplayName = u.DisplayName,
                RoleName = u.AspNetRoles.FirstOrDefault().Name
            }).OrderBy(o => o.RoleName).ThenBy(o=>o.UserName).ToList();


            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("searchBy", searchBy ?? "");
            routeValues.Add("keyword", keyword ?? "");
            routeValues.Add("sortBy", sortBy ?? "");
            routeValues.Add("direction", direction);
            var list = new PaginatedList<UserViewModel>(result, page ?? 0, pageSize, totalCount, true, routeValues);
            var viewModel = new ListViewModel<UserViewModel>()
            {
                SearchBy = searchBy,
                Keyword = keyword,
                Direction = direction,
                SortBy = sortBy,
                Data = list
            };
            return new JsonCamelCaseResult(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}