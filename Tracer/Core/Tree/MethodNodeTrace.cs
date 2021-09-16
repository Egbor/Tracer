using System.Diagnostics;

namespace Tracer.Core.Tree
{
    public class MethodNodeTrace : NodeTrace
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public string Name { get; }
        public string Class { get; }
        public long Time => _stopwatch.ElapsedMilliseconds;

        public MethodNodeTrace(string name, string className)
        {
            Name = name;
            Class = className;

            _stopwatch.Start();
        }

        protected override void Stop()
        {
            _stopwatch.Stop();
            base.Stop();
        }
    }
}
