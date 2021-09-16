using System;
using Tracer.Core.Tree;
using Tracer.Core.Result;

namespace Tracer.Core
{
    [Serializable]
    public struct TraceResult
    {
        public ProgramTraceResult Root { get; set; }

        public void SetTreeTrace(TreeTrace tree)
        {
            Root = new ProgramTraceResult(tree);
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }
}
