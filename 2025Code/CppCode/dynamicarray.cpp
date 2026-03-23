#include "dynamic_array.hpp"
#include "splashkit.h"
#include "utilities.h"
#include <new>
using std::to_string;

int main()
{
  // Create a dynamic array of int
  // and initialise it to a new dynamic array of 10 elements
  dynamic_array<int> *array = new_dynamic_array<int>(10);

  // Add 15 values to the array
  for(int i = 0; i < 15; i++)
  {
    add_to_dynamic_array(array, i);
  }

  write_line("Array size: " + to_string(array->size));
  write_line("Array capacity: " + to_string(array->capacity));

  for(int i = 0; i < array->size; i++)
  {
    int value = get_from_dynamic_array(array, i);
    write_line("Value at index " + to_string(i) + " = " + to_string(value));
    set_in_dynamic_array(array, i, value * 2);
  }

  try
  {
    int value = get_from_dynamic_array(array, 99);
    write_line("Error! Value at 99 = " + to_string(value));
  }
  catch(const string &e)
  {
    write_line("Exception: " + e);
  }

  try
  {
    set_in_dynamic_array(array, 99, 123);
    write_line("Error! Set value at 99");
  }
  catch(const string &e)
  {
    write_line("Exception: " + e);
  }
  

  // Free the array and ensure we do not have a dangling pointer
  delete_dynamic_array(array);
  array = nullptr;

  return 0;
}

