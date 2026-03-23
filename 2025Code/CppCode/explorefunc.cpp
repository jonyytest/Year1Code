#include "splashkit.h"
using std::to_string;
using std::stoi;

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
        input = read_string(prompt);
    }
    return stoi(input);
}

int read_integerr(string prompt, int low, int high)
{
    int input = read_integer(prompt);
    while (input < low || input > high)
    {
        write_line("Please enter a value between " + to_string(low) + " " + to_string(high));
        input = read_integer(prompt);
    }
    return input;
}

int main()
{
    string name;
    int age, value;

    name = read_string("enter your name: ");

    write_line("Hello " + name);

    age = read_integer("what is your age: ");

    write_line("You entered " + to_string(age));

    value = read_integer("Enter a value between 1 and 10: ", 1, 10);
    write_line("You entered " + to_string(value));

    return 0;
}