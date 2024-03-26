namespace SPP_1.Tracer;

public interface ITracer
{
    void StartTrace();
    void StopTrace();
    TraceResult GetTraceResult();
}