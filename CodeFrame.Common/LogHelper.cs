using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;

namespace CodeFrame.Common
{
    /// <summary>
    /// 此类暂时不用 为了控制解耦已改成serverice ，用DI注入
    /// </summary>
    public class LogHelper
    {
        ///// <summary>
        ///// The logger
        ///// </summary>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //private static readonly ILog Logger;
        //public static ILoggerRepository Repository;
        //static LogHelper()
        //{
        //    Repository = LogManager.CreateRepository("NETCoreRepository");
        //    if (Logger == null)
        //    {
        //        Logger = LogManager.GetLogger(Repository.Name, typeof(LogHelper));
        //        InitConfig();
        //    }
        //}

        ///// <summary>
        ///// Log开始标记
        ///// </summary>
        //public static string LogTextStart = "===开始===";

        ///// <summary>
        ///// Log结束标记
        ///// </summary>
        //public static string LogTextEnd = "===结束===\r\n";

        ///// <summary>
        ///// Errors the specified ex.
        ///// </summary>   
        ///// <param name="ex">Error Message.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Error(Exception ex)
        //{
        //    Logger.Error(ex);
        //    ILoggerRepository rep = LogManager.GetRepository(Repository.Name);
        //    foreach (IAppender appender in rep.GetAppenders())
        //    {
        //        var buffered = appender as BufferingAppenderSkeleton;
        //        buffered?.Flush();
        //    }
        //}

        ///// <summary>
        ///// Errors the specified message.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <param name="ex">The ex.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Error(string message, Exception ex=null)
        //{
        //    if (ex == null) Logger.Error("Method Name:" + MethodBase.GetCurrentMethod().Name + "\r\n" + message);
        //    else
        //        Logger.Error("Method Name:" + MethodBase.GetCurrentMethod().Name + "\r\n" + message, ex);
        //}

        ///// <summary>
        ///// Informations the specified message.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Info(string message)
        //{
        //    Logger.Info(message);
        //}

        ///// <summary>
        ///// Debugs the specified ex.
        ///// </summary>
        ///// <param name="ex">The ex.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Debug(Exception ex)
        //{
        //    Logger.Debug(ex);
        //}

        ///// <summary>
        ///// Debugs the specified message.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Debug(String message)
        //{
        //    Logger.Debug(message);
        //}

        ///// <summary>
        ///// Warns the specified ex.
        ///// </summary>
        ///// <param name="ex">The ex.</param>
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void Warn(Exception ex)
        //{
        //    Logger.Warn(ex);
        //}

        ///// <summary>
        ///// Initializes the configuration. Path：bin/log4net.Config
        ///// </summary>
 
        ///// <history>
        ///// 1. wenqing, 2017年7月11日, Created
        ///// </history>
        //public static void InitConfig()
        //{
        //    XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        //}
 
    }
}
