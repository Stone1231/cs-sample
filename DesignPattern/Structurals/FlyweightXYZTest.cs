using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Flyweight
{
    [TestClass]
    public class FlyweightXYZTest
    {
        [TestMethod]
        public void FlyweightTest()
        {
            ChessFlyweightFactory f = new ChessFlyweightFactory();

            ChessFlyweight a1 = f.GetChessFlyweight("黑棋"); // 取得黑棋共享物件
            a1.Display(1, 1); // 提供座標資料(非共享資料)
            ChessFlyweight a2 = f.GetChessFlyweight("黑棋"); // 取得黑棋共享物件
            a2.Display(1, 2); // 提供座標資料(非共享資料)
            ChessFlyweight a3 = f.GetChessFlyweight("黑棋"); // 取得黑棋共享物件
            a3.Display(1, 3); // 提供座標資料(非共享資料)
            ChessFlyweight b1 = f.GetChessFlyweight("白棋"); // 取得白棋共享物件
            b1.Display(2, 1); // 提供座標資料(非共享資料)
            ChessFlyweight b2 = f.GetChessFlyweight("白棋"); // 取得白棋共享物件
            b1.Display(2, 2); // 提供座標資料(非共享資料)
            ChessFlyweight b3 = f.GetChessFlyweight("白棋"); // 取得白棋共享物件
            b1.Display(2, 3); // 提供座標資料(非共享資料)

            Debug.WriteLine("ChessFlyweight物件數量：{0}", f.GetChessFlyweightCount());
        }
    }
}