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
        private UserManager<ApplicationUser> UserManager {
            get {
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
        public ActionResult LogIn(LoginViewModel model)
        {
            var data = new MobileResponseModel();
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

                }
                else
                {
                    data.Status = false;
                    data.ErrorCode = "001";
                    data.ErrorMessage = "";
                    data.MessageId = "";
                    data.TimeStamp = "";
                }
            } catch (Exception ex) {
                data.Status = false;
                data.ErrorCode = "001";
                data.ErrorMessage = ex.Message;
                data.MessageId = "";
                data.TimeStamp = "";
            }
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetWorkList(MobileWorkListSearchCriteria criteria) {
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
            catch (Exception ex) {
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