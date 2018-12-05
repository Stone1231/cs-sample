using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Decorator
{
    [TestClass]
    public class DecoratorXYZTest
    {
        [TestMethod]
        public void DecoratorTest()
        {
            // 玩家
            Player player = new Player();

            // 裝飾功能A (寶劍裝備)
            Decorator_A A = new Decorator_A();
            A.SetPlayer(player); // 將"玩家"給功能A，增加寶劍裝備

            // 裝飾功能B (護盾裝備)
            Decorator_B B = new Decorator_B();
            B.SetPlayer(A); // 繼續給功能B，增加護盾裝備

            // 裝飾功能C (靴子裝備)
            Decorator_C C = new Decorator_C();
            C.SetPlayer(B); // 繼續給功能C，增加靴子裝備

            // 開始一層一層執行裝備東西
            C.Operation();
        }
    }
}