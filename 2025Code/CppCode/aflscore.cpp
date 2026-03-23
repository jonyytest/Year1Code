#include "splashkit.h"
#include "utilities.h"
using std::to_string;
using std::stoi;


void game_details(string team1, int goals1, int behinds1, int score1,
                  string team2, int goals2, int behinds2, int score2)
{
    write_line(team1 + ": " + to_string(goals1) + ", " + to_string(behinds1) + ", " + to_string(score1));
    write_line(team2 + ": " + to_string(goals2) + ", " + to_string(behinds2) + ", " + to_string(score2));
    write_line("");
}

int menu(string team1, string team2)
{
    write_line("Menu:");
    write_line("1: Update " + team1 + " goals");
    write_line("2: Update " + team1 + " behinds");
    write_line("3: Update " + team2 + " goals");
    write_line("4: Update " + team2 + " behinds");
    write_line("5: Print game details");
    write_line("6: Quit");
    int choice = read_integer("Option: ");
    return choice;
}

int score(int goals, int behinds)
{
    int score = (goals * 6) + behinds;
    return score;
}

string winning(string team1, int score1, string team2, int score2)
{
    write_line("Calculating details...");
    string winner;
    if (score1 > score2)
    {
        write(team1 + " are winning!");
        return winner;
    }
    else if (score1 < score2)
    {
        write(team2 + " are winning!");
        return winner;
    }
    else
    {
        write("It is currently a draw.");
        return winner;
    }
}

bool confirm_quit()
{
    while (true)
    {
        string resp = read_string("Are you sure you want to quit? [Y/n]: ");
        if (resp == "y" || resp == "Y") return true;
        if (resp == "n" || resp == "N") return false;
        write_line("Please enter Y or N");
    }
}

int main()
{
    write_line("Welcome to the AFL score calculator!");
    write_line("");

    write_line("Enter team 1 details:");
    string team1   = read_string("Team name: ");
    int goals1     = read_integer("Goals: ");
    int behinds1   = read_integer("Behinds: ");
    write_line("");

    write_line("Enter team 2 details:");
    string team2   = read_string("Team name: ");
    int goals2     = read_integer("Goals: ");
    int behinds2   = read_integer("Behinds: ");
    write_line("");

    int score2 = score(goals2, behinds2);
    int score1 = score(goals1, behinds1);

    winning(team1, score1, team2, score2);
    write_line("");
    write_line("");

    game_details(team1, goals1, behinds1, score1,
                 team2, goals2, behinds2, score2);

    int choice;
    bool quit = false;
    do
    {
        choice = menu(team1, team2);
        switch(choice)
        {
            case 1:
            {
                int goals1 = read_integer("Goals: ");
                break;
            }
            case 2:
            {
                int behinds1 = read_integer("Behinds: ");
                break;
            }
            case 3:
            {
                int goals2 = read_integer("Goals: ");
                break;
            }
            case 4:
            {
                int behinds2 = read_integer("Behinds: ");
                break;
            }
            case 5:
            {
                write_line("");
                winning(team1, score1, team2, score2);
                write_line("");
                write_line("");
                game_details(team1, goals1, behinds1, score1,
                             team2, goals2, behinds2, score2);
                break;
            }
            case 6:
            {
                quit = confirm_quit();
                break;
            }
        }
    } while (!quit);

    write_line("");
    write_line("Bye!");
    write_line("");

    return 0;
}
