#include "splashkit.h"

void print_repeated(string text, int times, bool with_newline)
{
    int i = 0;
while (i < times)
{
    write(text);
    i++;
}
if(with_newline == true)
{
    write("\n");
}
}

void print_line(int length)
{
print_repeated("-", length, true);
}

int main()
{
        string input;
  int test_length;
  write("\n");

  print_repeated("(-----)", 6, true);
  print_repeated("| Welcome to the print line test program |", 1, true);
  print_repeated("(-----)", 6, true);
  write("\n");

  write("Enter a length for a test line: ");
  input = read_line();
  test_length = stoi(input);

  print_line(test_length);

}
