using static SplashKitSDK.SplashKit;
using static System.Convert;

string line;
int choice;
do
{
    WriteLine("1: Addition");
    WriteLine("2: Subtraction");
    WriteLine("3: Multiplication");
    WriteLine("4: Division");
    WriteLine("5: Quit");
    Write("Enter your choice: ");
    line = ReadLine();

    while (!IsInteger(line))
    {
        WriteLine("Please enter your answer as a whole numer");
        Write("Enter your choice: ");
        line = ReadLine();
    }
    choice = ToInt32(line);
    switch (choice)
    {
        case 1:
            WriteLine("Addition");
            break;
        case 2:
            WriteLine("Subtraction");
            break;
        case 3:
            WriteLine("Multiplication");
            break;
        case 4:
            WriteLine("Division");
            break;
        case 5:
            WriteLine("Quit");
            break;
        default:
            WriteLine("Invalid Option");
            break;

    }
} while (choice != 5);