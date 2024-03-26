using SPP_1.Tracer;

namespace SPP_1.Model;

public class TraceResultBaseDTO
{
    public TraceResultBaseDTO(TraceResult tr)
    {
        threads = new List<ThreadTrace>();
        foreach (var item in tr.records)
        {
            appendRecords(item);
        }
    }
    public TraceResultBaseDTO()
    {
        threads = new List<ThreadTrace>();
    }
    void appendRecords(KeyValuePair<int, List<TraceRecord>> item)
    {
        threads.Add(new ThreadTrace(item.Key));
        int ind = threads.Count - 1;
        long totalTime = 0;
        foreach (var record in item.Value)
        {
            threads[ind].records.Add(new TraceRecordBaseDTO(record));
            totalTime += record.timer.ElapsedMilliseconds;
        }
        threads[ind].totalTime = totalTime + "ms";
    }

    public List<ThreadTrace> threads { get; private set; }
}