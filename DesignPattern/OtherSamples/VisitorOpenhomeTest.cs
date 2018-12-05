using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace openhome.Visitor
{
    [TestClass]
    public class VisitorOpenhomTest
    {
        [TestMethod]
        public void VisitorTest()
        {
            Service service = new Service();
            service.doService(new Member());

            service.doService(new VIP());
        }
    }
}