#include "dynamic_array.hpp"
#include "splashkit.h"
#include "utilities.h"
#include <cstdio>
using std::to_string;

int read_integer(const char *prompt)
{
    int result = 0;
    printf("%s", prompt);

    while(scanf("%d", &result) != 1)
    {
        scanf("%*[^\n]");
        printf("Please enter a whole number.\n");
        printf("%s", prompt);
    }
    return result;
}

double read_double(const char *prompt)
{
    double result = 0;
    printf("%s", prompt);

    while(scanf("%lf", &result) != 1)
    {
        scanf("%*[^\n]");
        printf("Please enter a number.\n");
        printf("%s", prompt);
    }
    return result;
}

void populate_array(dynamic_array<double> *data)
{
    int size = read_integer("How many values will you store?: ");
    write_line("Enter Values:");
    for (int i = 0; i < size; i++) {
        double value = read_double(": ");
        add_to_dynamic_array(data, value);
    }
}

void print(const dynamic_array<double> *data)
{
    for (int i = 0; i < data->size; i++) {
        printf("%d: %lf\n", i, get_from_dynamic_array(data, i));
    }
}

double max(const dynamic_array<double> *data)
{
    if (data->size == 0)
        return 0;
    double max_val = get_from_dynamic_array(data, 0);
    for (int i = 1; i < data->size; i++) {
        double val = get_from_dynamic_array(data, i);
        if (max_val < val) {
            max_val = val;
        }
    }
    return max_val;
}

double sum(const dynamic_array<double> *data)
{
    double total = 0;
    for (int i = 0; i < data->size; i++) {
        total += get_from_dynamic_array(data, i);
    }
    return total;
}

double mean(const dynamic_array<double> *data)
{
    if (data->size > 0)
        return sum(data) / data->size;
    else return 0;
}

void add_data(dynamic_array<double> *data)
{
    double add = read_double("Enter new value: ");
    add_to_dynamic_array(data, add);
}

void remove_data(dynamic_array<double> *data)
{
    print(data);
    int index = read_integer("Which index would you like to remove: ");
    if (index < data->size && index >= 0)
    {
        for (int i = index; i < data->size - 1; i++)
        {
            set_in_dynamic_array(data, i, get_from_dynamic_array(data, i + 1));
        }
        data->size--;
    }
    else printf("Invalid index.\n");
}

void print_menu()
{
    printf("\nMenu\n");
    printf("1. Add a value\n");
    printf("2. Remove a value\n");
    printf("3. Print the values\n");
    printf("4. Calculate stats\n");
    printf("5. Quit\n");
}

int main()
{
    dynamic_array<double> *data = new_dynamic_array<double>(10);
    int option;

    populate_array(data);
    print_menu();
    option = read_integerr("Enter an option: ", 1, 5);

    while (option != 5)
    {
        switch (option)
        {
            case 1:
                add_data(data);
                break;
            case 2:
                remove_data(data);
                break;
            case 3:
                printf("\nYou entered...\n\n");
                print(data);
                break;
            case 4:
                printf("\nCalculating statistics...\n\n");
                printf("Sum:        %4.2lf\n", sum(data));
                printf("Mean:       %4.2lf\n", mean(data));
                printf("Max:        %4.2lf\n", max(data));
                break;
        }
        read_string("Press Enter to continue...");
        print_menu();
        option = read_integerr("Enter an option: ", 1, 5);
    }

    printf("Goodbye!\n");
    delete_dynamic_array(data);
    data = nullptr;
    return 0;
}