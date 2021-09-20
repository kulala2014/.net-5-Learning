using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET.MVC.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace NET.MVC.Project.Controllers
{
    public class FirstController : Controller
    {
        ILogger<FirstController> _logger;

        List<PeopleModel> peoples = new List<PeopleModel>
            {
                new PeopleModel
                {
                    Name = "Kulala",
                    Age = 20,
                    Gender = "male",
                    Height = "173",
                    Likes = new List<string>{"KOBE","Sarah","YYF" }
                },
                new PeopleModel
                 {
                    Name = "Clyde",
                    Age = 20,
                    Gender = "male",
                    Height = "173",
                    Likes = new List<string>{"KOBE","Sarah","YYF" }
                },
                new PeopleModel
                                 {
                    Name = "Xixi",
                    Age = 20,
                    Gender = "male",
                    Height = "173",
                    Likes = new List<string>{"KOBE","Sarah","YYF" }
                },
            };
        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
            logger.LogInformation($"你好init {nameof(FirstController)}");
        }


        public IActionResult Index(int id)
        {
            PeopleModel currentUser = peoples.FirstOrDefault(p => p.Age == id) ?? peoples[0];
            ViewData["CurrentUser"] = currentUser;
            ViewBag.CurrentUser = currentUser;

            TempData["CurrentUser"] = peoples[0];

            if (id < 20)
            {
                return View(currentUser);
            }
            else
            {
                return RedirectToAction("IndexId");
            }
        }


        public ActionResult IndexId(int id) => View();


        public ViewResult IndexIdNull(int? id) 
        {
            if (id is not null)
                ViewData["User2"] = "kulala";
           return View();
        }


        public ViewResult IndexIdAndName(int id, string name)
        {
            
            ViewBag.User = new
            {
                Id = id,
                Name = name
            };
            return View();
         }

        public string StringName(string name) => $"This is {name}";

        public string StringJson(string name)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    Id = 123,
                    Name = name
                });
        }

        public JsonResult JsonData(int id, string name, string remark)
        {
            return new JsonResult 
            ( new
                {
                    Id = 123,
                    Name = name,
                    Remark = remark??"空remark"
               }
            );
        }

        public ViewResult ChildAction(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
