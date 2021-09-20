using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NET.MVC.Project.Utility;
using NET.MVC.Project.Utility.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Controllers
{
    public class SecondController : Controller
    {
        [Injection]
        public ITestServiceF testServiceF { get; set; }
        private IConfiguration _configuration = null;
        public SecondController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.port = _configuration["port"];
            ITestServiceF f = ((ITestServiceF)this.testServiceF.AOP(typeof(ITestServiceF)));
            f.Show(123,"kulala");
            f.Show2(456, "Xixi");
            return View();
        }
    }
}
