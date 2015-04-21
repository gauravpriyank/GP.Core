using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace GP.Logger
{
    public class Log4Net : ILogger
    {
        private ILog log;

        public Log4Net(string loggerName)
        {
            log = LogManager.GetLogger(loggerName);
        }

        public void Log(Exception ex, string customMessage)
        {
            log.Error(customMessage, ex); ;
        }

        public void Log(string customMessage)
        {
            log.Fatal(customMessage);
        }
    }
}
