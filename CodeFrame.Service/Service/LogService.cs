using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;

namespace CodeFrame.Service.Service
{
    public class LogService<T> : ILogService<T>
    {
        private   readonly ILog _logger;
        public   ILoggerRepository Repository;

        public  LogService()
        {
            Repository = LogManager.GetRepository("NETCoreRepository") ??
                LogManager.CreateRepository("NETCoreRepository");
            if (_logger == null)
            {
                _logger = LogManager.GetLogger(Repository.Name, typeof(T));
                InitConfig();
            }
        }
        public void Debug(Exception ex)
        {
            _logger.Debug(ex);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error(ex);
            ILoggerRepository rep = LogManager.GetRepository(Repository.Name);
            foreach (IAppender appender in rep.GetAppenders())
            {
                var buffered = appender as BufferingAppenderSkeleton;
                buffered?.Flush();
            }
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null) _logger.Error(message);
            else
                _logger.Error(message, ex);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }
         

        public void Warn(Exception ex)
        {
            _logger.Warn(ex);
        }

        public void InitConfig()
        {
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        }
    }
}
