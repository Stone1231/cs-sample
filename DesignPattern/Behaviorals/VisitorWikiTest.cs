using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Visitor
{
    [TestClass]
    public class VisitorWikiTest
    {
        [TestMethod]
        public void VisitorTest()
        {
            Car car = new Car();
            car.accept(new CarElementPrintVisitor());
            car.accept(new CarElementDoVisitor());
        }
    }
}