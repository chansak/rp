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
    }
}