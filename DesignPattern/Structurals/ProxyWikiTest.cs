using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Proxy
{
    [TestClass]
    public class ProxyWikiTest
    {
        [TestMethod]
        public void ProxyTest()
        {
            IImage image = new ProxyImage("HiRes_Image");
            image.Display();
        }
    }
}