using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.State
{
    [TestClass]
    public class StateXYZTest
    {
        [TestMethod]
        public void StateTest()
        {
            Player user = new Player();
            user.level = 1; // 玩家等級
            user.stateWork(); // 玩家狀態處理
            user.level = 20;
            user.stateWork();
            user.level = 62;
            user.stateWork();
            user.level = 93;
            user.stateWork();

            user.level = 61;
            user.stateWork();

            user.level = 95;
            user.stateWork();
        }
    }
}
