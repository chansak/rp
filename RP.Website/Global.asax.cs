﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RP.Website
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelMapping.Configure();

            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ModelMapping.Configure();
        }
    }
}
