namespace Tracer.Core.Tree
{
    public class ThreadNodeTrace : NodeTrace
    {
        public int Id { get; }
        public long Time
        {
            get
            {
                long totalTime = 0;
                foreach (MethodNodeTrace node in _nodes)
                {
                    totalTime += node.Time;
                }
                return totalTime;
            }
        }

        public ThreadNodeTrace(int id)
        {
            Id = id;
        }
    }
}
