#include "splashkit.h"
#include "utilities.h"
using std::to_string;
using std::stoi;

enum user_level
{
    NO_ACCESS,
    USER,
    ADMIN,
    SUPER_USER
};

struct user_data
{
    string user;
    string pass;
    user_level role;
};

user_level read_role()
{
    write_line("Roles: \n0-No Access, \n1-User, \n2-Admin, \n3-Super User");
    int input = read_integer("Enter role level: ");
    switch(input)
    {
    case 0: return NO_ACCESS;
    case 1: return USER;
    case 2: return ADMIN;
    case 3: return SUPER_USER;
    default: write_line("Invalid role.");
    return NO_ACCESS;
    }
}

string tostring(user_level role)
{
    switch(role)
    {
        case NO_ACCESS: return "No access";
        case USER: return "User";
        case ADMIN: return "Admin";
        case SUPER_USER: return "Super User!";
        default: return "Null";
    }
}

void print_user(const user_data& user)
{
    write_line("User details:");
    write_line("Username: " + user.user);
    write_line("Password: " + user.pass);
    write_line("Permissions: " + tostring(user.role));
}

void update_user(user_data& user)
{
    bool update = true;
    while (update == true)
    {
    print_user(user);
    write_line("What do you want to change: ");
    write_line("1: Username");
    write_line("2: Password");
    write_line("3: Permission Level");
    write_line("4: Quit");
    int option=read_integer("Option: ");
    switch(option)
    {
        case 1:
        user.user = read_string("Change Username: ");
        break;
        case 2:
        user.pass = read_string("Change Password: ");
        break;
        case 3:
        user.role = read_role();
        break;
        case 4:
        update = false;
        break;
        default: write_line("Invalid option");
        break;
    }
}
}

int main()
{
    user_data user = {
        "my_user_name", "password",
        USER
    };

    update_user(user);
    print_user(user);

    double num = read_double("Write double");
    write(to_string(num));

    return 0;
}