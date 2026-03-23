#include "splashkit.h"
#include "utilities.h"

using std::to_string;
using std::stoi;

struct book_data
{
    string title;
    string location;
    int pages;
};

enum menu_options
{
    READ_BOOK,
    PRINT_BOOK,
    QUIT
};

book_data new_book()
{
    book_data result;
    write_line("");
    result.title    = read_string("Enter the name of the book: ");
    result.location = read_string("Enter book location: ");
    result.pages    = read_integer("Enter number of pages: ");
    return result;
}

void print_book(book_data book)
{
    write_line("");
    write_line("Book details:");
    write_line("Title: "    + book.title);
    write_line("Location: " + book.location);
    write_line("Pages: "    + to_string(book.pages));
}

menu_options menu()
{
    write_line("");
    write_line("Menu:");
    write_line("1 - Read book");
    write_line("2 - Print book");
    write_line("3 - Quit");
    int option = read_integer("Option: ");
    write_line("");

    switch(option)
    {
        case 1: return READ_BOOK;
        case 2: return PRINT_BOOK;
        case 3: return QUIT;
        default:
            write_line("Invalid option.");
            return menu();
    }
}

int main()
{
    write_line("Book entry system:");
    book_data book = new_book();
    bool running = true;

    while (running)
    {
        menu_options choice = menu();

        switch (choice)
        {
            case READ_BOOK:
                book = new_book();
                break;
            case PRINT_BOOK:
                print_book(book);
                break;
            case QUIT:
                running = false;
                write_line("Exiting program.");
                break;
        }
    }

    return 0;
}
