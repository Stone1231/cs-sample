using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Builder
{
    [TestClass]
    public class BuilderXYZTest
    {
        [TestMethod]
        public void BuilderTest()
        {
            Director aa = new Director();
            Bulider bb = new 大杯珍奶();
            aa.setBulider(bb);
            aa.create();

            Debug.WriteLine("----------");

            bb = new 小杯紅茶();
            aa.setBulider(bb);
            aa.create();
        }
    }
}