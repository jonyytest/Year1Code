using System;
class EmployeeProgram
{
    static void Main(string[] args)
    {
        Employee employee1 = new Employee("Bob", 50000.00);

        Console.WriteLine("Employee Name: " + employee1.getName() 
        + "\nCurrent Salary: " + employee1.getSalary().ToString("C"));
        Console.WriteLine();

        Console.WriteLine("Raising salary by 10%...");
        employee1.raiseSalary(10);
        Console.WriteLine("Employee Name: " + employee1.getName() 
        + "\nNew Salary: " + employee1.getSalary().ToString("C"));
        Console.WriteLine();

        Console.WriteLine("Calculating tax...");
        Console.WriteLine("Tax Amount: " + employee1.Tax().ToString("C"));
        Console.WriteLine();

        Employee employee2 = new Employee("Jenny", 110000.00);

        Console.WriteLine("Employee Name: " + employee2.getName() 
        + "\nCurrent Salary: " + employee2.getSalary().ToString("C"));
        Console.WriteLine();

        Console.WriteLine("Raising salary by 5%...");
        employee2.raiseSalary(5);
        Console.WriteLine("Employee Name: " + employee2.getName() 
        + "\nNew Salary: " + employee2.getSalary().ToString("C"));
        Console.WriteLine();

        Console.WriteLine("Calculating tax...");
        Console.WriteLine("Tax Amount: " + employee2.Tax().ToString("C"));
        Console.WriteLine();
    }
}

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
