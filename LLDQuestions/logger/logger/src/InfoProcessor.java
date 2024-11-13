public class InfoProcessor extends LogProcessor{
    public InfoProcessor(LogProcessor logProcessor) {
        super(logProcessor);
    }

    public void log(int logLevel, String message)
    {
        if(logLevel == INFO)
            System.out.println("info "+ message);
        else
            super.log(logLevel, message);
    }
}
