using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Observer
{
    [TestClass]
    public class ObserverWikiTest
    {
        [TestMethod]
        public void ObserverTest()
        {
			Subject mySubject = new Subject();
			IObserver myObserver1 = new Observer1();
			IObserver myObserver2 = new Observer2();

			// register observers
			mySubject.Register(myObserver1);
			mySubject.Register(myObserver2);

			mySubject.Notify("message 1");
			mySubject.Notify("message 2");
        }
    }
}