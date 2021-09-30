using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: HostingStartup(typeof(NET.MVC.Project.Utility.CustomHostingStartup))]
namespace NET.MVC.Project.Utility
{
    public class CustomHostingStartup : IHostingStartup
    {
        //构造ioc容器之前执行
        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("Before building IOC container");
        }
    }
}
