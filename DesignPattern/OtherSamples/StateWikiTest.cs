using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.State
{
    [TestClass]
    public class StateWikiTest
    {
        [TestMethod]
        public void StateTest()
        {
            var sc = new StateContext();

            sc.writeName("Monday");
            sc.writeName("Tuesday");
            sc.writeName("Wednesday");
            sc.writeName("Thursday");
            sc.writeName("Friday");
            sc.writeName("Saturday");
            sc.writeName("Sunday");
        }
    }
}