using Kulala.EF.Model;
using Kulala.Learning.Interface;
using Kulala.Learning.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using NET.MVC.Project.Utility;
using NET.MVC.Project.Utility.AOP;
using System.IO;

namespace NET.MVC.Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews().AddControllersAsServices();
    //        services.AddDbContext<KulalaDBContext>(options =>
    //options.UseSqlServer(Configuration.GetConnectionString("Cn")));
            //services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITestServiceF, TestServiceF>();

            ////默认的activator
            //var activator = services.FirstOrDefault(C => C.ServiceType == typeof(IControllerActivator));

            ////删除这个默认的activator
            //services.Remove(activator);
            //services.AddTransient<IControllerActivator, CustomControllerActivator>();

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, CustomControllerActivator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            NLog.LogManager.LoadConfiguration("CfgFile/NLog.config").GetCurrentClassLogger();
            NLog.LogManager.Configuration.Variables["connectionString"] = Configuration.GetConnectionString("ConnectionString");


            //
            //app.Run(async context => await context.Response.WriteAsync("Hello world!"));

            //app.Use(next =>
            //{
            //    Console.WriteLine("This is middleware 1");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is hello world 1 start ");
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("This is hello world 1 end ");
            //        });
            //});

            //app.Use(next =>
            //{
            //    Console.WriteLine("This is middleware 2");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is hello world 2 start ");
            //            await next.Invoke(context);
            //            await context.Response.WriteAsync("This is hello world 2 end ");
            //        });
            //});

            //app.Use(next =>
            //{
            //    Console.WriteLine("This is middleware 3");
            //    return new RequestDelegate(
            //        async context =>
            //        {
            //            await context.Response.WriteAsync("This is hello world 3 start ");
            //            await context.Response.WriteAsync("This is the one!!!!!");
            //            await context.Response.WriteAsync("This is hello world 3 end ");
            //        });
            //});

            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            app.UseMiddleware<RefuseStealingMiddleWare>();

            //全局异常处理
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //配置http 转https，如果同时监听http, https，访问http的时候自动跳转到https
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions 
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"))
            });

            //路由匹配这里处理
            app.UseRouting();
            app.UseSession();

            //鉴权
            app.UseAuthentication();//有没有登录
            //授权
            app.UseAuthorization();//有没有权限

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaProducts",
                    areaName: "Products",
                    pattern: "Products/{controller=Show}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{areas:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                name: "test",
                pattern: "test/{action=Index}/{year}",
                defaults: new 
                {
                    controller = "Home",
                    action = "Index"
                },
                constraints: new { year = @"\d{4}"});
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
            
        //}
    }
}
