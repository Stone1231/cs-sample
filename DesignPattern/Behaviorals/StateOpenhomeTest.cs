using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace openhome.State
{
    [TestClass]
    public class StateOpenhomeTest
    {
        [TestMethod]
        public void StateTest()
        {
            TrafficLight trafficLight = new TrafficLight();
            while (true)
            {
                trafficLight.change();
            }
        }
    }
}