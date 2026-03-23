#include "splashkit.h"
#include "utilities.h"

using std::to_string;

class scoreboard
{
    private:
    int score;
    
    public:
    string player;

    scoreboard(string player, int score)
    {
        this->player = player;
        this->score = score;
    }

    scoreboard()
    {
        player = "Player Not Found...";
        score = 0;
    }

    void print()
    {
        write_line(player + " | Score: " + to_string(score));
    }
};

int main()
{
    DynamicArray<scoreboard> scores;
    scores.push_back(scoreboard("Jon, 100"));
    scores.push_back(scoreboard("Bob, 75"));

    for(int i=0; i < scores.getSize(); i++)
    {
        scores[i].print();
    }
    return 0;
}