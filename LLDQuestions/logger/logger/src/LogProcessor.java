public abstract class LogProcessor {
    public static int INFO = 1;
    public static int DEBUG = 2;
    public static int ERROR = 3;
    LogProcessor nextProcessor;
    public LogProcessor(LogProcessor logProcessor)
    {
        this.nextProcessor = logProcessor;
    }

    public void log(int logLevel, String message)
    {
        if(nextProcessor!=null)
            nextProcessor.log(logLevel, message);
    }
}
