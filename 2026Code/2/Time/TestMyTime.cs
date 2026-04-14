using System;
using System.Threading;

class TestMyTime
{
    static void Main(string[] args)
    {
        MyTime time = new MyTime(0, 0, 0);

        Console.WriteLine("Enter hours:");
        int hours;
        while (!int.TryParse(Console.ReadLine(), out hours))
        {
            Console.WriteLine("Invalid input, please enter a number for hours:");
        }
        time.SetHour(hours);

        Console.WriteLine("Enter minutes:");
        int minutes;
        while (!int.TryParse(Console.ReadLine(), out minutes))
        {
            Console.WriteLine("Invalid input, please enter a number for minutes:");
        }
        time.SetMinute(minutes);

        Console.WriteLine("Enter seconds:");
        int seconds;
        while (!int.TryParse(Console.ReadLine(), out seconds))
        {
            Console.WriteLine("Invalid input, please enter a number for seconds:");
        }
        time.SetSecond(seconds);
        
        bool exit = false;
        while (exit == false)
        {
            int option = 0;
            while (option == 0)
            {
            Console.WriteLine("Time: " + time.ToString());
            Console.WriteLine("Options:");
            Console.WriteLine("1: Add Time");
            Console.WriteLine("2: Subtract Time");
            Console.WriteLine("3: Set Time");
            Console.WriteLine("4: Exit");
            string input = Console.ReadLine() ?? "";
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Invalid option, try again.");
                option = 0;
            }
            }
            switch (option)
            {
                case 1:    
                Console.Clear();
                Console.WriteLine("Choose unit to add:");
                Console.WriteLine("1: Seconds");
                Console.WriteLine("2: Minutes");
                Console.WriteLine("3: Hours");
                int unit;
                while (!int.TryParse(Console.ReadLine(), out unit) || unit < 1 || unit > 3)
                {
                    Console.WriteLine("Invalid unit, please choose 1, 2, or 3:");
                }
                Console.WriteLine("How much to add: ");
                int count;
                while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
                {
                    Console.WriteLine("Invalid count, please enter a non-negative number:");
                }
                for (int i = 0; i < count; i++)
                {
                    Thread.Sleep(10);
                    Console.Clear();   
                    Console.WriteLine("Time: " + time.ToString());
                    if (unit == 1) time.NextSecond();
                    else if (unit == 2) time.NextMinute();
                    else if (unit == 3) time.NextHour();
                }
                option = 0;
                break;
                case 2:
                Console.Clear();
                Console.WriteLine("Choose unit to subtract:");
                Console.WriteLine("1: Seconds");
                Console.WriteLine("2: Minutes");
                Console.WriteLine("3: Hours");
                int unit2;
                while (!int.TryParse(Console.ReadLine(), out unit2) || unit2 < 1 || unit2 > 3)
                {
                    Console.WriteLine("Invalid unit, please choose 1, 2, or 3:");
                }
                Console.WriteLine("How much to subtract: ");
                int count2;
                while (!int.TryParse(Console.ReadLine(), out count2) || count2 < 0)
                {
                    Console.WriteLine("Invalid count, please enter a non-negative number:");
                }
                for (int i = 0; i < count2; i++)                
                {
                    Thread.Sleep(10);
                    Console.Clear();   
                    Console.WriteLine("Time: " + time.ToString());
                    if (unit2 == 1) time.PreviousSecond();
                    else if (unit2 == 2) time.PreviousMinute();
                    else if (unit2 == 3) time.PreviousHour();
                }
                option = 0;
                break;
                case 3:
                Console.Clear();
                Console.WriteLine("Current hours: " + time.GetHour());
                Console.WriteLine("Enter new hours:");
                int newHours;
                while (!int.TryParse(Console.ReadLine(), out newHours))
                {
                    Console.WriteLine("Invalid input, please enter a number for hours:");
                }
                time.SetHour(newHours);
                Console.WriteLine("Current minutes: " + time.GetMinute());
                Console.WriteLine("Enter new minutes:");
                int newMinutes;
                while (!int.TryParse(Console.ReadLine(), out newMinutes))
                {
                    Console.WriteLine("Invalid input, please enter a number for minutes:");
                }
                time.SetMinute(newMinutes);
                Console.WriteLine("Current seconds: " + time.GetSecond());
                Console.WriteLine("Enter new seconds:");
                int newSeconds;
                while (!int.TryParse(Console.ReadLine(), out newSeconds))
                {
                    Console.WriteLine("Invalid input, please enter a number for seconds:");
                }
                time.SetSecond(newSeconds);
                option = 0;
                break;
                case 4:
                exit = true;
                break;
                default:
                Console.WriteLine("Invalid option, try again.");
                option = 0;
                break;
                
            }
        }
    }
}