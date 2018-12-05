using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.ChainResponsibility
{
    [TestClass]
    public class ChainResponsibilityXYZTest
    {
        [TestMethod]
        public void ChainResponsibilityTest()
        {
            Manager a1 = new Manager("阿福"); // 經理
            Director a2 = new Director("技安"); // 協理
            GeneralManager a3 = new GeneralManager("宜靜"); // 總經理
            a1.SetUpManager(a2); // 設定經理的上級為協理
            a2.SetUpManager(a3); // 設定協理的上級為總經理

            // 假單初始化
            LeaveRequest leaveRequest = new LeaveRequest(); // 假單
            leaveRequest.Name = "大雄"; // 員工姓名

            leaveRequest.DayNum = 1; // 請假天數
            a1.RequestPersonalLeave(leaveRequest);// 送出1天的假單

            leaveRequest.DayNum = 3; // 請假天數
            a1.RequestPersonalLeave(leaveRequest);// 送出3天的假單

            leaveRequest.DayNum = 7; // 請假天數
            a1.RequestPersonalLeave(leaveRequest);// 送出7天的假單

            leaveRequest.DayNum = 10; // 請假天數
            a1.RequestPersonalLeave(leaveRequest);// 送出10天的假單

            leaveRequest.DayNum = 2; // 請假天數
            a1.RequestPersonalLeave(leaveRequest);// 送出10天的假單
        }
    }
}