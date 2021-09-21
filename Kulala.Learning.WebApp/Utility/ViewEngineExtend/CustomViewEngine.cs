using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.ViewEnginExtend
{
    public class CustomViewEngine : RazorViewEngine
    {
		internal static readonly string ViewStartFileName = "_ViewStart";

		public CustomViewEngine()
			: this(null)
		{
		}

		public CustomViewEngine(IViewPageActivator viewPageActivator)
			: base(viewPageActivator)
		{
            this.SetEngine("");
		}

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext.HttpContext.Request.UserAgent.Contains("Chrome/93.0.4577.63"))
            {
                this.SetEngine("Chrome");
            }
            else
            {
                this.SetEngine("");//一定得有，因为只有一个Engine实例
            }
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext.HttpContext.Request.UserAgent.Contains("Chrome/93.0.4577.63"))
            {
                this.SetEngine("Chrome");
            }
            else
            {
                this.SetEngine("");
            }
            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

  //      protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
		//{
  //          return base.CreatePartialView(controllerContext, partialPath);
  //      }

		//protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
		//{
  //          return base.CreateView(controllerContext, viewPath,masterPath);
		//}

        /// <summary>
        /// 把模板给换了
        /// </summary>
        /// <param name="browser"></param>
        private void SetEngine(string browser)
        {
            if (!string.IsNullOrWhiteSpace(browser))
            {
                base.AreaViewLocationFormats = new string[]
                {
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.vbhtml"
                };
                base.AreaMasterLocationFormats = new string[]
                {
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.vbhtml"
                };
                base.AreaPartialViewLocationFormats = new string[]
                {
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.cshtml",
                "~/Areas/{2}/"+browser+"Views/Shared/{0}.vbhtml"
                };
                base.ViewLocationFormats = new string[]
                {
                "~/"+browser+"Views/{1}/{0}.cshtml",
                "~/"+browser+"Views/{1}/{0}.vbhtml",
                "~/"+browser+"Views/Shared/{0}.cshtml",
                "~/"+browser+"Views/Shared/{0}.vbhtml"
                };
                base.MasterLocationFormats = new string[]
                {
                "~/"+browser+"Views/{1}/{0}.cshtml",
                "~/"+browser+"Views/{1}/{0}.vbhtml",
                "~/"+browser+"Views/Shared/{0}.cshtml",
                "~/"+browser+"Views/Shared/{0}.vbhtml"
                };
                base.PartialViewLocationFormats = new string[]
                {
                "~/"+browser+"Views/{1}/{0}.cshtml",
                "~/"+browser+"Views/{1}/{0}.vbhtml",
                "~/"+browser+"Views/Shared/{0}.cshtml",
                "~/"+browser+"Views/Shared/{0}.vbhtml"
                };
            }
            else
            {
                base.AreaViewLocationFormats = new string[]
               {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
               };
                base.AreaMasterLocationFormats = new string[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                };
                base.AreaPartialViewLocationFormats = new string[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                };
                base.ViewLocationFormats = new string[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
                };
                base.MasterLocationFormats = new string[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
                };
                base.PartialViewLocationFormats = new string[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
                };
                base.FileExtensions = new string[]
                {
                "cshtml",
                "vbhtml"
                };
            }
        }
    }
}