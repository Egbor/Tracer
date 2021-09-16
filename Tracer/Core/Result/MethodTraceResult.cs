﻿using System;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using Tracer.Core.Tree;

namespace Tracer.Core.Result
{
    [Serializable]
    public class MethodTraceResult
    {
        private int _depth;

        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Class { get; set; }
        [XmlAttribute]
        public long Time { get; set; }
        [XmlElement("Method")]
        public MethodTraceResult[] Methods { get; set; }

        public MethodTraceResult() { }

        public MethodTraceResult(MethodNodeTrace node, int depth)
        {
            Name = node.Name;
            Class = node.Class;
            Time = node.Time;
            _depth = depth;

            CreateTraceResultTree(node.Nodes);
        }

        private void CreateTraceResultTree(List<NodeTrace> nodes)
        {
            int methodResultIndex = 0;
            MethodTraceResult[] methods = new MethodTraceResult[nodes.Count];

            foreach (MethodNodeTrace node in nodes)
            {
                methods[methodResultIndex] = new MethodTraceResult(node, _depth + 1);
                methodResultIndex++;
            }

            Methods = methods;
        }

        public override string ToString()
        {
            StringBuilder tabs = new StringBuilder();
            for (int i = 0; i < _depth; i++)
            {
                tabs.Append("\t");
            }

            StringBuilder builder = new StringBuilder();
            builder.Append($"{tabs}Name: {Name}\n{tabs}Class: {Class}\n{tabs}Time: {Time}\n{tabs}Methods:\n");

            foreach (MethodTraceResult result in Methods)
            {
                builder.Append($"{result}");
            }
            return builder.ToString();
        }
    }
}
