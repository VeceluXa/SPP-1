using SPP_1.Tracer;

namespace SPP_1.Test.Tests;

public class Test3 : ITest
{
    private ITracer tracer;

    public Test3(ITracer tracer)
    {
        this.tracer = tracer;
    }
    
    public void DoTest()
    {
        tracer.StartTrace();
        Thread.Sleep(600);
        tracer.StopTrace();
    }
}