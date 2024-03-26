using SPP_1.Serializer;

namespace SPP_1.Logger;

public class FileLogger : ILogger
{
    public void Log(string text, SerializerType type)
    {
        string name = "result.txt"; 
        switch (type)
        {
            case SerializerType.XML:
            {
                name = "result.xml";
                break;
            }
            case SerializerType.JSON:
            {
                name = "result.json";
                break;
            }
        }
        
        using (StreamWriter outputFile = new StreamWriter(name))
        {
            outputFile.WriteLine(text);
        }
    }
}