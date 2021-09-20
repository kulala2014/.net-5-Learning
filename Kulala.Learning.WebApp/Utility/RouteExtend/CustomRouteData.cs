using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kulala.Learning.WebApp.Utility.RouteExtend
{
    public class CustomRouteData : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.UserAgent.Contains("Chrome/93.0.4577.63"))
            {
                return null;
            }
            else
            {
                RouteData routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("Controller","pipe");
                routeData.Values.Add("Action","refuse");
                return routeData;
            }

        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}