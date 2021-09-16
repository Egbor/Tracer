using System.Reflection;
using System.Diagnostics;

using Tracer.Core;
using Tracer.Core.Tree;

namespace Tracer
{
    public class ProgramTracer : ITracer
    {
        private static TreeTrace _tree = new TreeTrace();

        public void StartTrace()
        {
            StackTrace stack = new StackTrace();
            MethodBase method = stack.GetFrame(1).GetMethod();

            _tree.StartTimerCurrentMethod(new MethodNodeTrace(method.Name, method.ReflectedType.Name));
        }

        public void StopTrace()
        {
            _tree.StopTimerCurrentMathod();
        }

        public TraceResult GetTraceResult()
        {
            TraceResult result = new TraceResult();
            result.SetTreeTrace(_tree);
            return result;
        }
    }
}
