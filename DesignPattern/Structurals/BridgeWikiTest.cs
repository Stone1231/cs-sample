using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Bridge
{
    [TestClass]
    public class BridgeWikiTest
    {
        [TestMethod]
        public void BridgeTest()
        {
            IShape[] shapes = new IShape[2];
            shapes[0] = new CircleShape(1, 2, 3, new DrawingAPI1());
            shapes[1] = new CircleShape(5, 7, 11, new DrawingAPI2());

            foreach (IShape shape in shapes)
            {
                shape.ResizeByPercentage(2.5);
                shape.Draw();
            }
        }
    }
}