using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CodeFrame.Common.Config
{
    public static  class AppConfig
    {
        /// <summary>
        /// mysql 数据库连接
        /// </summary>
        public static string MySqlConnection { get; } =   ConfigurationManager.GetConnectionString("MySqlConnection");

        /// <summary>
        /// redis 连接
        /// </summary>
        public static string RedisConnection { get; } =  ConfigurationManager.GetSection("RedisConnection");
 
    }
}
