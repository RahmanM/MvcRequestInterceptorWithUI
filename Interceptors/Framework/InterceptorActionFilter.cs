using Asp.Net.RequestInterceptors.Controllers;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Framework
{
    /// <summary>
    /// Interceptor that will intercept all the incoming requesta and Fire 
    /// interceptors if any
    /// </summary>
    public class InterceptorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;

            // Don't intercept these
            if (!ShouldIntercept(controller))
            {
                base.OnActionExecuting(filterContext);
                return; 
            }

            // Fire interceptor
            InterceptorHandler.Init().Fire(filterContext);
        }

        bool ShouldIntercept(ControllerBase controller)
        {

            var isAuthenticated = HttpContext.Current.Request.IsAuthenticated;
            if (!isAuthenticated)
            {
                return false;
            }

            var specificController =
                controller.GetType().IsAssignableFrom(typeof(AccountController));

            if(specificController)
            {
                return false;
            }

            var isInterceptor = typeof(InterceptorBaseController).IsAssignableFrom(controller.GetType());
            if (isInterceptor)
            {
                return false;
            }

            return true;
        }
    }
}