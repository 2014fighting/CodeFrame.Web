using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CodeFrame.Common
{
    public class AppConfig
    {
        public static readonly IConfiguration Configuration;
        static AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
        /// <summary>
        /// mysql 数据库连接
        /// </summary>
        public static string MySqlConnection { get; } =  Configuration.GetConnectionString("MySqlConnection");

        /// <summary>
        /// redis 连接
        /// </summary>
        public static string RedisConnection { get; } = Configuration.GetValue<string>("RedisConnection");
 
    }
}
