using System;
using System.IO;
using System.Text;
using Tracer.Core;

namespace Application.Output
{
    public class StandardOutput
    {
        public void Print(TraceResult result)
        {
            Console.WriteLine(result);
        }

        public void PrintToFile(string path, TraceResult result)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                string stringData = result.ToString();
                byte[] byteData = Encoding.UTF8.GetBytes(stringData);
                fs.Write(byteData, 0, byteData.Length);
            }
        }
    }
}
