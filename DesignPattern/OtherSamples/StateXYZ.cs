using System.Diagnostics;

namespace xyz.State
{
    // 玩家類別，有一個等級的屬性
    public class Player
    {
        public int level = 1; // 等級

        /* 狀態處理，一般用 if else 的寫法
        public void stateWork()
        {
            if (level >= 1 && level < 20)
            {
                Debug.WriteLine("等級 {0} ({1})", level, "新手");
            }
            else if (level >= 20 && level < 50)
            {
                Debug.WriteLine("等級 {0} ({1})", level, "老手");
            }
            else if (level >= 50 && level < 90)
            {
                Debug.WriteLine("等級 {0} ({1})", level, "高手");
            }
            else if (level >= 90)
            {
                Debug.WriteLine("等級 {0} ({1})", level, "神");
            }
        }
        */

        // 將狀態處理改為以下寫法 (狀態模式)
        private StateContext state;

        public Player()
        {
            // 初始化狀態處理的物件
            setStateContext(new ConcreteState001());
        }

        // 設定狀態處理的物件
        public void setStateContext(StateContext s)
        {
            state = s;
        }

        // 狀態處理，轉交由 StateContext 物件處理
        public void stateWork()
        {
            state.stateWork(this);
        }
    }

    // 狀態模式的抽象類別
    public abstract class StateContext
    {
        public abstract void stateWork(Player user);
    }

    // 等級 1~20
    public class ConcreteState001 : StateContext
    {
        public override void stateWork(Player user)
        {
            if (user.level < 20)
            {
                Debug.WriteLine("等級 {0} ({1})", user.level, "新手");
            }
            else
            {
                user.setStateContext(new ConcreteState050());
                user.stateWork();
            }
        }
    }

    // 等級 20~50
    public class ConcreteState050 : StateContext
    {
        public override void stateWork(Player user)
        {
            if (user.level < 50)
            {
                Debug.WriteLine("等級 {0} ({1})", user.level, "老手");
            }
            else
            {
                user.setStateContext(new ConcreteState090());
                user.stateWork();
            }
        }
    }

    // 等級 50~90
    public class ConcreteState090 : StateContext
    {
        public override void stateWork(Player user)
        {
            if (user.level < 90)
            {
                Debug.WriteLine("等級 {0} ({1})", user.level, "高手");
            }
            else
            {
                user.setStateContext(new ConcreteStateMAX());
                user.stateWork();
            }
        }
    }

    // 等級 90~
    public class ConcreteStateMAX : StateContext
    {
        public override void stateWork(Player user)
        {
            if (user.level >= 90)
            {
                Debug.WriteLine("等級 {0} ({1})", user.level, "神");
            }
        }
    }
}

