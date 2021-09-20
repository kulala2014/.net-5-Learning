using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kulala.Learning.WebApp.Utility.Pipeline
{
    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            //如果UrlReferrer为空，则显示一张默认的禁止盗链的图片
            //URLReferrer: 获取有关客户端上次请求的 URL 的信息，该请求链接到当前的 URL。
            if (context.Request.UrlReferrer == null || context.Request.UrlReferrer.Host == null)
            {
                //大部分都是爬虫
                context.Response.ContentType = "image/JPEG";
                context.Response.WriteFile("~/Content/Image/Forbidden.jpg");
            }
            else
            {
                //若包含自己站点主机名，允许访问
                if (context.Request.UrlReferrer.Host.Contains("localhost"))
                {
                    string fileName = context.Server.MapPath(context.Request.FilePath);
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile(fileName);
                }
                else
                {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile("~/Content/Image/Forbidden.jpg");
                }
            }
        }
    }
}