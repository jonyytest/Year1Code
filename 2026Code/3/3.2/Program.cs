using System;

enum MenuOption
{
    Withdraw,
    Deposit,
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
            Console.WriteLine("3. Print");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";
            try
            {
                choice = Convert.ToInt32(input);
                if (choice >= 1 && choice <= 4)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
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
            double amount = Convert.ToDouble(input);
            if (account.Deposit(amount))
            {
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Deposit failed. Amount must be positive.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void DoWithdraw(Account account)
    {
        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            double amount = Convert.ToDouble(input);
            if (account.Withdraw(amount))
            {
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Withdrawal failed. Amount must be positive and less than or equal to balance.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void DoPrint(Account account)
    {
        account.Print();
    }   

    static void Main(string[] args)
    {
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
            case MenuOption.Print:
                DoPrint(account);
                break;
            case MenuOption.Quit:
                Console.WriteLine("Exiting the program.");
                break;
        }
    } while (option != MenuOption.Quit);
    }
}

