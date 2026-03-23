/* dynamic-test.cpp - written by Jonathan Moffitt */

#include <cstdlib>
#include "splashkit.h"
#include "utilities.h"

using std::to_string;

int main()
{
   double *data_ptr;
   int size;

    size = read_integer("How many values do you want to store?");
    data_ptr = (double *)malloc(size * sizeof(double));

    if (data_ptr == NULL)
    {
        write_line("Memory allocation failed");
        return 1;
    }

    for (int i=0; i < size; i++)
    {
        data_ptr[i] = read_double("Enter a number: ");
    }

    for (int i=0; i < size; i++)
    {
        write_line("Value at index " + to_string(i) + ": " + to_string(data_ptr[i]));
    }

    free(data_ptr);
    data_ptr = NULL;

    return 0;
}