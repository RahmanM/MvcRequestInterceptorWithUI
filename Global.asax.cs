using Asp.Net.RequestInterceptors.Interceptors.Framework;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Asp.Net.RequestInterceptors
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InterceptorHandler.Init().RegisterInterceptors(new InterceptorRegisteration());

            GlobalFilters.Filters.Add(new InterceptorActionFilter());

        }

    }
}
