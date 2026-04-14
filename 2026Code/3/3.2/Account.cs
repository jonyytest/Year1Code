class Account
{
    private double balance;
    private string name;

    public Account(string name, double initialBalance)
    {
        this.name = name;
        this.balance = initialBalance;
    }

    public bool Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Print()
    {
        Console.WriteLine($"Account Name: {name}, Balance: {balance}");
    }
    public String Name(string name)
    {
        return name;
    }
}