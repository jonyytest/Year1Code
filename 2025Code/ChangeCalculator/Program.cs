using static System.Convert;
using static SplashKitSDK.SplashKit;

const int NUMBER_COINS = 6;
const int TWO_DOLLARS = 200;
const int ONE_DOLLAR = 100;
const int FIFTY_CENTS = 50;
const int TWENTY_CENTS = 20;
const int TEN_CENTS = 10;
const int FIVE_CENTS = 5;

string userInput;
int cost;
int paid;
int change;
int toGive;
int coinValue;
string coinText;
string again;

do
{
    WriteLine("Cost of item (in cents):");
    userInput = ReadLine();

    while (!IsInteger(userInput))
    {
        WriteLine("Please enter the cost of the item as a whole number: ");
        userInput = ReadLine();
    }
    cost = ToInt32(userInput);

    WriteLine("Amount paid (in cents):");
    userInput = ReadLine();
    while (!IsInteger(userInput))
    {
        WriteLine("Please enter the amount paid as a whole number: ");
        userInput = ReadLine();
    }
    paid = ToInt32(userInput);

    change = paid - cost;

    if (change < 0)
    {
        WriteLine("Not enough money was paid.");
        Write("Run again? Y/N: ");
        again = ReadLine();
        continue;
    }
    WriteLine($"Change: {change}c");

    for (int i = 0; i < NUMBER_COINS; i++)
    {
        switch (i)
        {
            case 0:
                coinValue = TWO_DOLLARS;
                coinText = "$2, ";
                break;
            case 1:
                coinValue = ONE_DOLLAR;
                coinText = "$1, ";
                break;
            case 2:
                coinValue = FIFTY_CENTS;
                coinText = "50c, ";
                break;
            case 3:
                coinValue = TWENTY_CENTS;
                coinText = "20c, ";
                break;
            case 4:
                coinValue = TEN_CENTS;
                coinText = "10c, ";
                break;
            case 5:
                coinValue = FIVE_CENTS;
                coinText = "5c, ";
                break;
            default:
                coinValue = 1;
                coinText = "ERROR";
                break;
        }

        toGive = change / coinValue;
        change = change - toGive * coinValue;
        Write($"{toGive} x {coinText}");


    }
    WriteLine("");
    WriteLine("Again? Y/N: ");
    again = ReadLine();
        
} while (again != "N" && again != "n");