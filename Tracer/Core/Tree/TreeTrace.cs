using System.Threading;
using System.Collections.Generic;

namespace Tracer.Core.Tree
{
    public class TreeTrace
    {
        private List<NodeTrace> _threads = new List<NodeTrace>();

        public List<NodeTrace> Threads => _threads;

        private ThreadNodeTrace AllocateCurrentThreadNode()
        {
            ThreadNodeTrace thread = new ThreadNodeTrace(Thread.CurrentThread.ManagedThreadId);
            _threads.Add(thread);
            return thread;
        }

        private ThreadNodeTrace GetCurrentThreadNode()
        {
            foreach (ThreadNodeTrace thread in _threads)
            {
                if (Thread.CurrentThread.ManagedThreadId == thread.Id)
                {
                    return thread;
                }
            }
            return AllocateCurrentThreadNode();
        }

        public void StartTimerCurrentMethod(MethodNodeTrace node)
        {
            ThreadNodeTrace thread = GetCurrentThreadNode();
            thread.Add(node);
        }

        public void StopTimerCurrentMathod()
        {
            ThreadNodeTrace thread = GetCurrentThreadNode();
            thread.StopTimer();
        }
    }
}
