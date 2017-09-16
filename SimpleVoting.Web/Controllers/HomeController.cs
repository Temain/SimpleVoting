using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleVoting.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Congratulations()
        {
            return View();
        }

        public ActionResult Results()
        {
            return View();
        }
    }
}