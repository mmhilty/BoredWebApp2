using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoredWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult One()
        {
            return RedirectToAction("Index", "One");
        }

        public ActionResult Specific()
        {

            return RedirectToAction("Index", "Specific");
        }

        public ActionResult Multiple()
        {

            return RedirectToAction("Index", "Multiple");
        }
    }
}