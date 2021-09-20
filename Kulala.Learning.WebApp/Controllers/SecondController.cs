using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timer(string year, string month, string day)
        {
            return View();
        }

        [ChildActionOnly]//只能被子请求访问  不能独立访问
        public ViewResult ChildAction(string name)
        {
            base.ViewBag.Name = name;
            return View();
        }
    }
}