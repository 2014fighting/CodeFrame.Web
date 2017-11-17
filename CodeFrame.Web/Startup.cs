using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Common;
using CodeFrame.Models;
using CodeFrame.Service.Service;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Controllers;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web
{
    public class Startup
    {
        public static ILoggerRepository Repository;
       
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

           
             Repository = LogManager.CreateRepository("wenqingNETCoreRepository");
            //XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));

            Configuration = configuration;
        }
   
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("MySqlConnection");
            //services.AddDbContext<CodeFrameContext>(options => options.UseMySql(connection));
            //DbContext 连接池 2.0版本
            services.AddDbContextPool<CodeFrameContext>(options => options.UseMySql(connection));

            services.AddUnitOfWork<CodeFrameContext>();//添加UnitOfWork支持
            //集中注册服务
            foreach (var item in ProjectCom.GetClassName("CodeFrame.Service"))
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }
            //services.AddScoped(typeof(IUserInfoService), typeof(UserInfoService));//用ASP.NET Core自带依赖注入(DI)注入使用的类
 

            //添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面。
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//传入默认授权方案
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    
                    o.LoginPath = new PathString("/Account/Login");
                    o.AccessDeniedPath = new PathString("/Account/AccessDenied");
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogService logger)
        {

            //var log = LogManager.GetLogger(Repository.Name, typeof(Startup));
            logger.Info("启动web");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();//使用静态文件
            app.UseAuthentication();//使用授权  
            app.UseMvc(routes =>//路由
            {
                //区域路由 此路由方式 不需要给 控制器添加 区域属性[Area("Manage")]
                routes.MapAreaRoute("Manage_route", "Manage",
                    "Manage/{controller=MyHome}/{action=Index}/{id?}"
                    );

                //此方式必须给控制器加上区域属性[Area("Manage")]
                //routes.MapRoute(name: "areaRoute",
                //    template: "{area:exists}/{controller=MyHome}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
 
            });

           
        }
    }
}
