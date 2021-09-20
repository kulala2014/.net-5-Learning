using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.MVC.Plugins
{
    public class HomeController : Controller
    {
        // GET: System/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}