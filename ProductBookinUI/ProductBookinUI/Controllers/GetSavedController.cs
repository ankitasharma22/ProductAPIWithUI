using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductBookinUI.Controllers
{
    public class GetSavedController : Controller
    {
        // GET: GetSaved
        public ActionResult GetSavedProducts()
        {
            return View();
        }

    }
}