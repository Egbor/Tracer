using Tracer.Core;
using Tracer.Test.Class;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tracer.Test
{
    [TestClass]
    public class TracerTest
    {
        private ITracer _tracer = new ProgramTracer();

        [TestMethod]
        public void Tracer_CallClassTest1Method1_ReturnedMethod1()
        {
            ClassTest1 test = new ClassTest1();

            test.Method1();
            TraceResult result = _tracer.GetTraceResult();

            Assert.AreEqual("Method1", result.Root.Threads[0].Methods[0].Name);
        }

        [TestMethod]
        public void Tracer_CallClassTest1Method1_ReturnedClassTest1()
        {
            ClassTest1 test = new ClassTest1();

            test.Method1();
            TraceResult result = _tracer.GetTraceResult();

            Assert.AreEqual("ClassTest1", result.Root.Threads[0].Methods[0].Class);
        }

        [TestMethod]
        public void Tracer_CallClassTest1Method1_ReturnedAbout1000()
        {
            ClassTest1 test = new ClassTest1();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            test.Method1();
            stopwatch.Stop();

            long actualTime = _tracer.GetTraceResult().Root.Threads[0].Methods[0].Time;

            Assert.IsTrue(actualTime - 1000 < 10);
        }

        [TestMethod]
        public void Tracer_CallClassTest1Method2_ReturnedAbout1100()
        {
            ClassTest1 test = new ClassTest1();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            test.Method2();
            stopwatch.Stop();

            long actualTime = _tracer.GetTraceResult().Root.Threads[0].Methods[0].Time;

            Assert.IsTrue(actualTime - 1100 < 20);
        }
    }
}
