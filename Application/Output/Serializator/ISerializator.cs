using Tracer.Core;

namespace Application.Output.Serializator
{
    public interface ISerializator
    {
        string Serialize(TraceResult result);
        void SerializeToFile(string path, TraceResult result);
    }
}
