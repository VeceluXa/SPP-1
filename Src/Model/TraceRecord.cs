using System.Reflection;
using SPP_1.Tracer;

namespace SPP_1.Model;

public class TraceRecordBaseDTO
{
    public TraceRecordBaseDTO(TraceRecord tr)
    {
        childs = new List<TraceRecordBaseDTO>();
        className = tr.method.ReflectedType.Name;
        methodName = tr.method.Name;
        time = tr.timer.ElapsedMilliseconds + "ms";
        foreach (var item in tr.childMethods)
            appendChild(item);
    }
    public TraceRecordBaseDTO()
    {
        childs = new List<TraceRecordBaseDTO>();
        className = "";
        methodName = "";
        time = "0ms";
    }
    void appendChild(KeyValuePair<MethodBase, TraceRecord> item)
    {
        childs.Add(new TraceRecordBaseDTO(item.Value));
    }
    public string className { get; set; }
    public string methodName { get; set; }
    public string time { get; set; }
    public List<TraceRecordBaseDTO> childs { get; set; }
}