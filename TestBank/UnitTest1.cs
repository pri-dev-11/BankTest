//asasasa
using Bank1;
using NUnit.Framework;
using System;

namespace TestBank
{
    [TestFixture]
    public class UnitTest1
    {
        public Account account = new Account(1000);
        [Test]
        public void Add_Amount()
        {
            account.addAmount(500);
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Add_Negative_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.addAmount(-500));
        }

        [Test]
        public void Transfer_Amount()
        {
            var otherAccount = new Account();
            account.TransferFundsTo(otherAccount, 500);
            Assert.AreEqual(1000, account.Balance);
            Assert.AreEqual(500, otherAccount.Balance);
        }

        [Test]
        public void Transfer_To_Non_Existing_Account_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }

        [Test]
        public void Withdraw_Amount()
        {
           
            account.withdrawAmount(500);
            Assert.AreEqual(500, account.Balance);
        }

        
        [Test]
        public void Withdraw_Negative_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdrawAmount(-500));
        }

        [Test]
        public void Withdraw_Overflow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdrawAmount(2000));
        }
    }
}
