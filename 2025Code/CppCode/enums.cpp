#include "splashkit.h"
#include "utilities.h"

using std::to_string;

// add enumeration here called 'day'
enum day
{
    SUNDAY,
    MONDAY,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY,
    SATURDAY
};

const int NUM_DAYS = (int)SATURDAY + 1;

string to_string(day d)
{
    switch(d)
    {
        case SUNDAY:
        return "Sunday";
        case MONDAY:
        return "Monday";
        case TUESDAY:
        return "Tuesday";
        case WEDNESDAY:
        return "Wednesday";
        case THURSDAY:
        return "Thursday";
        case FRIDAY:
        return "Friday";
        case SATURDAY:
        return "Saturday";
    }
}

day read_day(string prompt)
{
    int day_number;
    int raw;
    write(prompt);
    for(raw=0; raw < NUM_DAYS; raw++)
    {
        day current_day = (day)raw;
        write_line(to_string(raw + 1) + ": " + to_string(current_day));
    }
    day_number = read_integer("Enter a day number (1-7): ") - 1;
    return(day)day_number;
}

int main()
{
    // Enum variable declaration
    day today;

    // Assigning a value to the enum variable
    today = WEDNESDAY;

    // Print the value of today
    write_line("Today is " + to_string(today));

    return 0;
}