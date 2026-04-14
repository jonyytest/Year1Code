using System;

enum MenuOption
{
    Withdraw,
    Deposit,
    Transfer,
    Print,
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
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";
            try
            {
                choice = Convert.ToInt32(input);
                if (choice >= 1 && choice <= 5)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (!valid);
        return (MenuOption)(choice - 1);
    }

    static void DoDeposit(Account account)
    {
        Console.Write("Enter amount to deposit: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            DepositTransaction transaction = new DepositTransaction(account, amount);
            transaction.Execute();
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

    static void DoWithdraw(Account account)
    {
        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
            transaction.Execute();
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

    static void DoTransfer(Account fromAccount, Account toAccount)
    {
        Console.Write("Enter amount to transfer: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            decimal amount = Convert.ToDecimal(input);
            TransferTransaction transaction = new TransferTransaction(fromAccount, toAccount, amount);
            transaction.Execute();
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

    static void DoPrint(Account account, Account friendAccount)
    {
        account.Print();
        friendAccount.Print();
    }   

    static void Main(string[] args)
    {
        Account friendAccount = new Account("Friend's Account", 1000);
        Console.Write("Enter account name: ");
        string name = Console.ReadLine() ?? "";
        Account account = new Account(name, 0);
        MenuOption option;
    do
    {
        option = ReadUserOption();
        Console.WriteLine($"You selected: {option}");
        switch (option)
        {
            case MenuOption.Withdraw:
                DoWithdraw(account);
                break;
            case MenuOption.Deposit:
                DoDeposit(account);
                break;
            case MenuOption.Transfer:
                DoTransfer(account, friendAccount);
                break;
            case MenuOption.Print:
                DoPrint(account, friendAccount);
                break;
            case MenuOption.Quit:
                Console.WriteLine("Exiting the program.");
                break;
        }
    } while (option != MenuOption.Quit);
    }
}

