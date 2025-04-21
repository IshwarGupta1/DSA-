using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loggingFramework
{
    internal class Filelogger : ILogger
    {
        private string _filePath;
        public Filelogger(string filePath)
        {
            _filePath = filePath;
        }
        public void Log(string message, LogLevel level)
        {
            lock (this)
            {
                File.AppendAllText(_filePath, $"{level} : {DateTime.Now} : {message}");
            }
        }
    }
}
