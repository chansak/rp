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
                new { controller = "Mobile", action = "GetCustomerBranchByCustomerId", id = UrlParameter.Optional }
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
            routes.MapRoute("CheckStock",
               "api/CheckStock",
               new { controller = "Mobile", action = "CheckStock" }
            );
            routes.MapRoute("getOptionsByProductId",
                "api/getOptionsByProductId/{id}",
                new { controller = "Mobile", action = "GetOptionsByProductId", id = UrlParameter.Optional }
            );
            routes.MapRoute("addOrUpdateDocument",
               "api/addOrUpdateDocument",
               new { controller = "Mobile", action = "AddOrUpdateDocument" }
            );
            routes.MapRoute("getDocumentDetail",
               "api/getDocumentDetail/{id}",
               new { controller = "Mobile", action = "GetDocumentDetail", id = UrlParameter.Optional }
            );
            routes.MapRoute("getProductItemsByDocumentId",
               "api/getProductItemsByDocumentId/{id}",
               new { controller = "Mobile", action = "GetProductItemsByDocumentId", id = UrlParameter.Optional }
            );
            routes.MapRoute("updateLocation",
               "api/updateLocation",
               new { controller = "Mobile", action = "UpdateLocation" }
           );
            routes.MapRoute("addOrUpdateGeneralAndSaleInfo",
               "api/addOrUpdateGeneralAndSaleInfo",
               new { controller = "Mobile", action = "AddOrUpdateGeneralAndSaleInfo" }
            );
            routes.MapRoute("addOrUpdateCustomerAndContact",
               "api/addOrUpdateCustomerAndContact",
               new { controller = "Mobile", action = "AddOrUpdateCustomerAndContact" }
            );
            routes.MapRoute("addOrUpdateProductItem",
               "api/addOrUpdateProductItem",
               new { controller = "Mobile", action = "AddOrUpdateProductItem" }
            );
            routes.MapRoute("addOrUpdateDelivery",
               "api/addOrUpdateDelivery",
               new { controller = "Mobile", action = "AddOrUpdateDelivery" }
            );
            routes.MapRoute("addOrUpdateRemark",
               "api/addOrUpdateRemark",
               new { controller = "Mobile", action = "AddOrUpdateRemark" }
            );
            routes.MapRoute("deleteDocument",
               "api/deleteDocument/{id}",
               new { controller = "Mobile", action = "DeleteDocument", id = UrlParameter.Optional }
            );
            routes.MapRoute("deleteProductItem",
               "api/deleteProductItem",
               new { controller = "Mobile", action = "DeleteProductItem", id = UrlParameter.Optional }
            );
            routes.MapRoute("copyProductItem",
               "api/copyProductItem",
               new { controller = "Mobile", action = "CopyProductItem", id = UrlParameter.Optional }
            );
            routes.MapRoute("getPatternImages",
               "api/getPatternImages/{id}",
               new { controller = "Mobile", action = "GetPatternImages", id = UrlParameter.Optional }
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
