# ASP.Net Interceptor with UI Component

- Enables to intercept the requests (InterceptorActionFilter)
- Excludes requests for controllers, actions e.g. Logging, or interceptor itself (InterceptorActionFilter)
- Supports actions on interceptors e.g. OnOk, OnCancel, OnShow (InterceptorBaseController)
- Multiple interceptors
- Ability to fire interceptors in specific orders (InterceptorRegisteration)
- Strongly typed interceptor registeration (InterceptorRegisteration)

```
using Asp.Net.RequestInterceptors.Data;
using Asp.Net.RequestInterceptors.Interceptors.Framework;
using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Registers
{
    // Inheriting from the interceptor base class
    public class LoginWelcomeInterceptorController : InterceptorBaseController
    {
        public override string InterceptorName { get; set; } = "LoginWelcomeInterceptorController";
    
        // The action to be called if the user accepts the interceptor condition
        public override ActionResult OnOk()
        {
            FakeDatabase.SetUserHasAccepted(true);
            return RedirectToAction("Home", "Home");
        }

        // The action to be called if the user rejects the interceptor condition
        public override ActionResult OnCancel()
        {
            FakeDatabase.SetUserHasAccepted(false);
            return View("WelcomeInterceptor");
        }

        // The action to be called when the interceptor fires
        public override ActionResult OnShow()
        {
            return View("WelcomeInterceptor");
        }

        // Condition to be checked to if to show this interceptor or not
        public override bool ShouldIntercept()
        {
            var should = FakeDatabase.GetUserHasAccepted();
            return !should;
        }
    }
}

```
