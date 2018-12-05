using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyz.Builder
{
    //標準化的生產步驟
    interface Bulider
    {
        void 拿杯子();

        void 裝飲料();

        void 加蓋子();

        void 拿吸管();
    }

    //大杯奶茶生產過程，實作 Bulider 介面
    class 大杯珍奶 : Bulider
    {
        public void 拿杯子()
        {
            Debug.WriteLine("拿大杯子");
        }
        public void 裝飲料()
        {
            Debug.WriteLine("裝珍珠、裝奶茶");
        }

        public void 加蓋子()
        {
            Debug.WriteLine("拿大蓋子加蓋");
        }

        public void 拿吸管()
        {
            Debug.WriteLine("拿粗吸管");
        }
    }

    //小杯紅茶生產過程，實作 Bulider 介面
    class 小杯紅茶 : Bulider
    {
        public void 拿杯子()
        {
            Debug.WriteLine("拿小杯子");
        }
        public void 裝飲料()
        {
            Debug.WriteLine("裝紅茶");
        }

        public void 加蓋子()
        {
            Debug.WriteLine("拿小蓋子加蓋");
        }

        public void 拿吸管()
        {
            Debug.WriteLine("拿細吸管");
        }
    }

    //統一由指揮者 class 執行生產步驟
    class Director
    {
        private Bulider builder;

        public void setBulider(Bulider builder)
        {
            this.builder = builder;
        }

        public void create()
        {
            this.builder.拿杯子();
            this.builder.裝飲料();
            this.builder.加蓋子();
            this.builder.拿吸管();
        }
    }
}