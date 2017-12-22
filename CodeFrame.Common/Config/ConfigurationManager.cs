using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CodeFrame.Common.Config
{
    /// <summary>
    /// 参考:https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/configuration/index?tabs=basicconfiguration
    /// </summary>
    public class ConfigurationManager
    {
        public static readonly IConfiguration Configuration;

        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
        /// <summary>
        /// 获取json配置映射到模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSection<T>(string key) where T : class, new()
        { 
            return Configuration.GetSection(key).Get<T>();
        }
        /// <summary>
        /// 获取json字符串  key 需要重头开始以键值对方式如  "JwtSettings:SecretKey"
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSection(string key)
        {
            return Configuration.GetSection(key).Value;
        }
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return Configuration.GetConnectionString(key);
        }
    }
}
