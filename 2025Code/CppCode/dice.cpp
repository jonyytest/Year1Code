#include "splashkit.h"
#include "utilities.h"

using std::to_string;

class die
{
    private:
    int sides;
    int current_value;

    public:

    die(int s)
    {
        sides = s;
        roll();
    }

    die()
    {
        sides = 6;
        roll();
    }

    ~die()
    {}

    void roll()
    {
        current_value = rnd(1, sides);
    }

    int get_value() const
    {
        return current_value;
    }

    void print() const
    {
        write_line(to_string(sides) + " sides: value is " + to_string(current_value));
    }
    
};

class die_array
{
    die* data;
    int size;
    int capacity;

    die_array(int start_cap = 2)
    {
        size = 0;
        capacity = start_cap;
        data = new die[capacity];
    }

    ~die_array()
    {
        delete[] data;
    }

    void push_back(const die& d)
    {
        if (size == capacity)
        {
            die* temp = new die[capacity * 2];
            for (int i = 0; i < size; ++i)
            {
                temp[i] = data[i];
            }
            delete[] data;
            data = temp;
            capacity *= 2;
        }
        data[size++] = d;
    }

    die& operator[](int index)
    {
        return data[index];
    }

    int get_size() const
    {
        return size;
    }

};

void menu()
{
    write_line("\n1: Roll Die");
    write_line("2: Get new die");
    write_line("3: Quit");
}

int main()
{
    int new_sides = read_integerr("Sides: ", 1, 1000000);
    die* current = new die(new_sides);
   bool quit = false;
   while(!quit)
   {
    menu();
    int option = read_integerr("> ", 1, 3);
    switch (option)
    {
    case 1:
    {
        current->roll();
        current->print();
        break;
    }
    case 2:
    {
        delete current;
        new_sides = read_integer("Sides: ");
        current = new die(new_sides);
        break;
    }
    case 3:
    {
        quit = true;
        break;
    }
    default:
    {
        write_line("Invalid option");
        break;
    }
    }
   }
   delete current;
   write_line("Bye!");
   return 0;
}