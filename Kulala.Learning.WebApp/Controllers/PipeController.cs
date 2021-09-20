using Kulala.Learning.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kulala.Learning.WebApp.Controllers
{
    public class PipeController : Controller
    {
        /// <summary>
        ///    /// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config
        /// .NetFramework安装路径，是一个全局的配置，是当前电脑上任何一个网站的默认配置
        /// 
        /// 
        /// 1 HttpHandler及扩展，自定义后缀，图片防盗链等
        /// 2 RoutingModule,IRouteHandler、IHttpHandler
        /// 3 MVC扩展Route，扩展HttpHandle
        /// </summary>
        /// <returns></returns>
        // GET: Pipe
        public ActionResult Index()
        {
            return View();
        }

        //获取当前application配置的module，默认的和自定义的
        public ActionResult Module()
        {
            HttpApplication app = base.HttpContext.ApplicationInstance;

            List<SysEvent> sysEventsList = new List<SysEvent>();
            int i = 1;
            foreach (EventInfo e in app.GetType().GetEvents())
            {
                sysEventsList.Add(new SysEvent()
                {
                    Id = i++,
                    Name = e.Name,
                    TypeName = e.GetType().Name
                });
            }

            List<string> list = new List<string>();
            foreach (string item in app.Modules.Keys)
            {
                list.Add($"{item}: {app.Modules.Get(item)}");
            }
            ViewBag.Modules = string.Join(",", list);

            return View(sysEventsList);
        }

        public ActionResult ImageTest()
        {
            ViewBag.Handler = HttpContext.CurrentHandler.GetType().FullName;
            HttpContextBase context = HttpContext;

            var routeData = base.RouteData.Values;
            return View();
        }

        public ActionResult Refuse()
        {
            return View();
        }
    }
}