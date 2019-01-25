using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RP.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Routing
            routes.MapRoute("mobileLogin",
                "api/Login",
                new { controller = "Mobile", action = "Login" }
            );
            routes.MapRoute("GetWorkList",
                "api/getWorkList",
                new { controller = "Mobile", action = "GetWorkList" }
            );
            routes.MapRoute("GetCustomers",
                "api/getCustomer",
                new { controller = "Mobile", action = "GetCustomers" }
            );
            routes.MapRoute("getCategoriesProduct",
                "api/getCategoriesProduct",
                new { controller = "Mobile", action = "GetCategoriesProduct" }
            );
            routes.MapRoute("GetFabricType",
                "api/getFabricType",
                new { controller = "Mobile", action = "GetFabricType" }
            );
            routes.MapRoute("GetCustomerBranchByCustomerId",
                "api/GetCustomerBranchByCustomerId/{id}",
                new { controller = "Mobile", action = "GetCustomerBranchByCustomerId",id=UrlParameter.Optional }
            );
            routes.MapRoute("GetContact",
                "api/GetContact/{id}",
                new { controller = "Mobile", action = "GetContact", id = UrlParameter.Optional }
            );
            routes.MapRoute("GetProducts",
                "api/GetProducts/{id}",
                new { controller = "Mobile", action = "GetProducts", id = UrlParameter.Optional }
            );
            routes.MapRoute("GetUnitByProduct",
                "api/getUnitByProduct/{id}",
                new { controller = "Mobile", action = "GetUnitByProduct", id = UrlParameter.Optional }
            );
            routes.MapRoute("GetCalculateDate",
               "api/GetCalculateDate",
               new { controller = "Mobile", action = "GetCalculateDate" }
           );
            #endregion
            #region Common
            routes.MapRoute(
                name: "404-NotFound",
                url: "NotFound",
                defaults: new { controller = "Error", action = "NotFound" }
            );

            routes.MapRoute(
                name: "500-Error",
                url: "Error",
                defaults: new { controller = "Error", action = "Error" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            #endregion

            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
