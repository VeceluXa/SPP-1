using System.Text;

namespace SPP_1.Serializer;

public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}