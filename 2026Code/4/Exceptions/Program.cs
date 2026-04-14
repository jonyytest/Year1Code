using System;
using System.Collections.Generic;

class Account
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Balance { get; private set; }

    public Account(string firstName, string lastName, int balance)
    {
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public void Withdraw(int amount)
    {
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient fund");
        }
        Balance = Balance - amount;
    }
}

class Exceptions
{
    static void Main(string[] args)
    {
        try
        {
            Account emptyAccount = null;
            int balanceCheck = emptyAccount.Balance;
        }
        catch (NullReferenceException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            int[] recentTransactions = { 100, 50, 20, 200, 10 };
            int missingTransaction = recentTransactions[10];
        }
        catch (IndexOutOfRangeException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            int totalWithdrawn = 500;
            int numberOfWithdrawals = 0;
            int averageWithdrawal = totalWithdrawn / numberOfWithdrawals;
        }
        catch (DivideByZeroException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            string accountHolderName = null;
            if (accountHolderName == null)
            {
                throw new ArgumentNullException(nameof(accountHolderName), "Account holder name cannot be null.");
            }
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            int depositAmount = -50;
            if (depositAmount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depositAmount), "Deposit amount cannot be negative.");
            }
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            string userInputString = "Fifty Dollars";
            int parsedAmount = int.Parse(userInputString);
        }
        catch (FormatException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            string newPin = "12";
            if (newPin.Length < 4)
            {
                throw new ArgumentException("Account PIN must be at least 4 digits long.", nameof(newPin));
            }
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            throw new SystemException("Bank central server connection lost.");
        }
        catch (SystemException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();

        try
        {
            Account myAccount = new Account("Sergey", "P.", 100);
            myAccount.Withdraw(1000);
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine("The following error detected: " +
                exception.GetType().ToString() + " with message \"" +
                exception.Message + "\"");
        }
        Console.ReadKey();
    }
} 
// StackOverflowException and OutOfMemoryException have been intentionally 
// omitted from this sequence because they cause fatal execution failures. 
// Please see the written report for details.
