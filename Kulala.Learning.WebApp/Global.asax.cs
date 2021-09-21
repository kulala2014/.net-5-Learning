using Kulala.Learning.WebApp.Utility;
using Kulala.Learning.WebApp.Utility.ViewEnginExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kulala.Learning.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Logger logger = new Logger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();//注册区域
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//注册全局Filter
            RouteConfig.RegisterRoutes(RouteTable.Routes);//注册路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);//合并压缩，打包工具

            //替换默认ControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new KulalaControllerFactory());

            //替换默认viewEngine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());

            this.logger.Info("WebSite started............"); 
        }

        //全局异常处理
        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exception = Server.GetLastError();//返回前一个异常
            //logger.Error($"{base.Context.Request.Url.AbsoluteUri}出现异常");
            //Response.Write("System is Error....");
            //Server.ClearError();
        }


        protected void CustomHttpModule_eventHandler(object sender, EventArgs e)
        {
            logger.Info("This is event for CustomHttpModule_eventHandler, add event in global");
        }
    }
}
