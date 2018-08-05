using Asp.Net.RequestInterceptors.Data;
using Asp.Net.RequestInterceptors.Interceptors.Framework;
using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Registers
{
    public class LoginWelcomeInterceptorController : InterceptorBaseController
    {
        public override string InterceptorName { get; set; } = "LoginWelcomeInterceptorController";

        public override ActionResult OnOk()
        {
            FakeDatabase.SetUserHasAccepted(true);
            return RedirectToAction("Home", "Home");
        }

        public override ActionResult OnCancel()
        {
            FakeDatabase.SetUserHasAccepted(false);
            return View("WelcomeInterceptor");
        }

        public override ActionResult OnShow()
        {
            return View("WelcomeInterceptor");
        }

        public override bool ShouldIntercept()
        {
            var should = FakeDatabase.GetUserHasAccepted();
            return !should;
        }
    }

    public class TestInterceptorController : InterceptorBaseController
    {
        public override string InterceptorName { get; set; } = "TestInterceptorController";

        public override ActionResult OnOk()
        {
            FakeDatabase.SetUserHasAcceptedTest(true);
            return RedirectToAction("Home", "Home");
        }

        public override ActionResult OnCancel()
        {
            FakeDatabase.SetUserHasAcceptedTest(false);
            return View("TestInterceptor");
        }

        public override ActionResult OnShow()
        {
            return View("TestInterceptor");
        }

        public override bool ShouldIntercept()
        {
            var should = FakeDatabase.GetUserHasAcceptedTest();
            return !should;
        }
    }
}