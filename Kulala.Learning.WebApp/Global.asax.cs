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
            AreaRegistration.RegisterAllAreas();//ע������
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//ע��ȫ��Filter
            RouteConfig.RegisterRoutes(RouteTable.Routes);//ע��·��
            BundleConfig.RegisterBundles(BundleTable.Bundles);//�ϲ�ѹ�����������

            //�滻Ĭ��ControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new KulalaControllerFactory());

            //�滻Ĭ��viewEngine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());

            this.logger.Info("WebSite started............"); 
        }

        //ȫ���쳣����
        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception exception = Server.GetLastError();//����ǰһ���쳣
            //logger.Error($"{base.Context.Request.Url.AbsoluteUri}�����쳣");
            //Response.Write("System is Error....");
            //Server.ClearError();
        }


        protected void CustomHttpModule_eventHandler(object sender, EventArgs e)
        {
            logger.Info("This is event for CustomHttpModule_eventHandler, add event in global");
        }
    }
}
