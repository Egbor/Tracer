using Tracer;
using Tracer.Core;

using System;
using System.Threading;

using Application.Output;
using Application.Output.Serializator;

namespace Application
{
    public class Program
    {
        private static ProgramTracer _tracer = new ProgramTracer();
        private static Thread _thread = new Thread(ThreadTest);

        public static void Test()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }

        public static void ThreadTest()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }

        public static void Main(string[] args)
        {
            _tracer.StartTrace();
            _thread.Start();
            Test();
            _tracer.StopTrace();

            TraceResult result = _tracer.GetTraceResult();

            StandardOutput output = new StandardOutput();
            output.Print(result);
            output.PrintToFile("result.txt", result);
            ISerializator jsonSerializator = new JsonSerializator();
            ISerializator xmlSerializator = new XmlSerializator();

            Console.WriteLine(jsonSerializator.Serialize(result));
            Console.WriteLine(xmlSerializator.Serialize(result));

            jsonSerializator.SerializeToFile("result.json", result);
            xmlSerializator.SerializeToFile("result.xml", result);

            Console.ReadKey();
        }
    }
}
