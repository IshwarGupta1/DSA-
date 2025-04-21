using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loggingFramework
{
    internal class loggerManager
    {
        private List<ILogger> loggerList = new List<ILogger>();
        public loggerManager(List<ILogger> loggers)
        {
            loggerList = loggers;
        }

        public void AddLogger(ILogger logger)
        {
            loggerList.Add(logger);
        }
        public void Log(string message, LogLevel level) 
        {
            foreach (var logger in loggerList)
            {
                logger.Log(message, level);
            }
        }
    }
}
