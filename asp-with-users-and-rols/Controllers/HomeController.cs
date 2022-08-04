using asp_with_users_and_rols.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_with_users_and_rols.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeUser(idOperacion:1)]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser(idOperacion:2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeUser(idOperacion:6)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}