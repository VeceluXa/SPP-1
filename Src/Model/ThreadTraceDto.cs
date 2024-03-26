using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SPP_1.Model;

public class ThreadTraceDto
{
    [JsonPropertyName("id"), XmlAttribute("id")]
    public int id { get; set; }
    
    [JsonPropertyName("time"), XmlAttribute("time")]
    public string totalTime { get; set; }
    
    [JsonPropertyName("methods"), XmlElement("method")]
    public List<TraceRecordDto> records { get; set; }
    
    public ThreadTraceDto(int id)
    {
        this.id = id;
        totalTime = "";
        records = new List<TraceRecordDto>();
    }
    
    public ThreadTraceDto()
    {
        id = 0;
        totalTime = "";
        records = new List<TraceRecordDto>();
    }
}