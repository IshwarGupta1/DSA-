namespace ChainofResponsibility
{
    public class WarningLogProcessor : LogProcessor
    {
        public WarningLogProcessor(LogProcessor processor) : base(processor)
        {
        }
        public override void Log(int logLevel, string message)
        {
            if (logLevel == WARNING)
            {
                Console.WriteLine($"warning is : {message}");
            }
            else
                base.Log(logLevel, message);
        }
    }
}
