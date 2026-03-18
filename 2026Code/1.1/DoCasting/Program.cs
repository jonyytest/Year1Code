using System;

    class DoCasting
    {
    static void Main(string[] args)
    {
        int sum = 42;
        int count = 12;
        int intAverage = sum / count;
        Console.WriteLine("Integer average: " + intAverage);
        double doubleAverage = (double)sum / count;
        Console.WriteLine("Double average: " + doubleAverage);
        }

    }