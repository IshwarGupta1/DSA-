using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int valueType = 10;
        object refType = valueType; // Boxing
        Console.WriteLine(refType);
        int? nullableVar = null;
        nullableVar ??= 100;
        Console.WriteLine($"Nullable Value: {nullableVar}");

        await AsyncMethod();
    }

    static async Task AsyncMethod()
    {
        await Task.Delay(1000);
        Console.WriteLine("Async Task Done!");
    }
}
