using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SPP_1.Tracer;

public class TraceResult
{
    public readonly ConcurrentDictionary<int, List<TraceRecord>> records;

    internal TraceResult()
    {
        records = new ConcurrentDictionary<int, List<TraceRecord>>();
    }

    private void Append(TraceRecord record)
    {
        if (!records.ContainsKey(record.threadID))
            records.TryAdd(record.threadID, new List<TraceRecord>());
        records[record.threadID].Add(record);
    }

    internal void AppendNested(TraceRecord record, int nestingLevel)
    {
        if (nestingLevel != 1)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase parent = stackTrace.GetFrame(nestingLevel + 1).GetMethod();
            TraceRecord toAddIn = records[record.threadID].Find(x => x.Equals(parent));
            for (int i = nestingLevel; i > 2; --i)
            {
                var nextMethod = stackTrace.GetFrame(i).GetMethod();
                toAddIn = toAddIn?.childMethods[nextMethod];
            }

            toAddIn?.AppendChild(record);
        }
        else
            Append(record);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in records)
        {
            sb.Append("In " + item.Key + " thread:\n");
            foreach (var record in item.Value)
                sb.Append(record);
        }

        return sb.ToString();
    }
}