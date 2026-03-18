using System;

class MobileProgram
{
    static void Main(string[] args)
    {
        Mobile jinMobile = new Mobile("Monthly", "Samsung Galaxy S9", "07712223344");

        Console.WriteLine("Account Type: " + jinMobile.getAccType() 
        + "\nMobile Number: " + jinMobile.getNumber() 
        + "\nDevice: " + jinMobile.getDevice()
        + "\nBalance: " + jinMobile.getBalance());

        Console.WriteLine();
        jinMobile.addCredit(10.00);
        jinMobile.makeCall(5);
        jinMobile.sendText(2);
        Console.ReadLine();


        jinMobile.setAccType("PAYG");
        jinMobile.setDevice("iPhone 6S");
        jinMobile.setNumber("07713334466");
        jinMobile.setBalance(15.50);

        Console.WriteLine();
        Console.WriteLine("Account Type: " + jinMobile.getAccType() 
        + "\nMobile Number: " + jinMobile.getNumber() 
        + "\nDevice: " + jinMobile.getDevice()
        + "\nBalance: " + jinMobile.getBalance());

        Console.WriteLine();
        jinMobile.addCredit(10.00);
        jinMobile.makeCall(5);
        jinMobile.sendText(2);
        Console.ReadLine();

        Mobile anaMobile = new Mobile("PAYG", "iPhone 16", "07776112822");

        Console.WriteLine("Account Type: " + anaMobile.getAccType() 
        + "\nMobile Number: " + anaMobile.getNumber() 
        + "\nDevice: " + anaMobile.getDevice()
        + "\nBalance: " + anaMobile.getBalance());

        Console.WriteLine();
        anaMobile.addCredit(20.00);
        anaMobile.makeCall(10);
        anaMobile.sendText(5);
        Console.ReadLine();
    }

}

class Mobile
{
    private String accType, device, number;
    private double balance;

    private const double CALL_COST = 0.245;
    private const double TEXT_COST = 0.078;
    public Mobile(String accType, String device, String number)
    {
        this.accType = accType;
        this.device = device;
        this.number = number;
        this.balance = 0.0;
    }
    public String getAccType()
    {
        return this.accType;
    }
    public String getDevice()
    {
        return this.device;
    }
    public String getNumber()
    {
        return this.number;
    }
    public String getBalance()
    {
        return this.balance.ToString("C");
    }
    public void setAccType(String accType)
    {
        this.accType = accType;
    }
    public void setDevice(String device)
    {
        this.device = device;
    }
    public void setNumber(String number)
    {
        this.number = number;
    }
    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    public void addCredit(double amount)
    {
        this.balance += amount;
        Console.WriteLine("Credit added successfully. New balance: " + getBalance());
    }   
    public void makeCall(double minutes)
    {
        double cost = minutes * CALL_COST;
        this.balance -= cost;
        Console.WriteLine("Call made. New balance: " + getBalance());
    }
    public void sendText(int numTexts)
    {
        double cost = numTexts * TEXT_COST;
        this.balance -= cost;
        Console.WriteLine("Text sent. New balance: " + getBalance());
    }
}
