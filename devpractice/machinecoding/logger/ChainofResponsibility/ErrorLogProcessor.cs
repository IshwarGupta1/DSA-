namespace ChainofResponsibility
{
    public class ErrorLogProcessor : LogProcessor
    {
        public ErrorLogProcessor(LogProcessor processor) : base(processor)
        {
        }
        public override void Log(int logLevel, string message)
        {
            if (logLevel == ERROR)
            {
                Console.WriteLine($"error is : {message}");
            }
            else
                Console.WriteLine("Wrong logging attempt");
        }
    }
}
