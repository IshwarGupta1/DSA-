// See https://aka.ms/new-console-template for more information
using ChainofResponsibility;

Console.WriteLine("Hello, World!");
var logger = new InfoLogProcessor(new WarningLogProcessor(new ErrorLogProcessor(null)));
logger.Log(0, "warning is given");
logger.Log(1, "error is given");
logger.Log(2, "wrong try");
logger.Log(3, " incorrect");
