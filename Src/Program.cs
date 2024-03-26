using SPP_1.Logger;
using SPP_1.Serializer;
using SPP_1.Test;
using SPP_1.Test.Tests;
using SPP_1.Tracer;

internal class Program
{
    static ITracer tracer = new Tracer();

    static void Main(string[] args)
    {
        ITest[] tests = {
            new Test1(tracer),
            new Test2(tracer),
            new Test3(tracer)
        };
        
        Task[] tasks = new Task[3];
        
        for (int i = 0; i <= 2; i++)
        {
            tasks[i] = new Task(tests[i].DoTest);
            tasks[i].Start();
        }
        
        foreach (var task in tasks)
        {
            task.Wait();
        }
        
        var result = tracer.GetTraceResult();

        ITraceSerializer[] serializers = {
            new XmlTraceTraceSerializer(),
            new JsonTraceTraceSerializer()
        };

        ILogger[] loggers =
        {
            new FileLogger(),
            new ConsoleLogger()
        };
        
        foreach (var serializer in serializers)
        {
            foreach (var logger in loggers)
            {
                logger.Log(serializer.Serialize(result), serializer.type);
            }
        }
    }
}