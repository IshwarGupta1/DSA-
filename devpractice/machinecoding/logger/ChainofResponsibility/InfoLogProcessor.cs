namespace ChainofResponsibility
{
    public class InfoLogProcessor : LogProcessor
    {
        public InfoLogProcessor(LogProcessor processor) : base(processor)
        {
        }

        public override void Log(int logLevel, string message)
        {
            if (logLevel == INFO)
            {
                Console.WriteLine($"info is : {message}");
            }
            else
            {
                base.Log(logLevel, message);
            }
        }
    }
}
