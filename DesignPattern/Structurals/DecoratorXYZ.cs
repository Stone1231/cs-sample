using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyz.Decorator
{
    // 「元件」抽像類別，定義了「被裝飾者」和「裝飾功能」要實做的方法
    abstract class Component
    {
        public abstract void Operation();
    }

    // 玩家(被裝飾者)，實做元件抽像介面
    class Player : Component
    {
        public override void Operation()
        {
            Debug.WriteLine("玩家的裝備：");
        }
    }

    // 裝飾功能抽像類別，繼承「元件」抽像類別
    abstract class Decorator : Component
    {
        protected Component component;

        // 設定玩家(也可理解成設定Component)
        public void SetPlayer(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (this.component != null)
            {
                this.component.Operation();
            }
        }
    }

    // 裝飾功能A (寶劍裝備)
    class Decorator_A : Decorator
    {
        public override void Operation()
        {
            base.Operation(); // 執行原本玩家的功能
            Debug.WriteLine("裝備了 寶劍，攻擊力+10"); // 執行新功能
        }
    }

    // 裝飾功能B (護盾裝備)
    class Decorator_B : Decorator
    {
        public override void Operation()
        {
            base.Operation(); // 執行原本玩家的功能
            Debug.WriteLine("裝備了 護盾，防禦力+5"); // 執行新功能
        }
    }

    // 裝飾功能C (靴子裝備)
    class Decorator_C : Decorator
    {
        public override void Operation()
        {
            base.Operation(); // 執行原本玩家的功能
            Debug.WriteLine("裝備了 靴子，速度+2"); // 執行新功能
        }
    }
}