using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dofactory.State
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StateTest()
        {
            // Open a new account

            Account account = new Account("Jim Johnson");

            // Apply financial transactions

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);

            // Wait for user

            //Console.ReadKey();
        }
    }
}
