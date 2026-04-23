using System;

class GuessingNumber
{
    static void Main(string[] args)
    {
        int number = 0;
        Console.WriteLine("User one, enter a number between 1 and 10 for user two to guess: ");
        while (number == 0)
        {
        string input1 = Console.ReadLine() ?? "";
        if (int.TryParse(input1, out number))
        {
            if (number <= 10 && number >= 1)
            {
                Console.Clear();
                Console.WriteLine("User two, it's your turn to guess the number!");
            }
            else
            {
                Console.WriteLine("Please enter a valid number between 1 and 10.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid NUMBER between 1 and 10.");
        }
        }
        Console.WriteLine("User two, guess the number between 1 and 10: ");
        int guess = 0;
        while (guess != number)
        {
            string input2 = Console.ReadLine() ?? "";
            if (int.TryParse(input2, out guess)) 
            {
                if (guess <= 10 && guess >= 1)
                {
                    if (guess == number)
                    {
                        Console.WriteLine("You have guessed the number! Well done!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that's not correct. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 10.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid NUMBER between 1 and 10.");
            }
        }
    }
}