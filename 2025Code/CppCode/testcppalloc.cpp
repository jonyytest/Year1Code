#include "splashkit.h"
#include "utilities.h"

using std::to_string;

struct account
{
    string name;
    int balance;
};

void print_account(account &act)
{
    write_line("Name: " + act.name);
    write_line("Balance: " + to_string(act.balance));
}

int main()
{
    account *ptr;
    ptr = new account();

    ptr->name = "My Account";
    ptr->balance = 154;

    write_line("Name: " + ptr->name);
    write_line("Balance: " + to_string(ptr->balance));

    print_account(*ptr);

    delete ptr;
    ptr = NULL;

    return 0;
}