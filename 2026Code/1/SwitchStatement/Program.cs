using System;

    class SwitchStatement
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number (as an integer): ");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;

                    default: Console.WriteLine("ERROR: Must be an integer between 1 and 9"); break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Input must be an integer");
            }
            Console.ReadLine();
        }
    }
