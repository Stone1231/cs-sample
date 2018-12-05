using System;
using System.Diagnostics;

namespace xyz.ChainResponsibility
{
// 管理者處理事假申請的抽象類別
abstract class ManagerHandler
{
    protected string name;
    protected ManagerHandler upManager; // 上一級的管理者
 
    public ManagerHandler(string name)
    {
        this.name = name;
    }
 
    // 設定上一級的管理者
    public void SetUpManager(ManagerHandler upManager)
    {
        this.upManager = upManager;
    }
 
    // 事假處理
    abstract public void RequestPersonalLeave(LeaveRequest leaveRequest);
}
 
// 經理
class Manager : ManagerHandler
{
    public Manager(string name) : base(name) { }
 
    public override void RequestPersonalLeave(LeaveRequest leaveRequest)
    {
        if (leaveRequest.DayNum <= 2)
        {
            // 2天以內，經理可以批准
            Debug.WriteLine("經理 {0} 已批准 {1}{2}天的事假", this.name, leaveRequest.Name, leaveRequest.DayNum);
        }
        else
        {
            // 超過2天，轉呈上級
            if (null != upManager)
            {
                upManager.RequestPersonalLeave(leaveRequest);
            }
        }
    }
}
 
// 協理
class Director : ManagerHandler
{
    public Director(string name) : base(name) { }
 
    public override void RequestPersonalLeave(LeaveRequest leaveRequest)
    {
        if (leaveRequest.DayNum <= 5)
        {
            // 5天以內，經理可以批准
            Debug.WriteLine("協理 {0} 已批准 {1}{2}天的事假", this.name, leaveRequest.Name, leaveRequest.DayNum);
        }
        else
        {
            // 超過5天，轉呈上級
            if (null != upManager)
            {
                upManager.RequestPersonalLeave(leaveRequest);
            }
        }
    }
}
 
// 總經理
class GeneralManager : ManagerHandler
{
    public GeneralManager(string name) : base(name) { }
 
    public override void RequestPersonalLeave(LeaveRequest leaveRequest)
    {
        if (leaveRequest.DayNum <= 7)
        {
            // 7天以內，總經理批准
            Debug.WriteLine("總經理 {0} 已批准 {1}{2}天的事假", this.name, leaveRequest.Name, leaveRequest.DayNum);
        }
        else
        {
            // 超過7天以上，再深入了解原因
            Debug.WriteLine("總經理 {0} 要再了解 {1}{2}天的事假原因", this.name, leaveRequest.Name, leaveRequest.DayNum);
        }
    }
}
 
 
// 假單
class LeaveRequest
{
    // 姓名
    public string Name{get;set;}
 
    // 天數
    public int DayNum{get;set;}
}
}