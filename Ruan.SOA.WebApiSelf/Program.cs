using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Ruan.SOA.WebApiSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = new HttpSelfHostConfiguration("http://localhost:7077");
                config.Routes.MapHttpRoute(name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
                using (var sever = new HttpSelfHostServer(config))
                {
                    sever.OpenAsync().Wait();
                    Console.WriteLine("服务已经启动了。。。。");
                    Console.WriteLine("输入任意字符关闭");
                    Console.Read();
                    sever.CloseAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
