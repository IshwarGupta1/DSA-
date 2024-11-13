public class ErrorProcessor extends LogProcessor{
    public ErrorProcessor(LogProcessor logProcessor) {
        super(logProcessor);
    }

    public void log(int logLevel, String message)
    {
        if(logLevel == ERROR)
            System.out.println("error "+ message);
        else
            super.log(logLevel, message);
    }
}
