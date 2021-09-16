using Tracer.Core;
using System.Threading;

namespace Tracer.Test.Class
{
    public class ClassTest1
    {
        private ITracer _tracer = new ProgramTracer();

        public void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }

        public void Method2()
        {
            _tracer.StartTrace();
            Method1();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
}
