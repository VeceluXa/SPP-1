using System.Text.Json;
using SPP_1.Model;
using SPP_1.Tracer;

namespace SPP_1.Serializer;

public class JsonTraceSerializer : ISerializer
{
    private static JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };
    public string Serialize(TraceResult result)
    {
        TraceResultDto dto = new TraceResultDto(result);
        return JsonSerializer.Serialize(dto, options);
    }
}