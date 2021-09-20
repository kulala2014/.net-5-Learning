using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.Filter
{
    public class CompressActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;
            string acceptEncoding = request.Headers["Accept-Encoding"];//检测支持的压缩类型
            if (!string.IsNullOrEmpty(acceptEncoding) && acceptEncoding.ToLower().Contains("gzip"))
            {
                response.AddHeader("Content-Encoding", "gzip");//响应头指定类型
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);//压缩类型指定
            }
        }
    }
}