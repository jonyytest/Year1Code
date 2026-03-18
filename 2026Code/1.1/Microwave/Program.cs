using System;

    class Microwave
    { 
        static void Main(string[] args)
        {
            int items = 0;
            int duration = 0;

            Console.WriteLine("How many items are being heated?");
            try
            {
                items = Convert.ToInt32(Console.ReadLine());

                if (items > 3)
                {
                    Console.WriteLine("Warning: Heating more than three items is not recommended.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Input must be an integer.");
                return;
            }

            Console.WriteLine("How long to heat a single item? (in seconds)");
            try
            {
                duration = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Input must be an integer.");
                return;
            }

            if (items == 1)
            {
                Console.WriteLine("Heat for " + duration + " seconds.");
            }
            else if (items == 2)
            {
                Console.WriteLine("Heat for " + (duration * 1.5) + " seconds.");
            }
            else if (items == 3)
            {
                Console.WriteLine("Heat for " + (duration * 2) + " seconds.");
            }
            else
            {
                Console.WriteLine("Invalid number of items.");
            }
        }
    }
