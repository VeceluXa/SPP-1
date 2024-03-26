using System.Text;
using System.Xml.Serialization;
using SPP_1.Model;
using SPP_1.Tracer;

namespace SPP_1.Serializer;

public class XmlTraceTraceSerializer : ITraceSerializer
{
    public override SerializerType type => SerializerType.XML;

    public override string Serialize(TraceResult result)
    {
        var dto = new TraceResultDto(result);
        XmlSerializer serializer = new XmlSerializer(dto.GetType(), new XmlRootAttribute("root"));
        using StringWriter textWriter = new Utf8StringWriter();
        serializer.Serialize(textWriter, dto);
        return textWriter.ToString();
    }
}