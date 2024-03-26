using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SPP_1.Tracer;

namespace SPP_1.Model;

public class TraceRecordDto
{
    [JsonPropertyName("class"), XmlAttribute("class")]
    public string className { get; set; }
    
    [JsonPropertyName("name"), XmlAttribute("name")]
    public string methodName { get; set; }
    
    [JsonPropertyName("time"), XmlAttribute("time")]
    public string time { get; set; }
    
    [JsonPropertyName("methods"), XmlElement("method")]
    public List<TraceRecordDto> childs { get; set; }
    
    public TraceRecordDto(TraceRecord tr)
    {
        childs = new List<TraceRecordDto>();
        className = tr.method.ReflectedType.Name;
        methodName = tr.method.Name;
        time = tr.timer.ElapsedMilliseconds + "ms";
        foreach (var item in tr.childMethods)
            AppendChild(item);
    }
    public TraceRecordDto()
    {
        childs = new List<TraceRecordDto>();
        className = "";
        methodName = "";
        time = "0ms";
    }
    void AppendChild(KeyValuePair<MethodBase, TraceRecord> item)
    {
        childs.Add(new TraceRecordDto(item.Value));
    }
}