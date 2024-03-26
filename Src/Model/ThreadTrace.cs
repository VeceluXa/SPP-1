namespace SPP_1.Model;

public class ThreadTrace
{
    public ThreadTrace(int id)
    {
        this.id = id;
        totalTime = "";
        records = new List<TraceRecordBaseDTO>();
    }
    
    public ThreadTrace()
    {
        id = 0;
        totalTime = "";
        records = new List<TraceRecordBaseDTO>();
    }
    public int id { get; set; }
    public string totalTime { get; set; }
    public List<TraceRecordBaseDTO> records { get; set; }
}