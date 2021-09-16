using System;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using Tracer.Core.Tree;

namespace Tracer.Core.Result
{
    [Serializable]
    public class ProgramTraceResult
    {
        [XmlElement("Thread")]
        public ThreadTraceResult[] Threads { get; set; }

        public ProgramTraceResult() { }

        public ProgramTraceResult(TreeTrace tree)
        {
            CreateTraceResultTree(tree.Threads);
        }

        private void CreateTraceResultTree(List<NodeTrace> nodes)
        {
            int threadResultIndex = 0;
            ThreadTraceResult[] threads = new ThreadTraceResult[nodes.Count];

            foreach (ThreadNodeTrace node in nodes)
            {
                threads[threadResultIndex] = new ThreadTraceResult(node, 0);
                threadResultIndex++;
            }

            Threads = threads;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (ThreadTraceResult result in Threads)
            {
                builder.Append(result.ToString());
            }
            return builder.ToString();
        }
    }
}
