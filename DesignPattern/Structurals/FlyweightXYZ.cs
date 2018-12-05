using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyz.Flyweight
{
    // 棋子享元工廠，回傳棋子物件
    class ChessFlyweightFactory
    {
        private Hashtable chessFlyweight = new Hashtable();

        public ChessFlyweight GetChessFlyweight(string key)
        {
            if (!chessFlyweight.ContainsKey(key))
            {
                chessFlyweight.Add(key, new ConcreteChessFlyweight(key));
            }
            return (ChessFlyweight)chessFlyweight[key];
        }

        // 取得目前棋子物件數量
        public int GetChessFlyweightCount()
        {
            return chessFlyweight.Count;
        }
    }


    // 棋子享元抽像物件
    abstract class ChessFlyweight
    {
        protected string name; // 共享資料
        public ChessFlyweight(string name)
        {
            this.name = name;
        }
        public abstract void Display(int x, int y);
    }

    // 棋子享元(共享物件)
    class ConcreteChessFlyweight : ChessFlyweight
    {
        public ConcreteChessFlyweight(string name)
            : base(name)
        {
        }

        // X、Y座標，非共享資料
        public override void Display(int x, int y)
        {
            Debug.WriteLine("{0}({1},{2})", this.name, x, y);
        }
    }
}