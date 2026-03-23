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
