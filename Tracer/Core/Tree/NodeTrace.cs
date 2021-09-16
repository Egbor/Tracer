using System.Linq;
using System.Collections.Generic;

namespace Tracer.Core.Tree
{
    public class NodeTrace
    {
        protected List<NodeTrace> _nodes = new List<NodeTrace>();
        private bool _isActive = true;

        public List<NodeTrace> Nodes => _nodes;

        public NodeTrace GetNextNode()
        {
            NodeTrace lastNode = _nodes.LastOrDefault();
            if ((lastNode != null) && (lastNode._isActive))
            {
                return lastNode;
            }
            return null;
        }

        public void Add(NodeTrace node)
        {
            NodeTrace nextNode = GetNextNode();
            if (nextNode == null)
            {
                _nodes.Add(node);
            }
            else
            {
                nextNode.Add(node);
            }
        }

        public void StopTimer()
        {
            NodeTrace nextNode = GetNextNode();
            if (nextNode == null)
            {
                Stop();
            }
            else
            {
                nextNode.StopTimer();
            }
        }

        protected virtual void Stop()
        {
            _isActive = false;
        }
    }
}
