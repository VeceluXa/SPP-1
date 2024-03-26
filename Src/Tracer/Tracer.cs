using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace SPP_1.Tracer;

public class Tracer : ITracer
{
    ConcurrentDictionary<int, Stack<TraceRecord>> records;
    TraceResult res;

    public Tracer()
    {
        records = new ConcurrentDictionary<int, Stack<TraceRecord>>();
        res = new TraceResult();
    }

    public TraceResult GetTraceResult()
    {
        return res;
    }

    private void AddRecord(TraceRecord record)
    {
        if (!records.ContainsKey(record.threadID))
            records.TryAdd(record.threadID, new Stack<TraceRecord>());
        records[record.threadID].Push(record);
    }

    public void StartTrace()
    {
        MethodBase method = new StackTrace().GetFrame(1).GetMethod();
        TraceRecord record = new TraceRecord(method);
        AddRecord(record);
        int nestingLevel = records[record.threadID].Count;
        res.AppendNested(record, nestingLevel);
    }

    public void StopTrace()
    {
        int currThreadId = Environment.CurrentManagedThreadId;
        var record = records[currThreadId].Pop();
        record.StopStopwatch();
    }
}