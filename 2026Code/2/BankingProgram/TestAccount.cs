using System;

class TestAccount
{
    static void Main(string[] args)
    {
        Account account = new Account("Jon Dome", 1000);
        account.Print();
        account.Deposit(500);
        account.Print();
        account.Withdraw(200);
        account.Print();
        account.Withdraw(1500);
        account.Print();
        account.Name();
    }
}