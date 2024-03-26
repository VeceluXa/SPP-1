using System.Xml.Serialization;
using SPP_1.Tracer;

namespace SPP_1.Model;

public class TraceResultDto
{
    [XmlElement("thread")]
    public List<ThreadTraceDto> threads { get; set; }
    
    public TraceResultDto(TraceResult tr)
    {
        threads = new List<ThreadTraceDto>();
        foreach (var item in tr.records)
        {
            AppendRecords(item);
        }
    }
    public TraceResultDto()
    {
        threads = new List<ThreadTraceDto>();
    }
    void AppendRecords(KeyValuePair<int, List<TraceRecord>> item)
    {
        threads.Add(new ThreadTraceDto(item.Key));
        int ind = threads.Count - 1;
        long totalTime = 0;
        foreach (var record in item.Value)
        {
            threads[ind].records.Add(new TraceRecordDto(record));
            totalTime += record.timer.ElapsedMilliseconds;
        }
        threads[ind].totalTime = totalTime + "ms";
    }
}