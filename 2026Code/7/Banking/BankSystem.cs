using System;
using System.Collections.Generic;

enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
    NewAccount,
    Quit
}

class BankSystem
{
    static MenuOption ReadUserOption()
    {
        int choice = 0;
        bool valid = false;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Print");
            Console.WriteLine("5. Add new account");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";
            try
            {
                choice = Convert.ToInt32(input);
                if (choice >= 1 && choice <= 6)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (!valid);
        return (MenuOption)(choice - 1);
    }

    static void DoDeposit(Bank bank)
    {
        Account account = FindAccount(bank);
        if (account == null) return;
        Console.Write("Enter amount to deposit: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            DepositTransaction transaction = new DepositTransaction(account, amount);
            bank.ExecuteTransaction(transaction);
            transaction.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Amount is too large. Please enter a smaller number.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Transaction failed: " + ex.Message);
        }
    }

    static void DoWithdraw(Bank bank)
    {
        Account account = FindAccount(bank);
        if (account == null) return;
        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
            bank.ExecuteTransaction(transaction);
            transaction.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Amount is too large. Please enter a smaller number.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Transaction failed: " + ex.Message);
        }
    }

    static void DoTransfer(Bank bank)
    {
        Console.Write("Transfer from: ");
        Account fromAccount = FindAccount(bank);
        if (fromAccount == null) return;
        Console.Write("Transfer to: ");
        Account toAccount = FindAccount(bank);
        if (fromAccount == toAccount)
        {
            Console.WriteLine("Invalid input. Funds must be transfered to a different account");
            return;
        }
        if (toAccount == null) return;
        Console.Write("Enter amount to transfer: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            TransferTransaction transaction = new TransferTransaction(fromAccount, toAccount, amount);
            bank.ExecuteTransaction(transaction);
            transaction.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Amount is too large. Please enter a smaller number.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Transaction failed: " + ex.Message);
        }
    }

    static void DoPrint(Bank bank)
    {
        Account print = FindAccount(bank);
        if (print == null) return;
        print.Print();
    }   

    static void NewAccount(Bank bank)
    {
        Console.Write("New account name: ");
        string name = Console.ReadLine() ?? "";
        while (true) 
        {
            if (name == "")
            {
                Console.WriteLine("Invalid input. Name cannot be empty.");
            }
            else if (bank.GetAccount(name) != null)
            {
                Console.WriteLine("An account named " + name + "Already exists. Please choose a unique name");
            }
            else
            {
                break;
            }
            Console.Write("Enter account name: ");
            name = Console.ReadLine() ?? "";
        }
        Console.Write("Starting balance: ");
        double balance;
        while (!double.TryParse(Console.ReadLine() ?? "", out balance) || balance < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Starting balance: ");
        }
        Account account = new Account(name, balance);
        bank.AddAccount(account);
        Console.WriteLine("Account Status: Successfully created account " + name);
    }

    static Account FindAccount(Bank bank)
    {
        Console.Write("Enter the account name: ");
        string name = Console.ReadLine() ?? "";
        while (name == "") 
        {
            Console.WriteLine("Invalid input. Name cannot be empty.");
            Console.Write("Enter the account name: ");
            name = Console.ReadLine() ?? "";
        }
        Account foundAccount = bank.GetAccount(name); 
        if (foundAccount == null)
        {
            Console.WriteLine("Account " + name + " not found.");
        }
        return foundAccount;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter account name: ");
        string name = Console.ReadLine() ?? "";
        while (name == "") 
        {
            Console.WriteLine("Invalid input. Name cannot be empty.");
            Console.Write("Enter account name: ");
            name = Console.ReadLine() ?? "";
        }
        Account account = new Account(name, 0);
        Bank bank = new Bank();
        bank.AddAccount(account);
        MenuOption option;
        do
        {
            option = ReadUserOption();
            Console.WriteLine($"You selected: {option}");
            switch (option)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(bank);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(bank);
                    break;
                case MenuOption.Transfer:
                    DoTransfer(bank);
                    break;
                case MenuOption.Print:
                    DoPrint(bank);
                    break;
                case MenuOption.NewAccount:
                    NewAccount(bank);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Exiting the program.");
                    break;
            }
        } while (option != MenuOption.Quit);
    }
}

