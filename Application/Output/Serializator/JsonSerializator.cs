using Tracer.Core;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Application.Output.Serializator
{
    public class JsonSerializator : ISerializator
    {
        JsonSerializerOptions _option = new JsonSerializerOptions() { WriteIndented = true };

        public string Serialize(TraceResult result)
        {
            return JsonSerializer.Serialize(result, result.GetType(), _option);
        }

        public void SerializeToFile(string path, TraceResult result)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                string stringData = JsonSerializer.Serialize(result, result.GetType(), _option);
                byte[] byteData = Encoding.UTF8.GetBytes(stringData);
                fs.Write(byteData, 0, byteData.Length);
            }
        }
    }
}
