using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Mediator
{
    [TestClass]
    public class MediatorXYZTest
    {
        [TestMethod]
        public void MediatorTest()
        {
            ConcreteMediator mediator = new ConcreteMediator(); // 中介者

            MedicColleague medic = new MedicColleague("小護士", mediator); // 醫護兵
            InfantryColleague infantry = new InfantryColleague("小小強", mediator); // 步兵

            medic.Send("normal", "吹東風了");
            infantry.Send("normal", "左前方一隻小白兔走過去");
            medic.Send("attack", "遭受敵人攻擊");
            infantry.Send("hurt", "我中彈了");
        }
    }
}