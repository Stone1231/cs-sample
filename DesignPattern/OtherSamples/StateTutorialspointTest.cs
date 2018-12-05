using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tutorialspoint.State
{
    [TestClass]
    public class StateTutorialspointTest
    {
        [TestMethod]
        public void StateTest()
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);

            Debug.WriteLine(context.getState().ToString());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Debug.WriteLine(context.getState().ToString());
        }
    }
}
