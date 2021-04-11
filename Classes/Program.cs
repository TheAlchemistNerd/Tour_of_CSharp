using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Nevil", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend Paid me back");
            Console.WriteLine(account.Balance);

            // Test that the initial balances must be positive
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating acount with negative balance");
                Console.WriteLine(e.ToString());
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(1750, DateTime.Now, "Attempting to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());

            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.performMonthEndTransactions();
            // can make additional deposits
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("saving account", 1000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.performMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());
        }  
    }
}