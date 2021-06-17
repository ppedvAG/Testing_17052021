using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDBank.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void New_account_should_have_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void Can_Deposit_and_balance_gets_added()
        {
            var ba = new BankAccount();

            ba.Deposit(3m);
            Assert.AreEqual(3m, ba.Balance);

            ba.Deposit(5m);
            Assert.AreEqual(8m, ba.Balance);
        }

        [TestMethod]
        public void Deposit_a_negative_value_or_zero_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-3m));
            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0m));
        }

        [TestMethod]
        public void Can_Withdraw_and_reduce_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(10m);

            ba.Withdraw(10m);
            Assert.AreEqual(7m, ba.Balance);

            ba.Withdraw(5m);
            Assert.AreEqual(2m, ba.Balance);
        }

        [TestMethod]
        public void Withdraw_a_negative_value_or_zero_throws()
        {
            var ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-3m));
            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0m));
        }

        [TestMethod]
        public void Withdraw_more_than_balance_throws()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);

            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(12m));

        }
    }
}
