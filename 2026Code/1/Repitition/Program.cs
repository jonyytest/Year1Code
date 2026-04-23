using System;

class Repition
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an upper bound: ");
        int upperbound = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        double average;
        int number;

        for (number = 1; number <= upperbound; number++)
        {
            sum += number;
            Console.WriteLine("Current number is " + number + " sum is " + sum);
        }

        average = (double)sum / upperbound;

        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);
        
        sum = 0;
        number = 1;
        while (number <= upperbound)
        {
            sum += number;
            Console.WriteLine("Current number is " + number + " sum is " + sum);
            number++;
        }

        average = (double)sum / upperbound;

        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);

        number = 1;
        sum = 0;
        do
        {
            sum += number;
            Console.WriteLine("Current number is " + number + " sum is " + sum);
            number++;
        } while (number <= upperbound);

        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);
    }
}