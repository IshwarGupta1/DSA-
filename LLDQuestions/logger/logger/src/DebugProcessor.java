public class DebugProcessor extends LogProcessor{
    public DebugProcessor(LogProcessor logProcessor) {
        super(logProcessor);
    }

    public void log(int logLevel, String message)
    {
        if(logLevel == DEBUG)
            System.out.println("debug "+ message);
        else
            super.log(logLevel, message);
    }
}
