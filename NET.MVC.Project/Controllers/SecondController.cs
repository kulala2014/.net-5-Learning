using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NET.MVC.Project.Utility;
using NET.MVC.Project.Utility.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.MVC.Project.Utility.Filters;


namespace NET.MVC.Project.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilterAttribute))]
    public class SecondController : Controller
    {
        [Injection]
        public ITestServiceF testServiceF { get; set; }
        private IConfiguration _configuration = null;
        public SecondController(IConfiguration configuration)
        {
            _configuration = configuration;
            Console.WriteLine("Create instance for SecondController");
        }

        [DIFactory(typeof(CustomActionFilterAttribute))]
        public IActionResult Index()
        {
            ViewBag.port = _configuration["port"];
            ITestServiceF f = ((ITestServiceF)this.testServiceF.AOP(typeof(ITestServiceF)));
            f.Show(123,"kulala");
            f.Show2(456, "Xixi");
            return View();
        }

        //[CustomActionFilter]//如果特性类需要构造函数传参，这样是不行的
        [CustomResourceFilter]
        [TypeFilter(typeof(CustomActionFilterAttribute))]
        [CustomAlwaysRunResultFilter]
        [CustomResultFilter]
        public async Task<IActionResult> AsyncIndex()
        {
            ViewBag.Date = DateTime.Now;
          return  await Task.FromResult<IActionResult>(View());
        }

        //[CustomActionFilter]//如果特性类需要构造函数传参，这样是不行的
        [CustomResourceFilter]
        [TypeFilter(typeof(CustomActionFilterAttribute))]
        [CustomAlwaysRunResultFilter]
        [CustomResultFilter]
        public IActionResult TestFilter()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public IActionResult ExceptionTest()
        {
            int j = 0;
            int i = 1;
            var result = i/j;
            return View();
        }
    }
}
