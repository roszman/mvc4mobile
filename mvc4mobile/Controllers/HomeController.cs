using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using System.Web.Http;

namespace mvc4mobile.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Mobile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NonMobileTemplate()
        {
            return View();
        }

        public ActionResult Responsive()
        {
            return View();
        }
    }
}
