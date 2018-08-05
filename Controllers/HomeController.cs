using Asp.Net.RequestInterceptors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Home()
        {
            return View("Index");
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cancel()
        {
            FakeDatabase.SetUserHasAccepted(false);
            return RedirectToAction("Home", "Home");
        }
    }
}