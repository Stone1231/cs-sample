using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Decorator
{
    [TestClass]
    public class DecoratorWiki1Test
    {
        [TestMethod]
        public void DecoratorTest()
        {
            // Create a decorated Window with horizontal and vertical scrollbars
            Window decoratedWindow = new HorizontalScrollBarDecorator(
                    new VerticalScrollBarDecorator(
                        new SimpleWindow()));

            // Print the Window's description
            Debug.WriteLine(decoratedWindow.getDescription());
        }
    }
}