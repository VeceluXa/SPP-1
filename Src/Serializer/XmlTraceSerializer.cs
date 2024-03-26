using System.Xml.Serialization;
using SPP_1.Model;
using SPP_1.Tracer;

namespace SPP_1.Serializer;

public class XmlTraceSerializer : ISerializer
{
    private static Type[] arr = { typeof(ThreadTrace), typeof(TraceRecordBaseDTO) };
    public string Serialize(TraceResult result)
    {
        var dto = new TraceResultBaseDTO(result);
        XmlSerializer serializer = new XmlSerializer(dto.GetType(), arr);
        using StringWriter textWriter = new StringWriter();
        serializer.Serialize(textWriter, dto);
        return textWriter.ToString();
    }
}