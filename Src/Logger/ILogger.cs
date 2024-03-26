using SPP_1.Serializer;

namespace SPP_1.Logger;

public interface ILogger
{
    public void Log(String text, SerializerType type);
}