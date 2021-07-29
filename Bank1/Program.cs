using System;

namespace Bank1
{
    public class Account
    {
        private double balance;
        public double Balance
        {
            get { return balance; }
        }

        public Account()
        {
            this.balance = 0;
        }

        public Account(double balance)
        {
            this.balance = balance;
        }

        
        public void addAmount(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Please don't add negative amount!!");
            }

            balance += amount;
        }

        public void withdrawAmount(double amount)
        {
            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException("Withdraw amount cannot be more than balance!!");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Please don't withdraw negative amount!!");
            }

            balance -= amount;
        }

        public void TransferFundsTo(Account otherAccount, double amount)
        {
            if (otherAccount == null)
            {
                throw new ArgumentNullException("Account doesn't exist!!");
            }

            withdrawAmount(amount);
            otherAccount.addAmount(amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(2000);
            Account a2 = new Account();
            a1.TransferFundsTo(a2,500);
            Console.WriteLine(a1.Balance + " " + a2.Balance);
        }
    }
}
