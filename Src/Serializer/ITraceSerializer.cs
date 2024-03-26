using SPP_1.Tracer;

namespace SPP_1.Serializer;

internal interface ISerializer
{
     string Serialize(TraceResult result);
}