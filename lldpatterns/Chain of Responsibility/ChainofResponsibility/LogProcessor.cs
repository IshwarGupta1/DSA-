namespace ChainofResponsibility
{
    public abstract class LogProcessor
    {
        public static int INFO = 0;
        public static int WARNING = 1;
        public static int ERROR = 2;
        public LogProcessor _processor;
        public LogProcessor(LogProcessor processor)
        {
            _processor = processor;
        }

        public virtual void Log(int logLevel, string message)
        {
            if(_processor != null)
            {
                _processor.Log(logLevel, message);
            }
        }
    }
}
