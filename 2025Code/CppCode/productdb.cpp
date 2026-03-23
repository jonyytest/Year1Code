#include "splashkit.h"
#include "utilities.h"
#include <cstdio>
using std::to_string;

const int MAX_PRODUCTS = 100;

struct product
{
    string product_name;
    double cost_price;
    double sale_price;
    int quantity;
};

struct product_list
{
    product info[MAX_PRODUCTS];
    int size;
    double sales;
    double profit;
};

void print_status(const product_list &products)
{
    int low = 0;
    for (int i=0; i < products.size; i++)
    {
        if (products.info[i].quantity < 10)
        {
            low++;
        }
    }
    double stock_value;
    for (int b=0; b < products.size; b++)
    {
        stock_value += products.info[b].quantity * products.info[b].cost_price;
    }
printf("Total sale value: $%.2f\n", products.sales);
printf("Total profit: $%.2f\n", products.profit);
printf("Number of products: %d\n", products.size);
printf("Value of stock on hand: $%.2f\n", stock_value);
printf("Products with low stock: %d\n", low);

    return;
}

void sell_product(product_list &products)
{
    string search = to_lowercase(read_string("Enter a Product name: "));
    bool found = false;

    for (int i = 0; i < products.size; i++)
    {
        string name = to_lowercase(products.info[i].product_name);
        int name_len = name.length();
        int search_len = search.length();

        for (int j = 0; j <= name_len - search_len; j++)
        {
            if (name.substr(j, search_len) == search)
            {
                printf("%d: %s | Quantity: %d\n", i, products.info[i].product_name.c_str(), products.info[i].quantity);
                found = true;
                break;
            }
        }
    }
    if (!found)
    {
        write_line("Product not found.");
        return;
    }

    int index = read_integer("Which index would you like to add sales: ");
    if (index < products.size && index >= 0)
    {
        int sold = -1;
        do
        {
        sold = read_integer("Number of units sold: ");
        if (sold < 0 && sold <= products.info[index].quantity)
        {
            printf("Enter a number less than or equal to the product quantity: %d", products.info[index].quantity);
        }
        } while (sold < 0 && sold <= products.info[index].quantity);
        products.sales += sold * products.info[index].sale_price;
        products.profit += sold * (products.info[index].sale_price - products.info[index].cost_price);
        if (sold == products.info[index].quantity)
        {
            for(int r = index; r < products.size -1; r++)
        {
            products.info[r] = products.info[r+1];
        }
        products.size--;
        }
        else
        {
        products.info[index].quantity -= sold;
        }
    }
    else printf("Invalid index.\n");

    return;
}

void remove_product(product_list &products)
{
    string search = to_lowercase(read_string("Enter a Product name: "));
    bool found = false;

    for (int i = 0; i < products.size; i++)
    {
        string name = to_lowercase(products.info[i].product_name);
        int name_len = name.length();
        int search_len = search.length();

        for (int j = 0; j <= name_len - search_len; j++)
        {
            if (name.substr(j, search_len) == search)
            {
                printf("%d: %s | Quantity: %d\n", i, products.info[i].product_name.c_str(), products.info[i].quantity);
                found = true;
                break;
            }
        }
    }

    if (!found)
    {
        write_line("Product not found.");
        return;
    }

    int index = read_integer("Which index would you like to remove: ");
    if (index < products.size && index >= 0)
    {
        for(int r = index; r < products.size -1; r++)
        {
            products.info[r] = products.info[r+1];
        }
        products.size--;
    }
    else printf("Invalid index.\n");

    return;
}

void add_product(product_list &products)
{
    if (products.size >= MAX_PRODUCTS)
    {
        printf("Error. You can only enter %d products.\n", MAX_PRODUCTS);
        return;
    }
        if (products.size < 0)
        {
            products.size=0;
        }
        products.info[products.size].product_name = read_string("New product name: ");
        products.info[products.size].cost_price = read_double("New product cost: ");
        do 
        {
            products.info[products.size].sale_price = read_double("New product sale price: ");
        if (products.info[products.size].sale_price <= products.info[products.size].cost_price)
        {
            write_line("Sale price must be more than cost price.");
        }
    } while (products.info[products.size].sale_price <= products.info[products.size].cost_price);
        products.info[products.size].quantity = read_integerr("New product quantity: ", 1, 100000);
        products.size++;
        return;
}

