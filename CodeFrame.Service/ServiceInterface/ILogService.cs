using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace CodeFrame.Service.ServiceInterface
{
    public interface ILogService 
    {
            
        void Error(Exception ex);
        void Error(string message, Exception ex = null);
        void Info(string message);

        void Debug(Exception ex);

        void Debug(string message);

        void Warn(Exception ex);

        void InitConfig();
    }
}
