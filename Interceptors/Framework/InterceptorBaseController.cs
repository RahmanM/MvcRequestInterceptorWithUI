using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Framework
{

    public abstract class InterceptorBaseController : Controller, IInterceptor
    {
        public abstract string InterceptorName {get; set;}
        public int Order { get; set; }
        public abstract ActionResult OnShow();
        public abstract ActionResult OnOk();
        public abstract ActionResult OnCancel();
        public abstract bool ShouldIntercept();

    }
}