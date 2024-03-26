using System.Xml.Serialization;
using SPP_1.Model;
using SPP_1.Tracer;

namespace SPP_1.Serializer;

public class XmlTraceSerializer : ISerializer
{
    public string Serialize(TraceResult result)
    {
        var dto = new TraceResultDto(result);
        XmlSerializer serializer = new XmlSerializer(dto.GetType(), new XmlRootAttribute("root"));
        using StringWriter textWriter = new StringWriter();
        serializer.Serialize(textWriter, dto);
        return textWriter.ToString();
    }
}