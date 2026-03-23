#include "splashkit.h"
using std::stoi;
using std::to_string;

string read_string(string input)
{
    write(input);
    return read_line();
}
int read_integer(string prompt)
{
    string input = read_string(prompt);
    while (!is_integer(input))
    {
        write("Please enter a whole number.");
        write("\n");
        input = read_string(prompt);
    }
    return stoi(input);
}
 
void give_change(int change)
{
const int NUMBER_COINS = 6;
const int TWO_DOLLARS = 200;
const int ONE_DOLLAR = 100;
const int FIFTY_CENTS = 50;
const int TWENTY_CENTS = 20;
const int TEN_CENTS = 10;
const int FIVE_CENTS = 5;

int to_give;

write("Change: ");

int coin_value;
string coin_text;

for (int i = 0; i < NUMBER_COINS; i++)
    {
        switch (i)
        {
            case 0:
                coin_value = TWO_DOLLARS;
                coin_text = "$2, ";
                break;
            case 1:
                coin_value = ONE_DOLLAR;
                coin_text = "$1, ";
                break;
            case 2:
                coin_value = FIFTY_CENTS;
                coin_text = "50c, ";
                break;
            case 3:
                coin_value = TWENTY_CENTS;
                coin_text = "20c, ";
                break;
            case 4:
                coin_value = TEN_CENTS;
                coin_text = "10c, ";
                break;
            case 5:
                coin_value = FIVE_CENTS;
                coin_text = "5c, ";
                break;
            default:
                coin_value = 1;
                coin_text = "ERROR";
                break;
        }

        to_give = change / coin_value;
        change = change - to_give * coin_value;
        write(""+to_string(to_give)+ "x" + coin_text +"");
    }
    write("");
}


int main()
{
string again = "";
string line;
   
do
{
    int cost = read_integer("Cost of item in cents: ");

   int paid = read_integer("Payment in cents: ");

    if (paid >= cost)
    {
        give_change(paid - cost);
    }
    else
    {
    write_line("Not enough to cover the cost");
    }
    
    write("\n");
    again = read_string("Run again? Y/N: ");
        
 }while(again != "N" && again != "n");

return 0;
}