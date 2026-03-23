#include "splashkit.h"
using std::to_string;
using std::stoi;

const int MAX_NUMBER = 100;
const int MAX_GUESSES = 7;

string read_string(string input)
{
    write(input);
    return read_line();
}

int read_integer(string prompt)
{
    string input = read_string(prompt);
    while (!is_integer(input))
    {
        write("Please enter a whole number.");
        write("\n");
        input = read_string(prompt);
    }
    while (stoi(input) > MAX_NUMBER || stoi(input) < 1)
    {
        write("Please enter a number between 1 and 100.");
        write("\n");
        input = read_string(prompt);
    }
    return stoi(input);
}

int read_integer(string prompt, int low, int high)
{
    int input = read_integer(prompt);
    while (input < low || input > high)
    {
        write_line("Please enter a value between " + to_string(low) + " " + to_string(high));
        input = read_integer(prompt);
    }
    return input;
}

void print_line(int length)
{
    int i = 0;
while (i < length)
{
    write("-");
    i++;
}
write("\n");
}

bool perform_guess(int guess_number, int target)
{
    int guess;
    guess = read_integer("Guess " + to_string(guess_number) + ": ");
    if(guess > target)
    {
        write("The number is less than " + to_string(guess));
        write("\n");
    }
    else if(guess < target)
    {
        write("The number is greater than " + to_string(guess));
        write("\n");
    }
    else
    {
        write("Correct! The number is " + to_string(guess));
        write("\n");
    }
    return guess == target;
}


void play_game()
{
    int my_number, guess_number;
    bool got_it;

    my_number = rnd(1, MAX_NUMBER);
    guess_number = 0;

    write("I have chosen a number between 1 and " + to_string(MAX_NUMBER) + "\n");
    
    do
    {
        guess_number++;
        got_it = perform_guess(guess_number, my_number);
    } while (guess_number < MAX_GUESSES && !got_it);
    
    if(!got_it)
    {
        write("You have ran out of guesses.\nThe number was " + to_string(my_number) + "\n");
    }
}

int main()
{
    string again = "";

    do
    {
        play_game();
        print_line(50);
        again = read_string("Play again? [Y or n]: ");
    } while (again != "n" && again != "N");

    write("\nBye");
    return 0;
   
}
