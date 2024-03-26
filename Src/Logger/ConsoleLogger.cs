using SPP_1.Serializer;

namespace SPP_1.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string text, SerializerType type)
    {
        Console.WriteLine(text);
        Console.WriteLine();
    }
}