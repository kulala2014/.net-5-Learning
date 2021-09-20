using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility
{
    /// <summary>
    /// 中间件--Invoke --Next --放在前面
    /// 
    /// </summary>
    public class RefuseStealingMiddleWare
    {
        private readonly RequestDelegate _next;

        public RefuseStealingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value;

            if (!url.Contains(".jpg"))
            {
                await _next(context);
            }
            else
            {
                string urlReferer = context.Request.Headers["Referer"];
                if (string.IsNullOrWhiteSpace(urlReferer))//直接访问
                {
                    await this.SetForbiddenImage(context);//返回404
                }
                else if (!urlReferer.Contains("localhost"))//非当前域名
                {
                    await this.SetForbiddenImage(context);//返回404
                }
                else
                {
                    await _next(context);
                }
            }
        }

        private async Task SetForbiddenImage(HttpContext context)
        {
            string defaultImagePath = "wwwroot/image/Forbidden.jpg";
            string path = Path.Combine(Directory.GetCurrentDirectory(), defaultImagePath);

            FileStream fs = File.OpenRead(path);
            byte[] bytes = new byte[fs.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);

            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
