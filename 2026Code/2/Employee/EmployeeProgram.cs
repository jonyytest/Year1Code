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

