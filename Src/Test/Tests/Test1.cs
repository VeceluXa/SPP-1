using SPP_1.Tracer;

namespace SPP_1.Test.Tests;

public class Test1 : ITest
{
    private ITracer tracer;

    public Test1(ITracer tracer)
    {
        this.tracer = tracer;
    }
    
    public void DoTest()
    {
        tracer.StartTrace();
        Thread.Sleep(800);
        tracer.StopTrace();
    }
}