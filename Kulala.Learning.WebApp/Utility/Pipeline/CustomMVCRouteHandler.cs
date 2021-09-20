using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kulala.Learning.WebApp.Utility.Pipeline
{
    public class CustomMVCRouteHandler: MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomRouteHandler();
        }
    }

    public class CustomRouteHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.WriteFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config"));
        }
    }
}