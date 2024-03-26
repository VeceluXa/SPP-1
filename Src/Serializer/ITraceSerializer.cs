using SPP_1.Tracer;

namespace SPP_1.Serializer;

public abstract class ITraceSerializer
{
     public abstract SerializerType type { get; }
     public abstract string Serialize(TraceResult result);
}