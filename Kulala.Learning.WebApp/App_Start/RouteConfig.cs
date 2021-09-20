using Kulala.Learning.WebApp.Utility.Pipeline;
using Kulala.Learning.WebApp.Utility.RouteExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kulala.Learning.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("customService/{*pathInfo}");


            //固定路由
            //routes.MapRoute(
            //    name: "About",
            //    url: "about",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //    );

            //修改或隐藏控制器路由
            //routes.MapRoute(
            //    name: "Test",
            //    url: "Test/{action}/{id}",
            //    defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "Regax",
            //    url: "{controller}/{action}_{year}_{month}_{day}",
            //    defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional },
            //    constraints: new { year=@"\d{4}", month=@"\d{2}", day=@"\d{2}"}
            //    );

            routes.Add("customroute", new CustomRouteData());
            routes.Add("config", new Route("kulala/{path}", new CustomMVCRouteHandler()));

            //常规路由，一般不修改，扩展
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
