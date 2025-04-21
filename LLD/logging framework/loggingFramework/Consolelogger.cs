using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loggingFramework
{
    internal class Consolelogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            Console.WriteLine($"{level} : {DateTime.Now} : {message}");
        }
    }
}
