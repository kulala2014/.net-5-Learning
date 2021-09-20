using Kulala.Learning.WebApp.Utility;
using Kulala.Learning.WebApp.Utility.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Controllers
{
    //[CustomActionClassFilterAttribute]
    public class FifthController : Controller
    {
        private Logger logger = new Logger(typeof(FifthController));
        // GET: Fifth
        public ActionResult Index()
        {
            return View();
        }

        [CustomActionFilter]

        public ActionResult ActionFilterTest()
        {
            return View();
        }
    }
}