void update_product(product_list &products)
{
    string search = to_lowercase(read_string("Enter a Product name: "));
    bool found = false;

    for (int i = 0; i < products.size; i++)
    {
        string name = to_lowercase(products.info[i].product_name);
        int name_len = name.length();
        int search_len = search.length();

        for (int j = 0; j <= name_len - search_len; j++)
        {
            if (name.substr(j, search_len) == search)
            {
                printf("%d: %s | Quantity: %d\n", i, products.info[i].product_name.c_str(), products.info[i].quantity);
                found = true;
                break;
            }
        }
    }
     if (!found)
    {
        write_line("Product not found.");
        return;
    }

    int index = read_integer("Which index would you like to update: ");
    if (index < products.size && index >= 0)
    {
        int choice;
    do
    {
    printf("%d: %s Costs: $%.2f Sold at: $%.2f Quantity: %d\n", index, products.info[index].product_name.c_str(), products.info[index].cost_price, products.info[index].sale_price, products.info[index].quantity);
    write_line("1: Update name");
    write_line("2: Update cost");
    write_line("3: Update sale price");
    write_line("4: Update quantity");
    write_line("5: Exit update");
    choice = read_integerr("Enter option: ", 1, 5);
    switch (choice)
    {
        case 1:
        {
          products.info[index].product_name = read_string("Update product name: ");  
          break;
        }
        case 2:
        {
           do {
            products.info[index].cost_price = read_double("Update product cost price: ");
        if (products.info[index].sale_price <= products.info[index].cost_price)
        {
            write_line("Sale price must be more than cost price.");
        }
    } while (products.info[index].sale_price <= products.info[index].cost_price);
    break;
        }
        case 3:
        {
            do {
            products.info[index].sale_price = read_double("Update product sale price: ");
        if (products.info[index].sale_price <= products.info[index].cost_price)
        {
            write_line("Sale price must be more than cost price.");
        }
    } while (products.info[index].sale_price <= products.info[index].cost_price);
    break;
        }
        case 4:
        {
            products.info[index].quantity = read_integerr("New product quantity: ", 1, 100000);
        }
    }
} while (choice != 5);
    }
    else {
        write_line("Invalid Index"); 
        return;
    }
return;
}

int menu(const product_list &products)
{
    write_line("\n|= Product Database Menu =|\n");
    write_line("1: Add New Product");
    if (products.size > 0)
    {
    write_line("2: Delete Product");
    write_line("3: Update Product");
    write_line("4: Sell Product");
    write_line("5: Print Status");
    }
    write_line("6: Quit");
    return read_integerr("Enter your choice number: ", 1, 6);
}

int main()
{
    bool quit = false;
    product_list products = {};
    products.size = 0;
    products.sales = 0;
    products.profit = 0;
    write_line("Welcome to the Product Database\n");
    while (!quit)
    {
        int option = menu(products);
        switch (option)
        {
            case 1:
            {
                add_product(products);
                break;
            }
            case 2:
            {
                if (products.size > 0) {
                remove_product(products);
                }
                else write_line("Please add a product first.");
                break;
            }
            case 3:
            {
                if (products.size > 0) {
                update_product(products);
                }
                else write_line("Please add a product first.");
                break;
            }
            case 4:
            {
                if (products.size > 0) {
                sell_product(products);
                }
                else write_line("Please add a product first.");
                break;
            }
            case 5:
            {
                if (products.size > 0) {
                print_status(products);
                }
                else write_line("Please add a product first.");
                break;
            }
            case 6:
            {
                string quitting=read_string("Are you sure you want to quit? Y/n:\n");
                if(to_lowercase(quitting) == "y") quit = true;
                else if(to_lowercase(quitting) == "n") quit = false;
                else write_line("Invalid option"); break;
            }
        }
        read_string("Press Enter to continue...");
    }
    write_line("Goodbye!");
return 0;

}
