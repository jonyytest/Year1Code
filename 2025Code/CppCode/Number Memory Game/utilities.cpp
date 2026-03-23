#include "utilities.h"
#include "splashkit.h"

string read_string(string prompt)
{
  write(prompt);
  return read_line();
}

int read_integer(string prompt)
{
  string line = read_string(prompt);
  while (!is_integer(line))
  {
    write_line("Please enter a whole number.");
    write("\n");
    line= read_string(prompt);
  }
  return stoi(line);
}

double read_double(string prompt)
{
  string line = read_string(prompt);
  while (!is_double(line))
  {
    write_line("Please enter a real number.");
    write("\n");
    line= read_string(prompt);
  }
  return convert_to_double(line);
}

int read_integerr(string prompt, int low, int high)
{
  int input = read_integer(prompt);
    while (input < low || input > high)
    {
        write_line("Please enter a value between " + std::to_string(low) + " " + std::to_string(high));
        input = read_integer(prompt);
    }
    return input;
}