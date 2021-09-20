using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace NET.MVC.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logBuilder =>
                {
                    //logBuilder.ClearProviders();//É¾³ýÆäËûµÄlogÅäÖÃ
                    logBuilder.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();
                //.UseServiceProviderFactory(new AutofacServiceProviderFactory());
                //.ConfigureLogging(logBuilder =>
                //{
                //    logBuilder.ClearProviders();
                //    logBuilder.SetMinimumLevel(LogLevel.Trace);
                //    logBuilder.log
                //});
    }
}
