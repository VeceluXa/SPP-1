using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SPP_1.Tracer;

public class TraceRecord
{
    public readonly MethodBase method;
    public readonly int threadID;
    public readonly Stopwatch timer;
    public readonly Dictionary<MethodBase, TraceRecord> childMethods;

    internal TraceRecord(MethodBase method, Stopwatch timer)
    {
        threadID = Environment.CurrentManagedThreadId;
        this.method = method;
        this.timer = timer;
        childMethods = new Dictionary<MethodBase, TraceRecord>();
    }

    internal TraceRecord(MethodBase method) : this(method, Stopwatch.StartNew())
    {
    }

    internal void StopStopwatch()
    {
        timer.Stop();
    }

    internal void AppendChild(TraceRecord record)
    {
        childMethods.Add(record.method, record);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in childMethods)
        {
            sb.Append(item.Value.ToString());
        }

        if (sb.Length < 1)
            sb.Append("None");
        return "Traced class " + method.ReflectedType?.Name + "\n"
               + "Traced method " + method.Name + "\n"
               + "Elapsed time " + timer.ElapsedMilliseconds + " ms. \n"
               + "Child methods: \n" + sb;
    }

    public bool Equals(TraceRecord other)
    {
        return method.Equals(other.method);
    }

    public bool Equals(MethodBase other)
    {
        return method.Equals(other);
    }
}