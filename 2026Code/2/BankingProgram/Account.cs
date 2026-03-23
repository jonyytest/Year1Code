class Account
{
    private double balance;
    private string name;

    public Account(string name, double initialBalance)
    {
        this.name = name;
        this.balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }
    public void Print()
    {
        Console.WriteLine($"Account Name: {name}, Balance: {balance}");
    }
    public String Name()
    {
        return name;
    }
}