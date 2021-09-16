using System.IO;
using System.Text;
using System.Xml.Serialization;
using Tracer.Core;

namespace Application.Output.Serializator
{
    class XmlSerializator : ISerializator
    {
        private XmlSerializer _formatter = new XmlSerializer(typeof(TraceResult));

        public string Serialize(TraceResult result)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    _formatter.Serialize(sw, result);
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public void SerializeToFile(string path, TraceResult result)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, result);
            }
        }
    }
}
