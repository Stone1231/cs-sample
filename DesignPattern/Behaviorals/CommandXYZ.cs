using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyz.Command
{
    // 用來發出命令的類別
    class Invoker
    {
        private IList<Command> cmds = new List<Command>();

        public void SetCommand(Command command)
        {
            cmds.Add(command);
        }

        public void Run()
        {
            foreach (Command command in cmds)
            {
                command.Execute();
            }
        }

    }

    // 命令的抽像類別，用來衍生各種命令，建構時，須設定實際執行命令的物件
    abstract class Command
    {
        protected ReceiverRobot robot;

        // 設定實際執行命令的物件
        public Command(ReceiverRobot robot)
        {
            this.robot = robot;
        }

        // 用來呼叫執行命令的物件，開始執行命令
        abstract public void Execute();
    }

    // 向前走一步的命令
    class GoAheadCommand : Command
    {
        public GoAheadCommand(ReceiverRobot robot)
            : base(robot)
        {
        }

        public override void Execute()
        {
            robot.GoAhead();
        }
    }

    // 向左轉的命令
    class TurnLeftCommand : Command
    {
        public TurnLeftCommand(ReceiverRobot robot)
            : base(robot)
        {
        }

        public override void Execute()
        {
            robot.TurnLeft();
        }
    }

    // 向右轉的命令
    class TurnRightCommand : Command
    {
        public TurnRightCommand(ReceiverRobot robot)
            : base(robot)
        {
        }

        public override void Execute()
        {
            robot.TurnRight();
        }
    }

    // 實際執行命令的物件
    class ReceiverRobot
    {
        public void GoAhead()
        {
            Debug.WriteLine("向前走一步");
        }

        public void TurnLeft()
        {
            Debug.WriteLine("向左轉");
        }

        public void TurnRight()
        {
            Debug.WriteLine("向右轉");
        }
    }

}