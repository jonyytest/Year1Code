#include "splashkit.h"

using std::to_string;

string read_string(string prompt)
{
    string result;

    write(prompt);
    result = read_line();

    return result;
}

int read_integer(string prompt)
{
    string line;
    line = read_string(prompt);
    return convert_to_integer(line);
}

int total_length(string names[], int size)
{
    int length =0;
    for (int i=0; i < size; i++)
    {
    length = length + length_of(names[i]);
    }
    return length;
}

bool contains(string names[], int size, string name)
{
    for(int i=0; i < size; i++)
    {
    if(to_lowercase(names [i]) == to_lowercase(name))
    {
        return true;
    }
    }
    return false;
}

string shortest_name(string names[], int size)
{
    string min;
    min=names[0];
    for(int i=1; i < size; i++)
    {
        if (min.length() > names[i].length())
        {
            min = names[i];
        }
    }
    return min;
}

int index_of(string name, string names[], int size)
{
    for(int i=0; i < size; i++)
    {
    if(to_lowercase(names [i]) == to_lowercase(name))
    return i;
    }
    int i = -1;
    return i;
}

int main()
{
    #define SIZE 5
    string names[SIZE];
    int i =0;

    while(i < SIZE)
    {
         names[i] = read_string("Enter name: ");
         i++; 
    }

    for (i=0; i < SIZE; i++)
    {
       write_line(names[i]);
    }

    write_line("Total Length: " + to_string(total_length(names, SIZE)));

    bool has_name = contains(names, SIZE, read_string("Search for name: "));
    if (has_name) write_line("Contains name.");
    else write_line("Not Found.");

    write_line("Shortest name: " + shortest_name(names, SIZE));

    string search = read_string("Search name index for name: ");
    if(i > -1)
    {
    write_line(search + " found at index: " + to_string(index_of(search, names, SIZE)));
    }
    else if(i == -1)
    {
        write_line("Name not found.");
    }

    return 0;
}