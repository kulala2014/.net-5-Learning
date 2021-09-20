using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kulala.Learning.WebApp.Utility.Pipeline
{
    public class CustomRTMPHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("This is customhandler for rtmp");
            context.Response.ContentType = "text/html";
        }
    }
}