using System;
class DivisibleFour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int num))
            {
                Console.WriteLine($"Numbers divisible by 4 but not by 5 from {num} down to 1:");
            for (int n = num; n > 0; n--)
            {
            if (n % 4 == 0 && n % 5 != 0)
            {
                Console.WriteLine(n);
            }
            n--;
            }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            
        }
    }
