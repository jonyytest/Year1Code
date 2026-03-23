class Employee
{
    private string name;
    private double salary;

    public Employee(string name, double salary)
    {
        this.name = name;
        this.salary = salary;
    }
    public String getName()
    {
        return this.name;
    }
    public double getSalary()
    {
        return this.salary;
    }
    public void raiseSalary(double percentage)
    {
        this.salary = this.salary + (this.salary * (percentage / 100));
    }
    public double Tax()
{
    double taxAmount = 0;

    if (this.salary <= 18200)
    {
        taxAmount = 0; 
    }
    else if (this.salary <= 37000)
    {
        taxAmount = (this.salary - 18200) * 0.19;
    }
    else if (this.salary <= 90000)
    {
        taxAmount = 3572 + (this.salary - 37000) * 0.325;
    }
    else if (this.salary <= 180000)
    {
        taxAmount = 20797 + (this.salary - 90000) * 0.37;
    }
    else
    {
        taxAmount = 54096 + (this.salary - 180000) * 0.45;
    }

    return taxAmount;
    }

}
