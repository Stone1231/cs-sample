using System.Diagnostics;
using System;
using System.Threading;

namespace openhome.State
{

    interface State
    {
        void change(TrafficLight light);
    }

    abstract class Light : State
    {
        public abstract void change(TrafficLight light);
        protected void sleep(int second)
        {
            try
            {
                Thread.Sleep(second);
            }
            catch (ThreadInterruptedException e)
            {
                Debug.Write(e.Message);
                //e.printStackTrace();
            }
        }
    }

    class Red : Light
    {
        public override void change(TrafficLight light)
        {
            Debug.Write("紅燈");
            sleep(5000);
            light.set(new Green()); // 如果考慮彈性調整狀態，可以不用寫死狀態物件設定
        }
    }

    class Green : Light
    {
        public override void change(TrafficLight light)
        {
            Debug.Write("綠燈");
            sleep(5000);
            light.set(new Yellow());
        }
    }

    class Yellow : Light
    {
        public override void change(TrafficLight light)
        {
            Debug.Write("黃燈");
            sleep(1000);
            light.set(new Red());
        }
    }

    class TrafficLight
    {
        private State current = new Red();
        public void set(State state)
        {
            this.current = state;
        }
        public void change()
        {
            current.change(this);
        }
    }
}