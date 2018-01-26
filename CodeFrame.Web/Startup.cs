using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodeFrame.Common;
using CodeFrame.Common.Config;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodeFrame.Web
{
    public class Startup
    {
        public static ILoggerRepository Repository;
        private IServiceCollection _services;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var path = Directory.GetCurrentDirectory();
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
            //在CreateDefaultBuilder 已经配置 再此可以重写
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)//热更新
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();


            Repository = LogManager.CreateRepository("NETCoreRepository");
            //XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ILogService<Startup> log=new LogService<Startup>();
            log.Info("ConfigureServices开始");

            //DbContext 连接池 2.0版本

            //  services.AddDbContextPool<CodeFrameContext>(options => options.UseInMemoryDatabase("mytempdb"));

            services.AddDbContextPool<CodeFrameContext>(options => options.UseMySql(AppConfig.MySqlConnection));



            services.AddUnitOfWork<CodeFrameContext>();//添加UnitOfWork支持
          
            foreach (var item in ProjectCom.GetClassName("CodeFrame.Service")) //集中注入服务
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }
            services.AddScoped(typeof(ILogService<>), typeof(LogService<>));//注入泛型loger

            //services.AddScoped(typeof(IUserInfoService), typeof(UserInfoService));//用ASP.NET Core自带依赖注入(DI)注入使用的类
            //添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面。
            //https://www.cnblogs.com/seriawei/p/7452743.html
            services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })//传入默认授权方案
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account/Login");
                    o.AccessDeniedPath = new PathString("/Account/AccessDenied");
                });

   

            services.AddAutoMapper();//配置autoapper

            
            services.AddCors(options =>//配置跨域处理
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();//指定处理cookie
                });
            });
             
             services.AddMvc()//全局配置Json序列化处理
                .AddJsonOptions(options =>
                    {
                        //忽略循环引用
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        //不使用驼峰样式的key
                       options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        //设置时间格式
                        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    }
                );
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogService<Startup> logger)
        {

            //var log = LogManager.GetLogger(Repository.Name, typeof(Startup));
            logger.Info("启动web");

            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
                ListAllRegisteredServices(app);
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

 
        private void ListAllRegisteredServices(IApplicationBuilder app)
        {
            app.Map("/allservices", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>All Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }

    }
}
