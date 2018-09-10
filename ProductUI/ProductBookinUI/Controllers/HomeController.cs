using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductBookinUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult AvailableProductsAdminUser()
        {
            return View();
        }

        public ActionResult AvailableProductsNormalUser()
        {
            return View();
        }
    }
}