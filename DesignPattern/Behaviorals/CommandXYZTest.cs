using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Command
{
    [TestClass]
    public class CommandXYZTest
    {
        [TestMethod]
        public void CommandTest()
        {
            // 初始化各個物件
            Invoker invoker = new Invoker(); // 發命令物件

            ReceiverRobot robot = new ReceiverRobot(); // 執行命令物件

            GoAheadCommand cmd_go_ahead = new GoAheadCommand(robot); // 向前走指令
            TurnLeftCommand cmd_turn_left = new TurnLeftCommand(robot); // 左轉指令
            TurnRightCommand cmd_turn_right = new TurnRightCommand(robot); // 右轉指令

            // 設定要執行的命令
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_left);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_right);

            // 開始執行命令
            invoker.Run();
        }
    }
}